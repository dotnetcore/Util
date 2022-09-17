using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.BreadCrumbs.Builders;

namespace Util.Ui.NgZorro.Components.Breadcrumbs.Renders {
    /// <summary>
    /// 面包屑分隔符渲染器
    /// </summary>
    public class BreadcrumbSeparatorRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化面包屑分隔符渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public BreadcrumbSeparatorRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new BreadcrumbSeparatorBuilder();
            ConfigContent( builder );
            return builder;
        }
    }
}