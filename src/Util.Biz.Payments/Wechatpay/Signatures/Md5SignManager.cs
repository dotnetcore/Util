using Util.Helpers;
using Util.Parameters;
using Util.Signatures;

namespace Util.Biz.Payments.Wechatpay.Signatures {
    /// <summary>
    /// 微信支付Md5签名服务
    /// </summary>
    public class Md5SignManager : ISignManager {
        /// <summary>
        /// 签名密钥
        /// </summary>
        private readonly ISignKey _key;
        /// <summary>
        /// Url参数生成器
        /// </summary>
        private readonly UrlParameterBuilder _builder;

        /// <summary>
        /// 初始化微信支付Md5签名服务
        /// </summary>
        /// <param name="key">签名密钥</param>
        /// <param name="builder">参数生成器</param>
        public Md5SignManager( ISignKey key, ParameterBuilder builder = null ) {
            key.CheckNull( nameof( key ) );
            _key = key;
            _builder = builder == null ? new UrlParameterBuilder() : new UrlParameterBuilder( builder );
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public ISignManager Add( string key, object value ) {
            _builder.Add( key, value );
            return this;
        }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign() {
            var value = $"{_builder.Result( true )}&key={_key.GetKey()}";
            return Encrypt.Md5By32( value ).ToUpper();
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="sign">签名</param>
        public bool Verify( string sign ) {
            if ( sign.IsEmpty() )
                return false;
            return sign == Sign();
        }
    }
}
