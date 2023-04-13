using System.Collections.Generic;

namespace Util.Tests.Models
{
    /// <summary>
    /// 应用程序扩展信息
    /// </summary>
    public class ApplicationExtend
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public ApplicationExtend()
        {
            Client = new Client();
        }

        /// <summary>
        /// 应用程序类型
        /// </summary>
        public int ApplicationType { get; set; }
        /// <summary>
        /// 是否客户端
        /// </summary>
        public bool IsClient { get; set; }
        /// <summary>
        /// 客户端
        /// </summary>
        public Client Client { get; set; }
    }

    /// <summary>
    /// 客户端
    /// </summary>
    public class Client
    {
        /// <summary>
        /// 初始化客户端
        /// </summary>
        public Client()
        {
            AllowedCorsOrigins = new List<string>();
            RedirectUris = new List<string>();
            PostLogoutRedirectUris = new List<string>();
            AllowedScopes = new List<string>();
        }

        /// <summary>
        /// 允许的授权类型
        /// </summary>
        public int AllowedGrantType { get; set; }
        /// <summary>
        /// 允许通过浏览器访问令牌
        /// </summary>
        public bool? AllowAccessTokensViaBrowser { get; set; }
        /// <summary>
        /// 允许的跨域来源
        /// </summary>
        public List<string> AllowedCorsOrigins { get; set; }
        /// <summary>
        /// 需要同意
        /// </summary>
        public bool? RequireConsent { get; set; }
        /// <summary>
        /// 需要客户端密钥
        /// </summary>
        public bool? RequireClientSecret { get; set; }
        /// <summary>
        /// 客户端密钥列表
        /// </summary>
        public List<string> ClientSecrets { get; set; }
        /// <summary>
        /// 认证重定向地址列表
        /// </summary>
        public List<string> RedirectUris { get; set; }
        /// <summary>
        /// 注销重定向地址列表
        /// </summary>
        public List<string> PostLogoutRedirectUris { get; set; }
        /// <summary>
        /// 允许的作用域
        /// </summary>
        public List<string> AllowedScopes { get; set; }
        /// <summary>
        /// 访问令牌生命周期
        /// </summary>
        public int AccessTokenLifetime { get; set; }
    }
}
