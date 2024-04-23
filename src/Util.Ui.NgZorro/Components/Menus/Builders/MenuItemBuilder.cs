using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Extensions;
using Util.Ui.NgZorro.Components.Icons.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Menus.Builders; 

/// <summary>
/// 菜单项标签生成器
/// </summary>
public class MenuItemBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化菜单项标签生成器
    /// </summary>
    public MenuItemBuilder( Config config ) : base( config,"li" ) {
        _config = config;
        base.Attribute( "nz-menu-item" );
    }

    /// <summary>
    /// 配置Update文本
    /// </summary>
    public MenuItemBuilder TextUpdate() {
        var value = _config.GetValue<bool?>( UiConst.TextUpdate );
        if ( value != true )
            return this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Update );
            return this;
        }
        _config.SetAttribute( UiConst.Text, "Update" );
        return this;
    }

    /// <summary>
    /// 配置Delete文本
    /// </summary>
    public MenuItemBuilder TextDelete() {
        var value = _config.GetValue<bool?>( UiConst.TextDelete );
        if ( value != true )
            return this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Delete );
            return this;
        }
        _config.SetAttribute( UiConst.Text, "Delete" );
        return this;
    }

    /// <summary>
    /// 配置Detail文本
    /// </summary>
    public MenuItemBuilder TextDetail() {
        var value = _config.GetValue<bool?>( UiConst.TextDetail );
        if ( value != true )
            return this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Detail );
            return this;
        }
        _config.SetAttribute( UiConst.Text, "Detail" );
        return this;
    }

    /// <summary>
    /// 配置Enable文本
    /// </summary>
    public MenuItemBuilder TextEnable() {
        var value = _config.GetValue<bool?>( UiConst.TextEnable );
        if ( value != true )
            return this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Enable );
            return this;
        }
        _config.SetAttribute( UiConst.Text, "Enable" );
        return this;
    }

    /// <summary>
    /// 配置Disable文本
    /// </summary>
    public MenuItemBuilder TextDisable() {
        var value = _config.GetValue<bool?>( UiConst.TextDisable );
        if ( value != true )
            return this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Text, I18nKeys.Disable );
            return this;
        }
        _config.SetAttribute( UiConst.Text, "Disable" );
        return this;
    }

    /// <summary>
    /// 配置文本
    /// </summary>
    public MenuItemBuilder Text() {
        var options = NgZorroOptionsService.GetOptions();
        var text = _config.GetValue( UiConst.Text );
        if ( text.IsEmpty() )
            return this;
        if ( options.EnableI18n ) {
            this.AppendContentByI18n( text );
            return this;
        }
        AppendContent( text );
        return this;
    }

    /// <summary>
    /// 配置禁用
    /// </summary>
    public MenuItemBuilder Disabled() {
        AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( UiConst.Disabled ) );
        return this;
    }

    /// <summary>
    /// 配置选中
    /// </summary>
    public MenuItemBuilder Selected() {
        AttributeIfNotEmpty( "[nzSelected]", _config.GetValue( UiConst.Selected ) );
        return this;
    }

    /// <summary>
    /// 配置危险状态
    /// </summary>
    public MenuItemBuilder Danger() {
        AttributeIfNotEmpty( "[nzDanger]", _config.GetValue( UiConst.Danger ) );
        return this;
    }

    /// <summary>
    /// 配置匹配路由
    /// </summary>
    public MenuItemBuilder MatchRouter() {
        AttributeIfNotEmpty( "[nzMatchRouter]", _config.GetValue( UiConst.MatchRouter ) );
        AttributeIfNotEmpty( "[nzMatchRouterExact]", _config.GetValue( UiConst.MatchRouterExact ) );
        return this;
    }

    /// <summary>
    /// 配置图标
    /// </summary>
    public MenuItemBuilder Icon() {
        if ( _config.Contains( UiConst.Icon ) == false )
            return this;
        var iconBuilder = new IconBuilder( _config );
        iconBuilder.Class( "mr-sm" );
        iconBuilder.Icon();
        AppendContent( iconBuilder );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public MenuItemBuilder Events() {
        this.OnClick( _config );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Icon();
        TextUpdate().TextDelete().TextDetail().TextEnable().TextDisable().Text().
            Disabled().Selected().Danger().MatchRouter().Events();
    }
}