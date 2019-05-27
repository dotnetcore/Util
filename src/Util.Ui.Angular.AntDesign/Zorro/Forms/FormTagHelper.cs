using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Forms.Renders;

namespace Util.Ui.Zorro.Forms {
    /// <summary>
    /// 表单
    /// </summary>
    [HtmlTargetElement( "util-form" )]
    public class FormTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 提交事件处理函数，范例：handle()
        /// </summary>
        public string OnSubmit { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new FormRender( new Config( context ) );
        }
    }
}