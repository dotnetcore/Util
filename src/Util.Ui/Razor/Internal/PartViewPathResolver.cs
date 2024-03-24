using System.Text.RegularExpressions;
using Regex = Util.Helpers.Regex;

namespace Util.Ui.Razor.Internal;

/// <summary>
/// 分部视图路径解析器
/// </summary>
public class PartViewPathResolver : IPartViewPathResolver {
    /// <summary>
    /// 分部视图路径查找器
    /// </summary>
    private readonly IPartViewPathFinder _pathFinder;

    /// <summary>
    /// 初始化分部视图路径解析器
    /// </summary>
    /// <param name="pathFinder">分部视图路径查找器</param>
    public PartViewPathResolver( IPartViewPathFinder pathFinder ) {
        _pathFinder = pathFinder ?? throw new ArgumentNullException( nameof( pathFinder ) );
    }

    /// <inheritdoc />
    public List<string> Resolve( string path, string content ) {
        var result = new List<string>();
        if ( path.IsEmpty() )
            return result;
        if ( content.IsEmpty() )
            return result;
        var matches = Regex.Matches( content, "<[ ]*partial[ ]+name[ ]*=[ ]*\"(.+?)\"[ ]*/[ ]*>", RegexOptions.IgnoreCase );
        foreach ( Match match in matches ) {
            if ( match.Success == false )
                continue;
            var partPath = _pathFinder.Find( path, match.Groups[1].Value );
            result.Add( partPath );
        }
        return result;
    }
}