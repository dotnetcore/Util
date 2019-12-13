using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Util.Helpers {
    /// <summary>
    /// 常用公共操作
    /// </summary>
    public static partial class Common {
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

        /// <summary>
        /// 是否Linux操作系统
        /// </summary>
        public static bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        /// <summary>
        /// 是否Windows操作系统
        /// </summary>
        public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        /// <summary>
        /// 是否苹果操作系统
        /// </summary>
        public static bool IsOsx => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        /// <summary>
        /// 当前操作系统
        /// </summary>
        public static string System => IsWindows ? "Windows" : IsLinux ? "Linux" : IsOsx ? "OSX" : string.Empty;
    }
}
