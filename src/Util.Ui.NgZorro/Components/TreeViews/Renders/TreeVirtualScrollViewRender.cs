using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.TreeViews.Builders;

namespace Util.Ui.NgZorro.Components.TreeViews.Renders {
    /// <summary>
    /// 虚拟滚动树视图渲染器
    /// </summary>
    public class TreeVirtualScrollViewRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化虚拟滚动树视图渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeVirtualScrollViewRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TreeVirtualScrollViewBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}