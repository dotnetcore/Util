using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.NgZorro.Components.Forms.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms {
    /// <summary>
    /// 表单,生成的标签为&lt;form nz-form&gt;&lt;/form&gt;
    /// </summary>
    [HtmlTargetElement( "util-form" )]
    public class FormTagHelper : FormContainerTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// nzLayout,布局方式,可选值: 'horizontal' | 'vertical' | 'inline' ,默认值: 'horizontal'
        /// </summary>
        public FormLayout Layout { get; set; }
        /// <summary>
        /// [nzLayout],布局方式,可选值: 'horizontal' | 'vertical' | 'inline' ,默认值: 'horizontal'
        /// </summary>
        public string BindLayout { get; set; }
        /// <summary>
        /// [nzAutoTips],自动提示,配置 nz-form-control 的 [nzAutoTips] 的默认值
        /// </summary>
        public string AutoTips { get; set; }
        /// <summary>
        /// [nzDisableAutoTips],禁用自动提示,配置 nz-form-control 的 [nzDisableAutoTips] 的默认值
        /// </summary>
        public string DisableAutoTips { get; set; }
        /// <summary>
        /// [nzNoColon],是否不显示表单标签的冒号，配置 nz-form-label 的 [nzNoColon] 的默认值
        /// </summary>
        public bool NoColon { get; set; }
        /// <summary>
        /// [nzNoColon],是否不显示表单标签的冒号，配置 nz-form-label 的 [nzNoColon] 的默认值
        /// </summary>
        public string BindNoColon { get; set; }
        /// <summary>
        /// nzTooltipIcon,标签提示图标，配置 nz-form-label 的 nzTooltipIcon 的默认值
        /// </summary>
        public AntDesignIcon TooltipIcon { get; set; }
        /// <summary>
        /// [nzTooltipIcon],标签提示图标，配置 nz-form-label 的 [nzTooltipIcon] 的默认值
        /// </summary>
        public string BindTooltipIcon { get; set; }
        /// <summary>
        /// autocomplete,是否打开浏览器自动完成功能
        /// </summary>
        public bool AutoComplete { get; set; }
        /// <summary>
        /// [formGroup],表单组实例
        /// </summary>
        public string FormGroup { get; set; }
        /// <summary>
        /// (ngSubmit),表单提交事件
        /// </summary>
        public string OnSubmit { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new FormShareService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new FormRender( _config );
        }
    }
}