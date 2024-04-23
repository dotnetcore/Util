using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.FooterToolbars.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.FooterToolbars.Renders;

/// <summary>
/// 底部工具栏渲染器
/// </summary>
public class FooterToolbarRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化底部工具栏渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public FooterToolbarRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new FooterToolbarBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new FooterToolbarRender( _config.CopyRemoveAttributes() );
    }
}