using Util.Ui.TagHelpers;

namespace Util.Ui.Angular.Base {
    /// <summary>
    /// angular TagHelper基类
    /// </summary>
    public abstract class AngularTagHelperBase : TagHelperBase {
        /// <summary>
        /// *ngIf
        /// </summary>
        public string NgIf { get; set; }
        /// <summary>
        /// *ngFor,范例：let item of items
        /// </summary>
        public string NgFor { get; set; }
        /// <summary>
        /// ngClass指令
        /// </summary>
        public string NgClass { get; set; }
    }
}