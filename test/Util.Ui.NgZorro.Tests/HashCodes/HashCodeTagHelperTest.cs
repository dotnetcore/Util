using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.HashCodes;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.HashCodes;

/// <summary>
/// 哈希码测试
/// </summary>
public class HashCodeTagHelperTest {
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
    public HashCodeTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new HashCodeTagHelper().ToWrapper();
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
        result.Append( "<nz-hash-code></nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试值
    /// </summary>
    [Fact]
    public void TestValue() {
        _wrapper.SetContextAttribute( UiConst.Value, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-hash-code nzValue=\"a\"></nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试值
    /// </summary>
    [Fact]
    public void TestBindValue() {
        _wrapper.SetContextAttribute( AngularConst.BindValue, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-hash-code [nzValue]=\"a\"></nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标题
    /// </summary>
    [Fact]
    public void TestTitle() {
        _wrapper.SetContextAttribute( UiConst.Title, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-hash-code nzTitle=\"a\"></nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标题
    /// </summary>
    [Fact]
    public void TestBindTitle() {
        _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-hash-code [nzTitle]=\"a\"></nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标志
    /// </summary>
    [Fact]
    public void TestLogo() {
        _wrapper.SetContextAttribute( UiConst.Logo, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-hash-code nzLogo=\"a\"></nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标志
    /// </summary>
    [Fact]
    public void TestBindLogo() {
        _wrapper.SetContextAttribute( AngularConst.BindLogo, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-hash-code [nzLogo]=\"a\"></nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试展示模式
    /// </summary>
    [Fact]
    public void TestMode() {
        _wrapper.SetContextAttribute( UiConst.Mode, HashCodeMode.Rect );
        var result = new StringBuilder();
        result.Append( "<nz-hash-code nzMode=\"rect\"></nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试展示模式
    /// </summary>
    [Fact]
    public void TestBindMode() {
        _wrapper.SetContextAttribute( AngularConst.BindMode, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-hash-code [nzMode]=\"a\"></nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试样式
    /// </summary>
    [Fact]
    public void TestType() {
        _wrapper.SetContextAttribute( UiConst.Type, HashCodeType.Primary );
        var result = new StringBuilder();
        result.Append( "<nz-hash-code nzType=\"primary\"></nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试样式
    /// </summary>
    [Fact]
    public void TestBindType() {
        _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-hash-code [nzType]=\"a\"></nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<nz-hash-code>a</nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试复制事件
    /// </summary>
    [Fact]
    public void TestOnCopy() {
        _wrapper.SetContextAttribute( UiConst.OnCopy, "a" );
        var result = new StringBuilder();
        result.Append( "<nz-hash-code (nzOnCopy)=\"a\"></nz-hash-code>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}