using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Ellipsis;
using Util.Ui.NgAlain.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgAlain.Tests.Ellipsis;

/// <summary>
/// 文本省略组件测试
/// </summary>
public partial class EllipsisTagHelperTest {
    /// <summary>
    /// 输出工具
    /// </summary>
    private readonly ITestOutputHelper _output;
    /// <summary>
    /// TagHelper包装器
    /// </summary>
    private readonly TagHelperWrapper<Customer> _wrapper;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public EllipsisTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new EllipsisTagHelper().ToWrapper<Customer>();
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
        result.Append( "<ellipsis></ellipsis>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试工具提示
    /// </summary>
    [Fact]
    public void TestTooltip() {
        _wrapper.SetContextAttribute( UiConst.Tooltip, "true" );
        var result = new StringBuilder();
        result.Append( "<ellipsis [tooltip]=\"true\"></ellipsis>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试文本最大长度
    /// </summary>
    [Fact]
    public void TestLength() {
        _wrapper.SetContextAttribute( UiConst.Length, "2" );
        var result = new StringBuilder();
        result.Append( "<ellipsis [length]=\"2\"></ellipsis>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试文本最大行数
    /// </summary>
    [Fact]
    public void TestLines() {
        _wrapper.SetContextAttribute( UiConst.Lines, "2" );
        var result = new StringBuilder();
        result.Append( "<ellipsis [lines]=\"2\"></ellipsis>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试是否将全角字符的长度视为2来计算字符串长度
    /// </summary>
    [Fact]
    public void TestFullWidthRecognition() {
        _wrapper.SetContextAttribute( UiConst.FullWidthRecognition, "true" );
        var result = new StringBuilder();
        result.Append( "<ellipsis [fullWidthRecognition]=\"true\"></ellipsis>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试溢出尾巴
    /// </summary>
    [Fact]
    public void TestTail() {
        _wrapper.SetContextAttribute( UiConst.Tail, "a" );
        var result = new StringBuilder();
        result.Append( "<ellipsis tail=\"a\"></ellipsis>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试溢出尾巴
    /// </summary>
    [Fact]
    public void TestBindTail() {
        _wrapper.SetContextAttribute( AngularConst.BindTail, "a" );
        var result = new StringBuilder();
        result.Append( "<ellipsis [tail]=\"a\"></ellipsis>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestAppendContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<ellipsis>a</ellipsis>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}