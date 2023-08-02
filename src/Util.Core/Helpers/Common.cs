namespace Util.Helpers; 

/// <summary>
/// 公共操作
/// </summary>
public static class Common {
    /// <summary>
    /// 获取当前应用程序基路径
    /// </summary>
    public static string ApplicationBaseDirectory => AppContext.BaseDirectory;
    /// <summary>
    /// 换行符
    /// </summary>
    public static string Line => System.Environment.NewLine;
    /// <summary>
    /// 是否Linux操作系统
    /// </summary>
    public static bool IsLinux => RuntimeInformation.IsOSPlatform( OSPlatform.Linux );
    /// <summary>
    /// 是否Windows操作系统
    /// </summary>
    public static bool IsWindows => RuntimeInformation.IsOSPlatform( OSPlatform.Windows );

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
    /// 获取物理路径
    /// </summary>
    /// <param name="relativePath">相对路径,范例:"test/a.txt" 或 "/test/a.txt"</param>
    /// <param name="basePath">基路径,默认为AppContext.BaseDirectory</param>
    public static string GetPhysicalPath( string relativePath, string basePath = null ) {
        if ( relativePath.StartsWith( "~" ) )
            relativePath = relativePath.TrimStart( '~' );
        if ( relativePath.StartsWith( "/" ) )
            relativePath = relativePath.TrimStart( '/' );
        if ( relativePath.StartsWith( "\\" ) )
            relativePath = relativePath.TrimStart( '\\' );
        basePath ??= ApplicationBaseDirectory;
        return Path.Combine( basePath, relativePath );
    }

    /// <summary>
    /// 连接路径
    /// </summary>
    /// <param name="paths">路径列表</param>
    public static string JoinPath( params string[] paths ) {
        return Url.JoinPath( paths );
    }

    /// <summary>
    /// 获取当前目录路径
    /// </summary>
    public static string GetCurrentDirectory() {
        return Directory.GetCurrentDirectory();
    }

    /// <summary>
    /// 获取当前目录的上级路径
    /// </summary>
    /// <param name="depth">向上钻取的深度</param>
    public static string GetParentDirectory( int depth = 1 ) {
        var path = Directory.GetCurrentDirectory();
        for ( int i = 0; i < depth; i++ ) {
            var parent = Directory.GetParent( path );
            if ( parent is { Exists: true } )
                path = parent.FullName;
        }
        return path;
    }
}