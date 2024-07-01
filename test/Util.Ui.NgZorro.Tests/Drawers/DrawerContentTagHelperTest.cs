using System.Text;
using Util.Ui.NgZorro.Components.Drawers;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Drawers;

/// <summary>
/// 抽屉内容测试
/// </summary>
public class DrawerContentTagHelperTest {
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
    public DrawerContentTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new DrawerContentTagHelper().ToWrapper();
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
        result.Append( "<ng-container *nzDrawerContent=\"\"></ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestAppendContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<ng-container *nzDrawerContent=\"\">a</ng-container>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}