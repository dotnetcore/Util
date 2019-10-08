using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular.Base;

namespace Util.Ui.Zorro.Forms.Base {
    /// <summary>
    /// 表单控件
    /// </summary>
    public abstract class FormControlTagHelperBase : AngularTagHelperBase {
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 是否显示标签，默认值：false
        /// </summary>
        public bool ShowLabel { get; set; }
        /// <summary>
        /// 标签文本
        /// </summary>
        public string LabelText { get; set; }
        /// <summary>
        /// 标签的栅格占位格数
        /// </summary>
        public int LabelSpan { get; set; }
        /// <summary>
        /// 是否flex布局，默认值：false
        /// </summary>
        public bool IsFlex { get; set; }
        /// <summary>
        /// [(ngModel)],模型绑定
        /// </summary>
        public string NgModel { get; set; }
        /// <summary>
        /// name,名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// [name],名称
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// [nzDisabled],禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// nzPlaceHolder,占位提示
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// [nzPlaceHolder],占位提示
        /// </summary>
        public string BindPlaceholder { get; set; }
        /// <summary>
        /// 必填项
        /// </summary>
        public string Required { get; set; }
        /// <summary>
        /// 必填项错误消息
        /// </summary>
        public string RequiredMessage { get; set; }
        /// <summary>
        /// nzSpan,24栅格占位格数，可选值: 0 - 24, 为 0 时隐藏
        /// </summary>
        public int Span { get; set; }
        /// <summary>
        /// (ngModelChange),变更事件处理函数
        /// </summary>
        public string OnChange { get; set; }
        /// <summary>
        /// 获得焦点事件处理函数,范例：handle()
        /// </summary>
        public string OnFocus { get; set; }
        /// <summary>
        /// 失去焦点事件处理函数,范例：handle()
        /// </summary>
        public string OnBlur { get; set; }
        /// <summary>
        /// 键盘按键事件处理函数,范例：handle()
        /// </summary>
        public string OnKeyup { get; set; }
        /// <summary>
        /// 键盘按下事件处理函数,范例：handle()
        /// </summary>
        public string OnKeydown { get; set; }
    }
}
