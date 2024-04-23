using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.QrCodes.Builders;

/// <summary>
/// 二维码标签生成器
/// </summary>
public class QrCodeBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化二维码标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public QrCodeBuilder( Config config ) : base( config, "nz-qrcode" ) {
        _config = config;
    }

    /// <summary>
    /// 配置值
    /// </summary>
    public QrCodeBuilder Value() {
        AttributeIfNotEmpty( "nzValue", _config.GetValue( UiConst.Value ) );
        AttributeIfNotEmpty( "[nzValue]", _config.GetValue( AngularConst.BindValue ) );
        return this;
    }

    /// <summary>
    /// 配置二维码颜色
    /// </summary>
    public QrCodeBuilder Color() {
        AttributeIfNotEmpty( "nzColor", _config.GetValue( UiConst.Color ) );
        AttributeIfNotEmpty( "[nzColor]", _config.GetValue( AngularConst.BindColor ) );
        return this;
    }

    /// <summary>
    /// 配置背景色
    /// </summary>
    public QrCodeBuilder BgColor() {
        AttributeIfNotEmpty( "nzBgColor", _config.GetValue( UiConst.BgColor ) );
        AttributeIfNotEmpty( "[nzBgColor]", _config.GetValue( AngularConst.BindBgColor ) );
        return this;
    }

    /// <summary>
    /// 配置尺寸
    /// </summary>
    public QrCodeBuilder Size() {
        AttributeIfNotEmpty( "[nzSize]", _config.GetValue( UiConst.Size ) );
        return this;
    }

    /// <summary>
    /// 配置填充
    /// </summary>
    public QrCodeBuilder Padding() {
        AttributeIfNotEmpty( "[nzPadding]", _config.GetValue( UiConst.Padding ) );
        return this;
    }

    /// <summary>
    /// 配置图标地址
    /// </summary>
    public QrCodeBuilder Icon() {
        AttributeIfNotEmpty( "nzIcon", _config.GetValue( UiConst.Icon ) );
        AttributeIfNotEmpty( "[nzIcon]", _config.GetValue( AngularConst.BindIcon ) );
        return this;
    }

    /// <summary>
    /// 配置图标尺寸
    /// </summary>
    public QrCodeBuilder IconSize() {
        AttributeIfNotEmpty( "[nzIconSize]", _config.GetValue( UiConst.IconSize ) );
        return this;
    }

    /// <summary>
    /// 配置边框
    /// </summary>
    public QrCodeBuilder Bordered() {
        AttributeIfNotEmpty( "[nzBordered]", _config.GetValue( UiConst.Bordered ) );
        return this;
    }

    /// <summary>
    /// 配置状态
    /// </summary>
    public QrCodeBuilder Status() {
        AttributeIfNotEmpty( "nzStatus", _config.GetValue<QrCodeStatus?>( UiConst.Status ).Description() );
        AttributeIfNotEmpty( "[nzStatus]", _config.GetValue( AngularConst.BindStatus ) );
        return this;
    }

    /// <summary>
    /// 配置容错级别
    /// </summary>
    public QrCodeBuilder Level() {
        AttributeIfNotEmpty( "nzLevel", _config.GetValue<QrCodeCorrectionLevel?>( UiConst.Level ).Description() );
        AttributeIfNotEmpty( "[nzLevel]", _config.GetValue( AngularConst.BindLevel ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public QrCodeBuilder Events() {
        AttributeIfNotEmpty( "(nzRefresh)", _config.GetValue( UiConst.OnRefresh ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Value().Color().BgColor().Size().Padding().Icon().IconSize()
            .Bordered().Status().Level()
            .Events();
    }
}