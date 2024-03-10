using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Segments.Builders;

namespace Util.Ui.NgZorro.Components.Segments.Renders;

/// <summary>
/// 分段控制器渲染器
/// </summary>
public class SegmentedRender : FormControlRenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化分段控制器渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public SegmentedRender( Config config ) : base( config ) {
        _config = config;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    protected override void Init() {
        SetControlId();
    }

    /// <summary>
    /// 添加表单控件
    /// </summary>
    protected override void AppendControl( TagBuilder formControlBuilder ) {
        var builder = new SegmentedBuilder( _config );
        builder.Config();
        formControlBuilder.AppendContent( builder );
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new SegmentedRender( _config.Copy() );
    }
}