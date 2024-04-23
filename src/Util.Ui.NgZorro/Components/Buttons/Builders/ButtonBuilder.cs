using Util.Ui.Angular.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Directives.Tooltips;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Buttons.Builders; 

/// <summary>
/// 按钮标签生成器
/// </summary>
public class ButtonBuilder : ButtonBuilderBase<ButtonBuilder> {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化按钮标签生成器
    /// </summary>
    public ButtonBuilder( Config config ) : base( config,"button" ) {
        _config = config;
    }

    /// <summary>
    /// 设置提交按钮类型
    /// </summary>
    public ButtonBuilder IsSubmit() {
        AttributeIf( "type", "submit",_config.GetValue<bool?>( UiConst.IsSubmit ) == true,true );
        return this;
    }

    /// <summary>
    /// 设置按钮类型
    /// </summary>
    public ButtonBuilder ButtonType() {
        var formShareConfig = _config.GetValueFromItems<FormShareConfig>();
        if ( formShareConfig != null )
            Attribute( "type", "button" );
        return this;
    }

    /// <summary>
    /// 配置复制到剪贴板
    /// </summary>
    public ButtonBuilder CopyToClipboard() {
        var value = _config.GetValue( UiConst.CopyToClipboard );
        if( value.IsEmpty() )
            return this;
        EnableExtend();
        _config.SetAttribute( UiConst.Type, Util.Ui.NgZorro.Enums.ButtonType.Text );
        _config.SetAttribute( UiConst.Icon,AntDesignIcon.Copy );
        this.OnClick($"{GetButtonExtendId()}.copyToClipboard({value})");
        var options = NgZorroOptionsService.GetOptions();
        if( options.EnableI18n ) {
            this.BindTooltipTitle( $"'{I18nKeys.CopyToClipboard}'|i18n" );
            return this;
        }
        this.TooltipTitle( "复制到剪贴板" );
        return this;
    }

    /// <summary>
    /// 配置全屏
    /// </summary>
    public ButtonBuilder Fullscreen() {
        var value = _config.GetValue( UiConst.Fullscreen );
        if ( value.IsEmpty() )
            return this;
        this.OnClick( $"{GetButtonExtendId()}.fullscreen({value}{GetFullscreenWrapClass()}{GetFullscreenPack()}{GetFullscreenTitle()})" );
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            AppendContent( "{{" + $"({GetButtonExtendId()}.isFullscreen?'{I18nKeys.FullscreenExit}':'{I18nKeys.Fullscreen}')|i18n" + "}}" );
            return this;
        }
        AppendContent( "{{"+ $"{GetButtonExtendId()}.isFullscreen?'退出全屏':'全屏'" + "}}" );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        CopyToClipboard();
        Fullscreen();
        ConfigButton();
        base.Config();
        IsSubmit().ButtonType();
    }

    /// <summary>
    /// 是否启用扩展
    /// </summary>
    protected override bool IsEnableExtend() {
        if ( base.IsEnableExtend() )
            return true;
        if ( IsCopyToClipboard() )
            return true;
        return false;
    }

    /// <summary>
    /// 是否复制到剪贴板
    /// </summary>
    protected bool IsCopyToClipboard() {
        return _config.Contains( UiConst.CopyToClipboard );
    }
}