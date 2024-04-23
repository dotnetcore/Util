using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Buttons;

/// <summary>
/// 按钮测试 - 指令扩展
/// </summary>
public partial class ButtonTagHelperTest {
    /// <summary>
    /// 测试是否验证表单
    /// </summary>
    [Fact]
    public void TestValidateForm_1() {
        _wrapper.SetItem( new FormShareConfig { FormId = "formId" } );
        _wrapper.SetContextAttribute( UiConst.ValidateForm, true );
        _wrapper.SetContextAttribute( UiConst.OnClick, "test()" );
        var result = new StringBuilder();
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.validateForm();test()\" nz-button=\"\" " );
        result.Append( "type=\"button\" x-button-extend=\"\" [disabled]=\"x_id.isDisabled(formId.invalid)\">" );
        result.Append( "</button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试是否验证表单 - 指定按钮标识
    /// </summary>
    [Fact]
    public void TestValidateForm_2() {
        _wrapper.SetItem( new FormShareConfig { FormId = "formId" } );
        _wrapper.SetContextAttribute( UiConst.ValidateForm, true );
        _wrapper.SetContextAttribute( UiConst.Id, "a" );
        _wrapper.SetContextAttribute( UiConst.OnClick, "test()" );
        var result = new StringBuilder();
        result.Append( "<button #a=\"\" #x_a=\"xButtonExtend\" (click)=\"x_a.validateForm();test()\" nz-button=\"\" " );
        result.Append( "type=\"button\" x-button-extend=\"\" [disabled]=\"x_a.isDisabled(formId.invalid)\">" );
        result.Append( "</button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试复制到剪贴板
    /// </summary>
    [Fact]
    public void TestCopyToClipboard() {
        _wrapper.SetContextAttribute( UiConst.CopyToClipboard, "a" );
        var result = new StringBuilder();
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.copyToClipboard(a)\" " );
        result.Append( "nz-button=\"\" nz-tooltip=\"\" nzTooltipTitle=\"复制到剪贴板\" nzType=\"text\" x-button-extend=\"\">" );
        result.Append( "<i nz-icon=\"\" nzType=\"copy\"></i>" );
        result.Append( "</button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试复制到剪贴板 - 多语言
    /// </summary>
    [Fact]
    public void TestCopyToClipboard_I18n() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.CopyToClipboard, "a" );
        var result = new StringBuilder();
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.copyToClipboard(a)\" " );
        result.Append( "nz-button=\"\" nz-tooltip=\"\" nzType=\"text\" x-button-extend=\"\" [nzTooltipTitle]=\"'util.copyToClipboard'|i18n\">" );
        result.Append( "<i nz-icon=\"\" nzType=\"copy\"></i>" );
        result.Append( "</button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试全屏
    /// </summary>
    [Fact]
    public void TestFullscreen() {
        _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
        var result = new StringBuilder();
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a)\" " );
        result.Append( "nz-button=\"\" x-button-extend=\"\">" );
        result.Append( "{{x_id.isFullscreen?'退出全屏':'全屏'}}" );
        result.Append( "</button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试全屏 - 多语言
    /// </summary>
    [Fact]
    public void TestFullscreen_I18n() {
        NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
        _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
        var result = new StringBuilder();
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a)\" " );
        result.Append( "nz-button=\"\" x-button-extend=\"\">" );
        result.Append( "{{(x_id.isFullscreen?'util.fullscreenExit':'util.fullscreen')|i18n}}" );
        result.Append( "</button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试全屏外层容器样式类名
    /// </summary>
    [Fact]
    public void TestFullscreenWrapClass() {
        _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
        _wrapper.SetContextAttribute( UiConst.FullscreenWrapClass, "b" );
        var result = new StringBuilder();
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a,'b')\" " );
        result.Append( "nz-button=\"\" x-button-extend=\"\">" );
        result.Append( "{{x_id.isFullscreen?'退出全屏':'全屏'}}" );
        result.Append( "</button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试全屏包装
    /// </summary>
    [Fact]
    public void TestFullscreenPack() {
        _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
        _wrapper.SetContextAttribute( UiConst.FullscreenWrapClass, "b" );
        _wrapper.SetContextAttribute( UiConst.FullscreenPack, false );
        var result = new StringBuilder();
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a,'b',false)\" " );
        result.Append( "nz-button=\"\" x-button-extend=\"\">" );
        result.Append( "{{x_id.isFullscreen?'退出全屏':'全屏'}}" );
        result.Append( "</button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试全屏包装 - 不设置外层容器样式类名
    /// </summary>
    [Fact]
    public void TestFullscreenPack_2() {
        _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
        _wrapper.SetContextAttribute( UiConst.FullscreenPack, false );
        var result = new StringBuilder();
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a,null,false)\" " );
        result.Append( "nz-button=\"\" x-button-extend=\"\">" );
        result.Append( "{{x_id.isFullscreen?'退出全屏':'全屏'}}" );
        result.Append( "</button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试全屏标题
    /// </summary>
    [Fact]
    public void TestFullscreenTitle() {
        _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
        _wrapper.SetContextAttribute( UiConst.FullscreenWrapClass, "b" );
        _wrapper.SetContextAttribute( UiConst.FullscreenPack, false );
        _wrapper.SetContextAttribute( UiConst.FullscreenTitle, "c" );
        var result = new StringBuilder();
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a,'b',false,'c')\" " );
        result.Append( "nz-button=\"\" x-button-extend=\"\">" );
        result.Append( "{{x_id.isFullscreen?'退出全屏':'全屏'}}" );
        result.Append( "</button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试全屏标题 - 全屏包装未设置
    /// </summary>
    [Fact]
    public void TestFullscreenTitle_2() {
        _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
        _wrapper.SetContextAttribute( UiConst.FullscreenWrapClass, "b" );
        _wrapper.SetContextAttribute( UiConst.FullscreenTitle, "c" );
        var result = new StringBuilder();
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a,'b',true,'c')\" " );
        result.Append( "nz-button=\"\" x-button-extend=\"\">" );
        result.Append( "{{x_id.isFullscreen?'退出全屏':'全屏'}}" );
        result.Append( "</button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试全屏标题 - 全屏包装和外层容器样式类名未设置
    /// </summary>
    [Fact]
    public void TestFullscreenTitle_3() {
        _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
        _wrapper.SetContextAttribute( UiConst.FullscreenTitle, "c" );
        var result = new StringBuilder();
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a,null,true,'c')\" " );
        result.Append( "nz-button=\"\" x-button-extend=\"\">" );
        result.Append( "{{x_id.isFullscreen?'退出全屏':'全屏'}}" );
        result.Append( "</button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }
}