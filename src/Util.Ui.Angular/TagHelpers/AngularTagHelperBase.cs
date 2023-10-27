using Util.Ui.TagHelpers;

namespace Util.Ui.Angular.TagHelpers; 

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
    /// [ngStyle]
    /// </summary>
    public string NgStyle { get; set; }
    /// <summary>
    /// *aclIf,访问控制,设置资源标识,有权则显示,多个资源or条件控制,使用 || 运算符,范例: a || b, and条件控制使用 &amp;&amp; 运行算符,范例: a &amp;&amp; b
    /// </summary>
    public string Acl { get; set; }
    /// <summary>
    /// 与acl属性配合使用,设置无权显示区域的ng-template组件标识
    /// </summary>
    public string AclElseTemplateId { get; set; }
    /// <summary>
    /// [acl],访问控制
    /// </summary>
    public string BindAcl { get; set; }
}