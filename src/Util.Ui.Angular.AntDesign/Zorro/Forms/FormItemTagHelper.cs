using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Forms.Renders;

namespace Util.Ui.Zorro.Forms {
    /// <summary>
    /// 表单项
    /// </summary>
    [HtmlTargetElement( "util-form-item" )]
    public class FormItemTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzGutter],栅格间隔，可以是数字，单位为像素，也可以是响应式写法,范例：{ xs: 8, sm: 16, md: 24, lg: 32, xl: 32, xxl: 32 }
        /// </summary>
        public string Gutter { get; set; }
        /// <summary>
        /// 是否flex布局模式，默认值：false
        /// </summary>
        public bool IsFlex { get; set; }
        /// <summary>
        /// nzAlign,垂直对齐方式
        /// </summary>
        public Align Align { get; set; }
        /// <summary>
        /// nzJustify,水平排列方式
        /// </summary>
        public Justify Justify { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new FormItemRender( new Config( context ) );
        }
    }
}