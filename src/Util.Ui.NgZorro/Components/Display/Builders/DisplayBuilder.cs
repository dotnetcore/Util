using Util.Ui.Angular.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Buttons.Builders;
using Util.Ui.NgZorro.Components.Typographies.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Display.Builders;

/// <summary>
/// 数据项展示标签生成器
/// </summary>
public class DisplayBuilder : FormControlBuilderBase<DisplayBuilder> {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化数据项展示标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public DisplayBuilder( Config config ) : base( config, "span" ) {
        _config = config;
    }

    /// <summary>
    /// 配置值
    /// </summary>
    public DisplayBuilder Value() {
        var dataType = _config.GetValue<DataType?>( UiConst.Type );
        var value = _config.GetValue( UiConst.Value );
        if ( value.IsEmpty() )
            return this;
        if ( dataType == DataType.Bool ) {
            LoadBool( value );
            return this;
        }
        if ( dataType == DataType.Date ) {
            LoadDate( value );
            return this;
        }
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n )
            SetContent( "{{" + $"{value}|i18n" + "}}" );
        else
            SetContent( "{{" + value + "}}" );
        return this;
    }

    /// <summary>
    /// 加载布尔值
    /// </summary>
    protected void LoadBool( string value ) {
        var options = NgZorroOptionsService.GetOptions();
        var result = new StringBuilder();
        result.Append( "{{" );
        if ( options.EnableI18n )
            result.Append( $"({value}?'{I18nKeys.Yes}':'{I18nKeys.No}')|i18n" );
        else
            result.Append( $"{value}?'是':'否'" );
        result.Append( "}}" );
        SetContent( result.ToString() );
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
    /// 配置显示标签
    /// </summary>
    public DisplayBuilder ShowLabel() {
        var showLabel = _config.GetValue<bool?>( UiConst.ShowLabel );
        if ( showLabel != true )
            return this;
        var title = _config.GetValue( UiConst.Title );
        return SetLabel( title );
    }

    /// <summary>
    /// 配置标签
    /// </summary>
    private DisplayBuilder SetLabel( string value ) {
        if ( value.IsEmpty() )
            return this;
        var options = NgZorroOptionsService.GetOptions();
        var labelBuilder = new SpanBuilder( _config );
        labelBuilder.Class( "mr-sm" );
        if ( options.EnableI18n ) {
            labelBuilder.AppendContentByI18n( value );
        } else {
            labelBuilder.AppendContent( value );
        }
        labelBuilder.AppendContent( ":" );
        PreBuilder = labelBuilder;
        return this;
    }

    /// <inheritdoc />
    public override void Config() {
        base.Config();
        Value().ShowLabel();
        CopyToClipboard();
    }

    /// <summary>
    /// 配置复制到剪贴板
    /// </summary>
    public void CopyToClipboard() {
        if ( _config.GetValue<bool?>( UiConst.Clipboard ) != true )
            return;
        var value = _config.GetValue( UiConst.Value );
        _config.SetAttribute( UiConst.CopyToClipboard, value );
        var buttonBuilder = new ButtonBuilder( _config );
        buttonBuilder.Attribute( "nz-button" );
        buttonBuilder.NgIf( value );
        buttonBuilder.CopyToClipboard().Type().Icon();
        PostBuilder = buttonBuilder;
    }
}