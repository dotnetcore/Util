using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Steps.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Steps {
    /// <summary>
    /// 步骤条,生成的标签为&lt;nz-steps&gt;&lt;/nz-steps&gt;
    /// </summary>
    [HtmlTargetElement( "util-steps" )]
    public class StepsTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzType,步骤条类型,可选值: 'default' | 'navigation'
        /// </summary>
        public StepsType Type { get; set; }
        /// <summary>
        /// [nzType],步骤条类型,可选值: 'default' | 'navigation'
        /// </summary>
        public string BindType { get; set; }
        /// <summary>
        /// [nzCurrent],指定当前步骤，从 0 开始记数,在子 nz-step 元素中，可以通过 nzStatus 属性覆盖状态
        /// </summary>
        public int Current { get; set; }
        /// <summary>
        /// [nzCurrent],指定当前步骤，从 0 开始记数,在子 nz-step 元素中，可以通过 nzStatus 属性覆盖状态
        /// </summary>
        public string BindCurrent { get; set; }
        /// <summary>
        /// nzSize,步骤条尺寸,可选值: 'default' | 'small'
        /// </summary>
        public StepsSize Size { get; set; }
        /// <summary>
        /// [nzSize],步骤条尺寸,可选值: 'default' | 'small'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// [nzStartIndex],起始位置的序号,默认值: 0
        /// </summary>
        public int StartIndex { get; set; }
        /// <summary>
        /// [nzStartIndex],起始位置的序号,默认值: 0
        /// </summary>
        public string BindStartIndex { get; set; }
        /// <summary>
        /// nzDirection,步骤条方向,可选值: 'vertical' | 'horizontal'
        /// </summary>
        public StepsDirection Direction { get; set; }
        /// <summary>
        /// [nzDirection],步骤条方向,可选值: 'vertical' | 'horizontal'
        /// </summary>
        public string BindDirection { get; set; }
        /// <summary>
        /// nzStatus,当前步骤的状态,可选值: 'wait' | 'process' | 'finish' | 'error'
        /// </summary>
        public StepStatus Status { get; set; }
        /// <summary>
        /// [nzStatus],当前步骤的状态,可选值: 'wait' | 'process' | 'finish' | 'error'
        /// </summary>
        public string BindStatus { get; set; }
        /// <summary>
        /// [nzProgressDot],点状步骤条
        /// </summary>
        public bool ProgressDot { get; set; }
        /// <summary>
        /// [nzProgressDot],点状步骤条
        /// </summary>
        public string BindProgressDot { get; set; }
        /// <summary>
        /// nzLabelPlacement,标签放置位置，默认水平放图标右侧，可选 vertical 放图标下方,可选值:  'horizontal' | 'vertical'
        /// </summary>
        public StepsLabelPlacement LabelPlacement { get; set; }
        /// <summary>
        /// [nzLabelPlacement],标签放置位置，默认水平放图标右侧，可选 vertical 放图标下方,可选值:  'horizontal' | 'vertical'
        /// </summary>
        public string BindLabelPlacement { get; set; }
        /// <summary>
        /// (nzIndexChange),点击单个步骤时触发的事件
        /// </summary>
        public string OnIndexChange { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new StepsRender( config );
        }
    }
}