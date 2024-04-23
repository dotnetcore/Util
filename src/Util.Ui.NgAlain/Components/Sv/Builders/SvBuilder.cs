using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgAlain.Enums;
using Util.Ui.NgZorro.Components.Buttons.Builders;
using Util.Ui.NgZorro.Components.Icons.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgAlain.Components.Sv.Builders;

/// <summary>
/// 查看列标签生成器
/// </summary>
public class SvBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 初始化查看列标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public SvBuilder( Config config ) : base( config, "sv" ) {
        _config = config;
    }

    /// <summary>
    /// 配置列跨度
    /// </summary>
    public SvBuilder Column() {
        AttributeIfNotEmpty( "[col]", _config.GetValue( UiConst.Column ) );
        return this;
    }

    /// <summary>
    /// 配置标签
    /// </summary>
    public SvBuilder Label() {
        SetLabel( _config.GetValue( UiConst.Label ) );
        AttributeIfNotEmpty( "[label]", _config.GetValue( AngularConst.BindLabel ) );
        return this;
    }

    /// <summary>
    /// 设置标签文本
    /// </summary>
    private void SetLabel( string value ) {
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            this.AttributeByI18n( "[label]", value );
            return;
        }
        AttributeIfNotEmpty( "label", value );
    }

    /// <summary>
    /// 配置单位
    /// </summary>
    public SvBuilder Unit() {
        AttributeIfNotEmpty( "unit", _config.GetValue( UiConst.Unit ) );
        AttributeIfNotEmpty( "[unit]", _config.GetValue( AngularConst.BindUnit ) );
        return this;
    }

    /// <summary>
    /// 配置显示默认文本
    /// </summary>
    public SvBuilder Default() {
        AttributeIfNotEmpty( "[default]", _config.GetValue( UiConst.Default ) );
        return this;
    }

    /// <summary>
    /// 配置类型
    /// </summary>
    public SvBuilder Type() {
        AttributeIfNotEmpty( "type", _config.GetValue<SvType?>( UiConst.Type )?.Description() );
        AttributeIfNotEmpty( "[type]", _config.GetValue( AngularConst.BindType ) );
        return this;
    }

    /// <summary>
    /// 配置标签可选信息
    /// </summary>
    public SvBuilder Optional() {
        AttributeIfNotEmpty( "optional", _config.GetValue( UiConst.Optional ) );
        AttributeIfNotEmpty( "[optional]", _config.GetValue( AngularConst.BindOptional ) );
        AttributeIfNotEmpty( "optionalHelp", _config.GetValue( UiConst.OptionalHelp ) );
        AttributeIfNotEmpty( "[optionalHelp]", _config.GetValue( AngularConst.BindOptionalHelp ) );
        AttributeIfNotEmpty( "optionalHelpColor", _config.GetValue( UiConst.OptionalHelpColor ) );
        AttributeIfNotEmpty( "[optionalHelpColor]", _config.GetValue( AngularConst.BindOptionalHelpColor ) );
        return this;
    }

    /// <summary>
    /// 配置冒号
    /// </summary>
    public SvBuilder NoColon() {
        AttributeIfNotEmpty( "[noColon]", _config.GetValue( UiConst.NoColon ) );
        return this;
    }

    /// <summary>
    /// 配置是否隐藏标签
    /// </summary>
    public SvBuilder HideLabel() {
        AttributeIfNotEmpty( "[hideLabel]", _config.GetValue( UiConst.HideLabel ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Column().Label().Unit().Default().Type()
            .Optional().NoColon().HideLabel();
    }

    /// <summary>
    /// 配置内容
    /// </summary>
    protected override void ConfigContent( Config config ) {
        if ( config.Content.IsEmpty() == false ) {
            config.Content.AppendTo( this );
            return;
        }
        ConfigValue();
        CopyToClipboard();
    }

    /// <summary>
    /// 配置值
    /// </summary>
    private void ConfigValue() {
        var dataType = _config.GetValue<DataType?>( UiConst.Type );
        var value = _config.GetValue( UiConst.Value );
        if ( value.IsEmpty() )
            return;
        if ( dataType == DataType.Bool ) {
            LoadBool( value );
            return;
        }
        if ( dataType == DataType.Date ) {
            LoadDate( value );
            return;
        }
        if ( dataType == DataType.Number ) {
            LoadNumber( value );
            return;
        }
        SetContent( "{{" + GetValue( value ) + "}}" );
    }

    /// <summary>
    /// 加载布尔值
    /// </summary>
    protected void LoadBool( string value ) {
        AppendContent( new IconBuilder( _config ).Type( AntDesignIcon.Check.Description() ).Attribute( "*ngIf", $"{value}" ) );
        AppendContent( new IconBuilder( _config ).Type( AntDesignIcon.Close.Description() ).Attribute( "*ngIf", $"!({value})" ) );
    }

    /// <summary>
    /// 加载日期值
    /// </summary>
    protected void LoadDate( string value ) {
        var format = _config.GetValue( UiConst.DateFormat );
        if ( format.IsEmpty() )
            format = "yyyy-MM-dd HH:mm:ss";
        SetContent( $"{{{{{value}|date:\"{format}\"}}}}" );
    }

    /// <summary>
    /// 加载数值
    /// </summary>
    protected void LoadNumber( string value ) {
        SetContent( "{{" + value + "}}" );
    }

    /// <summary>
    /// 获取值
    /// </summary>
    private string GetValue( string value ) {
        var enabledI18n = _config.GetValue<bool>( UiConst.ValueI18n );
        if ( enabledI18n )
            return $"{value}|i18n";
        return value;
    }

    /// <summary>
    /// 配置复制到剪贴板
    /// </summary>
    private void CopyToClipboard() {
        if ( _config.GetValue<bool?>( UiConst.Clipboard ) != true )
            return;
        var value = _config.GetValue( UiConst.Value );
        if ( value.IsEmpty() )
            return;
        _config.SetAttribute( UiConst.CopyToClipboard, value );
        var buttonBuilder = new ButtonBuilder( _config );
        buttonBuilder.Attribute( "nz-button" );
        buttonBuilder.NgIf( value );
        buttonBuilder.CopyToClipboard().Type().Icon();
        AppendContent( buttonBuilder );
    }
}