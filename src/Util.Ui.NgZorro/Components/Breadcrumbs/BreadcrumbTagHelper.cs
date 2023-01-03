using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.BreadCrumbs.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Breadcrumbs {
    /// <summary>
    /// 面包屑,生成的标签为&lt;nz-breadcrumb&gt;&lt;/nz-breadcrumb&gt;
    /// </summary>
    [HtmlTargetElement( "util-breadcrumb" )]
    public class BreadcrumbTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzSeparator,分隔符,默认值: '/' 
        /// </summary>
        public string Separator { get; set; }
        /// <summary>
        /// [nzSeparator],分隔符,设置为null隐藏分隔符, 默认值: '/' 
        /// </summary>
        public string BindSeparator { get; set; }
        /// <summary>
        /// [nzAutoGenerate],通过配置 router.data 自动生成面包屑
        /// </summary>
        public bool AutoGenerate { get; set; }
        /// <summary>
        /// [nzAutoGenerate],通过配置 router.data 自动生成面包屑
        /// </summary>
        public string BindAutoGenerate { get; set; }
        /// <summary>
        /// nzRouteLabel,自定义 route data 属性名称, nzAutoGenerate 为 true 时生效,默认值: 'breadcrumb'
        /// </summary>
        public string RouteLabel { get; set; }
        /// <summary>
        /// [nzRouteLabel],自定义 route data 属性名称, nzAutoGenerate 为 true 时生效,默认值: 'breadcrumb'
        /// </summary>
        public string BindRouteLabel { get; set; }
        /// <summary>
        /// [nzRouteLabelFn],格式化面包屑导航项的显示文字，通常用于在国际化应用中翻译键值, nzAutoGenerate 为 true 时生效
        /// </summary>
        public string RouteLabelFn { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new BreadcrumbRender( config );
        }
    }
}