using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.BreadCrumbs.Builders;

namespace Util.Ui.NgZorro.Components.Breadcrumbs.Renders {
    /// <summary>
    /// 面包屑项渲染器
    /// </summary>
    public class BreadcrumbItemRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化面包屑项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public BreadcrumbItemRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new BreadcrumbItemBuilder();
            ConfigOverlay( builder );
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置弹出层
        /// </summary>
        private void ConfigOverlay( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzOverlay]", _config.GetValue( UiConst.Overlay ) );
        }
    }
}