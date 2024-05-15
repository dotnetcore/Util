using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Buttons.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Buttons; 

/// <summary>
/// 按钮,生成的标签为&lt;button nz-button>&lt;/button>，当按钮类型为链接按钮时，生成的标签为&lt;a nz-button nzType="link">&lt;/a>
/// </summary>
[HtmlTargetElement( "util-button" )]
public class ButtonTagHelper : ButtonTagHelperBase {
    /// <summary>
    /// nzType,按钮类型,可选值: 'primary'|'dashed'|'link'|'text'
    /// </summary>
    public ButtonType Type { get; set; }
    /// <summary>
    /// [nzType],按钮类型,可选值: 'primary'|'dashed'|'link'|'text'
    /// </summary>
    public string BindType { get; set; }
    /// <summary>
    /// nzSize,按钮尺寸, 可选值: 'large'|'small'|'default', 默认值: 'default'
    /// </summary>
    public ButtonSize Size { get; set; }
    /// <summary>
    /// [nzSize],按钮尺寸, 可选值: 'large'|'small'|'default', 默认值: 'default'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// nzShape,按钮形状, 可选值: 'circle'|'round'
    /// </summary>
    public ButtonShape Shape { get; set; }
    /// <summary>
    /// [nzShape],按钮形状, 可选值: 'circle'|'round'
    /// </summary>
    public string BindShape { get; set; }
    /// <summary>
    /// [disabled],是否禁用, 默认值: false
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// [nzDanger],是否危险状态, 默认值: false
    /// </summary>
    public string Danger { get; set; }
    /// <summary>
    /// [nzLoading],是否加载状态, 默认值: false
    /// </summary>
    public string Loading { get; set; }
    /// <summary>
    /// [nzGhost],是否幽灵按钮,幽灵按钮将按钮的内容反色，背景变为透明，常用在有色背景上, 默认值: false
    /// </summary>
    public string Ghost { get; set; }
    /// <summary>
    /// [nzBlock],将按钮宽度调整为父容器宽度, 默认值: false
    /// </summary>
    public string Block { get; set; }
    /// <summary>
    /// 扩展属性, 设置图标
    /// </summary>
    public AntDesignIcon Icon { get; set; }
    /// <summary>
    /// 扩展属性, 当按钮在表单中, 是否验证表单,如果设置为 true, 表单无效时禁用按钮, 默认值: false
    /// </summary>
    public bool ValidateForm { get; set; }
    /// <summary>
    /// 扩展属性, 是否提交按钮,如果设置为 true,添加 type='submit', 默认值: false
    /// </summary>
    public bool IsSubmit { get; set; }
    /// <summary>
    /// 扩展属性,将内容复制到剪贴板,设置复制内容的引用
    /// </summary>
    public string CopyToClipboard { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new ButtonRender( config );
    }
}