using System;
using System.IO;

namespace Util.Helpers {
    /// <summary>
    /// 平台操作
    /// </summary>
    public static class Platform {
        /// <summary>
        /// 获取当前应用程序基路径
        /// </summary>
        public static string ApplicationBaseDirectory => AppContext.BaseDirectory;

        /// <summary>
        /// 获取物理路径
        /// </summary>
        /// <param name="relativePath">相对路径,范例:"test/a.txt" 或 "/test/a.txt"</param>
        public static string GetPhysicalPath( string relativePath ) {
            if( relativePath.StartsWith( "~" ) )
                relativePath = relativePath.TrimStart( '~' );
            if( relativePath.StartsWith( "/" ) )
                relativePath = relativePath.TrimStart( '/' );
            if( relativePath.StartsWith( "\\" ) )
                relativePath = relativePath.TrimStart( '\\' );
            return Path.Combine( ApplicationBaseDirectory, relativePath );
        }
    }
}
