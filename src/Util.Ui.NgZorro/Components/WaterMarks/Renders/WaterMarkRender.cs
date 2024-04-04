using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.WaterMarks.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.WaterMarks.Renders;

/// <summary>
/// 水印渲染器
/// </summary>
public class WaterMarkRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化水印渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public WaterMarkRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new WaterMarkBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new WaterMarkRender( _config.Copy() );
    }
}