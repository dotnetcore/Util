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
/// 查看值组件测试
/// </summary>
public class SvValueTagHelperTest {
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
    public SvValueTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new SvValueTagHelper().ToWrapper();
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
    /// 测试前缀
    /// </summary>
    [Fact]
    public void TestPrefix() {
        _wrapper.SetContextAttribute( UiConst.Prefix, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-value prefix=\"a\"></sv-value>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试前缀
    /// </summary>
    [Fact]
    public void TestBindPrefix() {
        _wrapper.SetContextAttribute( AngularConst.BindPrefix, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-value [prefix]=\"a\"></sv-value>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试单位
    /// </summary>
    [Fact]
    public void TestUnit() {
        _wrapper.SetContextAttribute( UiConst.Unit, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-value unit=\"a\"></sv-value>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试单位
    /// </summary>
    [Fact]
    public void TestBindUnit() {
        _wrapper.SetContextAttribute( AngularConst.BindUnit, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-value [unit]=\"a\"></sv-value>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试文字提示
    /// </summary>
    [Fact]
    public void TestTooltip() {
        _wrapper.SetContextAttribute( UiConst.Tooltip, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-value tooltip=\"a\"></sv-value>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试文字提示
    /// </summary>
    [Fact]
    public void TestBindTooltip() {
        _wrapper.SetContextAttribute( AngularConst.BindTooltip, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-value [tooltip]=\"a\"></sv-value>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试尺寸
    /// </summary>
    [Fact]
    public void TestSize() {
        _wrapper.SetContextAttribute( UiConst.Size, SvValueSize.Large );
        var result = new StringBuilder();
        result.Append( "<sv-value size=\"large\"></sv-value>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试尺寸
    /// </summary>
    [Fact]
    public void TestBindSize() {
        _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-value [size]=\"a\"></sv-value>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<sv-value>a</sv-value>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}