using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Inputs.Configs;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Inputs.Builders;

/// <summary>
/// 输入框标签生成器
/// </summary>
public class InputBuilder : FormControlBuilderBase<InputBuilder> {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化输入框标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public InputBuilder( Config config ) : base( config, "input", Microsoft.AspNetCore.Mvc.Rendering.TagRenderMode.SelfClosing ) {
        base.Attribute( "nz-input" );
        _config = config;
    }

    /// <summary>
    /// 配置占位符
    /// </summary>
    public virtual InputBuilder Placeholder() {
        AttributeIfNotEmpty( "placeholder", _config.GetValue( UiConst.Placeholder ) );
        AttributeIfNotEmpty( "[placeholder]", _config.GetValue( AngularConst.BindPlaceholder ) );
        return this;
    }

    /// <summary>
    /// 配置禁用
    /// </summary>
    public InputBuilder Disabled() {
        AttributeIfNotEmpty( "[disabled]", _config.GetValue( UiConst.Disabled ) );
        return this;
    }

    /// <summary>
    /// 配置只读
    /// </summary>
    public InputBuilder Readonly() {
        AttributeIfNotEmpty( "[readOnly]", _config.GetValue( UiConst.Readonly ) );
        return this;
    }

    /// <summary>
    /// 配置输入框大小
    /// </summary>
    public InputBuilder Size() {
        SetSize();
        SetBindSize();
        return this;
    }

    /// <summary>
    /// 设置输入框大小
    /// </summary>
    private void SetSize() {
        var shareConfig = GetInputGroupShareConfig();
        if ( shareConfig.Size == null )
            return;
        if ( shareConfig.InputGroupCreated )
            return;
        AttributeIfNotEmpty( "nzSize", shareConfig.Size?.Description() );
    }

    /// <summary>
    /// 设置输入框大小
    /// </summary>
    private void SetBindSize() {
        var shareConfig = GetInputGroupShareConfig();
        if ( shareConfig.BindSize.IsEmpty() )
            return;
        if ( shareConfig.InputGroupCreated )
            return;
        AttributeIfNotEmpty( "[nzSize]", shareConfig.BindSize );
    }

    /// <summary>
    /// 配置校验状态
    /// </summary>
    public InputBuilder Status() {
        SetStatus();
        SetBindStatus();
        return this;
    }

    /// <summary>
    /// 设置校验状态
    /// </summary>
    private void SetStatus() {
        var shareConfig = GetInputGroupShareConfig();
        if ( shareConfig.Status == null )
            return;
        if ( shareConfig.InputGroupCreated )
            return;
        AttributeIfNotEmpty( "nzStatus", shareConfig.Status?.Description() );
    }

    /// <summary>
    /// 设置校验状态
    /// </summary>
    private void SetBindStatus() {
        var shareConfig = GetInputGroupShareConfig();
        if ( shareConfig.BindStatus.IsEmpty() )
            return;
        if ( shareConfig.InputGroupCreated )
            return;
        AttributeIfNotEmpty( "[nzStatus]", shareConfig.BindStatus );
    }

    /// <summary>
    /// 获取输入框组合共享配置
    /// </summary>
    private InputGroupShareConfig GetInputGroupShareConfig() {
        return _config.GetValueFromItems<InputGroupShareConfig>() ?? new InputGroupShareConfig();
    }

    /// <summary>
    /// 配置输入框类型
    /// </summary>
    public InputBuilder Type() {
        var type = _config.GetValue<InputType?>( UiConst.Type );
        if ( type == InputType.Password )
            return this;
        if ( type == InputType.Email ) {
            Attribute( "[email]", "true" );
        }
        AttributeIfNotEmpty( "type", type?.Description() );
        AttributeIfNotEmpty( "[type]", _config.GetValue( AngularConst.BindType ) );
        return this;
    }

    /// <summary>
    /// 配置自动完成
    /// </summary>
    public InputBuilder Autocomplete() {
        var autocompleteId = _config.GetValue( UiConst.Autocomplete );
        if ( autocompleteId.IsEmpty() )
            return this;
        AttributeIfNotEmpty( "[nzAutocomplete]", autocompleteId );
        var autocompleteSearchKeyword = _config.GetValue<bool?>( UiConst.AutocompleteSearchKeyword );
        if ( autocompleteSearchKeyword == true )
            OnInput( $"x_{autocompleteId}.search($event.target)" );
        return this;
    }

    /// <summary>
    /// 配置手机号验证
    /// </summary>
    public InputBuilder ValidatePhone() {
        AttributeIfNotEmpty( "[isInvalidPhone]", _config.GetValue( UiConst.IsInvalidPhone ) );
        return this;
    }

    /// <summary>
    /// 配置身份证验证
    /// </summary>
    public InputBuilder ValidateIdCard() {
        AttributeIfNotEmpty( "[isInvalidIdCard]", _config.GetValue( UiConst.IsInvalidIdCard ) );
        return this;
    }

    /// <summary>
    /// 配置必填项验证
    /// </summary>
    public override InputBuilder Required() {
        AttributeIfNotEmpty( "[x-required-extend]", _config.GetValue( UiConst.Required ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public InputBuilder Events() {
        OnInput( _config.GetValue( UiConst.OnInput ) );
        AttributeIfNotEmpty( "(blur)", _config.GetValue( UiConst.OnBlur ) );
        AttributeIfNotEmpty( "(keyup.enter)", _config.GetValue( UiConst.OnKeyupEnter ) );
        AttributeIfNotEmpty( "(keydown.enter)", _config.GetValue( UiConst.OnKeydownEnter ) );
        return this;
    }

    /// <summary>
    /// 输入事件
    /// </summary>
    public InputBuilder OnInput( string value ) {
        AttributeIfNotEmpty( "(input)", value );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.ConfigBase( _config );
        ConfigForm().Name().Placeholder().Disabled().Readonly()
            .Size().Status()
            .Type().Autocomplete()
            .ValidatePhone().ValidateIdCard()
            .Events();
    }

    /// <summary>
    /// 配置间距项
    /// </summary>
    public override InputBuilder SpaceItem() {
        if ( FormItemShareConfig.FormItemCreated )
            return this;
        var inputGroupShareConfig = GetInputGroupShareConfig();
        if ( inputGroupShareConfig.InputGroupCreated )
            return this;
        this.SpaceItem( FormItemShareConfig.SpaceItem );
        return this;
    }
}