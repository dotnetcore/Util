using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.BackTops.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.BackTops.Renders;

/// <summary>
/// 回到顶部渲染器
/// </summary>
public class BackTopRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化回到顶部渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public BackTopRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new BackTopBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new BackTopRender( _config.Copy() );
    }
}