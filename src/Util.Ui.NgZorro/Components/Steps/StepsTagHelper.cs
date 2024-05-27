using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Steps.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Steps; 

/// <summary>
/// 步骤条,生成的标签为&lt;nz-steps&gt;&lt;/nz-steps&gt;
/// </summary>
[HtmlTargetElement( "util-steps" )]
public class StepsTagHelper : AngularTagHelperBase {
    /// <summary>
    /// nzType,步骤条类型,可选值: 'default' | 'navigation', 默认值: 'default'
    /// </summary>
    public StepsType Type { get; set; }
    /// <summary>
    /// [nzType],步骤条类型,可选值: 'default' | 'navigation', 默认值: 'default'
    /// </summary>
    public string BindType { get; set; }
    /// <summary>
    /// [nzCurrent],指定当前步骤，从 `0` 开始记数。在 &lt;util-step> 中，可通过 status 覆盖状态,类型: number, 默认值: 0
    /// </summary>
    public string Current { get; set; }
    /// <summary>
    /// nzSize,步骤条尺寸,可选值: 'default' | 'small', 默认值:  'default'
    /// </summary>
    public StepsSize Size { get; set; }
    /// <summary>
    /// [nzSize],步骤条尺寸,可选值: 'default' | 'small', 默认值:  'default'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// [nzStartIndex],起始位置的序号,类型: number, 默认值: 0
    /// </summary>
    public string StartIndex { get; set; }
    /// <summary>
    /// nzDirection,步骤条方向,可选值: 'vertical' | 'horizontal' ,默认值:  'horizontal'
    /// </summary>
    public StepsDirection Direction { get; set; }
    /// <summary>
    /// [nzDirection],步骤条方向,可选值: 'vertical' | 'horizontal' ,默认值:  'horizontal'
    /// </summary>
    public string BindDirection { get; set; }
    /// <summary>
    /// nzStatus,当前步骤的状态,可选值: 'wait' | 'process' | 'finish' | 'error',默认值: 'process'
    /// </summary>
    public StepStatus Status { get; set; }
    /// <summary>
    /// [nzStatus],当前步骤的状态,可选值: 'wait' | 'process' | 'finish' | 'error',默认值: 'process'
    /// </summary>
    public string BindStatus { get; set; }
    /// <summary>
    /// [nzProgressDot],点状步骤条, 类型: boolean | TemplateRef&lt;{ $implicit: TemplateRef&lt;void>, status: string, index: number }>, 默认值: false
    /// </summary>
    public string ProgressDot { get; set; }
    /// <summary>
    /// nzLabelPlacement,标签位置，可选值:  'horizontal' | 'vertical', 默认值: 'horizontal'
    /// </summary>
    public StepsLabelPlacement LabelPlacement { get; set; }
    /// <summary>
    /// [nzLabelPlacement],标签位置，可选值:  'horizontal' | 'vertical', 默认值: 'horizontal'
    /// </summary>
    public string BindLabelPlacement { get; set; }
    /// <summary>
    /// (nzIndexChange),步骤索引变化事件,点击步骤时触发,类型: EventEmitter&lt;number>
    /// </summary>
    public string OnIndexChange { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new StepsRender( config );
    }
}