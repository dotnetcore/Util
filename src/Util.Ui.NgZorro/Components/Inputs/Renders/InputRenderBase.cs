using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Icons.Builders;
using Util.Ui.NgZorro.Components.Inputs.Builders;
using Util.Ui.NgZorro.Components.Inputs.Configs;
using Util.Ui.NgZorro.Components.Mentions.Configs;
using Util.Ui.NgZorro.Components.Templates.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;

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
    /// 获取后置图标模板标识
    /// </summary>
    protected string GetSuffixTemplateId() {
        return $"tmp_{GetId()}";
    }

    /// <summary>
    /// 获取ngModel引用变量名称
    /// </summary>
    protected string GetNgModelId() {
        return $"model_{GetId()}";
    }

    /// <summary>
    /// 添加表单控件
    /// </summary>
    protected override void AppendControl( TagBuilder formControlBuilder ) {
        var inputGroup = GetInputGroup();
        var input = GetInput();
        inputGroup.AppendContent( input );
        var suffixTemplate = GetSuffixTemplate();
        formControlBuilder.AppendContent( inputGroup ).AppendContent( suffixTemplate );
    }

    /// <summary>
    /// 初始化
    /// </summary>
    protected override void Init() {
        SetControlId();
        SetSuffixAttribute();
    }

    /// <summary>
    /// 设置后置图标模板属性
    /// </summary>
    protected void SetSuffixAttribute() {
        if( IsAllowClear() || IsPassword() )
            _config.SetAttribute( AngularConst.BindSuffix, GetSuffixTemplateId() );
    }

    /// <summary>
    /// 是否允许清除
    /// </summary>
    private bool IsAllowClear() {
        var isAllowClear = _config.GetValue<bool?>( UiConst.AllowClear );
        if ( isAllowClear == null ) {
            var options = NgZorroOptionsService.GetOptions();
            if( options.EnableAllowClear )
                return true;
        }
        return isAllowClear.SafeValue();
    }

    /// <summary>
    /// 是否密码类型
    /// </summary>
    private bool IsPassword() {
        return _config.GetValue<InputType?>( UiConst.Type ) == InputType.Password;
    }

    /// <summary>
    /// 获取输入框组合
    /// </summary>
    private TagBuilder GetInputGroup() {
        if( NeedCreateInputGroup() )
            return GetInputGroupBuilder();
        return new EmptyContainerTagBuilder();
    }

    /// <summary>
    /// 是否需要创建输入框组合
    /// </summary>
    protected virtual bool NeedCreateInputGroup() {
        var shareConfig = GetInputGroupShareConfig();
        if ( shareConfig.AutoCreateInputGroup == true )
            return true;
        if( IsAllowClear() )
            return true;
        if( IsPassword() )
            return true;
        return false;
    }

    /// <summary>
    /// 获取输入框组合共享配置
    /// </summary>
    private InputGroupShareConfig GetInputGroupShareConfig() {
        return _config.GetValueFromItems<InputGroupShareConfig>() ?? new InputGroupShareConfig();
    }

    /// <summary>
    /// 获取输入框组合标签生成器
    /// </summary>
    private TagBuilder GetInputGroupBuilder() {
        var builder = new InputGroupBuilder( _config.CopyRemoveAttributes() );
        builder.Config();
        builder.Class( GetInputGroupClass() );
        return builder;
    }

    /// <summary>
    /// 获取输入框组合的样式类
    /// </summary>
    protected virtual string GetInputGroupClass() {
        return null;
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
        builder.Attribute( "x-input-extend" );
        builder.Attribute( $"#xi_{GetId()}", "xInputExtend" );
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
        builder.Attribute( "[type]", $"xi_{GetId()}.passwordVisible?'text':'password'" );
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

    /// <summary>
    /// 获取后置图标模板
    /// </summary>
    private TagBuilder GetSuffixTemplate() {
        if( IsAllowClear() == false && IsPassword() == false )
            return new EmptyTagBuilder();
        var templateBuilder = new TemplateBuilder( _config );
        templateBuilder.Id( GetSuffixTemplateId() );
        templateBuilder.AppendContent( GetPasswordIconBuilder() );
        templateBuilder.AppendContent( GetClearIconBuilder() );
        return templateBuilder;
    }

    /// <summary>
    /// 获取密码图标标签生成器
    /// </summary>
    private TagBuilder GetPasswordIconBuilder() {
        if( IsPassword() == false )
            return new EmptyTagBuilder();
        var builder = new IconBuilder( _config );
        builder.BindType( $"xi_{GetId()}.passwordVisible?'eye-invisible':'eye'" );
        builder.OnClick( $"xi_{GetId()}.passwordVisible = !xi_{GetId()}.passwordVisible" );
        return builder;
    }

    /// <summary>
    /// 获取清除图标标签生成器
    /// </summary>
    private TagBuilder GetClearIconBuilder() {
        if ( IsAllowClear() == false )
            return new EmptyTagBuilder();
        var builder = new IconBuilder( _config );
        builder.Class( GetClearIconClass() );
        builder.Theme( IconTheme.Fill ).Type( AntDesignIcon.CloseCircle );
        builder.NgIf( $"{GetNgModelId()}.value" );
        builder.OnClick( $"{GetNgModelId()}.reset()" );
        return builder;
    }

    /// <summary>
    /// 获取清除图标的样式类
    /// </summary>
    protected virtual string GetClearIconClass() {
        return "ant-input-clear-icon";
    }
}