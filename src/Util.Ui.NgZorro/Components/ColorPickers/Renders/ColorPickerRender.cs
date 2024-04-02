using Util.Ui.Builders;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.ColorPickers.Builders;

namespace Util.Ui.NgZorro.Components.ColorPickers.Renders;

/// <summary>
/// 颜色选择渲染器
/// </summary>
public class ColorPickerRender : FormControlRenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化颜色选择渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public ColorPickerRender( Config config ) : base( config ) {
        _config = config;
    }

    /// <summary>
    /// 添加表单控件
    /// </summary>
    protected override void AppendControl( TagBuilder formControlBuilder ) {
        var builder = new ColorPickerBuilder( _config );
        builder.Config();
        _config.Content.AppendTo( builder );
        formControlBuilder.AppendContent( builder );
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new ColorPickerRender( _config.Copy() );
    }
}