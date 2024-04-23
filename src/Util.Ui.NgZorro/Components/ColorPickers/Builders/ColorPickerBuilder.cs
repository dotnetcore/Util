using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.ColorPickers.Builders; 

/// <summary>
/// 颜色选择标签生成器
/// </summary>
public class ColorPickerBuilder : FormControlBuilderBase<ColorPickerBuilder> {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化颜色选择标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public ColorPickerBuilder( Config config ) : base( config, "nz-color-picker" ) {
        _config = config;
    }

    /// <summary>
    /// 配置标题
    /// </summary>
    public ColorPickerBuilder Title() {
        SetTitle( _config.GetValue( UiConst.Title ) );
        AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
        return this;
    }

    /// <summary>
    /// 设置表单标签文本
    /// </summary>
    private void SetTitle( string value ) {
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            this.AttributeByI18n( "[nzTitle]", value );
            return;
        }
        AttributeIfNotEmpty( "nzTitle", value );
    }

    /// <summary>
    /// 配置颜色默认值
    /// </summary>
    public ColorPickerBuilder DefaultValue() {
        AttributeIfNotEmpty( "nzDefaultValue", _config.GetValue( UiConst.DefaultValue ) );
        AttributeIfNotEmpty( "[nzDefaultValue]", _config.GetValue( AngularConst.BindDefaultValue ) );
        return this;
    }

    /// <summary>
    /// 配置颜色值
    /// </summary>
    public ColorPickerBuilder Value() {
        AttributeIfNotEmpty( "nzValue", _config.GetValue( UiConst.Value ) );
        AttributeIfNotEmpty( "[nzValue]", _config.GetValue( AngularConst.BindValue ) );
        return this;
    }

    /// <summary>
    /// 配置显示颜色文本
    /// </summary>
    public ColorPickerBuilder ShowText() {
        AttributeIfNotEmpty( "[nzShowText]", _config.GetValue( UiConst.ShowText ) );
        return this;
    }

    /// <summary>
    /// 配置控件尺寸
    /// </summary>
    public ColorPickerBuilder Size() {
        AttributeIfNotEmpty( "nzSize", _config.GetValue<InputSize?>( UiConst.Size )?.Description() );
        AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
        return this;
    }

    /// <summary>
    /// 配置禁用
    /// </summary>
    public ColorPickerBuilder Disabled() {
        AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( UiConst.Disabled ) );
        return this;
    }

    /// <summary>
    /// 配置禁用透明度
    /// </summary>
    public ColorPickerBuilder DisabledAlpha() {
        AttributeIfNotEmpty( "[nzDisabledAlpha]", _config.GetValue( UiConst.DisabledAlpha ) );
        return this;
    }

    /// <summary>
    /// 配置触发模式
    /// </summary>
    public ColorPickerBuilder Trigger() {
        AttributeIfNotEmpty( "nzTrigger", _config.GetValue<ColorPickerTrigger?>( UiConst.Trigger )?.Description() );
        AttributeIfNotEmpty( "[nzTrigger]", _config.GetValue( AngularConst.BindTrigger ) );
        return this;
    }

    /// <summary>
    /// 配置允许清除
    /// </summary>
    public ColorPickerBuilder AllowClear() {
        AttributeIfNotEmpty( "[nzAllowClear]", _config.GetValue( UiConst.AllowClear ) );
        return this;
    }

    /// <summary>
    /// 配置颜色格式
    /// </summary>
    public ColorPickerBuilder Format() {
        AttributeIfNotEmpty( "nzFormat", _config.GetValue<ColorPickerFormat?>( UiConst.Format )?.Description() );
        AttributeIfNotEmpty( "[nzFormat]", _config.GetValue( AngularConst.BindFormat ) );
        return this;
    }

    /// <summary>
    /// 配置显示弹出窗口
    /// </summary>
    public ColorPickerBuilder Open() {
        AttributeIfNotEmpty( "[nzOpen]", _config.GetValue( UiConst.Open ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public ColorPickerBuilder Events() {
        AttributeIfNotEmpty( "(nzOnChange)", _config.GetValue( UiConst.OnChange ) );
        AttributeIfNotEmpty( "(nzOnClear)", _config.GetValue( UiConst.OnClear ) );
        AttributeIfNotEmpty( "(nzOnFormatChange)", _config.GetValue( UiConst.OnFormatChange ) );
        AttributeIfNotEmpty( "(nzOnOpenChange)", _config.GetValue( UiConst.OnOpenChange ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.ConfigBase( _config );
        ConfigForm().Name().DefaultValue().Value()
            .Title().ShowText().Size().Disabled().DisabledAlpha()
            .Trigger().AllowClear().Format().Open()
            .Events();
    }
}