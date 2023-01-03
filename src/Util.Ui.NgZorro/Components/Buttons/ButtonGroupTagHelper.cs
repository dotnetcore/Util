using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Buttons.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Buttons {
    /// <summary>
    /// 按钮组,生成的标签为&lt;nz-button-group&gt;&lt;/nz-button-group&gt;
    /// </summary>
    [HtmlTargetElement( "util-button-group" )]
    public class ButtonGroupTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzSize,按钮尺寸
        /// </summary>
        public ButtonSize Size { get; set; }
        /// <summary>
        /// [nzSize],按钮尺寸
        /// </summary>
        public string BindSize { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ButtonGroupRender( config );
        }
    }
}
