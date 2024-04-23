using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sg.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.Sg.Renders;

/// <summary>
/// 简易栅格列渲染器
/// </summary>
public class SgRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化简易栅格列渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public SgRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new SgBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new SgRender( _config.Copy() );
    }
}