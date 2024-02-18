using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.FooterToolbars;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgAlain.Tests.FooterToolbars;

/// <summary>
/// 底部工具栏测试
/// </summary>
public class FooterToolbarTagHelperTest {
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
    public FooterToolbarTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new FooterToolbarTagHelper().ToWrapper();
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
        result.Append( "<footer-toolbar></footer-toolbar>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试错误收集
    /// </summary>
    [Fact]
    public void TestErrorCollect() {
        _wrapper.SetContextAttribute( UiConst.ErrorCollect, "true" );
        var result = new StringBuilder();
        result.Append( "<footer-toolbar [errorCollect]=\"true\"></footer-toolbar>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试额外信息
    /// </summary>
    [Fact]
    public void TestExtra() {
        _wrapper.SetContextAttribute( UiConst.Extra, "a" );
        var result = new StringBuilder();
        result.Append( "<footer-toolbar extra=\"a\"></footer-toolbar>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试额外信息
    /// </summary>
    [Fact]
    public void TestBindExtra() {
        _wrapper.SetContextAttribute( AngularConst.BindExtra, "a" );
        var result = new StringBuilder();
        result.Append( "<footer-toolbar [extra]=\"a\"></footer-toolbar>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestAppendContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<footer-toolbar>a</footer-toolbar>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}