using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Util.Security.Principals;

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
            try {
                HttpContextAccessor = Ioc.Create<IHttpContextAccessor>();
                Environment = Ioc.Create<IHostingEnvironment>();
            }
            catch{
            }
        }

        #endregion

        #region 属性

        /// <summary>
        /// Http上下文访问器
        /// </summary>
        public static IHttpContextAccessor HttpContextAccessor { get; set; }

        /// <summary>
        /// 当前Http上下文
        /// </summary>
        public static HttpContext HttpContext => HttpContextAccessor?.HttpContext;

        /// <summary>
        /// 当前用户安全主体
        /// </summary>
        public static ClaimsPrincipal User {
            get {
                if ( HttpContext == null )
                    return UnauthenticatedPrincipal.Instance;
                if ( HttpContext.User is ClaimsPrincipal principal )
                    return principal;
                return UnauthenticatedPrincipal.Instance;
            }
        }

        /// <summary>
        /// 当前用户身份
        /// </summary>
        public static ClaimsIdentity Identity {
            get {
                if ( User.Identity is ClaimsIdentity identity )
                    return identity;
                return UnauthenticatedIdentity.Instance;
            }
        }

        /// <summary>
        /// 当前Http请求
        /// </summary>
        public static HttpRequest Request => HttpContext?.Request;

        /// <summary>
        /// 当前Http响应
        /// </summary>
        public static HttpResponse Response => HttpContext?.Response;

        /// <summary>
        /// 宿主环境
        /// </summary>
        public static IHostingEnvironment Environment { get; set; }

        #endregion

        #region Client( Web客户端 )

        /// <summary>
        /// Web客户端，用于发送Http请求
        /// </summary>
        public static Util.Webs.Clients.WebClient Client() {
            return new Util.Webs.Clients.WebClient();
        }

        /// <summary>
        /// Web客户端，用于发送Http请求
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        public static Util.Webs.Clients.WebClient<TResult> Client<TResult>() where TResult : class {
            return new Util.Webs.Clients.WebClient<TResult>();
        }

        #endregion

        #region Url(请求地址)

        /// <summary>
        /// 请求地址
        /// </summary>
        public static string Url => HttpContext?.Request?.GetDisplayUrl();

        #endregion

        #region Ip(客户端Ip地址)

        /// <summary>
        /// 客户端Ip地址
        /// </summary>
        public static string Ip {
            get {
                var list = new[] { "127.0.0.1", "::1" };
                var result = HttpContext?.Connection?.RemoteIpAddress.SafeString();
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
        public static string Host => HttpContext == null ? Dns.GetHostName() : GetClientHostName();

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
            return HttpContext?.Request?.Headers["HTTP_X_FORWARDED_FOR"] ?? HttpContext?.Request?.Headers["REMOTE_ADDR"];
        }

        #endregion

        #region Browser(浏览器)

        /// <summary>
        /// 浏览器
        /// </summary>
        public static string Browser => HttpContext?.Request?.Headers["User-Agent"];

        #endregion

        #region RootPath(根路径)

        /// <summary>
        /// 根路径
        /// </summary>
        public static string RootPath => Environment?.ContentRootPath;

        #endregion 

        #region WebRootPath(Web根路径)

        /// <summary>
        /// Web根路径，即wwwroot
        /// </summary>
        public static string WebRootPath => Environment?.WebRootPath;

        #endregion 

        #region GetFiles(获取客户端文件集合)

        /// <summary>
        /// 获取客户端文件集合
        /// </summary>
        public static List<IFormFile> GetFiles() {
            var result = new List<IFormFile>();
            var files = HttpContext.Request.Form.Files;
            if( files == null || files.Count == 0 )
                return result;
            result.AddRange( files.Where( file => file?.Length > 0 ) );
            return result;
        }

        #endregion

        #region GetFile(获取客户端文件)

        /// <summary>
        /// 获取客户端文件
        /// </summary>
        public static IFormFile GetFile() {
            var files = GetFiles();
            return files.Count == 0 ? null : files[0];
        }

        #endregion
    }
}
