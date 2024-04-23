using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Components.Base;

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
        AttributeIfNotEmpty( "nzSize", _config.GetValue<InputSize?>( UiConst.Size )?.Description() );
        AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
        return this;
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
            OnInput($"x_{autocompleteId}.search($event.target.value)" );
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
        OnEnter( _config.GetValue( UiConst.OnEnter ) );
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
    /// 回车事件
    /// </summary>
    public InputBuilder OnEnter( string value ) {
        AttributeIfNotEmpty( "(keyup.enter)", value );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.ConfigBase( _config );
        ConfigForm().Name().Placeholder().Disabled().Readonly().Size()
            .Type().Autocomplete()
            .ValidatePhone().ValidateIdCard()
            .Events().AutocompleteOff();
    }
}