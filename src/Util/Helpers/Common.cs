using System;
using System.IO;

namespace Util.Helpers {
    /// <summary>
    /// 常用公共操作
    /// </summary>
    public static class Common {
        /// <summary>
        /// 获取类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type GetType<T>() {
            return GetType( typeof( T ) );
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type">类型</param>
        public static Type GetType( Type type ) {
            return Nullable.GetUnderlyingType( type ) ?? type;
        }

        /// <summary>
        /// 换行符
        /// </summary>
        public static string Line => Environment.NewLine;

        /// <summary>
        /// 获取物理路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        public static string GetPhysicalPath( string relativePath ) {
            if( string.IsNullOrWhiteSpace( relativePath ) )
                return string.Empty;
            var rootPath = Web.RootPath;
            if( string.IsNullOrWhiteSpace( rootPath ) )
                return Path.GetFullPath( relativePath );
            return $"{Web.RootPath}\\{relativePath.Replace( "/", "\\" ).TrimStart( '\\' )}";
        }

        /// <summary>
        /// 获取wwwroot路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        public static string GetWebRootPath( string relativePath ) {
            if( string.IsNullOrWhiteSpace( relativePath ) )
                return string.Empty;
            var rootPath = Web.WebRootPath;
            if( string.IsNullOrWhiteSpace( rootPath ) )
                return Path.GetFullPath( relativePath );
            return $"{Web.WebRootPath}\\{relativePath.Replace( "/", "\\" ).TrimStart( '\\' )}";
        }
    }
}
