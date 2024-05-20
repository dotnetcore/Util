using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Results.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Results.Renders; 

/// <summary>
/// 结果图标渲染器
/// </summary>
public class ResultIconRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化结果图标渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public ResultIconRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new ResultIconBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new ResultIconRender( _config.Copy() );
    }
}