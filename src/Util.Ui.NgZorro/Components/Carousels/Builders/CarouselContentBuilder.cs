using Util.Ui.Angular.Builders;

namespace Util.Ui.NgZorro.Components.Carousels.Builders;

/// <summary>
/// 走马灯内容标签生成器
/// </summary>
public class CarouselContentBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化走马灯内容标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public CarouselContentBuilder( Config config ) : base( config, "div" ) {
        _config = config;
        base.Attribute( "nz-carousel-content" );
    }
}