using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.HashCodes.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.HashCodes;

/// <summary>
/// 哈希码,生成的标签为&lt;nz-hash-code&gt;&lt;/nz-hash-code&gt;
/// </summary>
[HtmlTargetElement( "util-hash-code" )]
public class HashCodeTagHelper : AngularTagHelperBase {
    /// <summary>
    /// nzValue,值
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// [nzValue],值
    /// </summary>
    public string BindValue { get; set; }
    /// <summary>
    /// nzTitle,标题, 默认值: HashCode
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// [nzTitle],标题, 默认值: HashCode
    /// </summary>
    public string BindTitle { get; set; }
    /// <summary>
    /// nzLogo,设置右上角的标志, 类型: TemplateRef&lt;void> | string
    /// </summary>
    public string Logo { get; set; }
    /// <summary>
    /// [nzLogo],设置右上角的标志, 类型: TemplateRef&lt;void> | string
    /// </summary>
    public string BindLogo { get; set; }
    /// <summary>
    /// nzMode,展示模式, 可选值: single | double | strip | rect , 默认值: double
    /// </summary>
    public HashCodeMode Mode { get; set; }
    /// <summary>
    /// [nzMode],展示模式, 可选值: single | double | strip | rect , 默认值: double
    /// </summary>
    public string BindMode { get; set; }
    /// <summary>
    /// nzType,样式, 可选值: defalut | primary , 默认值: primary
    /// </summary>
    public HashCodeType Type { get; set; }
    /// <summary>
    /// [nzType],样式, 可选值: defalut | primary , 默认值: primary
    /// </summary>
    public string BindType { get; set; }
    /// <summary>
    /// (nzOnCopy), 复制事件,类型: EventEmitter&lt;string>
    /// </summary>
    public string OnCopy { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new HashCodeRender( config );
    }
}