using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.WaterMarks;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.WaterMarks;

/// <summary>
/// 水印测试
/// </summary>
public class WaterMarkTagHelperTest {
    /// <summary>
    /// 输出工具
    /// </summary>
    private readonly ITestOutputHelper _output;
    /// <summary>
    /// TagHelper包装器
    /// </summary>
    private readonly TagHelperWrapper _wrapper;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public WaterMarkTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new WaterMarkTagHelper().ToWrapper();
    }

    /// <summary>
    /// 获取结果
    /// </summary>
    private string GetResult() {
        var result = _wrapper.GetResult();
        _output.WriteLine( result );
        return result;
    }

    /// <summary>
    /// 测试默认输出
    /// </summary>
    [Fact]
    public void TestDefault() {
        var result = new StringBuilder();
        result.Append( "<nz-water-mark></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试水印文字内容
    /// </summary>
    [Fact]
    public void TestContent() {
        _wrapper.SetContextAttribute( UiConst.Content, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark nzContent=\"a\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试水印文字内容
    /// </summary>
    [Fact]
    public void TestBindContent() {
        _wrapper.SetContextAttribute( AngularConst.BindContent, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzContent]=\"a\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试水印宽度
    /// </summary>
    [Fact]
    public void TestWidth() {
        _wrapper.SetContextAttribute( UiConst.Width, 1 );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzWidth]=\"1\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试水印宽度
    /// </summary>
    [Fact]
    public void TestBindWidth() {
        _wrapper.SetContextAttribute( AngularConst.BindWidth, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzWidth]=\"a\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试水印高度
    /// </summary>
    [Fact]
    public void TestHeight() {
        _wrapper.SetContextAttribute( UiConst.Height, 1 );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzHeight]=\"1\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试水印高度
    /// </summary>
    [Fact]
    public void TestBindHeight() {
        _wrapper.SetContextAttribute( AngularConst.BindHeight, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzHeight]=\"a\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试旋转角度
    /// </summary>
    [Fact]
    public void TestRotate() {
        _wrapper.SetContextAttribute( UiConst.Rotate, 1 );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzRotate]=\"1\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试旋转角度
    /// </summary>
    [Fact]
    public void TestBindRotate() {
        _wrapper.SetContextAttribute( AngularConst.BindRotate, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzRotate]=\"a\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试z-index
    /// </summary>
    [Fact]
    public void TestZIndex() {
        _wrapper.SetContextAttribute( UiConst.ZIndex, 1 );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzZIndex]=\"1\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试z-index
    /// </summary>
    [Fact]
    public void TestBindZIndex() {
        _wrapper.SetContextAttribute( AngularConst.BindZIndex, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzZIndex]=\"a\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试水印图片地址
    /// </summary>
    [Fact]
    public void TestImage() {
        _wrapper.SetContextAttribute( UiConst.Image, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark nzImage=\"a\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试水印图片地址
    /// </summary>
    [Fact]
    public void TestBindImage() {
        _wrapper.SetContextAttribute( AngularConst.BindImage, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzImage]=\"a\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试文字样式
    /// </summary>
    [Fact]
    public void TestFont() {
        _wrapper.SetContextAttribute( UiConst.Font, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzFont]=\"a\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试字体颜色
    /// </summary>
    [Fact]
    public void TestFontColor() {
        _wrapper.SetContextAttribute( UiConst.FontColor, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzFont]=\"{'color':'a'}\"></nz-water-mark>" ); 
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试字体大小
    /// </summary>
    [Fact]
    public void TestFontSize() {
        _wrapper.SetContextAttribute( UiConst.FontSize, 1 );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzFont]=\"{'fontSize':1}\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试字体粗细
    /// </summary>
    [Fact]
    public void TestFontWeight() {
        _wrapper.SetContextAttribute( UiConst.FontWeight, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzFont]=\"{'fontWeight':'a'}\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试字体类型
    /// </summary>
    [Fact]
    public void TestFontFamily() {
        _wrapper.SetContextAttribute( UiConst.FontFamily, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzFont]=\"{'fontFamily':'a'}\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试字体样式
    /// </summary>
    [Fact]
    public void TestFontStyle() {
        _wrapper.SetContextAttribute( UiConst.FontStyle, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzFont]=\"{'fontStyle':'a'}\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试间距
    /// </summary>
    [Fact]
    public void TestGap() {
        _wrapper.SetContextAttribute( UiConst.Gap, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzGap]=\"a\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试偏移量
    /// </summary>
    [Fact]
    public void TestOffset() {
        _wrapper.SetContextAttribute( UiConst.Offset, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark [nzOffset]=\"a\"></nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestAppendContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<nz-water-mark>a</nz-water-mark>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}