using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Checkboxes.Helpers;
using Util.Ui.NgZorro.Components.Checkboxes.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Checkboxes {
    /// <summary>
    /// 复选框组合,生成的标签为&lt;nz-checkbox-group&gt;&lt;/nz-checkbox-group&gt;
    /// </summary>
    [HtmlTargetElement( "util-checkbox-group" )]
    public class CheckboxGroupTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// [nzDisabled],禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],禁用
        /// </summary>
        public string BindDisabled { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new CheckboxService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new CheckboxGroupRender( _config );
        }
    }
}