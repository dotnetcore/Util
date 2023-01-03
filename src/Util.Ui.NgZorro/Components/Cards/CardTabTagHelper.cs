using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Cards.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Cards {
    /// <summary>
    /// 卡片标签页,生成的标签为&lt;nz-card-tab>&lt;/nz-card-tab>
    /// </summary>
    [HtmlTargetElement( "util-card-tab" )]
    public class CardTabTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new CardTabRender( config );
        }
    }
}