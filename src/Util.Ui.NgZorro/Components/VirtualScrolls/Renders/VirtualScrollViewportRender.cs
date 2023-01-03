using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.VirtualScrolls.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.VirtualScrolls.Renders {
    /// <summary>
    /// 虚拟滚动窗口渲染器
    /// </summary>
    public class VirtualScrollViewportRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化虚拟滚动窗口渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public VirtualScrollViewportRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new VirtualScrollViewportBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new VirtualScrollViewportRender( _config.Copy() );
        }
    }
}