using System.IO;
using System.Linq;

namespace Util.Helpers {
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
            paths = paths.Select( t => t.Trim( '/' ) ).ToArray();
            var result = Path.Combine( paths ).Replace( @"\", "/" );
            if ( firstPath.StartsWith( '/' ) )
                result = $"/{result}";
            if ( lastPath.EndsWith( '/' ) )
                result = $"{result}/";
            return result;
        }
    }
}
