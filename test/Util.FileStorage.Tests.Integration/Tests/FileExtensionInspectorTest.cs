namespace Util.FileStorage.Tests;

/// <summary>
/// 文件扩展名检查器测试
/// </summary>
public class FileExtensionInspectorTest {
    /// <summary>
    /// 文件扩展名检查器
    /// </summary>
    private readonly IFileExtensionInspector _inspector;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public FileExtensionInspectorTest( IFileExtensionInspector inspector ) {
        _inspector = inspector;
    }

    /// <summary>
    /// 测试是否图片文件
    /// </summary>
    [Fact]
    public void TestIsImage() {
        var filePath = Util.Helpers.Common.GetPhysicalPath( "Resources/a.jpg" );
        using var stream = Util.Helpers.File.ReadToStream( filePath );
        Assert.True( _inspector.IsImage( stream ) );

        filePath = Util.Helpers.Common.GetPhysicalPath( "Resources/b.png" );
        using var stream2 = Util.Helpers.File.ReadToStream( filePath );
        Assert.True( _inspector.IsImage( stream2 ) );

        filePath = Util.Helpers.Common.GetPhysicalPath( "Resources/c.gif" );
        using var stream3 = Util.Helpers.File.ReadToStream( filePath );
        Assert.True( _inspector.IsImage( stream3 ) );
    }

    /// <summary>
    /// 测试是否pdf文件
    /// </summary>
    [Fact]
    public void TestIsPdf() {
        var filePath = Util.Helpers.Common.GetPhysicalPath( "Resources/4.pdf" );
        using var stream = Util.Helpers.File.ReadToStream( filePath );
        Assert.True( _inspector.IsPdf( stream ) );
    }

    /// <summary>
    /// 测试是否Office文件
    /// </summary>
    [Fact]
    public void TestIsOffice() {
        var filePath = Util.Helpers.Common.GetPhysicalPath( "Resources/5.docx" );
        using var stream = Util.Helpers.File.ReadToStream( filePath );
        Assert.True( _inspector.IsOffice( stream ) );

        filePath = Util.Helpers.Common.GetPhysicalPath( "Resources/6.xlsx" );
        using var stream2 = Util.Helpers.File.ReadToStream( filePath );
        Assert.True( _inspector.IsOffice( stream2 ) );
    }
}