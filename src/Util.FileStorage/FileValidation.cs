namespace Util.FileStorage;

/// <summary>
/// 文件验证操作
/// </summary>
public static class FileValidation {
    /// <summary>
    /// 扩展名是否有效
    /// </summary>
    /// <param name="fileName">文件名,范例: a.jpg</param>
    /// <param name="accepts">接受的扩展名列表,以逗号分隔,范例: .jpg,.png,.gif</param>
    public static bool IsValidExtension( string fileName, string accepts ) {
        if( fileName.IsEmpty() )
            return false;
        if( accepts.IsEmpty() )
            return true;
        var extension = Path.GetExtension( fileName );
        var list = accepts.Split( ',' ).Where( t => t.IsEmpty() == false ).ToList();
        if ( list.Count == 0 )
            return true;
        return list.Any( type => type.TrimStart( '.' ) == extension.TrimStart( '.' ) );
    }
}