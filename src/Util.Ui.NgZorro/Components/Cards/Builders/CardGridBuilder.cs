using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Extensions;

namespace Util.Ui.NgZorro.Components.Cards.Builders; 

/// <summary>
/// 网格内嵌卡片标签生成器
/// </summary>
public class CardGridBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化网格内嵌卡片标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public CardGridBuilder( Config config ) : base( config,"div" ) {
        base.Attribute( "nz-card-grid" );
        _config = config;
    }

    /// <summary>
    /// 配置鼠标滑过时是否可浮起
    /// </summary>
    public CardGridBuilder Hoverable() {
        AttributeIfNotEmpty( "[nzHoverable]", _config.GetValue( UiConst.Hoverable ) );
        return this;
    }

    /// <summary>
    /// 配置单击事件
    /// </summary>
    public CardGridBuilder OnClick() {
        this.OnClick( _config );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Hoverable().OnClick();
    }
}