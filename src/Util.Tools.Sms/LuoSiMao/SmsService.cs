using System.Text;
using System.Threading.Tasks;
using Util.Helpers;

namespace Util.Tools.Sms.LuoSiMao {
    /// <summary>
    /// 短信服务
    /// </summary>
    public class SmsService : ISmsService {
        /// <summary>
        /// 短信配置提供器
        /// </summary>
        private readonly ISmsConfigProvider _configProvider;

        /// <summary>
        /// 初始化短信服务
        /// </summary>
        /// <param name="configProvider">短信配置提供器</param>
        public SmsService( ISmsConfigProvider configProvider ) {
            configProvider.CheckNull( nameof( configProvider ) );
            _configProvider = configProvider;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="content">内容</param>
        public async Task<SmsResult> SendAsync( string mobile, string content ) {
            var result = await Web.Client().Post( "https://sms-api.luosimao.com/v1/send.json" )
                .Header( "Authorization", await GetAuthorization() )
                .Data( "mobile", mobile )
                .Data( "message", content )
                .ResultAsync();
            return CreateResult( result );
        }

        /// <summary>
        /// 获取授权头信息
        /// </summary>
        private async Task<string> GetAuthorization() {
            var config = await _configProvider.GetConfigAsync();
            return $"Basic {System.Convert.ToBase64String( Encoding.UTF8.GetBytes( $"api:{config.Key}" ) )}";
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        private SmsResult CreateResult( string message ) {
            var result = Json.ToObject<LuoSiMaoResult>( message );
            result.CheckNull( nameof( result ) );
            if( result.error == "0" )
                return SmsResult.Ok;
            if( result.msg == "WRONG_MOBILE" )
                return new SmsResult( false, message, SmsErrorCode.MobileError );
            return new SmsResult( false, message );
        }
    }
}
