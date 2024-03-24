using Util.Helpers;
using File = Util.Helpers.File;

namespace Util.Ui.Razor.Internal;

/// <summary>
/// 视图内容解析器
/// </summary>
public class ViewContentResolver : IViewContentResolver {
    /// <inheritdoc />
    public string Resolve( string path ) {
        if ( path.IsEmpty() )
            return null;
        if ( File.FileExists( path ) == false )
            path = Url.JoinPath( Util.Helpers.Common.GetCurrentDirectory(), path );
        return File.ReadToString( path );
    }
}