using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.BreadCrumbs.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Breadcrumbs.Renders {
    /// <summary>
    /// 面包屑项渲染器
    /// </summary>
    public class BreadcrumbItemRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化面包屑项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public BreadcrumbItemRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new BreadcrumbItemBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new BreadcrumbItemRender( _config.Copy() );
        }
    }
}