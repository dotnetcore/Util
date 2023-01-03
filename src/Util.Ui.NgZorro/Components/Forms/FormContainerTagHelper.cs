using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Containers.Renders;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms {
    /// <summary>
    /// 表单容器,生成的标签为&lt;ng-container&gt;&lt;/ng-container&gt;
    /// </summary>
    [HtmlTargetElement( "util-form-container" )]
    public class FormContainerTagHelper : FormContainerTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new FormShareService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new ContainerRender( _config );
        }
    }
}