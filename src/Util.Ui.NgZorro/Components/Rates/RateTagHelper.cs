using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Rates.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Rates; 

/// <summary>
/// 评分,生成的标签为&lt;nz-rate&gt;&lt;/nz-rate&gt;
/// </summary>
[HtmlTargetElement( "util-rate" )]
public class RateTagHelper : FormControlTagHelperBase {
    /// <summary>
    /// [nzAllowClear],是否允许再次点击后清除,默认值: true
    /// </summary>
    public string AllowClear { get; set; }
    /// <summary>
    /// [nzAllowHalf],是否允许半选,默认值: false
    /// </summary>
    public string AllowHalf { get; set; }
    /// <summary>
    /// [nzAutoFocus],是否自动聚焦,默认值: false
    /// </summary>
    public string AutoFocus { get; set; }
    /// <summary>
    /// [nzCharacter],自定义字符,可以将星星替换为其他字符，比如字母，数字，字体图标甚至中文,类型:TemplateRef&lt;/void&gt;,默认值: &lt;i nz-icon nzType="star"&gt;&lt;/i&gt;
    /// </summary>
    public string Character { get; set; }
    /// <summary>
    /// nzCount,星星的显示数量,默认值: 5
    /// </summary>
    public string Count { get; set; }
    /// <summary>
    /// [nzDisabled],禁用
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// [nzTooltips],自定义每项的提示信息,类型: string[],范例: ['terrible', 'bad', 'normal', 'good', 'wonderful']
    /// </summary>
    public string Tooltips { get; set; }
    /// <summary>
    /// (nzOnFocus),获得焦点事件
    /// </summary>
    public string OnFocus { get; set; }
    /// <summary>
    /// (nzOnBlur),失去焦点事件
    /// </summary>
    public string OnBlur { get; set; }
    /// <summary>
    /// (nzOnHoverChange),鼠标滑过事件
    /// </summary>
    public string OnHoverChange { get; set; }
    /// <summary>
    /// (nzOnKeyDown),键盘按下事件
    /// </summary>
    public string OnKeydown { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new RateRender( config );
    }
}