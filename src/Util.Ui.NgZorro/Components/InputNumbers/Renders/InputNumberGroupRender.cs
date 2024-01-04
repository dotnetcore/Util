using Util.Ui.Builders;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.InputNumbers.Builders;

namespace Util.Ui.NgZorro.Components.InputNumbers.Renders;

/// <summary>
/// 数字输入框组合渲染器
/// </summary>
public class InputNumberGroupRender : FormControlRenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化数字输入框组合渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public InputNumberGroupRender( Config config ) : base( config ) {
        _config = config;
    }

    /// <summary>
    /// 添加表单控件
    /// </summary>
    protected override void AppendControl( TagBuilder formControlBuilder ) {
        var builder = new InputNumberGroupBuilder( _config );
        builder.Config();
        _config.Content.AppendTo( builder );
        formControlBuilder.AppendContent( builder );
    }

    /// <summary>
    /// 是否添加验证模板
    /// </summary>
    protected override bool IsAppendValidationTempalte() {
        return false;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new InputNumberGroupRender( _config.Copy() );
    }
}