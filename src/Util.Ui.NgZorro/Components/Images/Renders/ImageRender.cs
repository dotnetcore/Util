using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Images.Builders;

namespace Util.Ui.NgZorro.Components.Images.Renders {
    /// <summary>
    /// 图片渲染器
    /// </summary>
    public class ImageRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化图片渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ImageRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ImageBuilder( _config );
            builder.Config();
            return builder;
        }
    }
}