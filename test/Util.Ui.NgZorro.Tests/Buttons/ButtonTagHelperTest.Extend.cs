using System.Text;
using Util.Ui.Configs;
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
        _wrapper.SetContextAttribute( UiConst.ValidateForm, true );
        _wrapper.SetContextAttribute( UiConst.OnClick, "test()" );
        var result = new StringBuilder();
        result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.validateForm();test()\" nz-button=\"\" x-button-extend=\"\"></button>" );
        Assert.Equal( result.ToString(), GetResult() );
    }

    /// <summary>
    /// 测试是否验证表单 - 指定按钮标识
    /// </summary>
    [Fact]
    public void TestValidateForm_2() {
        _wrapper.SetContextAttribute( UiConst.ValidateForm, true );
        _wrapper.SetContextAttribute( UiConst.Id, "a" );
        _wrapper.SetContextAttribute( UiConst.OnClick, "test()" );
        var result = new StringBuilder();
        result.Append( "<button #a=\"\" #x_a=\"xButtonExtend\" (click)=\"x_a.validateForm();test()\" nz-button=\"\" x-button-extend=\"\"></button>" );
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
}