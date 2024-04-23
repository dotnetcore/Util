using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Flex.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Flex.Renders;

/// <summary>
/// 弹性布局栅格渲染器
/// </summary>
public class FlexRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化弹性布局栅格渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public FlexRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new FlexBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new FlexRender( _config.CopyRemoveAttributes() );
    }
}