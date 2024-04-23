using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sv;
using Util.Ui.NgAlain.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgAlain.Tests.Sv;

/// <summary>
/// 查看容器组件测试
/// </summary>
public class SvContainerTagHelperTest {
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
    public SvContainerTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new SvContainerTagHelper().ToWrapper();
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
    /// 测试列数
    /// </summary>
    [Fact]
    public void TestColumn() {
        _wrapper.SetContextAttribute( UiConst.Column, "2" );
        var result = new StringBuilder();
        result.Append( "<sv-container [col]=\"2\"></sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试尺寸
    /// </summary>
    [Fact]
    public void TestSize() {
        _wrapper.SetContextAttribute( UiConst.Size, SvSize.Large );
        var result = new StringBuilder();
        result.Append( "<sv-container size=\"large\"></sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试尺寸
    /// </summary>
    [Fact]
    public void TestBindSize() {
        _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-container [size]=\"a\"></sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试布局
    /// </summary>
    [Fact]
    public void TestLayout() {
        _wrapper.SetContextAttribute( UiConst.Layout, SvLayout.Vertical );
        var result = new StringBuilder();
        result.Append( "<sv-container layout=\"vertical\"></sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试布局
    /// </summary>
    [Fact]
    public void TestBindLayout() {
        _wrapper.SetContextAttribute( AngularConst.BindLayout, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-container [layout]=\"a\"></sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试间距
    /// </summary>
    [Fact]
    public void TestGutter() {
        _wrapper.SetContextAttribute( UiConst.Gutter, "2" );
        var result = new StringBuilder();
        result.Append( "<sv-container [gutter]=\"2\"></sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标签文本宽度
    /// </summary>
    [Fact]
    public void TestLabelWidth() {
        _wrapper.SetContextAttribute( UiConst.LabelWidth, 2 );
        var result = new StringBuilder();
        result.Append( "<sv-container [labelWidth]=\"2\"></sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试是否显示默认文本
    /// </summary>
    [Fact]
    public void TestDefault() {
        _wrapper.SetContextAttribute( UiConst.Default, "true" );
        var result = new StringBuilder();
        result.Append( "<sv-container [default]=\"true\"></sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标题
    /// </summary>
    [Fact]
    public void TestTitle() {
        _wrapper.SetContextAttribute( UiConst.Title, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-container title=\"a\"></sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标题
    /// </summary>
    [Fact]
    public void TestBindTitle() {
        _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-container [title]=\"a\"></sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试是否不显示标签后面的冒号
    /// </summary>
    [Fact]
    public void TestNoColon() {
        _wrapper.SetContextAttribute( UiConst.NoColon, "true" );
        var result = new StringBuilder();
        result.Append( "<sv-container [noColon]=\"true\"></sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试是否显示边框
    /// </summary>
    [Fact]
    public void TestBordered() {
        _wrapper.SetContextAttribute( UiConst.Bordered, "true" );
        var result = new StringBuilder();
        result.Append( "<sv-container [bordered]=\"true\"></sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<sv-container>a</sv-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}