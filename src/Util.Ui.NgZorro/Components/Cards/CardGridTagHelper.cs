using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Cards.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Cards {
    /// <summary>
    /// 网格内嵌卡片,生成的标签为&lt;div nz-card-grid>&lt;/div>
    /// </summary>
    [HtmlTargetElement( "util-card-grid" )]
    public class CardGridTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzHoverable],鼠标滑过时是否可浮起,默认值: true
        /// </summary>
        public bool Hoverable { get; set; }
        /// <summary>
        /// [nzHoverable],鼠标滑过时是否可浮起,默认值: true
        /// </summary>
        public string BindHoverable { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new CardGridRender( config );
        }
    }
}