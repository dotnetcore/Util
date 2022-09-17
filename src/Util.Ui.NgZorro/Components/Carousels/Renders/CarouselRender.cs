using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Carousels.Builders;

namespace Util.Ui.NgZorro.Components.Carousels.Renders {
    /// <summary>
    /// 走马灯渲染器
    /// </summary>
    public class CarouselRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化走马灯渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CarouselRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CarouselBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}