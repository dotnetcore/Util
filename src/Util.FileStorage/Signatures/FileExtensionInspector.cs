namespace Util.FileStorage.Signatures;

/// <summary>
/// 文件扩展名检查器
/// </summary>
public class FileExtensionInspector : IFileExtensionInspector {
    /// <summary>
    /// 文件格式检查器
    /// </summary>
    private readonly FileFormatInspector _inspector;

    /// <summary>
    /// 初始化文件扩展名检查器
    /// </summary>
    public FileExtensionInspector() {
        _inspector = new FileFormatInspector();
    }

    /// <inheritdoc />
    public string GetExtension( Stream stream ) {
        if ( stream == null )
            return null;
        var result = _inspector.DetermineFileFormat( stream );
        return result?.Extension;
    }

    /// <inheritdoc />
    public bool IsImage( Stream stream ) {
        if( stream == null )
            return false;
        var result = _inspector.DetermineFileFormat( stream );
        return result is Image;
    }

    /// <inheritdoc />
    public bool IsPdf( Stream stream ) {
        if( stream == null )
            return false;
        var result = _inspector.DetermineFileFormat( stream );
        return result is Pdf;
    }

    /// <inheritdoc />
    public bool IsOffice( Stream stream ) {
        if( stream == null )
            return false;
        var result = _inspector.DetermineFileFormat( stream );
        return result is OfficeOpenXml or CompoundFileBinary;
    }

    /// <inheritdoc />
    public bool IsVideo( Stream stream ) {
        if( stream == null )
            return false;
        var result = _inspector.DetermineFileFormat( stream );
        return result is Isobmff;
    }
}