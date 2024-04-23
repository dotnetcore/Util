using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Drawers.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Drawers.Renders;

/// <summary>
/// 抽屉页脚渲染器
/// </summary>
public class DrawerFooterRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化抽屉页脚渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public DrawerFooterRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new DrawerFooterBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new DrawerFooterRender( _config.Copy() );
    }
}