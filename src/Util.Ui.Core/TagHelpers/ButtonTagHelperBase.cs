namespace Util.Ui.TagHelpers {
    /// <summary>
    /// 按钮TagHelper
    /// </summary>
    public abstract class ButtonTagHelperBase : TagHelperBase {
        /// <summary>
        /// 扁平风格
        /// </summary>
        public bool AspPlain { get; set; }
        /// <summary>
        /// 单击事件
        /// </summary>
        public string AspClick { get; set; }
    }
}
