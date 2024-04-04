using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.QrCodes.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.QrCodes.Renders;

/// <summary>
/// 二维码渲染器
/// </summary>
public class QrCodeRender : RenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化二维码渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public QrCodeRender( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 获取标签生成器
    /// </summary>
    protected override TagBuilder GetTagBuilder() {
        var builder = new QrCodeBuilder( _config );
        builder.Config();
        return builder;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new QrCodeRender( _config.Copy() );
    }
}