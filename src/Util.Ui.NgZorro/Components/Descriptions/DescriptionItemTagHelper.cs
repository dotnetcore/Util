using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Descriptions.Renders;
using Util.Ui.NgZorro.Components.Display.Helpers;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Descriptions; 

/// <summary>
/// 描述列表项,生成的标签为&lt;nz-descriptions-item>&lt;/nz-descriptions-item>
/// </summary>
[HtmlTargetElement( "util-descriptions-item" )]
public class DescriptionItemTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// 扩展属性, 属性表达式
    /// </summary>
    public ModelExpression For { get; set; }
    /// <summary>
    /// nzTitle,标题,支持i18n
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// [nzTitle],标题,类型: string|TemplateRef&lt;void>
    /// </summary>
    public string BindTitle { get; set; }
    /// <summary>
    /// 扩展属性,内容值,自动包含在 {{}} 中,范例: 设置为 model.name, 内容为 {{model.name}}
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// 扩展属性,值是否支持多语言,设置为 true 添加i18n管道,默认值: false, 范例: value="model.name",value-i18n="true", 内容为 {{model.name|i18n}}
    /// </summary>
    public bool ValueI18n { get; set; }
    /// <summary>
    /// [nzSpan],包含列的数量,默认值: 1
    /// </summary>
    public string Span { get; set; }
    /// <summary>
    /// 日期格式化字符串，默认值: yyyy-MM-dd HH:mm:ss,仅在使用属性表达式For时有效,格式说明：
    /// 1. 年 - yyyy
    /// 2. 月 - MM
    /// 3. 日 - dd
    /// 4. 时 - HH
    /// 5. 分 - mm
    /// 6. 秒 - ss
    /// 7. 毫秒 - SSS
    /// </summary>
    public string DateFormat { get; set; }
    /// <summary>
    /// 扩展属性 [cdkCopyToClipboard],是否允许复制到剪贴板,注意: 需要设置 value 属性
    /// </summary>
    public bool Clipboard { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        LoadExpression();
    }

    /// <summary>
    /// 加载表达式
    /// </summary>
    private void LoadExpression() {
        var loader = new DisplayExpressionLoader();
        loader.Load( _config );
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new DescriptionItemRender( _config );
    }
}