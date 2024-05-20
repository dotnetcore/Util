using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Containers.Builders;
using Util.Ui.NgZorro.Components.Inputs.Builders;
using Util.Ui.NgZorro.Components.Inputs.Configs;

namespace Util.Ui.NgZorro.Components.Inputs.Renders;

/// <summary>
/// 输入框组合渲染器
/// </summary>
public class InputGroupRender : FormControlRenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化输入框组合渲染器
    /// </summary>
    /// <param name="config">配置</param>
    public InputGroupRender( Config config ) : base( config ) {
        _config = config;
    }

    /// <summary>
    /// 添加表单控件
    /// </summary>
    protected override void AppendControl( TagBuilder formControlBuilder ) {
        var container = GetContainerBuilder();
        var builder = new InputGroupBuilder( _config );
        builder.Config();
        _config.Content.AppendTo( builder );
        container.AppendContent( builder );
        formControlBuilder.AppendContent( container );
    }

    /// <summary>
    /// 获取容器生成器
    /// </summary>
    public TagBuilder GetContainerBuilder() {
        TagBuilder container = new EmptyContainerTagBuilder();
        var ngIf = _config.GetValue( AngularConst.NgIf );
        var shareConfig = GetInputGroupShareConfig();
        if ( ngIf.IsEmpty() )
            ngIf = shareConfig.NgIf;
        if ( ngIf.IsEmpty() )
            return container;
        _config.RemoveAttribute( AngularConst.NgIf );
        container = new ContainerBuilder( _config );
        container.NgIf( ngIf );
        return container;
    }

    /// <summary>
    /// 获取输入框组合共享配置
    /// </summary>
    private InputGroupShareConfig GetInputGroupShareConfig() {
        return _config.GetValueFromItems<InputGroupShareConfig>() ?? new InputGroupShareConfig();
    }

    /// <summary>
    /// 是否添加验证模板
    /// </summary>
    protected override bool IsAppendValidationTempalte() {
        return false;
    }

    /// <inheritdoc />
    public override IHtmlContent Clone() {
        return new InputGroupRender( _config.Copy() );
    }
}