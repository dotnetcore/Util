using System.Linq;
using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Util.Helpers {
    /// <summary>
    /// Web操作
    /// </summary>
    public static class Web {

        #region 静态构造方法

        /// <summary>
        /// 初始化Web操作
        /// </summary>
        static Web() {
            HttpContextAccessor = Ioc.Create<IHttpContextAccessor>();
        }

        #endregion

        #region 属性

        /// <summary>
        /// Http上下文访问器
        /// </summary>
        public static IHttpContextAccessor HttpContextAccessor { get; set; }

        #endregion

        #region Url(请求地址)

        /// <summary>
        /// 请求地址
        /// </summary>
        public static string Url => HttpContextAccessor?.HttpContext?.Request?.GetDisplayUrl();

        #endregion

        #region Ip(客户端Ip地址)

        /// <summary>
        /// 客户端Ip地址
        /// </summary>
        public static string Ip {
            get {
                var list = new[] { "127.0.0.1", "::1" };
                var result = HttpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress.SafeString();
                if( string.IsNullOrWhiteSpace( result ) || list.Contains( result ) )
                    result = GetLanIp();
                return result;
            }
        }

        /// <summary>
        /// 获取局域网IP
        /// </summary>
        private static string GetLanIp() {
            foreach( var hostAddress in Dns.GetHostAddresses( Dns.GetHostName() ) ) {
                if( hostAddress.AddressFamily == AddressFamily.InterNetwork )
                    return hostAddress.ToString();
            }
            return string.Empty;
        }

        #endregion

        #region Host(主机)

        /// <summary>
        /// 主机
        /// </summary>
        public static string Host => HttpContextAccessor?.HttpContext == null ? Dns.GetHostName() : GetClientHostName();

        /// <summary>
        /// 获取Web客户端主机名
        /// </summary>
        private static string GetClientHostName() {
            var address = GetRemoteAddress();
            if( string.IsNullOrWhiteSpace( address ) )
                return Dns.GetHostName();
            var result = Dns.GetHostEntry( IPAddress.Parse( address ) ).HostName;
            if( result == "localhost.localdomain" )
                result = Dns.GetHostName();
            return result;
        }

        /// <summary>
        /// 获取远程地址
        /// </summary>
        private static string GetRemoteAddress() {
            return HttpContextAccessor?.HttpContext?.Request?.Headers["HTTP_X_FORWARDED_FOR"] ?? HttpContextAccessor?.HttpContext?.Request?.Headers["REMOTE_ADDR"];
        }

        #endregion

        #region Browser(浏览器)

        /// <summary>
        /// 浏览器
        /// </summary>
        public static string Browser => HttpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"];

        #endregion
    }
}
