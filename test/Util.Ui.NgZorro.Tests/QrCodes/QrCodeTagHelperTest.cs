using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.QrCodes;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.QrCodes;

/// <summary>
/// 二维码测试
/// </summary>
public class QrCodeTagHelperTest {
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
    public QrCodeTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new QrCodeTagHelper().ToWrapper();
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
        result.Append( "<nz-qrcode></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试值
    /// </summary>
    [Fact]
    public void TestValue() {
        _wrapper.SetContextAttribute( UiConst.Value, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode nzValue=\"a\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试值
    /// </summary>
    [Fact]
    public void TestBindValue() {
        _wrapper.SetContextAttribute( AngularConst.BindValue, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode [nzValue]=\"a\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试颜色
    /// </summary>
    [Fact]
    public void TestColor() {
        _wrapper.SetContextAttribute( UiConst.Color, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode nzColor=\"a\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试颜色
    /// </summary>
    [Fact]
    public void TestBindColor() {
        _wrapper.SetContextAttribute( AngularConst.BindColor, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode [nzColor]=\"a\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试背景色
    /// </summary>
    [Fact]
    public void TestBgColor() {
        _wrapper.SetContextAttribute( UiConst.BgColor, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode nzBgColor=\"a\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试背景色
    /// </summary>
    [Fact]
    public void TestBindBgColor() {
        _wrapper.SetContextAttribute( AngularConst.BindBgColor, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode [nzBgColor]=\"a\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试尺寸
    /// </summary>
    [Fact]
    public void TestSize() {
        _wrapper.SetContextAttribute( UiConst.Size, "1" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode [nzSize]=\"1\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试填充
    /// </summary>
    [Fact]
    public void TestPadding() {
        _wrapper.SetContextAttribute( UiConst.Padding, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode [nzPadding]=\"a\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试图标地址
    /// </summary>
    [Fact]
    public void TestIcon() {
        _wrapper.SetContextAttribute( UiConst.Icon, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode nzIcon=\"a\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试图标地址
    /// </summary>
    [Fact]
    public void TestBindIcon() {
        _wrapper.SetContextAttribute( AngularConst.BindIcon, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode [nzIcon]=\"a\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试图标尺寸
    /// </summary>
    [Fact]
    public void TestIconSize() {
        _wrapper.SetContextAttribute( UiConst.IconSize, "1" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode [nzIconSize]=\"1\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试边框
    /// </summary>
    [Fact]
    public void TestBordered() {
        _wrapper.SetContextAttribute( UiConst.Bordered, "true" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode [nzBordered]=\"true\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试状态
    /// </summary>
    [Fact]
    public void TestStatus() {
        _wrapper.SetContextAttribute( UiConst.Status, QrCodeStatus.Expired );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode nzStatus=\"expired\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试状态
    /// </summary>
    [Fact]
    public void TestBindStatus() {
        _wrapper.SetContextAttribute( AngularConst.BindStatus, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode [nzStatus]=\"a\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试容错级别
    /// </summary>
    [Fact]
    public void TestLevel() {
        _wrapper.SetContextAttribute( UiConst.Level, QrCodeCorrectionLevel.H );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode nzLevel=\"H\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试容错级别
    /// </summary>
    [Fact]
    public void TestBindLevel() {
        _wrapper.SetContextAttribute( AngularConst.BindLevel, 'a' );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode [nzLevel]=\"a\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode>a</nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试刷新事件
    /// </summary>
    [Fact]
    public void TestOnRefresh() {
        _wrapper.SetContextAttribute( UiConst.OnRefresh, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-qrcode (nzRefresh)=\"a\"></nz-qrcode>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}