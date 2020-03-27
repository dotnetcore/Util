using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;
using TinyCsvParser.Tokenizer;
using Util.Biz.Payments.Alipay.Abstractions;
using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Alipay.Parameters;
using Util.Biz.Payments.Alipay.Parameters.Requests;
using Util.Biz.Payments.Alipay.Results;
using Util.Biz.Payments.Alipay.Services.Base;
using Util.Biz.Payments.Alipay.Services.CsvMappings;
using Util.Helpers;

namespace Util.Biz.Payments.Alipay.Services {
    /// <summary>
    /// 支付宝下载对账单服务
    /// </summary>
    public class AlipayDownloadBillService : AlipayServiceBase<AlipayDownloadBillRequest>, IAlipayDownloadBillService {
        /// <summary>
        /// 初始化支付宝下载对账单服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        public AlipayDownloadBillService( IAlipayConfigProvider provider ) : base( provider ) {
        }

        /// <summary>
        /// 下载对账单
        /// </summary>
        /// <param name="request">下载对账单参数</param>
        public async Task<AlipayDownloadBillResult> DownloadAsync( AlipayDownloadBillRequest request ) {
            var result = await Request( request );
            var url = result.GetValue( "bill_download_url" );
            var bills = new List<AlipayBillInfo>();
            if( string.IsNullOrWhiteSpace( url ) == false )
                bills = await Download( url );
            return CreateResult( result, url, bills );
        }

        /// <summary>
        /// 初始化内容生成器
        /// </summary>
        /// <param name="builder">内容参数生成器</param>
        /// <param name="param">请求参数</param>
        protected override void InitContentBuilder( AlipayContentBuilder builder, AlipayDownloadBillRequest param ) {
            builder.Add( "bill_type", param.BillType.Description() );
            builder.Add( "bill_date", param.GetBillDate() );
        }

        /// <summary>
        /// 获取请求方法
        /// </summary>
        protected override string GetMethod() {
            return "alipay.data.dataservice.bill.downloadurl.query";
        }

        /// <summary>
        /// 下载并解析对账单
        /// </summary>
        private async Task<List<AlipayBillInfo>> Download( string url ) {
            var response = await Web.Client().GetStreamAsync( url );
            using( var zip = new ZipArchive( new MemoryStream( response ), ZipArchiveMode.Read, false, Encoding.GetEncoding( "gb2312" ) ) ) {
                var entry = zip.Entries.FirstOrDefault( t => t.FullName.Contains( "汇总" ) == false );
                if( entry == null )
                    return null;
                using( var stream = entry.Open() ) {
                    return ResolveCsv( stream );
                }
            }
        }

        /// <summary>
        /// 解析Csv文件流
        /// </summary>
        private List<AlipayBillInfo> ResolveCsv( Stream stream ) {
            var result = new List<AlipayBillInfo>();
            var tokenizer = new QuotedStringTokenizer( ',' );
            var options = new CsvParserOptions( true, tokenizer );
            var parser = new CsvParser<AlipayBillInfo>( options, new AlipayBillInfoMapping() );
            var records = parser.ReadFromStream( stream, Encoding.GetEncoding( "gb2312" ) );
            foreach( var record in records ) {
                if( record.IsValid == false )
                    continue;
                if( record.Result.TradeId.StartsWith( "#" ) )
                    continue;
                if( record.Result.TradeId == "支付宝交易号" )
                    continue;
                result.Add( record.Result );
            }
            return result;
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        protected virtual AlipayDownloadBillResult CreateResult( AlipayResult result, string url, List<AlipayBillInfo> bills ) {
            return new AlipayDownloadBillResult( result, url, bills );
        }
    }
}
