using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Ellipsis.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.Ellipsis.Renders;

/// <summary>
/// 文本省略渲染器
/// </summary>
public class EllipsisRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化文本省略渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public EllipsisRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new EllipsisBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new EllipsisBuilder( _config.Copy() );
    }
}