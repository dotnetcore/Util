using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Components.WaterMarks.Helpers;

namespace Util.Ui.NgZorro.Components.WaterMarks.Builders;

/// <summary>
/// 水印标签生成器
/// </summary>
public class WaterMarkBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化水印标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public WaterMarkBuilder( Config config ) : base( config, "nz-water-mark" ) {
        _config = config;
    }

    /// <summary>
    /// 配置水印文字内容
    /// </summary>
    public WaterMarkBuilder Content() {
        AttributeIfNotEmpty( "nzContent", _config.GetValue( UiConst.Content ) );
        AttributeIfNotEmpty( "[nzContent]", _config.GetValue( AngularConst.BindContent ) );
        return this;
    }

    /// <summary>
    /// 配置水印宽度
    /// </summary>
    public WaterMarkBuilder Width() {
        AttributeIfNotEmpty( "[nzWidth]", _config.GetValue( UiConst.Width ) );
        AttributeIfNotEmpty( "[nzWidth]", _config.GetValue( AngularConst.BindWidth ) );
        return this;
    }

    /// <summary>
    /// 配置水印高度
    /// </summary>
    public WaterMarkBuilder Height() {
        AttributeIfNotEmpty( "[nzHeight]", _config.GetValue( UiConst.Height ) );
        AttributeIfNotEmpty( "[nzHeight]", _config.GetValue( AngularConst.BindHeight ) );
        return this;
    }

    /// <summary>
    /// 配置旋转角度
    /// </summary>
    public WaterMarkBuilder Rotate() {
        AttributeIfNotEmpty( "[nzRotate]", _config.GetValue( UiConst.Rotate ) );
        AttributeIfNotEmpty( "[nzRotate]", _config.GetValue( AngularConst.BindRotate ) );
        return this;
    }

    /// <summary>
    /// 配置z-index
    /// </summary>
    public WaterMarkBuilder ZIndex() {
        AttributeIfNotEmpty( "[nzZIndex]", _config.GetValue( UiConst.ZIndex ) );
        AttributeIfNotEmpty( "[nzZIndex]", _config.GetValue( AngularConst.BindZIndex ) );
        return this;
    }

    /// <summary>
    /// 配置水印图片地址
    /// </summary>
    public WaterMarkBuilder Image() {
        AttributeIfNotEmpty( "nzImage", _config.GetValue( UiConst.Image ) );
        AttributeIfNotEmpty( "[nzImage]", _config.GetValue( AngularConst.BindImage ) );
        return this;
    }

    /// <summary>
    /// 配置文字样式
    /// </summary>
    public WaterMarkBuilder Font() {
        AttributeIfNotEmpty( "[nzFont]", GetFont() );
        return this;
    }

    /// <summary>
    /// 获取字体
    /// </summary>
    private string GetFont() {
        var result = _config.GetValue( UiConst.Font );
        if ( result.IsEmpty() == false )
            return result;
        var fontType = new FontType {
            Color = _config.GetValue( UiConst.FontColor ),
            FontSize = _config.GetValue<double?>( UiConst.FontSize ),
            FontWeight = _config.GetValue( UiConst.FontWeight ),
            FontFamily = _config.GetValue( UiConst.FontFamily ),
            FontStyle = _config.GetValue( UiConst.FontStyle )
        };
        result = Util.Helpers.Json.ToJson( fontType, new JsonOptions { ToSingleQuotes = true } );
        if ( result == "{}" )
            result = null;
        return result;
    }

    /// <summary>
    /// 配置间距
    /// </summary>
    public WaterMarkBuilder Gap() {
        AttributeIfNotEmpty( "[nzGap]", _config.GetValue( UiConst.Gap ) );
        return this;
    }

    /// <summary>
    /// 配置偏移量
    /// </summary>
    public WaterMarkBuilder Offset() {
        AttributeIfNotEmpty( "[nzOffset]", _config.GetValue( UiConst.Offset ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Content().Width().Height().Rotate()
            .ZIndex().Image().Font().Gap().Offset();
    }
}