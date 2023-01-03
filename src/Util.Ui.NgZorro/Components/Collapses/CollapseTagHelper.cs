using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Collapses.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Collapses {
    /// <summary>
    /// 折叠,生成的标签为&lt;nz-collapse>&lt;/nz-collapse>
    /// </summary>
    [HtmlTargetElement( "util-collapse" )]
    public class CollapseTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzAccordion],是否手风琴,即每次只打开一个标签页,默认值: false
        /// </summary>
        public bool Accordion { get; set; }
        /// <summary>
        /// [nzAccordion],是否手风琴,即每次只打开一个标签页,默认值: false
        /// </summary>
        public string BindAccordion { get; set; }
        /// <summary>
        /// [nzBordered],是否有边框,默认值: true
        /// </summary>
        public bool Bordered { get; set; }
        /// <summary>
        /// [nzBordered],是否有边框,默认值: true
        /// </summary>
        public string BindBordered { get; set; }
        /// <summary>
        /// [nzGhost],是否使折叠面板透明且无边框,默认值: false
        /// </summary>
        public bool Ghost { get; set; }
        /// <summary>
        /// [nzGhost],是否使折叠面板透明且无边框,默认值: false
        /// </summary>
        public string BindGhost { get; set; }
        /// <summary>
        /// nzExpandIconPosition,图标位置,可选值: 'left' | 'right' ,默认值: 'left'
        /// </summary>
        public string ExpandIconPosition { get; set; }
        /// <summary>
        /// [nzExpandIconPosition],图标位置,可选值: 'left' | 'right' ,默认值: 'left'
        /// </summary>
        public string BindExpandIconPosition { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new CollapseRender( config );
        }
    }
}