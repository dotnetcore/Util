using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sg;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgAlain.Tests.Sg;

/// <summary>
/// 简易栅格列组件测试
/// </summary>
public class SgTagHelperTest {
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
    public SgTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new SgTagHelper().ToWrapper();
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
        result.Append( "<sg></sg>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试列跨度
    /// </summary>
    [Fact]
    public void TestSpan() {
        _wrapper.SetContextAttribute( UiConst.Span, "2" );
        var result = new StringBuilder();
        result.Append( "<sg [col]=\"2\"></sg>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}