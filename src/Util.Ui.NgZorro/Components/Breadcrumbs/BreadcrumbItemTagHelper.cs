using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Breadcrumbs.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Breadcrumbs {
    /// <summary>
    /// 面包屑子项,生成的标签为&lt;nz-breadcrumb-item&gt;&lt;/nz-breadcrumb-item&gt;,放在&lt;util-breadcrumb&gt;&lt;/util-breadcrumb&gt;中使用
    /// </summary>
    [HtmlTargetElement( "util-breadcrumb-item" )]
    public class BreadcrumbItemTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzOverlay],用于支持下拉菜单
        /// </summary>
        public string Overlay { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new BreadcrumbItemRender( config );
        }
    }
}