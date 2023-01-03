using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Menus {
    /// <summary>
    /// 菜单组,生成的标签为&lt;li nz-menu-group&gt;&lt;ul&gt;&lt;/ul&gt;&lt;/li&gt;
    /// </summary>
    [HtmlTargetElement( "util-menu-group" )]
    public class MenuGroupTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzTitle,标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzTitle],标题
        /// </summary>
        public string BindTitle { get; set; }
        
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new MenuGroupRender( config );
        }
    }
}