namespace Util.Images; 

/// <summary>
/// 图片服务
/// </summary>
public class ImageManager : IImageManager {
    /// <summary>
    /// 字体集合
    /// </summary>
    private static readonly ConcurrentDictionary<string, FontFamily> _fonts = new();

    /// <inheritdoc />
    public IImageWrapper CreateImage( int width, int height, string backgroundColor = null ) {
        return new ImageWrapper( width, height, backgroundColor );
    }

    /// <inheritdoc />
    public IImageWrapper LoadImage( string path ) {
        return new ImageWrapper( path );
    }

    /// <summary>
    /// 加载字体集合
    /// </summary>
    /// <param name="path">字体文件目录的绝对路径</param>
    public static void LoadFonts( string path ) {
        if ( Util.Helpers.File.DirectoryExists( path ) == false )
            return;
        LoadTtfFonts( path );
    }

    /// <summary>
    /// 加载ttf字体
    /// </summary>
    private static void LoadTtfFonts( string path ) {
        var files = Util.Helpers.File.GetAllFiles( path, "*.ttf" );
        foreach ( var file in files ) {
            var name = System.IO.Path.GetFileNameWithoutExtension( file.Name );
            LoadFont( name, file.FullName );
        }
    }

    /// <summary>
    /// 加载字体
    /// </summary>
    /// <param name="name">字体名称</param>
    /// <param name="path">字体文件绝对路径</param>
    public static void LoadFont( string name, string path ) {
        var fonts = new FontCollection();
        var fontFamily = fonts.Add( path );
        _fonts.TryAdd( name, fontFamily );
    }

    /// <summary>
    /// 获取字体
    /// </summary>
    /// <param name="name">字体名称</param>
    public static FontFamily GetFont( string name ) {
        var result = GetFontFamily( name );
        return result.Name.IsEmpty() ? SystemFonts.Families.FirstOrDefault() : result;
    }

    /// <summary>
    /// 获取字体
    /// </summary>
    private static FontFamily GetFontFamily( string name ) {
        if ( name.IsEmpty() )
            return new FontFamily();
        if ( _fonts.TryGetValue( name, out var result ) )
            return result;
        return SystemFonts.Families.FirstOrDefault( t => t.Name == name );
    }

    /// <summary>
    /// 获取受支持的字体列表
    /// </summary>
    public static List<string> GetSupportedFonts() {
        var result = new List<string>();
        foreach ( var fontName in _fonts.Keys ) 
            result.Add( fontName );
        result.AddRange( SystemFonts.Families.Select( t => t.Name ) );
        return result;
    }
}