using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Expressions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.NgZorro.Components.Forms.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms {
    /// <summary>
    /// 表单标签,生成的标签为&lt;nz-form-label&gt;&lt;/nz-form-label&gt;
    /// </summary>
    [HtmlTargetElement( "util-form-label" )]
    public class FormLabelTagHelper : ColumnTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// 扩展属性,内容文本,支持i18n
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 扩展属性,属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// [nzRequired],是否必填项，显示红色星号
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// [nzRequired],是否必填项，显示红色星号
        /// </summary>
        public string BindRequired { get; set; }
        /// <summary>
        /// [nzNoColon],是否不显示冒号
        /// </summary>
        public bool NoColon { get; set; }
        /// <summary>
        /// [nzNoColon],是否不显示冒号
        /// </summary>
        public string BindNoColon { get; set; }
        /// <summary>
        /// nzFor,设置标签指向的组件Id,注意：应设置组件的raw-id,即原始Id属性,而不是引用变量
        /// </summary>
        public string LabelFor { get; set; }
        /// <summary>
        /// [nzFor],设置标签指向的组件Id,注意：应设置组件的raw-id,即原始Id属性,而不是引用变量
        /// </summary>
        public string BindLabelFor { get; set; }
        /// <summary>
        /// nzTooltipTitle,提示信息
        /// </summary>
        public string TooltipTitle { get; set; }
        /// <summary>
        /// [nzTooltipTitle],提示信息
        /// </summary>
        public string BindTooltipTitle { get; set; }
        /// <summary>
        /// nzTooltipIcon,提示图标
        /// </summary>
        public AntDesignIcon TooltipIcon { get; set; }
        /// <summary>
        /// [nzTooltipIcon],提示图标
        /// </summary>
        public string BindTooltipIcon { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new FormItemShareService( _config );
            service.Init();
            service.AutoCreateFormLabel( false );
            LoadExpression();
        }

        /// <summary>
        /// 加载表达式
        /// </summary>
        private void LoadExpression() {
            var loader = new ExpressionLoader();
            loader.Load( _config );
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new FormLabelRender( _config );
        }
    }
}