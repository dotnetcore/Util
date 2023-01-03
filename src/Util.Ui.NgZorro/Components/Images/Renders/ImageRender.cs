using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Images.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Images.Renders {
    /// <summary>
    /// 图片渲染器
    /// </summary>
    public class ImageRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化图片渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ImageRender( Config config ) {
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

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new ImageRender( _config.Copy() );
        }
    }
}