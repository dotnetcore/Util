using System.Text;
using Util.Ui.NgZorro.Components.Modals;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Modals;

/// <summary>
/// 对话框页脚测试
/// </summary>
public class ModalFooterTagHelperTest {
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
    public ModalFooterTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new ModalFooterTagHelper().ToWrapper();
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
        result.Append( "<div *nzModalFooter=\"\"></div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestAppendContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<div *nzModalFooter=\"\">a</div>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}