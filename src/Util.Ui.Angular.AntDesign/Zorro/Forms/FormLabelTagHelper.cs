using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Forms.Renders;

namespace Util.Ui.Zorro.Forms {
    /// <summary>
    /// 表单标签
    /// </summary>
    [HtmlTargetElement( "util-form-label" )]
    public class FormLabelTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 标签文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 是否必填项，显示红色星号
        /// </summary>
        public string Required { get; set; }
        /// <summary>
        /// nzFor,设置标签指向的组件Id,注意：请设置组件的raw-id属性
        /// </summary>
        public string LabelFor { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new FormLabelRender( new Config( context ) );
        }
    }
}