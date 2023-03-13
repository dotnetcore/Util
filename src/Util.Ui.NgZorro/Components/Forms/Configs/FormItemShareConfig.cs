namespace Util.Ui.NgZorro.Components.Forms.Configs {
    /// <summary>
    /// 表单项共享配置
    /// </summary>
    public class FormItemShareConfig : FormShareConfig {
        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 自动创建nz-form-item
        /// </summary>
        public bool? AutoCreateFormItem { get; set; }
        /// <summary>
        /// 自动创建nz-form-label
        /// </summary>
        public bool? AutoCreateFormLabel { get; set; }
        /// <summary>
        /// 自动创建nz-form-control
        /// </summary>
        public bool? AutoCreateFormControl { get; set; }
        /// <summary>
        /// 控件标识
        /// </summary>
        public string ControlId { get; set; }
        /// <summary>
        /// 标签文本
        /// </summary>
        public string LabelText { get; set; }
        /// <summary>
        /// 是否存在额外提示
        /// </summary>
        public bool HasExtra { get; set; }
        /// <summary>
        /// 是否存在成功提示
        /// </summary>
        public bool HasSuccessTip { get; set; }
        /// <summary>
        /// 是否存在警告提示
        /// </summary>
        public bool HasWarningTip { get; set; }
        /// <summary>
        /// 是否存在错误提示
        /// </summary>
        public bool HasErrorTip { get; set; }
        /// <summary>
        /// 是否存在校验提示
        /// </summary>
        public bool HasValidatingTip { get; set; }
        /// <summary>
        /// 是否启用验证扩展
        /// </summary>
        public bool IsValidationExtend { get; set; }
        /// <summary>
        /// 验证扩展标识
        /// </summary>
        public string ValidationExtendId { get; set; }
        /// <summary>
        /// 验证模板标识
        /// </summary>
        public string ValidationTempalteId { get; set; }
        /// <summary>
        /// ngIf*
        /// </summary>
        public string NgIf { get; set; }
    }
}
