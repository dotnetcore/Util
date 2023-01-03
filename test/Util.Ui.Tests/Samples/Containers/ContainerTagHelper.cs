using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.Tests.Samples.Containers.Renders;

namespace Util.Ui.Tests.Samples.Containers {
    /// <summary>
    /// 容器,生成的标签为&lt;ng-container&gt;&lt;/ng-container&gt;
    /// </summary>
    [HtmlTargetElement( "util-container" )]
    public class ContainerTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ContainerRender( config );
        }
    }
}