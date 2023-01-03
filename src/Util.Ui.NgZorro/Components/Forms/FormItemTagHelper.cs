using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.NgZorro.Components.Forms.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms {
    /// <summary>
    /// 表单项,生成的标签为&lt;nz-form-item&gt;&lt;/nz-form-item&gt;
    /// </summary>
    [HtmlTargetElement( "util-form-item" )]
    public class FormItemTagHelper : RowTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new FormItemShareService( _config );
            service.Init();
            service.AutoCreateFormItem( false );
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new FormItemRender( _config );
        }
    }
}