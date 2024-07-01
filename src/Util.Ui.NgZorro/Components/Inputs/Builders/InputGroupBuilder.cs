using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Components.Inputs.Configs;
using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Icons.Builders;
using Util.Ui.NgZorro.Components.Templates.Builders;
using Util.Ui.NgZorro.Extensions;
using Util.Ui.NgZorro.Components.Forms.Configs;

namespace Util.Ui.NgZorro.Components.Inputs.Builders;

/// <summary>
/// 输入框组合标签生成器
/// </summary>
public class InputGroupBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 输入框组合共享配置
    /// </summary>
    private readonly InputGroupShareConfig _shareConfig;

    /// <summary>
    /// 初始化输入框组合标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public InputGroupBuilder( Config config ) : base( config, "nz-input-group" ) {
        _config = config;
        _shareConfig = GetInputGroupShareConfig();
    }

    /// <summary>
    /// 获取输入框组合共享配置
    /// </summary>
    private InputGroupShareConfig GetInputGroupShareConfig() {
        return _config.GetValueFromItems<InputGroupShareConfig>() ?? new InputGroupShareConfig();
    }

    /// <summary>
    /// 配置前置标签
    /// </summary>
    public InputGroupBuilder AddOnBefore() {
        AttributeIfNotEmpty( "nzAddOnBefore", _config.GetValue( UiConst.AddOnBefore ) );
        AttributeIfNotEmpty( "[nzAddOnBefore]", _config.GetValue( AngularConst.BindAddOnBefore ) );
        AttributeIfNotEmpty( "nzAddOnBefore", _shareConfig.AddOnBefore );
        AttributeIfNotEmpty( "[nzAddOnBefore]", _shareConfig.BindAddOnBefore );
        return this;
    }

    /// <summary>
    /// 配置后置标签
    /// </summary>
    public InputGroupBuilder AddOnAfter() {
        AttributeIfNotEmpty( "nzAddOnAfter", _config.GetValue( UiConst.AddOnAfter ) );
        AttributeIfNotEmpty( "[nzAddOnAfter]", _config.GetValue( AngularConst.BindAddOnAfter ) );
        AttributeIfNotEmpty( "nzAddOnAfter", _shareConfig.AddOnAfter );
        AttributeIfNotEmpty( "[nzAddOnAfter]", _shareConfig.BindAddOnAfter );
        return this;
    }

    /// <summary>
    /// 配置前置图标
    /// </summary>
    public InputGroupBuilder AddOnBeforeIcon() {
        AttributeIfNotEmpty( "nzAddOnBeforeIcon", _config.GetValue<AntDesignIcon?>( UiConst.AddOnBeforeIcon )?.Description() );
        AttributeIfNotEmpty( "[nzAddOnBeforeIcon]", _config.GetValue( AngularConst.BindAddOnBeforeIcon ) );
        AttributeIfNotEmpty( "nzAddOnBeforeIcon", _shareConfig.AddOnBeforeIcon?.Description() );
        AttributeIfNotEmpty( "[nzAddOnBeforeIcon]", _shareConfig.BindAddOnBeforeIcon );
        return this;
    }

    /// <summary>
    /// 配置后置图标
    /// </summary>
    public InputGroupBuilder AddOnAfterIcon() {
        AttributeIfNotEmpty( "nzAddOnAfterIcon", _config.GetValue<AntDesignIcon?>( UiConst.AddOnAfterIcon )?.Description() );
        AttributeIfNotEmpty( "[nzAddOnAfterIcon]", _config.GetValue( AngularConst.BindAddOnAfterIcon ) );
        AttributeIfNotEmpty( "nzAddOnAfterIcon", _shareConfig.AddOnAfterIcon?.Description() );
        AttributeIfNotEmpty( "[nzAddOnAfterIcon]", _shareConfig.BindAddOnAfterIcon );
        return this;
    }

    /// <summary>
    /// 配置前缀
    /// </summary>
    public InputGroupBuilder Prefix() {
        AttributeIfNotEmpty( "nzPrefix", _shareConfig.Prefix );
        AttributeIfNotEmpty( "[nzPrefix]", _shareConfig.BindPrefix );
        return this;
    }

    /// <summary>
    /// 配置后缀
    /// </summary>
    public InputGroupBuilder Suffix() {
        AttributeIfNotEmpty( "nzSuffix", _shareConfig.Suffix );
        AttributeIfNotEmpty( "[nzSuffix]", _shareConfig.BindSuffix );
        if (_shareConfig.Suffix.IsEmpty() == false || _shareConfig.BindSuffix.IsEmpty() == false )
            return this;
        if ( IsAllowClear() || IsPassword() )
            AttributeIfNotEmpty( "[nzSuffix]", GetSuffixTemplateId() );
        return this;
    }

    /// <summary>
    /// 是否允许清除
    /// </summary>
    private bool IsAllowClear() {
        return _shareConfig.AllowClear;
    }

    /// <summary>
    /// 是否密码类型
    /// </summary>
    private bool IsPassword() {
        return _shareConfig.IsPassword;
    }

    /// <summary>
    /// 获取后置图标模板标识
    /// </summary>
    protected string GetSuffixTemplateId() {
        return $"tmp_{_shareConfig.InputId}";
    }

    /// <summary>
    /// 配置前缀图标
    /// </summary>
    public InputGroupBuilder PrefixIcon() {
        AttributeIfNotEmpty( "nzPrefixIcon", _config.GetValue<AntDesignIcon?>( UiConst.PrefixIcon )?.Description() );
        AttributeIfNotEmpty( "[nzPrefixIcon]", _config.GetValue( AngularConst.BindPrefixIcon ) );
        AttributeIfNotEmpty( "nzPrefixIcon", _shareConfig.PrefixIcon?.Description() );
        AttributeIfNotEmpty( "[nzPrefixIcon]", _shareConfig.BindPrefixIcon );
        return this;
    }

    /// <summary>
    /// 配置后缀图标
    /// </summary>
    public InputGroupBuilder SuffixIcon() {
        AttributeIfNotEmpty( "nzSuffixIcon", _config.GetValue<AntDesignIcon?>( UiConst.SuffixIcon )?.Description() );
        AttributeIfNotEmpty( "[nzSuffixIcon]", _config.GetValue( AngularConst.BindSuffixIcon ) );
        AttributeIfNotEmpty( "nzSuffixIcon", _shareConfig.SuffixIcon?.Description() );
        AttributeIfNotEmpty( "[nzSuffixIcon]", _shareConfig.BindSuffixIcon );
        return this;
    }

    /// <summary>
    /// 配置搜索
    /// </summary>
    public InputGroupBuilder Search() {
        AttributeIfNotEmpty( "[nzSearch]", _config.GetValue( UiConst.Search ) );
        return this;
    }

    /// <summary>
    /// 配置输入框大小
    /// </summary>
    public InputGroupBuilder Size() {
        AttributeIfNotEmpty( "nzSize", _shareConfig.Size?.Description() );
        AttributeIfNotEmpty( "[nzSize]", _shareConfig.BindSize );
        return this;
    }

    /// <summary>
    /// 配置校验状态
    /// </summary>
    public InputGroupBuilder Status() {
        AttributeIfNotEmpty( "nzStatus", _shareConfig.Status?.Description() );
        AttributeIfNotEmpty( "[nzStatus]", _shareConfig.BindStatus );
        return this;
    }

    /// <summary>
    /// 配置紧凑模式
    /// </summary>
    public InputGroupBuilder Compact() {
        AttributeIfNotEmpty( "[nzCompact]", _config.GetValue( UiConst.Compact ) );
        return this;
    }

    /// <summary>
    /// 配置间距项
    /// </summary>
    public InputGroupBuilder SpaceItem() {
        var formItemShareConfig = GetShareConfig();
        if ( formItemShareConfig.FormItemCreated )
            return this;
        this.SpaceItem( formItemShareConfig.SpaceItem );
        return this;
    }

    /// <summary>
    /// 获取表单项共享配置
    /// </summary>
    private FormItemShareConfig GetShareConfig() {
        return _config.GetValueFromItems<FormItemShareConfig>() ?? new FormItemShareConfig();
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.ConfigBase( _config );
        AddOnBefore().AddOnAfter().AddOnBeforeIcon().AddOnAfterIcon()
            .Prefix().Suffix().PrefixIcon().SuffixIcon()
            .Search().Size().Status().Compact().SpaceItem();
        Class( _shareConfig.Class );
        AppendContent( GetSuffixTemplate() );
    }

    /// <summary>
    /// 获取后置图标模板
    /// </summary>
    private TagBuilder GetSuffixTemplate() {
        if ( NeedCreateSuffixTemplate() == false )
            return new EmptyTagBuilder();
        var templateBuilder = new TemplateBuilder( _config );
        templateBuilder.Id( GetSuffixTemplateId() );
        templateBuilder.AppendContent( GetPasswordIconBuilder() );
        templateBuilder.AppendContent( GetClearIconBuilder() );
        return templateBuilder;
    }

    /// <summary>
    /// 是否需要创建后置图标模板
    /// </summary>
    private bool NeedCreateSuffixTemplate() {
        if ( _config.GetValue( UiConst.Suffix ).IsEmpty() == false )
            return false;
        if ( _config.GetValue( AngularConst.BindSuffix ).IsEmpty() == false )
            return false;
        if ( _shareConfig.Suffix.IsEmpty() == false )
            return false;
        if ( _shareConfig.BindSuffix.IsEmpty() == false )
            return false;
        return IsAllowClear() || IsPassword();
    }

    /// <summary>
    /// 获取密码图标标签生成器
    /// </summary>
    private TagBuilder GetPasswordIconBuilder() {
        if ( IsPassword() == false )
            return new EmptyTagBuilder();
        var builder = new IconBuilder( _config );
        builder.BindType( $"xi_{_shareConfig.InputId}.passwordVisible?'eye-invisible':'eye'" );
        builder.OnClick( $"xi_{_shareConfig.InputId}.passwordVisible = !xi_{_shareConfig.InputId}.passwordVisible" );
        return builder;
    }

    /// <summary>
    /// 获取清除图标标签生成器
    /// </summary>
    private TagBuilder GetClearIconBuilder() {
        if ( IsAllowClear() == false )
            return new EmptyTagBuilder();
        var builder = new IconBuilder( _config );
        builder.Class( "ant-input-clear-icon" );
        builder.Theme( IconTheme.Fill ).Type( AntDesignIcon.CloseCircle );
        builder.NgIf( $"{GetNgModelId()}.value" );
        SetClearIconReset( builder );
        return builder;
    }

    /// <summary>
    /// 设置清除操作
    /// </summary>
    private void SetClearIconReset( IconBuilder builder ) {
        var shareConfig = GetFormItemShareConfig();
        if ( shareConfig.IsValidationExtend == false ) {
            builder.OnClick( $"{GetNgModelId()}.reset()" );
            return;
        }
        builder.OnClick( $"{shareConfig.ValidationExtendId}.reset()" );
    }

    /// <summary>
    /// 获取表单项共享配置
    /// </summary>
    private FormItemShareConfig GetFormItemShareConfig() {
        return _config.GetValueFromItems<FormItemShareConfig>() ?? new FormItemShareConfig();
    }

    /// <summary>
    /// 获取ngModel引用变量名称
    /// </summary>
    protected string GetNgModelId() {
        return $"model_{_shareConfig.InputId}";
    }
}