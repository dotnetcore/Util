using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.ColorPickers.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.ColorPickers.Renders;

/// <summary>
/// 颜色块渲染器
/// </summary>
public class ColorBlockRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化颜色块渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public ColorBlockRender( Config config ){
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new ColorBlockBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new ColorBlockRender( _config.Copy() );
    }
}