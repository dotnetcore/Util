using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Steps.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Steps;

/// <summary>
/// 步骤,生成的标签为&lt;nz-step&gt;&lt;/nz-step&gt;,放在&lt;util-steps&gt;&lt;/util-steps&gt;中使用
/// </summary>
[HtmlTargetElement( "util-step" )]
public class StepTagHelper : AngularTagHelperBase {
    /// <summary>
    /// nzTitle,标题,支持多语言
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// [nzTitle],标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindTitle { get; set; }
    /// <summary>
    /// nzSubtitle,子标题,支持多语言
    /// </summary>
    public string Subtitle { get; set; }
    /// <summary>
    /// [nzSubtitle],子标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindSubtitle { get; set; }
    /// <summary>
    /// nzDescription,描述
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// [nzDescription],描述,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindDescription { get; set; }
    /// <summary>
    /// nzIcon,图标
    /// </summary>
    public AntDesignIcon Icon { get; set; }
    /// <summary>
    /// [nzIcon],图标,类型: string | string[] | Set&lt;string> | { [klass: string]: any; } | TemplateRef&lt;void>
    /// </summary>
    public string BindIcon { get; set; }
    /// <summary>
    /// nzStatus,状态,当不配置该属性时，使用 &lt;util-steps> 的 current 指定状态,可选值: 'wait' | 'process' | 'finish' | 'error',默认值: 'wait'
    /// </summary>
    public StepStatus Status { get; set; }
    /// <summary>
    /// [nzStatus],状态,当不配置该属性时，使用 &lt;util-steps> 的 current 指定状态,可选值: 'wait' | 'process' | 'finish' | 'error',默认值: 'wait'
    /// </summary>
    public string BindStatus { get; set; }
    /// <summary>
    /// [nzDisabled],是否禁用点击, 默认值: false
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// [nzPercentage],当前状态为 `process` 的步骤所显示的进度百分比, 类型: number
    /// </summary>
    public string Percentage { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new StepRender( config );
    }
}