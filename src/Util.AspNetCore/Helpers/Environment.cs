using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Util.Helpers {
    /// <summary>
    /// 上下文环境操作
    /// </summary>
    public class Environment : IEnvironment {
        /// <summary>
        /// 主机环境
        /// </summary>
        private readonly IWebHostEnvironment _environment;

        /// <summary>
        /// 初始化上下文环境操作
        /// </summary>
        /// <param name="environment">主机环境</param>
        public Environment( IWebHostEnvironment environment ) {
            _environment = environment;
        }

        /// <summary>
        /// 根路径
        /// </summary>
        public string RootPath => _environment.ContentRootPath;

        /// <summary>
        /// Web根路径，即wwwroot
        /// </summary>
        public string WebRootPath => _environment.WebRootPath;

        /// <summary>
        /// 获取物理路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        public string GetPath( string relativePath ) {
            if ( string.IsNullOrWhiteSpace( relativePath ) )
                return string.Empty;
            return Path.Combine( RootPath, relativePath.TrimStart( '/' ).TrimStart( '\\' ) );
        }

        /// <summary>
        /// 获取物理路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        public static string GetPhysicalPath( string relativePath ) {
            return Ioc.Create<IEnvironment>()?.GetPath( relativePath );
        }
    }
}
