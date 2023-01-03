using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.PageHeaders.Configs;
using Util.Ui.NgZorro.Components.PageHeaders.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.PageHeaders {
    /// <summary>
    /// 页头,生成的标签为&lt;nz-page-header&gt;&lt;/nz-page-header&gt;
    /// </summary>
    [HtmlTargetElement( "util-page-header" )]
    public class PageHeaderTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzGhost],是否使背景色透明,默认值:true
        /// </summary>
        public bool Ghost { get; set; }
        /// <summary>
        /// [nzGhost],是否使背景色透明,默认值:true
        /// </summary>
        public string BindGhost { get; set; }
        /// <summary>
        /// nzTitle,标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzTitle],标题
        /// </summary>
        public string BindTitle { get; set; }
        /// <summary>
        /// nzSubtitle,子标题
        /// </summary>
        public string Subtitle { get; set; }
        /// <summary>
        /// [nzSubtitle],子标题
        /// </summary>
        public string BindSubtitle { get; set; }
        /// <summary>
        /// nzBackIcon,显示返回按钮
        /// </summary>
        public bool ShowBack { get; set; }
        /// <summary>
        /// nzBackIcon,设置返回按钮图标
        /// </summary>
        public AntDesignIcon BackIcon { get; set; }
        /// <summary>
        /// [nzBackIcon],设置返回按钮图标
        /// </summary>
        public string BindBackIcon { get; set; }
        /// <summary>
        /// (nzBack),返回按钮点击事件
        /// </summary>
        public string OnBack { get; set; }

        /// <summary>
        /// 渲染前操作
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            context.SetValueToItems( new PageHeaderShareConfig() );
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new PageHeaderRender( config );
        }
    }
}