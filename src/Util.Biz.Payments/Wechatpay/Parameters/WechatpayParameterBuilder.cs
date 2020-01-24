using System.Xml;
using Util.Biz.Payments.Core;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Signatures;
using Util.Helpers;
using Util.Parameters;
using Convert = Util.Helpers.Convert;

namespace Util.Biz.Payments.Wechatpay.Parameters {
    /// <summary>
    /// 微信支付参数生成器
    /// </summary>
    public class WechatpayParameterBuilder {
        /// <summary>
        /// 参数生成器
        /// </summary>
        private readonly ParameterBuilder _builder;
        /// <summary>
        /// 签名参数名称
        /// </summary>
        private string _signName;

        /// <summary>
        /// 配置
        /// </summary>
        public WechatpayConfig Config { get; }

        /// <summary>
        /// 初始化微信支付参数生成器
        /// </summary>
        /// <param name="config">配置</param>
        public WechatpayParameterBuilder( WechatpayConfig config ) {
            config.CheckNull( nameof( config ) );
            Config = config;
            _builder = new ParameterBuilder();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            AppId( Config.AppId ).MerchantId( Config.MerchantId ).SignType( Config.SignType.Description() ).Add( "nonce_str", Id.Guid() );
        }

        /// <summary>
        /// 初始化支付参数
        /// </summary>
        public void Init( PayParam param ) {
            param.CheckNull( nameof( param ) );
            param.Init();
            SpbillCreateIp( Web.Ip ).Body( param.Subject ).OutTradeNo( param.OrderId )
                .TotalFee( param.Money ).NotifyUrl( param.NotifyUrl ).Attach( param.Attach );
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        public WechatpayParameterBuilder Add( string name, object value ) {
            _builder.Add( name, value );
            return this;
        }

        /// <summary>
        /// 设置应用标识
        /// </summary>
        /// <param name="appId">应用标识</param>
        public WechatpayParameterBuilder AppId( string appId ) {
            _builder.Add( WechatpayConst.AppId, appId );
            return this;
        }

        /// <summary>
        /// 设置商户号
        /// </summary>
        /// <param name="merchantId">商户号</param>
        public WechatpayParameterBuilder MerchantId( string merchantId ) {
            _builder.Add( WechatpayConst.MerchantId, merchantId );
            return this;
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="body">标题</param>
        public WechatpayParameterBuilder Body( string body ) {
            _builder.Add( WechatpayConst.Body, body );
            return this;
        }

        /// <summary>
        /// 设置商户订单号
        /// </summary>
        /// <param name="orderId">商户订单号</param>
        public WechatpayParameterBuilder OutTradeNo( string orderId ) {
            _builder.Add( WechatpayConst.OutTradeNo, orderId );
            return this;
        }

        /// <summary>
        /// 设置货币类型
        /// </summary>
        /// <param name="feeType">货币类型</param>
        public WechatpayParameterBuilder FeeType( string feeType ) {
            _builder.Add( WechatpayConst.FeeType, feeType );
            return this;
        }

        /// <summary>
        /// 设置总金额
        /// </summary>
        /// <param name="totalFee">总金额，单位：元</param>
        public WechatpayParameterBuilder TotalFee( decimal totalFee ) {
            _builder.Add( WechatpayConst.TotalFee, Convert.ToInt( totalFee * 100 ) );
            return this;
        }

        /// <summary>
        /// 设置回调通知地址
        /// </summary>
        /// <param name="notifyUrl">回调通知地址</param>
        public WechatpayParameterBuilder NotifyUrl( string notifyUrl ) {
            _builder.Add( WechatpayConst.NotifyUrl, GetNotifyUrl( notifyUrl ) );
            return this;
        }

        /// <summary>
        /// 获取回调通知地址
        /// </summary>
        private string GetNotifyUrl( string notifyUrl ) {
            if( notifyUrl.IsEmpty() )
                return Config.NotifyUrl;
            return notifyUrl;
        }

        /// <summary>
        /// 设置终端IP
        /// </summary>
        /// <param name="ip">终端IP</param>
        public WechatpayParameterBuilder SpbillCreateIp( string ip ) {
            _builder.Add( WechatpayConst.SpbillCreateIp, ip );
            return this;
        }

        /// <summary>
        /// 设置交易类型
        /// </summary>
        /// <param name="type">交易类型</param>
        public WechatpayParameterBuilder TradeType( string type ) {
            _builder.Add( WechatpayConst.TradeType, type );
            return this;
        }

        /// <summary>
        /// 设置签名类型
        /// </summary>
        /// <param name="type">签名类型</param>
        public WechatpayParameterBuilder SignType( string type ) {
            _builder.Add( WechatpayConst.SignType, type );
            return this;
        }

        /// <summary>
        /// 设置伙伴标识
        /// </summary>
        /// <param name="partnerId">伙伴标识</param>
        public WechatpayParameterBuilder PartnerId( string partnerId ) {
            _builder.Add( WechatpayConst.PartnerId, partnerId );
            return this;
        }

        /// <summary>
        /// 设置时间戳
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        public WechatpayParameterBuilder Timestamp( long timestamp = 0 ) {
            _builder.Add( WechatpayConst.Timestamp, timestamp == 0 ? Time.GetUnixTimestamp() : timestamp );
            return this;
        }

        /// <summary>
        /// 设置包
        /// </summary>
        /// <param name="package">包，默认值: "Sign=WXPay"</param>
        public WechatpayParameterBuilder Package( string package = "Sign=WXPay" ) {
            _builder.Add( WechatpayConst.Package, package );
            return this;
        }

        /// <summary>
        /// 设置附加数据
        /// </summary>
        /// <param name="attach">附加数据</param>
        public WechatpayParameterBuilder Attach( string attach ) {
            _builder.Add( WechatpayConst.Attach, attach );
            return this;
        }

        /// <summary>
        /// 设置用户标识
        /// </summary>
        /// <param name="openId">用户标识</param>
        public WechatpayParameterBuilder OpenId( string openId ) {
            _builder.Add( WechatpayConst.OpenId, openId );
            return this;
        }

        /// <summary>
        /// 设置签名参数名称
        /// </summary>
        /// <param name="name">参数名称</param>
        public WechatpayParameterBuilder SignParamName( string name ) {
            _signName = name;
            return this;
        }

        /// <summary>
        /// 获取Xml结果，包含签名
        /// </summary>
        public string ToXml() {
            return ToXmlDocument( GetSignBuilder() ).OuterXml;
        }

        /// <summary>
        /// 获取Xml文档
        /// </summary>
        private XmlDocument ToXmlDocument( ParameterBuilder builder ) {
            var xml = new Xml();
            foreach( var param in builder.GetDictionary() )
                AddNode( xml, param.Key, param.Value );
            return xml.Document;
        }

        /// <summary>
        /// 添加Xml节点
        /// </summary>
        private void AddNode( Xml xml, string key, object value ) {
            if( key.SafeString().ToLower() == WechatpayConst.TotalFee ) {
                xml.AddNode( key, value );
                return;
            }
            xml.AddCDataNode( value, key );
        }

        /// <summary>
        /// 获取签名的参数生成器
        /// </summary>
        private ParameterBuilder GetSignBuilder() {
            var builder = new ParameterBuilder( _builder );
            builder.Add( GetSignName(), GetSign() );
            return builder;
        }

        /// <summary>
        /// 获取签名参数名称
        /// </summary>
        private string GetSignName() {
            if ( _signName.IsEmpty() )
                return WechatpayConst.Sign;
            return _signName;
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        public string GetSign() {
            return SignManagerFactory.Create( Config, _builder ).Sign();
        }

        /// <summary>
        /// 获取Xml结果，不包含签名
        /// </summary>
        public string ToXmlNoContainsSign() {
            return ToXmlDocument( _builder ).OuterXml;
        }

        /// <summary>
        /// 获取Json结果，包含签名
        /// </summary>
        public string ToJson() {
            return GetSignBuilder().ToJson();
        }

        /// <summary>
        /// 输出结果
        /// </summary>
        public override string ToString() {
            return ToXml();
        }
    }
}