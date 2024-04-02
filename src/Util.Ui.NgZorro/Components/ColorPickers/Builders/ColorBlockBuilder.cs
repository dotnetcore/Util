using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.ColorPickers.Builders;

/// <summary>
/// 颜色块标签生成器
/// </summary>
public class ColorBlockBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化颜色块标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public ColorBlockBuilder( Config config ) : base( config, "nz-color-block" ) {
        _config = config;
    }

    /// <summary>
    /// 配置颜色
    /// </summary>
    public ColorBlockBuilder Color() {
        AttributeIfNotEmpty( "nzColor", _config.GetValue( UiConst.Color ) );
        AttributeIfNotEmpty( "[nzColor]", _config.GetValue( AngularConst.BindColor ) );
        return this;
    }

    /// <summary>
    /// 配置控件尺寸
    /// </summary>
    public ColorBlockBuilder Size() {
        AttributeIfNotEmpty( "nzSize", _config.GetValue<InputSize?>( UiConst.Size )?.Description() );
        AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public ColorBlockBuilder Events() {
        AttributeIfNotEmpty( "(nzOnClick)", _config.GetValue( UiConst.OnClick ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        Color().Size().Events();
    }
}