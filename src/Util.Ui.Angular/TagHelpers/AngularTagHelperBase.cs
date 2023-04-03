using Util.Ui.TagHelpers;

namespace Util.Ui.Angular.TagHelpers {
    /// <summary>
    /// angular TagHelper基类
    /// </summary>
    public abstract class AngularTagHelperBase : TagHelperBase {
        /// <summary>
        /// id,标签的id属性
        /// </summary>
        public string RawId { get; set; }
        /// <summary>
        /// *ngIf
        /// </summary>
        public string NgIf { get; set; }
        /// <summary>
        /// [ngSwitch]
        /// </summary>
        public string NgSwitch { get; set; }
        /// <summary>
        /// *ngSwitchCase
        /// </summary>
        public string NgSwitchCase { get; set; }
        /// <summary>
        /// *ngSwitchDefault
        /// </summary>
        public bool NgSwitchDefault { get; set; }
        /// <summary>
        /// *ngFor,范例：let item of items
        /// </summary>
        public string NgFor { get; set; }
        /// <summary>
        /// [ngClass]
        /// </summary>
        public string NgClass { get; set; }
        /// <summary>
        /// *aclIf,访问控制,设置资源标识
        /// </summary>
        public string Acl { get; set; }
        /// <summary>
        /// [acl],访问控制
        /// </summary>
        public string BindAcl { get; set; }
    }
}