using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.HashCodes.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.HashCodes.Renders;

/// <summary>
/// 哈希码渲染器
/// </summary>
public class HashCodeRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化哈希码渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public HashCodeRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new HashCodeBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new HashCodeRender( _config.Copy() );
    }
}