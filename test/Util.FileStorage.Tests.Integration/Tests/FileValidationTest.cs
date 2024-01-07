namespace Util.FileStorage.Tests;

/// <summary>
/// 文件验证操作测试
/// </summary>
public class FileValidationTest {
    /// <summary>
    /// 测试扩展名是否有效
    /// </summary>
    [Fact]
    public void TestIsValidExtension() {
        Assert.True( FileValidation.IsValidExtension( "a.jpg", "" ) );
        Assert.False( FileValidation.IsValidExtension( "", ".jpg" ) );
        Assert.True( FileValidation.IsValidExtension( "a.jpg", ".jpg" ) );
        Assert.True( FileValidation.IsValidExtension( "a.jpg", "jpg" ) );
        Assert.False( FileValidation.IsValidExtension( "a.png", ".jpg" ) );
        Assert.True( FileValidation.IsValidExtension( "a.jpg", ".jpg,.png" ) );
        Assert.True( FileValidation.IsValidExtension( "a.png", ".jpg,.png" ) );
        Assert.True( FileValidation.IsValidExtension( "a.jpg", "jpg,png" ) );
        Assert.True( FileValidation.IsValidExtension( "a.png", "jpg,png" ) );
        Assert.True( FileValidation.IsValidExtension( ".jpg", ".jpg,png" ) );
        Assert.True( FileValidation.IsValidExtension( ".png", "jpg,.png" ) );
        Assert.True( FileValidation.IsValidExtension( "a.png", "," ) );
        Assert.False( FileValidation.IsValidExtension( "a.png", ",.jpg" ) );
        Assert.False( FileValidation.IsValidExtension( "a", ",.jpg" ) );
        Assert.True( FileValidation.IsValidExtension( "a", ",." ) );
    }
}