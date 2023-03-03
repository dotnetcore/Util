using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Templates.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Templates {
    /// <summary>
    /// 模板,生成的标签为&lt;ng-template&gt;&lt;/ng-template&gt;
    /// </summary>
    [HtmlTargetElement( "util-template" )]
    public class TemplateTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nz-tab,选项卡是否延迟加载
        /// </summary>
        public bool Tab { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new TemplateRender( config );
        }
    }
}