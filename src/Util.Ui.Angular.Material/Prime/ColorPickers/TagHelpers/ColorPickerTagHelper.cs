using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Prime.ColorPickers.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Prime.ColorPickers.TagHelpers {
    /// <summary>
    /// 颜色选择器
    /// </summary>
    [HtmlTargetElement( "util-color-picker", TagStructure = TagStructure.WithoutEndTag )]
    public class ColorPickerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 控件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 控件的绑定名称 [name]
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// 模型绑定
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 内联
        /// </summary>
        public bool Inline { get; set; }
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 变更事件处理函数,范例：handle()
        /// </summary>
        public string OnChange { get; set; }
        /// <summary>
        /// 在循环中创建表单组件时使用，设置了ngModel，但无法设置固定的name，可以使用该属性创建控件，这样创建的控件独立于FormGroup
        /// </summary>
        public bool Standalone { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ColorPickerRender( new Config( context ) );
        }
    }
}