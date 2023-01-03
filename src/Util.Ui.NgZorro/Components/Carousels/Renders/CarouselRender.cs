using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Carousels.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Carousels.Renders {
    /// <summary>
    /// 走马灯渲染器
    /// </summary>
    public class CarouselRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化走马灯渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CarouselRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CarouselBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new CarouselRender( _config.Copy() );
        }
    }
}