using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Dropdowns.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Dropdowns {
    /// <summary>
    /// 下拉菜单,生成的标签为&lt;nz-dropdown-menu&gt;&lt;ul nz-menu&gt;&lt;/ul&gt;&lt;/nz-dropdown-menu&gt;
    /// </summary>
    [HtmlTargetElement( "util-dropdown-menu" )]
    public class DropdownMenuTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzSelectable],是否允许选中，默认值：false,注意:该属性设置在&lt;ul nz-menu&gt;&lt;/ul&gt;上
        /// </summary>
        public bool Selectable { get; set; }
        /// <summary>
        /// [nzSelectable],是否允许选中，默认值：false,注意:该属性设置在&lt;ul nz-menu&gt;&lt;/ul&gt;上
        /// </summary>
        public string BindSelectable { get; set; }
        /// <summary>
        /// 默认情况下会创建&lt;ul nz-menu&gt;&lt;/ul&gt;,设置为 true 则不会创建ul标签,生成的下拉菜单标签为 &lt;nz-dropdown-menu&gt;&lt;/nz-dropdown-menu&gt;
        /// </summary>
        public bool NotCreateUl { get; set; }
        /// <summary>
        /// (nzClick),单击菜单项事件处理函数,注意:该属性设置在&lt;ul nz-menu&gt;&lt;/ul&gt;上
        /// </summary>
        public string OnClick { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new DropdownMenuRender( config );
        }
    }
}