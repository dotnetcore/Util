namespace Util.Ui.NgZorro.Components.Base {
    /// <summary>
    /// 表单控件容器基类
    /// </summary>
    public abstract class FormControlContainerTagHelperBase : FormContainerTagHelperBase {
        /// <summary>
        /// 标签文本,自动创建nz-form-label,nz-form-control,nz-form-item容器标签,并设置nz-form-label的内容,支持i18n
        /// </summary>
        public string LabelText { get; set; }
        /// <summary>
        /// 显示额外提示信息,自动创建nz-form-control,nz-form-item容器标签,并设置nz-form-control的 nzExtra 属性
        /// </summary>
        public string Extra { get; set; }
        /// <summary>
        /// 显示额外提示信息,自动创建nz-form-control,nz-form-item容器标签,并设置nz-form-control的 [nzExtra] 属性
        /// </summary>
        public string BindExtra { get; set; }
        /// <summary>
        /// 校验状态为成功时的提示信息,自动创建nz-form-control,nz-form-item容器标签,并设置nz-form-control的 nzSuccessTip 属性
        /// </summary>
        public string SuccessTip { get; set; }
        /// <summary>
        /// 校验状态为警告时的提示信息,自动创建nz-form-control,nz-form-item容器标签,并设置nz-form-control的 nzWarningTip 属性
        /// </summary>
        public string WarningTip { get; set; }
        /// <summary>
        /// 校验状态为错误时的提示信息,自动创建nz-form-control,nz-form-item容器标签,并设置nz-form-control的 nzErrorTip 属性
        /// </summary>
        public string ErrorTip { get; set; }
        /// <summary>
        /// 正在校验时的提示信息,自动创建nz-form-control,nz-form-item容器标签,并设置nz-form-control的 nzValidatingTip 属性
        /// </summary>
        public string ValidatingTip { get; set; }
    }
}
