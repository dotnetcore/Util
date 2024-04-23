using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.BackTops;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.BackTops;

/// <summary>
/// 回到顶部测试
/// </summary>
public class BackTopTagHelperTest {
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
    public BackTopTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new BackTopTagHelper().ToWrapper();
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
        result.Append( "<nz-back-top></nz-back-top>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试自定义内容
    /// </summary>
    [Fact]
    public void TestTemplate() {
        _wrapper.SetContextAttribute( UiConst.Template, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-back-top [nzTemplate]=\"a\"></nz-back-top>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试可见高度
    /// </summary>
    [Fact]
    public void TestVisibilityHeight() {
        _wrapper.SetContextAttribute( UiConst.VisibilityHeight, "1" );
        var result = new StringBuilder();
        result.Append( "<nz-back-top [nzVisibilityHeight]=\"1\"></nz-back-top>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试监听目标
    /// </summary>
    [Fact]
    public void TestTarget() {
        _wrapper.SetContextAttribute( UiConst.Target, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-back-top [nzTarget]=\"a\"></nz-back-top>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试持续时间
    /// </summary>
    [Fact]
    public void TestDuration() {
        _wrapper.SetContextAttribute( UiConst.Duration, "1" );
        var result = new StringBuilder();
        result.Append( "<nz-back-top [nzDuration]=\"1\"></nz-back-top>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<nz-back-top>a</nz-back-top>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试单击事件
    /// </summary>
    [Fact]
    public void TestOnClick() {
        _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-back-top (nzClick)=\"a\"></nz-back-top>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}