using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular.Base;
using Util.Ui.Enums;
using Util.Ui.Zorro.Enums;

namespace Util.Ui.Zorro.Forms.Base {
    /// <summary>
    /// 表单控件
    /// </summary>
    public abstract class FormControlTagHelperBase : AngularTagHelperBase {
        /// <summary>
        /// 控件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 控件的绑定名称 [name]
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 占位提示符
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// 占位提示符绑定
        /// </summary>
        public string BindPlaceholder { get; set; }
        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// 后缀文本
        /// </summary>
        public string SuffixText { get; set; }
        /// <summary>
        /// 后缀FontAwesome图标
        /// </summary>
        public FontAwesomeIcon SuffixFontAwesomeIcon { get; set; }
        /// <summary>
        /// 后缀Material图标
        /// </summary>
        public AntDesignIcon SuffixMaterialIcon { get; set; }
        /// <summary>
        /// 后缀图标单击事件,范例：click()
        /// </summary>
        public string OnSuffixIconClick { get; set; }
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 模型绑定
        /// </summary>
        public string NgModel { get; set; }
        /// <summary>
        /// 必填项
        /// </summary>
        public string Required { get; set; }
        /// <summary>
        /// 必填项错误消息
        /// </summary>
        public string RequiredMessage { get; set; }
        /// <summary>
        /// 变更事件处理函数,范例：handle()
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
        /// <summary>
        /// 组件不添加到FormGroup，独立存在，这样也无法基于NgForm进行表单验证
        /// </summary>
        public bool Standalone { get; set; }
    }
}
