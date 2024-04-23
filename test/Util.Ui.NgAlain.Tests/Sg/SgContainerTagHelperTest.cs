using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sg;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgAlain.Tests.Sg;

/// <summary>
/// 简易栅格容器组件测试
/// </summary>
public class SgContainerTagHelperTest {
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
    public SgContainerTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new SgContainerTagHelper().ToWrapper();
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
        result.Append( "<div sg-container=\"\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试间距
    /// </summary>
    [Fact]
    public void TestGutter() {
        _wrapper.SetContextAttribute( UiConst.Gutter, "2" );
        var result = new StringBuilder();
        result.Append( "<div sg-container=\"\" [gutter]=\"2\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试列数
    /// </summary>
    [Fact]
    public void TestColumn() {
        _wrapper.SetContextAttribute( UiConst.Column, "2" );
        var result = new StringBuilder();
        result.Append( "<div sg-container=\"\" [col]=\"2\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<div sg-container=\"\">a</div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}