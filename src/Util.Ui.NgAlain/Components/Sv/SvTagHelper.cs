using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Sv.Helpers;
using Util.Ui.NgAlain.Components.Sv.Renders;
using Util.Ui.NgAlain.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.Sv;

/// <summary>
/// ng-alain 查看列组件,生成的标签为&lt;sv&gt;&lt;/sv&gt;
/// </summary>
[HtmlTargetElement( "util-descriptions-x-item" )]
[HtmlTargetElement( "util-sv" )]
public class SvTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// 扩展属性, 属性表达式
    /// </summary>
    public ModelExpression For { get; set; }
    /// <summary>
    /// [col], 占几列显示
    /// </summary>
    public string Column { get; set; }
    /// <summary>
    /// label, 标签, 支持i18n, 类型: string | TemplateRef&lt;void>
    /// </summary>
    public string Label { get; set; }
    /// <summary>
    /// [label], 标签, 类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindLabel { get; set; }
    /// <summary>
    /// unit, 单位, 类型: string | TemplateRef&lt;void>
    /// </summary>
    public string Unit { get; set; }
    /// <summary>
    /// [unit], 单位, 类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindUnit { get; set; }
    /// <summary>
    /// [default], 是否显示默认文本
    /// </summary>
    public string Default { get; set; }
    /// <summary>
    /// type, 类型, 可选值: 'primary','success','danger','warning'
    /// </summary>
    public SvType Type { get; set; }
    /// <summary>
    /// [type], 类型, 可选值: 'primary','success','danger','warning'
    /// </summary>
    public string BindType { get; set; }
    /// <summary>
    /// optional, 标签可选信息, 类型: string | TemplateRef&lt;void>
    /// </summary>
    public string Optional { get; set; }
    /// <summary>
    /// [optional], 标签可选信息, 类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindOptional { get; set; }
    /// <summary>
    /// optionalHelp, 标签可选帮助, 类型: string | TemplateRef&lt;void>
    /// </summary>
    public string OptionalHelp { get; set; }
    /// <summary>
    /// [optionalHelp], 标签可选帮助, 类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindOptionalHelp { get; set; }
    /// <summary>
    /// optionalHelpColor, 标签可选帮助背景颜色
    /// </summary>
    public string OptionalHelpColor { get; set; }
    /// <summary>
    /// [optionalHelpColor], 标签可选帮助背景颜色
    /// </summary>
    public string BindOptionalHelpColor { get; set; }
    /// <summary>
    /// [noColon], 是否不显示标签后面的冒号, 默认值: false
    /// </summary>
    public string NoColon { get; set; }
    /// <summary>
    /// [hideLabel], 是否隐藏标签, 默认值: false
    /// </summary>
    public string HideLabel { get; set; }
    /// <summary>
    /// 扩展属性,内容值,自动包含在 {{}} 中,范例: 设置为 model.name, 内容为 {{model.name}}
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// 扩展属性,值是否支持多语言,设置为 true 添加i18n管道,默认值: false, 范例: value="model.name",value-i18n="true", 内容为 {{model.name|i18n}}
    /// </summary>
    public bool ValueI18n { get; set; }
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
        var loader = new SvExpressionLoader();
        loader.Load( _config );
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new SvRender( _config );
    }
}