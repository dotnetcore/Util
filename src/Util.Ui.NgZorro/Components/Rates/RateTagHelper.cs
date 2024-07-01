using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Rates.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Rates; 

/// <summary>
/// 评分,生成的标签为&lt;nz-rate&gt;&lt;/nz-rate&gt;
/// </summary>
[HtmlTargetElement( "util-rate" )]
public class RateTagHelper : AngularTagHelperBase {
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
    /// (ngModelChange),模型变化事件
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
    /// [nzAllowClear],是否允许再次点击清除,类型: boolean, 默认值: true
    /// </summary>
    public string AllowClear { get; set; }
    /// <summary>
    /// [nzAllowHalf],是否允许半选,类型: boolean, 默认值: false
    /// </summary>
    public string AllowHalf { get; set; }
    /// <summary>
    /// [nzAutoFocus],是否自动聚焦,类型: boolean, 默认值: false
    /// </summary>
    public string AutoFocus { get; set; }
    /// <summary>
    /// [nzCharacter],自定义字符,将星星替换为其他字符,类型:TemplateRef&lt;/void&gt;,默认值: &lt;span nz-icon nzType="star"&gt;&lt;/span&gt;
    /// </summary>
    public string Character { get; set; }
    /// <summary>
    /// [nzCount],星星显示数量,类型: number, 默认值: 5
    /// </summary>
    public string Count { get; set; }
    /// <summary>
    /// [nzDisabled],是否禁用,类型: boolean, 默认值: false
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// [nzTooltips],自定义每项的提示信息,类型: string[],范例: ['terrible', 'bad', 'normal', 'good', 'wonderful']
    /// </summary>
    public string Tooltips { get; set; }
    /// <summary>
    /// (nzOnFocus),获得焦点事件,类型: EventEmitter&lt;FocusEvent>
    /// </summary>
    public string OnFocus { get; set; }
    /// <summary>
    /// (nzOnBlur),失去焦点事件,类型: EventEmitter&lt;FocusEvent>
    /// </summary>
    public string OnBlur { get; set; }
    /// <summary>
    /// (nzOnHoverChange),鼠标滑过事件,类型: EventEmitter&lt;number>
    /// </summary>
    public string OnHoverChange { get; set; }
    /// <summary>
    /// (nzOnKeyDown),键盘按下事件,类型: EventEmitter&lt;KeyboardEvent>
    /// </summary>
    public string OnKeydown { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new RateRender( config );
    }
}