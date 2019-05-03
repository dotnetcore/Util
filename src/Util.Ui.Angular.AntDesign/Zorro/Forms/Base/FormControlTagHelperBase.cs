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
        /// [(ngModel)],模型绑定
        /// </summary>
        public string NgModel { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 占位提示
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// 占位提示
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
