using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders; 

/// <summary>
/// 列表项标签生成器
/// </summary>
public class ListItemBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化列表项标签生成器
    /// </summary>
    public ListItemBuilder( Config config ) : base( config,"nz-list-item" ) {
        _config = config;
    }

    /// <summary>
    /// 配置列表项操作
    /// </summary>
    public ListItemBuilder Actions() {
        AttributeIfNotEmpty( "[nzActions]", _config.GetValue( UiConst.Actions ) );
        return this;
    }

    /// <summary>
    /// 配置列表项内容
    /// </summary>
    public ListItemBuilder Content() {
        AttributeIfNotEmpty( "nzContent", _config.GetValue( UiConst.Content ) );
        AttributeIfNotEmpty( "[nzContent]", _config.GetValue( AngularConst.BindContent ) );
        return this;
    }

    /// <summary>
    /// 配置列表项扩展
    /// </summary>
    public ListItemBuilder Extra() {
        AttributeIfNotEmpty( "[nzExtra]", _config.GetValue( UiConst.Extra ) );
        return this;
    }

    /// <summary>
    /// 配置是否非flex布局
    /// </summary>
    public ListItemBuilder NoFlex() {
        AttributeIfNotEmpty( "[nzNoFlex]", _config.GetValue( UiConst.NoFlex ) );
        return this;
    }

    /// <summary>
    /// 配置虚拟滚动循环
    /// </summary>
    public ListItemBuilder VirtualFor() {
        AttributeIfNotEmpty( "*cdkVirtualFor", _config.GetValue( UiConst.VirtualFor ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Actions().Content().Extra().NoFlex().VirtualFor();
    }
}