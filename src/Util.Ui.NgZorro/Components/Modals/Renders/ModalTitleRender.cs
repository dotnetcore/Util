using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Modals.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Modals.Renders;

/// <summary>
/// 对话框标题渲染器
/// </summary>
public class ModalTitleRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化对话框标题渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public ModalTitleRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new ModalTitleBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new ModalTitleRender( _config.Copy() );
    }
}