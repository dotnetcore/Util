using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Containers.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Containers {
    /// <summary>
    /// 容器,生成的标签为&lt;ng-container>&lt;/ng-container>
    /// </summary>
    [HtmlTargetElement( "util-container" )]
    public class ContainerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// *nzMentionSuggestion,提及建议渲染模板,范例: *nzMentionSuggestion="let item"
        /// </summary>
        public string MentionSuggestion { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ContainerRender( config );
        }
    }
}