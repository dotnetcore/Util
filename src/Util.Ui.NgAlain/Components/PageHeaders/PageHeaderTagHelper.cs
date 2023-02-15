using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.PageHeaders.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.PageHeaders {
    /// <summary>
    /// ng-alain页头,生成的标签为&lt;page-header&gt;&lt;/page-header&gt;
    /// </summary>
    [HtmlTargetElement( "util-page-header2" )]
    public class PageHeaderTagHelper : AngularTagHelperBase {
        /// <summary>
        /// title,标题,支持i18n
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 扩展属性,设置创建标题,支持i18n
        /// </summary>
        public string TitleCreate { get; set; }
        /// <summary>
        /// 扩展属性,设置修改标题,支持i18n
        /// </summary>
        public string TitleUpdate { get; set; }
        /// <summary>
        /// [title],标题
        /// </summary>
        public string BindTitle { get; set; }
        /// <summary>
        /// [autoTitle],是否自动生成标题，以当前路由从主菜单中定位,默认值: true
        /// </summary>
        public bool AutoTitle { get; set; }
        /// <summary>
        /// [autoTitle],是否自动生成标题，以当前路由从主菜单中定位,默认值: true
        /// </summary>
        public string BindAutoTitle { get; set; }
        /// <summary>
        /// [syncTitle],是否自动将标题同步至 TitleService、ReuseService 下，仅 title 为 string 类型时有效,默认值: true
        /// </summary>
        public bool SyncTitle { get; set; }
        /// <summary>
        /// [syncTitle],是否自动将标题同步至 TitleService、ReuseService 下，仅 title 为 string 类型时有效,默认值: true
        /// </summary>
        public string BindSyncTitle { get; set; }
        /// <summary>
        /// home,首页文本，若指定空表示不显示,默认值: 首页
        /// </summary>
        public string Home { get; set; }
        /// <summary>
        /// [home],首页文本，若指定空表示不显示,默认值: 首页
        /// </summary>
        public string BindHome { get; set; }
        /// <summary>
        /// homeLink,首页链接,默认值: /
        /// </summary>
        public string HomeLink { get; set; }
        /// <summary>
        /// [homeLink],首页链接,默认值: /
        /// </summary>
        public string BindHomeLink { get; set; }
        /// <summary>
        /// homeI18n,首页链接国际化参数
        /// </summary>
        public string HomeI18n { get; set; }
        /// <summary>
        /// [homeI18n],首页链接国际化参数
        /// </summary>
        public string BindHomeI18n { get; set; }
        /// <summary>
        /// [autoBreadcrumb],是否自动生成导航，以当前路由从主菜单中定位,默认值: true
        /// </summary>
        public bool AutoBreadcrumb { get; set; }
        /// <summary>
        /// [autoBreadcrumb],是否自动生成导航，以当前路由从主菜单中定位,默认值: true
        /// </summary>
        public string BindAutoBreadcrumb { get; set; }
        /// <summary>
        /// [recursiveBreadcrumb],是否自动向上递归查找，范例: 菜单数据源包含 /ware，则 /ware/1 也视为 /ware 项,默认值: false
        /// </summary>
        public bool RecursiveBreadcrumb { get; set; }
        /// <summary>
        /// [recursiveBreadcrumb],是否自动向上递归查找，范例: 菜单数据源包含 /ware，则 /ware/1 也视为 /ware 项,默认值: false
        /// </summary>
        public string BindRecursiveBreadcrumb { get; set; }
        /// <summary>
        /// [loading],是否加载中,默认值: false
        /// </summary>
        public string Loading { get; set; }
        /// <summary>
        /// [wide],是否定宽,默认值: false
        /// </summary>
        public bool Wide { get; set; }
        /// <summary>
        /// [wide],是否定宽,默认值: false
        /// </summary>
        public string BindWide { get; set; }
        /// <summary>
        /// [fixed],是否固定模式,默认值: false
        /// </summary>
        public bool Fixed { get; set; }
        /// <summary>
        /// [fixed],是否固定模式,默认值: false
        /// </summary>
        public string BindFixed { get; set; }
        /// <summary>
        /// [fixedOffsetTop],固定偏移值,默认值: 64
        /// </summary>
        public string FixedOffsetTop { get; set; }
        /// <summary>
        /// [breadcrumb],自定义导航区域,类型: TemplateRef&lt;void>
        /// </summary>
        public string Breadcrumb { get; set; }
        /// <summary>
        /// [logo],自定义Logo区域,类型: TemplateRef&lt;void>
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// [action],自定义操作区域,类型: TemplateRef&lt;void>
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// [content],自定义内容区域,类型: TemplateRef&lt;void>
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// [extra],自定义额外信息区域,类型: TemplateRef&lt;void>
        /// </summary>
        public string Extra { get; set; }
        /// <summary>
        /// [tab],自定义标签区域,类型: TemplateRef&lt;void>
        /// </summary>
        public string Tab { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new PageHeaderRender( config );
        }
    }
}