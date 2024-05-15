using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Inputs.Builders;
using Util.Ui.NgZorro.Components.Inputs.Configs;
using Util.Ui.NgZorro.Components.Mentions.Configs;
using Util.Ui.NgZorro.Configs;

namespace Util.Ui.NgZorro.Components.Inputs.Renders;

/// <summary>
/// 输入框渲染器基类
/// </summary>
public abstract class InputRenderBase : FormControlRenderBase {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化输入框渲染器基类
    /// </summary>
    /// <param name="config">配置</param>
    protected InputRenderBase( Config config ) : base( config ) {
        _config = config;
    }

    /// <summary>
    /// 添加表单控件
    /// </summary>
    protected override void AppendControl( TagBuilder formControlBuilder ) {
        var inputGroup = GetInputGroup();
        var input = GetInput();
        inputGroup.AppendContent( input );
        formControlBuilder.AppendContent( inputGroup );
    }

    /// <summary>
    /// 初始化
    /// </summary>
    protected override void Init() {
        SetControlId();
    }

    /// <summary>
    /// 是否允许清除
    /// </summary>
    private bool IsAllowClear() {
        var shareConfig = GetInputGroupShareConfig();
        return shareConfig.AllowClear;
    }

    /// <summary>
    /// 获取输入框组合共享配置
    /// </summary>
    private InputGroupShareConfig GetInputGroupShareConfig() {
        return _config.GetValueFromItems<InputGroupShareConfig>() ?? new InputGroupShareConfig();
    }

    /// <summary>
    /// 是否密码类型
    /// </summary>
    private bool IsPassword() {
        var shareConfig = GetInputGroupShareConfig();
        return shareConfig.IsPassword;
    }

    /// <summary>
    /// 获取输入框组合
    /// </summary>
    private TagBuilder GetInputGroup() {
        if (NeedCreateInputGroup()) {
            var shareConfig = GetInputGroupShareConfig();
            shareConfig.IsInputGroupCreated = true;
            return GetInputGroupBuilder();
        }
        return new EmptyContainerTagBuilder();
    }

    /// <summary>
    /// 是否需要创建输入框组合
    /// </summary>
    protected virtual bool NeedCreateInputGroup() {
        var shareConfig = GetInputGroupShareConfig();
        if ( shareConfig.AutoCreateInputGroup == false )
            return false;
        if ( shareConfig.AutoCreateInputGroup == true )
            return true;
        if ( IsAllowClear() )
            return true;
        if( IsPassword() )
            return true;
        return false;
    }

    /// <summary>
    /// 获取输入框组合标签生成器
    /// </summary>
    private TagBuilder GetInputGroupBuilder() {
        var builder = new InputGroupBuilder( _config.CopyRemoveAttributes() );
        builder.Config();
        return builder;
    }

    /// <summary>
    /// 获取输入框
    /// </summary>
    private TagBuilder GetInput() {
        var builder = GetInputBuilder();
        ExportNgModel( builder );
        AddInputExtendDirective( builder );
        AddPasswordType( builder );
        ConfigMentionTrigger( builder );
        return builder;
    }

    /// <summary>
    /// 获取输入框标签生成器
    /// </summary>
    protected abstract TagBuilder GetInputBuilder();

    /// <summary>
    /// 导出ngModel
    /// </summary>
    public void ExportNgModel( TagBuilder builder ) {
        if ( NeedExportNgModel() == false )
            return;
        builder.Attribute( $"#{GetNgModelId()}", "ngModel" );
    }

    /// <summary>
    /// 获取ngModel引用变量名称
    /// </summary>
    protected string GetNgModelId() {
        var shareConfig = GetInputGroupShareConfig();
        return $"model_{shareConfig.InputId}";
    }

    /// <summary>
    /// 是否需要导出ngModel
    /// </summary>
    private bool NeedExportNgModel() {
        if( IsAllowClear() )
            return true;
        return false;
    }

    /// <summary>
    /// 添加输入框扩展指令
    /// </summary>
    private void AddInputExtendDirective( TagBuilder builder ) {
        if ( NeedAddInputExtendDirective() == false )
            return;
        var shareConfig = GetInputGroupShareConfig();
        builder.Attribute( "x-input-extend" );
        builder.Attribute( $"#xi_{shareConfig.InputId}", "xInputExtend" );
    }

    /// <summary>
    /// 是否需要添加输入框扩展指令
    /// </summary>
    private bool NeedAddInputExtendDirective() {
        if( IsPassword() )
            return true;
        return false;
    }

    /// <summary>
    /// 添加密码类型
    /// </summary>
    private void AddPasswordType( TagBuilder builder ) {
        if ( IsPassword() == false )
            return;
        var shareConfig = GetInputGroupShareConfig();
        builder.Attribute( "[type]", $"xi_{shareConfig.InputId}.passwordVisible?'text':'password'" );
    }

    /// <summary>
    /// 配置提及触发元素
    /// </summary>
    private void ConfigMentionTrigger( TagBuilder builder ) {
        var shareConfig = _config.GetValueFromItems<MentionShareConfig>();
        if( shareConfig == null )
            return;
        builder.Attribute( "nzMentionTrigger" );
    }
}