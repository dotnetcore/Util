using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Alipay.Parameters;

namespace Util.Biz.Payments.Alipay.Results {
    /// <summary>
    /// 支付宝结果
    /// </summary>
    public class AlipayResult {
        /// <summary>
        /// 结果
        /// </summary>
        private readonly IDictionary<string, string> _result;

        /// <summary>
        /// 初始化支付宝结果
        /// </summary>
        public AlipayResult() {
        }

        /// <summary>
        /// 初始化支付宝结果
        /// </summary>
        /// <param name="response">json响应消息</param>
        /// <param name="builder">支付宝参数生成器</param>
        public AlipayResult( string response, AlipayParameterBuilder builder = null ) {
            Raw = response;
            Builder = builder;
            _result = new Dictionary<string, string>();
            LoadJson( response );
        }

        /// <summary>
        /// 支付宝原始响应
        /// </summary>
        public string Raw { get; }
        /// <summary>
        /// 支付宝参数生成器
        /// </summary>
        public AlipayParameterBuilder Builder { get; }
        /// <summary>
        /// 结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 加载json
        /// </summary>
        private void LoadJson( string json ) {
            if( json.IsEmpty() )
                return;
            var jObject = JObject.Parse( json );
            foreach( var token in jObject.Children() )
                AddNodes( token );
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        private void AddNodes( JToken token ) {
            if( !( token is JProperty item ) )
                return;
            foreach( var value in item.Value )
                AddNodes( value );
            if( GetIgnoreItems().Contains( item.Name ) )
                return;
            _result.Add( item.Name, item.Value.SafeString() );
        }

        /// <summary>
        /// 获取忽略项
        /// </summary>
        private List<string> GetIgnoreItems() {
            return new List<string> {
                "alipay_trade_pay_response",
                "alipay_trade_cancel_response"
            };
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        public IDictionary<string, string> GetDictionary() {
            return _result;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key">键</param>
        public string GetValue( string key ) {
            if( key.IsEmpty() )
                return string.Empty;
            return _result.ContainsKey( key ) ? _result[key].SafeString() : string.Empty;
        }

        /// <summary>
        /// 是否包含指定键
        /// </summary>
        /// <param name="key">键</param>
        public bool HasKey( string key ) {
            if( key.IsEmpty() )
                return false;
            return _result.ContainsKey( key );
        }

        /// <summary>
        /// 获取状态码
        /// </summary>
        public string GetCode() {
            return GetValue( "code" );
        }

        /// <summary>
        /// 获取消息
        /// </summary>
        public string GetMessage() {
            return GetValue( "msg" );
        }

        /// <summary>
        /// 获取支付交易号
        /// </summary>
        public string GetTradeNo() {
            return GetValue( AlipayConst.TradeNo );
        }

        /// <summary>
        /// 获取商户订单号
        /// </summary>
        public string GetOutTradeNo() {
            return GetValue( AlipayConst.OutTradeNo );
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success => GetCode() == "10000";
    }
}
