using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sv.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.Sv.Renders;

/// <summary>
/// 查看标题渲染器
/// </summary>
public class SvTitleRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化查看标题渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public SvTitleRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new SvTitleBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new SvTitleRender( _config.Copy() );
    }
}