using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Checkboxes.Renders;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Checkboxes {
    /// <summary>
    /// 复选框包装器,生成的标签为&lt;nz-checkbox-wrapper&gt;&lt;/nz-checkbox-wrapper&gt;
    /// </summary>
    [HtmlTargetElement( "util-checkbox-wrapper" )]
    public class CheckboxWrapperTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// (nzOnChange),变更事件
        /// </summary>
        public string OnChange { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var formItemShareService = new FormItemShareService( _config );
            formItemShareService.Init();
            formItemShareService.InitId();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new CheckboxWrapperRender( _config );
        }
    }
}