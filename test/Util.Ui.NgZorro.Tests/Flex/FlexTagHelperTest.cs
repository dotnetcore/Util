using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Flex;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Flex;

/// <summary>
/// 弹性布局栅格测试
/// </summary>
public class FlexTagHelperTest {
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
    public FlexTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new FlexTagHelper().ToWrapper();
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
        result.Append( "<div nz-flex=\"\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试是否垂直布局
    /// </summary>
    [Fact]
    public void TestVertical() {
        _wrapper.SetContextAttribute( UiConst.Vertical, "true" );
        var result = new StringBuilder();
        result.Append( "<div nz-flex=\"\" [nzVertical]=\"true\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试对齐方式
    /// </summary>
    [Fact]
    public void TestJustify() {
        _wrapper.SetContextAttribute( UiConst.Justify, FlexJustify.FlexEnd );
        var result = new StringBuilder();
        result.Append( "<div nz-flex=\"\" nzJustify=\"flex-end\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试对齐方式
    /// </summary>
    [Fact]
    public void TestBindJustify() {
        _wrapper.SetContextAttribute( AngularConst.BindJustify, "a" );
        var result = new StringBuilder();
        result.Append( "<div nz-flex=\"\" [nzJustify]=\"a\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试垂直对齐方式
    /// </summary>
    [Fact]
    public void TestAlign() {
        _wrapper.SetContextAttribute( UiConst.Align, FlexAlign.FlexEnd );
        var result = new StringBuilder();
        result.Append( "<div nz-flex=\"\" nzAlign=\"flex-end\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试垂直对齐方式
    /// </summary>
    [Fact]
    public void TestBindAlign() {
        _wrapper.SetContextAttribute( AngularConst.BindAlign, "a" );
        var result = new StringBuilder();
        result.Append( "<div nz-flex=\"\" [nzAlign]=\"a\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试间距
    /// </summary>
    [Fact]
    public void TestGap() {
        _wrapper.SetContextAttribute( UiConst.Gap, FlexGap.Middle );
        var result = new StringBuilder();
        result.Append( "<div nz-flex=\"\" nzGap=\"middle\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试间距
    /// </summary>
    [Fact]
    public void TestBindGap() {
        _wrapper.SetContextAttribute( AngularConst.BindGap, "10" );
        var result = new StringBuilder();
        result.Append( "<div nz-flex=\"\" [nzGap]=\"10\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试自动换行
    /// </summary>
    [Fact]
    public void TestWrap() {
        _wrapper.SetContextAttribute( UiConst.Wrap, FlexWrap.Nowrap );
        var result = new StringBuilder();
        result.Append( "<div nz-flex=\"\" nzWrap=\"nowrap\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试自动换行
    /// </summary>
    [Fact]
    public void TestBindWrap() {
        _wrapper.SetContextAttribute( AngularConst.BindWrap, "a" );
        var result = new StringBuilder();
        result.Append( "<div nz-flex=\"\" [nzWrap]=\"a\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试flex
    /// </summary>
    [Fact]
    public void TestFlex() {
        _wrapper.SetContextAttribute( UiConst.Flex, "1" );
        var result = new StringBuilder();
        result.Append( "<div nz-flex=\"\" nzFlex=\"1\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试flex
    /// </summary>
    [Fact]
    public void TestBindFlex() {
        _wrapper.SetContextAttribute( AngularConst.BindFlex, "a" );
        var result = new StringBuilder();
        result.Append( "<div nz-flex=\"\" [nzFlex]=\"a\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<div nz-flex=\"\">a</div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}