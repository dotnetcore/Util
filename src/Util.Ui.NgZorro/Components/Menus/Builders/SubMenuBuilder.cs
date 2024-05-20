using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Menus.Builders; 

/// <summary>
/// 子菜单标签生成器
/// </summary>
public class SubMenuBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化子菜单标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public SubMenuBuilder( Config config ) : base( config,"li" ) {
        _config = config;
        base.Attribute( "nz-submenu" );
    }

    /// <summary>
    /// 配置标题
    /// </summary>
    public SubMenuBuilder Title() {
        SetTitle( _config.GetValue( UiConst.Title ) );
        AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
        return this;
    }

    /// <summary>
    /// 设置标题
    /// </summary>
    private void SetTitle( string value ) {
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            this.AttributeByI18n( "[nzTitle]", value );
            return;
        }
        AttributeIfNotEmpty( "nzTitle", value );
    }

    /// <summary>
    /// 配置禁用
    /// </summary>
    public SubMenuBuilder Disabled() {
        AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( UiConst.Disabled ) );
        return this;
    }

    /// <summary>
    /// 配置图标
    /// </summary>
    public SubMenuBuilder Icon() {
        AttributeIfNotEmpty( "nzIcon", _config.GetValue<AntDesignIcon?>( UiConst.Icon )?.Description() );
        AttributeIfNotEmpty( "[nzIcon]", _config.GetValue( AngularConst.BindIcon ) );
        return this;
    }

    /// <summary>
    /// 配置展开
    /// </summary>
    public SubMenuBuilder Open() {
        AttributeIfNotEmpty( "[nzOpen]", _config.GetValue( UiConst.Open ) );
        AttributeIfNotEmpty( "[(nzOpen)]", _config.GetValue( AngularConst.BindonOpen ) );
        return this;
    }

    /// <summary>
    /// 配置自定义子菜单容器类名
    /// </summary>
    public SubMenuBuilder MenuClassName() {
        AttributeIfNotEmpty( "nzMenuClassName", _config.GetValue( UiConst.MenuClassName ) );
        AttributeIfNotEmpty( "[nzMenuClassName]", _config.GetValue( AngularConst.BindMenuClassName ) );
        return this;
    }

    /// <summary>
    /// 配置菜单弹出位置
    /// </summary>
    public SubMenuBuilder Placement() {
        AttributeIfNotEmpty( "nzPlacement", _config.GetValue<DropdownMenuPlacement?>( UiConst.Placement )?.Description() );
        AttributeIfNotEmpty( "[nzPlacement]", _config.GetValue( AngularConst.BindPlacement ) );
        return this;
    }

    /// <summary>
    /// 配置左内边距
    /// </summary>
    public SubMenuBuilder PaddingLeft() {
        AttributeIfNotEmpty( "[nzPaddingLeft]", _config.GetValue( UiConst.PaddingLeft ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public SubMenuBuilder Events() {
        AttributeIfNotEmpty( "(nzOpenChange)", _config.GetValue( UiConst.OnOpenChange ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Title().Disabled().Icon().Open().MenuClassName().Placement().PaddingLeft()
            .Events();
    }

    /// <summary>
    /// 配置内容元素
    /// </summary>
    protected override void ConfigContent( Config config ) {
        var ulBuilder = new UlBuilder();
        SetContent( ulBuilder );
        config.Content.AppendTo( ulBuilder );
    }
}