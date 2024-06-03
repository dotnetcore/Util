using Util.Ui.Angular.Builders;

namespace Util.Ui.NgZorro.Components.Images.Builders;

/// <summary>
/// 图片分组标签生成器
/// </summary>
public class ImageGroupBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化图片分组标签生成器
    /// </summary>
    public ImageGroupBuilder( Config config ) : base( config, "nz-image-group" ) {
        _config = config;
    }

    /// <summary>
    /// 配置缩放的每步倍数
    /// </summary>
    public ImageGroupBuilder ScaleStep() {
        AttributeIfNotEmpty( "[nzScaleStep]", _config.GetValue( UiConst.ScaleStep ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        ScaleStep();
    }
}