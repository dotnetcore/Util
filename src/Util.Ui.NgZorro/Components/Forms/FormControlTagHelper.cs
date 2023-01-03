using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.NgZorro.Components.Forms.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms {
    /// <summary>
    /// 表单域,生成的标签为&lt;nz-form-control&gt;&lt;/nz-form-control&gt;
    /// </summary>
    [HtmlTargetElement( "util-form-control" )]
    public class FormControlTagHelper : ColumnTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// [nzValidateStatus],校验状态，可选值: 'success' | 'warning' | 'error' | 'validating' | FormControl | NgModel
        /// </summary>
        public string ValidateStatus { get; set; }
        /// <summary>
        /// [nzHasFeedback],是否展示校验状态反馈图标，配合 nzValidateStatus 使用
        /// </summary>
        public string HasFeedback { get; set; }
        /// <summary>
        /// nzExtra,显示额外提示信息
        /// </summary>
        public string Extra { get; set; }
        /// <summary>
        /// [nzExtra],显示额外提示信息
        /// </summary>
        public string BindExtra { get; set; }
        /// <summary>
        /// nzSuccessTip,校验状态为成功时的提示信息
        /// </summary>
        public string SuccessTip { get; set; }
        /// <summary>
        /// [nzSuccessTip],校验状态为成功时的提示信息
        /// </summary>
        public string BindSuccessTip { get; set; }
        /// <summary>
        /// nzWarningTip,校验状态为警告时的提示信息
        /// </summary>
        public string WarningTip { get; set; }
        /// <summary>
        /// [nzWarningTip],校验状态为警告时的提示信息
        /// </summary>
        public string BindWarningTip { get; set; }
        /// <summary>
        /// nzErrorTip,校验状态为错误时的提示信息
        /// </summary>
        public string ErrorTip { get; set; }
        /// <summary>
        /// [nzErrorTip],校验状态为错误时的提示信息
        /// </summary>
        public string BindErrorTip { get; set; }
        /// <summary>
        /// nzValidatingTip,正在校验时的提示信息
        /// </summary>
        public string ValidatingTip { get; set; }
        /// <summary>
        /// [nzValidatingTip],正在校验时的提示信息
        /// </summary>
        public string BindValidatingTip { get; set; }
        /// <summary>
        /// [nzAutoTips],自动提示
        /// </summary>
        public string AutoTips { get; set; }
        /// <summary>
        /// [nzDisableAutoTips],禁用自动提示
        /// </summary>
        public string DisableAutoTips { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new FormItemShareService( _config );
            service.Init();
            service.AutoCreateFormControl( false );
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new FormControlRender( _config );
        }
    }
}