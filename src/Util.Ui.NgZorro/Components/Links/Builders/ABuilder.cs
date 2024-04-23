using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Enums;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Icons.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Directives.Tooltips;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Links.Builders;

/// <summary>
/// a标签生成器
/// </summary>
public class ABuilder : ButtonBuilderBase<ABuilder> {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化a标签生成器
    /// </summary>
    public ABuilder( Config config ) : base( config, "a" ) {
        _config = config;
    }

    /// <summary>
    /// 配置链接地址
    /// </summary>
    public ABuilder Href() {
        AttributeIfNotEmpty( "href", _config.GetValue( UiConst.Href ) );
        AttributeIfNotEmpty( "[href]", _config.GetValue( AngularConst.BindHref ) );
        return this;
    }

    /// <summary>
    /// 配置链接打开目标
    /// </summary>
    public ABuilder Target() {
        AttributeIfNotEmpty( "target", _config.GetValue<ATarget?>( UiConst.Target )?.Description() );
        AttributeIfNotEmpty( "[target]", _config.GetValue( AngularConst.BindTarget ) );
        return this;
    }

    /// <summary>
    /// 配置链接关系
    /// </summary>
    public ABuilder Rel() {
        AttributeIfNotEmpty( "rel", _config.GetValue( UiConst.Rel ) );
        AttributeIfNotEmpty( "[rel]", _config.GetValue( AngularConst.BindRel ) );
        return this;
    }

    /// <summary>
    /// 配置危险按钮
    /// </summary>
    public override ABuilder Danger() {
        var result = _config.GetValue<bool?>( UiConst.Danger );
        if ( result == true ) {
            Class( "ant-btn-dangerous" );
        }
        return this;
    }

    /// <summary>
    /// 配置查询表单链接
    /// </summary>
    public ABuilder IsSearch() {
        var isSearch = _config.GetValue<bool?>( UiConst.IsSearch );
        if ( isSearch != true )
            return this;
        this.OnClick( "expand=!expand" );
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n )
            AppendContent( "{{" + $"expand?('{I18nKeys.Collapse}'|i18n):('{I18nKeys.Expand}'|i18n)" + "}}" );
        else
            AppendContent( "{{expand?'收起':'展开'}}" );
        var icon = new IconBuilder( _config );
        icon.BindType( "expand?'up':'down'" );
        AppendContent( icon );
        return this;
    }

    /// <summary>
    /// 配置显示表格设置
    /// </summary>
    public ABuilder ShowTableSettings() {
        var tableId = _config.GetValue( UiConst.ShowTableSettings );
        if ( tableId.IsEmpty() )
            return this;
        this.OnClick( $"ts_{tableId}.show()" );
        Class( "card-tool-icon-btn" );
        var options = NgZorroOptionsService.GetOptions();
        this.TooltipTitle( options.EnableI18n ? "util.tableSettings" : "表格设置" );
        var icon = new IconBuilder( _config );
        icon.Type( AntDesignIcon.Setting );
        AppendContent( icon );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        ConfigButton().Href().Target().Rel().RouterLink().DropdownMenu()
            .DropdownMenuPlacement().IsSearch().ShowTableSettings();
        Fullscreen();
    }

    /// <summary>
    /// 配置全屏
    /// </summary>
    public ABuilder Fullscreen() {
        var value = _config.GetValue( UiConst.Fullscreen );
        if ( value.IsEmpty() )
            return this;
        this.OnClick( $"{GetButtonExtendId()}.fullscreen({value}{GetFullscreenWrapClass()}{GetFullscreenPack()}{GetFullscreenTitle()})" );
        Class( "card-tool-icon-btn" );
        AppendContent( GetFullscreenIcon() );
        AppendContent( GetFullscreenExitIcon() );
        var options = NgZorroOptionsService.GetOptions();
        if (options.EnableI18n) {
            this.BindTooltipTitle( $"({GetButtonExtendId()}.isFullscreen?'util.fullscreenExit':'util.fullscreen')|i18n" );
            return this;
        }
        this.BindTooltipTitle( $"{GetButtonExtendId()}.isFullscreen?'退出全屏':'全屏'" );
        return this;
    }

    /// <summary>
    /// 获取全屏图标
    /// </summary>
    private IconBuilder GetFullscreenIcon() {
        var icon = new IconBuilder( _config );
        icon.Theme( IconTheme.Outline );
        icon.Type( AntDesignIcon.Fullscreen );
        icon.NgIf( $"!{GetButtonExtendId()}.isFullscreen" );
        return icon;
    }

    /// <summary>
    /// 获取退出全屏图标
    /// </summary>
    private IconBuilder GetFullscreenExitIcon() {
        var icon = new IconBuilder( _config );
        icon.Theme( IconTheme.Outline );
        icon.Type( AntDesignIcon.FullscreenExit );
        icon.NgIf( $"{GetButtonExtendId()}.isFullscreen" );
        return icon;
    }
}