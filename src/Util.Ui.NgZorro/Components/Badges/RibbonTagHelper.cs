using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Badges.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Badges {
    /// <summary>
    /// 缎带徽标,生成的标签为&lt;nz-ribbon>&lt;/nz-ribbon>
    /// </summary>
    [HtmlTargetElement( "util-ribbon" )]
    public class RibbonTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzColor,颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// [nzColor],颜色
        /// </summary>
        public string BindColor { get; set; }
        /// <summary>
        /// nzPlacement,位置,可选值: 'start' | 'end',默认值: 'end'
        /// </summary>
        public string Placement { get; set; }
        /// <summary>
        /// [nzPlacement],位置,可选值: 'start' | 'end',默认值: 'end'
        /// </summary>
        public string BindPlacement { get; set; }
        /// <summary>
        /// nzText,文本内容
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// [nzText],文本内容
        /// </summary>
        public string BindText { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new RibbonRender( config );
        }
    }
}