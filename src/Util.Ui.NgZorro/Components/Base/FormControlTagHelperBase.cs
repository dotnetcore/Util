using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Util.Ui.NgZorro.Components.Base; 

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
    /// <summary>
    /// name,名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// [name],名称
    /// </summary>
    public string BindName { get; set; }
    /// <summary>
    /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
    /// </summary>
    public bool SpaceItem { get; set; }
}