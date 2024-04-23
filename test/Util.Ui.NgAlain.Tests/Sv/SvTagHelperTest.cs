using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sv;
using Util.Ui.NgAlain.Enums;
using Util.Ui.NgAlain.Tests.Samples;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgAlain.Tests.Sv;

/// <summary>
/// 查看列组件测试
/// </summary>
public partial class SvTagHelperTest {
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
    public SvTagHelperTest( ITestOutputHelper output ) {
        _output = output;
        _wrapper = new SvTagHelper().ToWrapper<Customer>();
        Id.SetId("id");
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
    /// 测试列跨度
    /// </summary>
    [Fact]
    public void TestColumn() {
        _wrapper.SetContextAttribute( UiConst.Column, "2" );
        var result = new StringBuilder();
        result.Append( "<sv [col]=\"2\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标签
    /// </summary>
    [Fact]
    public void TestLabel() {
        _wrapper.SetContextAttribute( UiConst.Label, "a" );
        var result = new StringBuilder();
        result.Append( "<sv label=\"a\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标签 - 多语言
    /// </summary>
    [Fact]
    public void TestLabel_I18n() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.Label, "a" );
        var result = new StringBuilder();
        result.Append( "<sv [label]=\"'a'|i18n\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标签
    /// </summary>
    [Fact]
    public void TestBindLabel() {
        _wrapper.SetContextAttribute( AngularConst.BindLabel, "a" );
        var result = new StringBuilder();
        result.Append( "<sv [label]=\"a\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试单位
    /// </summary>
    [Fact]
    public void TestUnit() {
        _wrapper.SetContextAttribute( UiConst.Unit, "a" );
        var result = new StringBuilder();
        result.Append( "<sv unit=\"a\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试单位
    /// </summary>
    [Fact]
    public void TestBindUnit() {
        _wrapper.SetContextAttribute( AngularConst.BindUnit, "a" );
        var result = new StringBuilder();
        result.Append( "<sv [unit]=\"a\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试显示默认文本
    /// </summary>
    [Fact]
    public void TestDefault() {
        _wrapper.SetContextAttribute( UiConst.Default, "a" );
        var result = new StringBuilder();
        result.Append( "<sv [default]=\"a\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    [Fact]
    public void TestType() {
        _wrapper.SetContextAttribute( UiConst.Type, SvType.Primary );
        var result = new StringBuilder();
        result.Append( "<sv type=\"primary\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    [Fact]
    public void TestBindType() {
        _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
        var result = new StringBuilder();
        result.Append( "<sv [type]=\"a\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标签可选信息
    /// </summary>
    [Fact]
    public void TestOptional() {
        _wrapper.SetContextAttribute( UiConst.Optional, "a" );
        var result = new StringBuilder();
        result.Append( "<sv optional=\"a\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标签可选信息
    /// </summary>
    [Fact]
    public void TestBindOptional() {
        _wrapper.SetContextAttribute( AngularConst.BindOptional, "a" );
        var result = new StringBuilder();
        result.Append( "<sv [optional]=\"a\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标签可选帮助
    /// </summary>
    [Fact]
    public void TestOptionalHelp() {
        _wrapper.SetContextAttribute( UiConst.OptionalHelp, "a" );
        var result = new StringBuilder();
        result.Append( "<sv optionalHelp=\"a\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标签可选帮助
    /// </summary>
    [Fact]
    public void TestBindOptionalHelp() {
        _wrapper.SetContextAttribute( AngularConst.BindOptionalHelp, "a" );
        var result = new StringBuilder();
        result.Append( "<sv [optionalHelp]=\"a\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标签可选帮助背景颜色
    /// </summary>
    [Fact]
    public void TestOptionalHelpColor() {
        _wrapper.SetContextAttribute( UiConst.OptionalHelpColor, "a" );
        var result = new StringBuilder();
        result.Append( "<sv optionalHelpColor=\"a\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试标签可选帮助背景颜色
    /// </summary>
    [Fact]
    public void TestBindOptionalHelpColor() {
        _wrapper.SetContextAttribute( AngularConst.BindOptionalHelpColor, "a" );
        var result = new StringBuilder();
        result.Append( "<sv [optionalHelpColor]=\"a\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试不显示冒号
    /// </summary>
    [Fact]
    public void TestNoColon() {
        _wrapper.SetContextAttribute( UiConst.NoColon, "true" );
        var result = new StringBuilder();
        result.Append( "<sv [noColon]=\"true\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试隐藏标签
    /// </summary>
    [Fact]
    public void TestHideLabel() {
        _wrapper.SetContextAttribute( UiConst.HideLabel, "true" );
        var result = new StringBuilder();
        result.Append( "<sv [hideLabel]=\"true\"></sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试值
    /// </summary>
    [Fact]
    public void TestValue() {
        _wrapper.SetContextAttribute( UiConst.Value, "a" );
        var result = new StringBuilder();
        result.Append( "<sv>{{a}}</sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试值 - 多语言
    /// </summary>
    [Fact]
    public void TestValueI18n() {
        _wrapper.SetContextAttribute( UiConst.ValueI18n, true );
        _wrapper.SetContextAttribute( UiConst.Value, "a" );
        var result = new StringBuilder();
        result.Append( "<sv>{{a|i18n}}</sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试复制到剪贴板
    /// </summary>
    [Fact]
    public void TestClipboard() {
        _wrapper.SetContextAttribute( UiConst.Value, "model.code" );
        _wrapper.SetContextAttribute( UiConst.Clipboard, true );
        var result = new StringBuilder();
        result.Append( "<sv>" );
        result.Append( "{{model.code}}" );
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.copyToClipboard(model.code)\" *ngIf=\"model.code\" " );
        result.Append( "nz-button=\"\" nz-tooltip=\"\" nzTooltipTitle=\"复制到剪贴板\" nzType=\"text\" x-button-extend=\"\">" );
        result.Append( "<i nz-icon=\"\" nzType=\"copy\"></i>" );
        result.Append( "</button>" );
        result.Append( "</sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试复制到剪贴板 - 多语言
    /// </summary>
    [Fact]
    public void TestClipboard_I18n() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.Value, "model.code" );
        _wrapper.SetContextAttribute( UiConst.Clipboard, true );
        _wrapper.SetContextAttribute( UiConst.ValueI18n, true );
        var result = new StringBuilder();
        result.Append( "<sv>" );
        result.Append( "{{model.code|i18n}}" );
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.copyToClipboard(model.code)\" *ngIf=\"model.code\" " );
        result.Append( "nz-button=\"\" nz-tooltip=\"\" nzType=\"text\" x-button-extend=\"\" [nzTooltipTitle]=\"'util.copyToClipboard'|i18n\">" );
        result.Append( "<i nz-icon=\"\" nzType=\"copy\"></i>" );
        result.Append( "</button>" );
        result.Append( "</sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试内容
    /// </summary>
    [Fact]
    public void TestContent() {
        _wrapper.AppendContent( "a" );
        var result = new StringBuilder();
        result.Append( "<sv>a</sv>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}