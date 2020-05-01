using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TinyCsvParser;
using TinyCsvParser.Mapping;
using TinyCsvParser.Tokenizer;
using Util.Biz.Payments.Wechatpay.Abstractions;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Enums;
using Util.Biz.Payments.Wechatpay.Parameters;
using Util.Biz.Payments.Wechatpay.Parameters.Requests;
using Util.Biz.Payments.Wechatpay.Results;
using Util.Biz.Payments.Wechatpay.Services.Base;
using Util.Biz.Payments.Wechatpay.Services.CsvMappings;

namespace Util.Biz.Payments.Wechatpay.Services {
    /// <summary>
    /// 微信支付下载对账单服务
    /// </summary>
    public class WechatpayDownloadBillService : WechatpayServiceBase<WechatpayDownloadBillRequest>, IWechatpayDownloadBillService {
        /// <summary>
        /// 初始化微信支付下载对账单服务
        /// </summary>
        /// <param name="configProvider">微信支付配置提供器</param>
        public WechatpayDownloadBillService( IWechatpayConfigProvider configProvider ) : base( configProvider ) {
        }

        /// <summary>
        /// 下载对账单
        /// </summary>
        /// <param name="request">下载对账单参数</param>
        public async Task<WechatpayDownloadBillResult> DownloadAsync( WechatpayDownloadBillRequest request ) {
            var config = await ConfigProvider.GetConfigAsync( request );
            Validate( config, request );
            var builder = new WechatpayParameterBuilder( config );
            ConfigBuilder( builder, request );
            return await Requst( config, builder, request );
        }

        /// <summary>
        /// 配置参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">请求参数</param>
        protected override void ConfigBuilder( WechatpayParameterBuilder builder, WechatpayDownloadBillRequest param ) {
            builder.Init();
            builder.Add( "bill_date", param.GetBillDate() );
            builder.Add( "bill_type", param.BillType.Description() );
        }

        /// <summary>
        /// 请求结果
        /// </summary>
        protected async Task<WechatpayDownloadBillResult> Requst( WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayDownloadBillRequest request ) {
            var response = await SendRequest( config, builder );
            if ( response.StartsWith( "交易时间" ) )
                return Success( response, builder, request );
            return await Fail( response,config, builder );
        }

        /// <summary>
        /// 请求失败
        /// </summary>
        private WechatpayDownloadBillResult Success( string response, WechatpayParameterBuilder builder, WechatpayDownloadBillRequest request ) {
            var bills = GetBills( response, request );
            return new WechatpayDownloadBillResult( true, builder.ToString(), bills );
        }

        /// <summary>
        /// 获取对帐单
        /// </summary>
        private List<WechatpayBillInfo> GetBills( string response, WechatpayDownloadBillRequest request ) {
            var result = new List<WechatpayBillInfo>();
            var tokenizer = new QuotedStringTokenizer( ',' );
            var options = new CsvParserOptions( true, tokenizer );
            var parser = new CsvParser<WechatpayBillInfo>( options, GetCsvMapping( request ) );
            var readerOptions = new CsvReaderOptions( new[] {Environment.NewLine} );
            var records = parser.ReadFromString( readerOptions, response );
            foreach( var record in records ) {
                if( record.IsValid == false )
                    continue;
                if( record.Result.TransactionTime == "交易时间" )
                    continue;
                if( record.Result.TransactionTime == "总交易单数" )
                    break;
                result.Add( record.Result );
            }
            return result;
        }

        /// <summary>
        /// 获取Csv映射
        /// </summary>
        private ICsvMapping<WechatpayBillInfo> GetCsvMapping( WechatpayDownloadBillRequest request ) {
            switch ( request.BillType ) {
                case WechatpayBillType.Success:
                    return new WechatpaySuccessBillInfoMapping();
                case WechatpayBillType.Refund:
                    return new WechatpayRefundBillInfoMapping();
                default:
                    return new WechatpayAllBillInfoMapping();
            }
        }

        /// <summary>
        /// 请求失败
        /// </summary>
        private async Task<WechatpayDownloadBillResult> Fail( string response,WechatpayConfig config, WechatpayParameterBuilder builder ) {
            var result = new WechatpayResult( ConfigProvider, response, config, builder );
            WriteLog( config, builder, result );
            var success = ( await result.ValidateAsync() ).IsValid;
            return new WechatpayDownloadBillResult( success, result );
        }

        /// <summary>
        /// 获取接口地址
        /// </summary>
        /// <param name="config">支付配置</param>
        protected override string GetUrl( WechatpayConfig config ) {
            return config.GetDownloadBillUrl();
        }
    }
}
