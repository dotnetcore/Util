using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sv;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgAlain.Tests.Sv;

/// <summary>
/// 查看标题组件测试
/// </summary>
public class SvTitleTagHelperTest {
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
    public SvTitleTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new SvTitleTagHelper().ToWrapper();
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
    /// 测试标题
    /// </summary>
    [Fact]
    public void TestTitle() {
        _wrapper.SetContextAttribute( UiConst.Title, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-title>a</sv-title>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标题 - 多语言
    /// </summary>
    [Fact]
    public void TestTitle_I18n() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.Title, "a" );
        var result = new StringBuilder();
        result.Append( "<sv-title>{{'a'|i18n}}</sv-title>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<sv-title>a</sv-title>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}