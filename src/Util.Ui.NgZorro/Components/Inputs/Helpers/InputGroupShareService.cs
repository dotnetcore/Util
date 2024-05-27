using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Components.Inputs.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Inputs.Helpers;

/// <summary>
/// 输入框组合共享服务
/// </summary>
public class InputGroupShareService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 输入框组合共享配置
    /// </summary>
    private InputGroupShareConfig _shareConfig;

    /// <summary>
    /// 初始化输入框组合共享服务
    /// </summary>
    /// <param name="config">配置</param>
    public InputGroupShareService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 设置nz-input-group已创建
    /// </summary>
    public void Created() {
        _shareConfig.InputGroupCreated = true;
    }

    /// <summary>
    /// 设置自动创建nz-input-group
    /// </summary>
    /// <param name="value">是否自动创建</param>
    public void AutoCreateInputGroup( bool value ) {
        if ( _shareConfig.AutoCreateInputGroup == false )
            return;
        _shareConfig.AutoCreateInputGroup = value;
    }

    /// <summary>
    /// 设置输入框标识
    /// </summary>
    /// <param name="id">输入框标识</param>
    public void SetInputId( string id ) {
        _shareConfig.InputId = id;
    }

    /// <summary>
    /// 设置样式类
    /// </summary>
    /// <param name="value">样式类</param>
    public void SetClass( string value ) {
        _shareConfig.Class = value;
    }

    /// <summary>
    /// 初始化输入框组合共享配置
    /// </summary>
    public void Init() {
        InitShareConfig();
        SetShareConfig();
        AutoCreateInputGroup();
        SetNgIf();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void InitShareConfig() {
        _shareConfig = GetShareConfig();
        _config.SetValueToItems( _shareConfig );
    }

    /// <summary>
    /// 获取共享配置
    /// </summary>
    private InputGroupShareConfig GetShareConfig() {
        return _config.GetValueFromItems<InputGroupShareConfig>() ?? new InputGroupShareConfig();
    }

    /// <summary>
    /// 设置共享配置
    /// </summary>
    private void SetShareConfig() {
        if ( _shareConfig.AddOnBefore.IsEmpty() )
            _shareConfig.AddOnBefore = _config.GetValue( UiConst.AddOnBefore );
        if ( _shareConfig.BindAddOnBefore.IsEmpty() )
            _shareConfig.BindAddOnBefore = _config.GetValue( AngularConst.BindAddOnBefore );
        if ( _shareConfig.AddOnAfter.IsEmpty() )
            _shareConfig.AddOnAfter = _config.GetValue( UiConst.AddOnAfter );
        if ( _shareConfig.BindAddOnAfter.IsEmpty() )
            _shareConfig.BindAddOnAfter = _config.GetValue( AngularConst.BindAddOnAfter );
        _shareConfig.AddOnBeforeIcon ??= _config.GetValue<AntDesignIcon?>( UiConst.AddOnBeforeIcon );
        if ( _shareConfig.BindAddOnBeforeIcon.IsEmpty() )
            _shareConfig.BindAddOnBeforeIcon = _config.GetValue( AngularConst.BindAddOnBeforeIcon );
        _shareConfig.AddOnAfterIcon ??= _config.GetValue<AntDesignIcon?>( UiConst.AddOnAfterIcon );
        if ( _shareConfig.BindAddOnAfterIcon.IsEmpty() )
            _shareConfig.BindAddOnAfterIcon = _config.GetValue( AngularConst.BindAddOnAfterIcon );
        if ( _shareConfig.Prefix.IsEmpty() )
            _shareConfig.Prefix = _config.GetValue( UiConst.Prefix );
        if ( _shareConfig.BindPrefix.IsEmpty() )
            _shareConfig.BindPrefix = _config.GetValue( AngularConst.BindPrefix );
        if ( _shareConfig.Suffix.IsEmpty() )
            _shareConfig.Suffix = _config.GetValue( UiConst.Suffix );
        if ( _shareConfig.BindSuffix.IsEmpty() )
            _shareConfig.BindSuffix = _config.GetValue( AngularConst.BindSuffix );
        _shareConfig.PrefixIcon ??= _config.GetValue<AntDesignIcon?>( UiConst.PrefixIcon );
        if ( _shareConfig.BindPrefixIcon.IsEmpty() )
            _shareConfig.BindPrefixIcon = _config.GetValue( AngularConst.BindPrefixIcon );
        _shareConfig.SuffixIcon ??= _config.GetValue<AntDesignIcon?>( UiConst.SuffixIcon );
        if ( _shareConfig.BindSuffixIcon.IsEmpty() )
            _shareConfig.BindSuffixIcon = _config.GetValue( AngularConst.BindSuffixIcon );
        _shareConfig.Size ??= _config.GetValue<InputSize?>( UiConst.Size );
        if ( _shareConfig.BindSize.IsEmpty() )
            _shareConfig.BindSize = _config.GetValue( AngularConst.BindSize );
        _shareConfig.Status ??= _config.GetValue<FormControlStatus?>( UiConst.Status );
        if ( _shareConfig.BindStatus.IsEmpty() )
            _shareConfig.BindStatus = _config.GetValue( AngularConst.BindStatus );
        _shareConfig.AllowClear = IsAllowClear();
        _shareConfig.IsPassword = IsPassword();
    }

    /// <summary>
    /// 是否允许清除
    /// </summary>
    private bool IsAllowClear() {
        if ( IsFormControl() )
            return false;
        if ( _config.GetValue( AngularConst.NgModel ).IsEmpty() )
            return false;
        var isAllowClear = _config.GetValue<bool?>( UiConst.AllowClear );
        if ( isAllowClear == null ) {
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableAllowClear )
                return true;
        }
        return isAllowClear.SafeValue();
    }

    /// <summary>
    /// 是否表单控件
    /// </summary>
    private bool IsFormControl() {
        if ( _config.GetValue( UiConst.FormControl ).IsEmpty() == false )
            return true;
        if ( _config.GetValue( UiConst.FormControlName ).IsEmpty() == false )
            return true;
        if ( _config.GetValue( AngularConst.BindFormControlName ).IsEmpty() == false )
            return true;
        return false;
    }

    /// <summary>
    /// 是否密码类型
    /// </summary>
    private bool IsPassword() {
        return _config.GetValue<InputType?>( UiConst.Type ) == InputType.Password;
    }

    /// <summary>
    /// 自动创建nz-input-group
    /// </summary>
    private void AutoCreateInputGroup() {
        if ( IsAutoCreateInputGroup() == false )
            return;
        AutoCreateInputGroup( true );
    }

    /// <summary>
    /// 是否自动创建nz-input-group
    /// </summary>
    private bool IsAutoCreateInputGroup() {
        if ( _shareConfig.AutoCreateInputGroup == false )
            return false;
        if ( string.IsNullOrWhiteSpace( _shareConfig.AddOnBefore ) == false )
            return true;
        if ( string.IsNullOrWhiteSpace( _shareConfig.BindAddOnBefore ) == false )
            return true;
        if ( string.IsNullOrWhiteSpace( _shareConfig.AddOnAfter ) == false )
            return true;
        if ( string.IsNullOrWhiteSpace( _shareConfig.BindAddOnAfter ) == false )
            return true;
        if ( _shareConfig.AddOnBeforeIcon != null )
            return true;
        if ( string.IsNullOrWhiteSpace( _shareConfig.BindAddOnBeforeIcon ) == false )
            return true;
        if ( _shareConfig.AddOnAfterIcon != null )
            return true;
        if ( string.IsNullOrWhiteSpace( _shareConfig.BindAddOnAfterIcon ) == false )
            return true;
        if ( string.IsNullOrWhiteSpace( _shareConfig.Prefix ) == false )
            return true;
        if ( string.IsNullOrWhiteSpace( _shareConfig.BindPrefix ) == false )
            return true;
        if ( string.IsNullOrWhiteSpace( _shareConfig.Suffix ) == false )
            return true;
        if ( string.IsNullOrWhiteSpace( _shareConfig.BindSuffix ) == false )
            return true;
        if ( _shareConfig.PrefixIcon != null )
            return true;
        if ( string.IsNullOrWhiteSpace( _shareConfig.BindPrefixIcon ) == false )
            return true;
        if ( _shareConfig.SuffixIcon != null )
            return true;
        if ( string.IsNullOrWhiteSpace( _shareConfig.BindSuffixIcon ) == false )
            return true;
        return false;
    }

    /// <summary>
    /// 设置ngIf*
    /// </summary>
    private void SetNgIf() {
        var value = _config.GetValueFromAttributes( AngularConst.NgIf );
        if ( value.IsEmpty() )
            return;
        if ( _shareConfig.AllowClear == false )
            return;
        _shareConfig.NgIf = value;
        _config.RemoveAttribute( AngularConst.NgIf );
    }
}