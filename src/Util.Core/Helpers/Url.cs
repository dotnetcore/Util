namespace Util.Helpers;

/// <summary>
/// Url操作
/// </summary>
public static class Url {
    /// <summary>
    /// 连接路径
    /// </summary>
    /// <param name="paths">路径列表</param>
    public static string JoinPath( params string[] paths ) {
        if ( paths == null )
            return string.Empty;
        paths = paths.Where( path => string.IsNullOrWhiteSpace( path ) == false ).Select( t => t.Replace( @"\", "/" ) ).ToArray();
        if ( paths.Length == 0 )
            return string.Empty;
        var firstPath = paths.First();
        var lastPath = paths.Last();
        string schema = string.Empty;
        if ( firstPath.StartsWith( "http:", StringComparison.OrdinalIgnoreCase ) )
            schema = "http://";
        if ( firstPath.StartsWith( "https:", StringComparison.OrdinalIgnoreCase ) )
            schema = "https://";
        paths = paths.Select( t => t.Trim( '/' ) ).ToArray();
        var result = Path.Combine( paths ).Replace( @"\", "/" );
        if ( paths.Any( path => path.StartsWith( "." ) ) ) {
            result = Path.GetFullPath( Path.Combine( paths ) );
            result = result.RemoveStart( AppContext.BaseDirectory ).Replace( @"\", "/" );
        }
        if ( firstPath.StartsWith( '/' ) )
            result = $"/{result}";
        if ( lastPath.EndsWith( '/' ) )
            result = $"{result}/";
        result = result.RemoveStart( "http:/" ).RemoveStart( "https:/" );
        if (schema.IsEmpty())
            return result;
        return schema + result.RemoveStart( "/" );
    }
}