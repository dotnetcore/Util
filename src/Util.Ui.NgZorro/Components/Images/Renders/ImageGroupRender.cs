using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Images.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Images.Renders;

/// <summary>
/// 图片分组渲染器
/// </summary>
public class ImageGroupRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化图片分组渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public ImageGroupRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new ImageGroupBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new ImageGroupRender( _config.Copy() );
    }
}