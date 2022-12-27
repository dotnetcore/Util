using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Util.Ui.NgZorro.Components.Base {
    /// <summary>
    /// 表单控件基类
    /// </summary>
    public abstract class FormControlTagHelperBase : FormControlContainerTagHelperBase {
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// [(ngModel)],模型双向绑定
        /// </summary>
        public string NgModel { get; set; }
        /// <summary>
        /// [ngModel],模型绑定
        /// </summary>
        public string BindNgModel { get; set; }
        /// <summary>
        /// [formControl],表单控件实例
        /// </summary>
        public string FormControl { get; set; }
        /// <summary>
        /// formControlName,表单控件名
        /// </summary>
        public string FormControlName { get; set; }
        /// <summary>
        /// [formControlName],表单控件名
        /// </summary>
        public string BindFormControlName { get; set; }
        /// <summary>
        /// (ngModelChange),模型变更事件
        /// </summary>
        public string OnModelChange { get; set; }
    }
}
