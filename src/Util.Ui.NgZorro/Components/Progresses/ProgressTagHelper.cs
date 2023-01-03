using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Progresses.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Progresses {
    /// <summary>
    /// 进度条,生成的标签为&lt;nz-progress>&lt;/nz-progress>
    /// </summary>
    [HtmlTargetElement( "util-progress" )]
    public class ProgressTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzType,进度条类型,可选值: 'line' | 'circle' | 'dashboard',默认值: 'line'
        /// </summary>
        public ProgressType Type { get; set; }
        /// <summary>
        /// [nzType],进度条类型,可选值: 'line' | 'circle' | 'dashboard',默认值: 'line'
        /// </summary>
        public string BindType { get; set; }
        /// <summary>
        /// [nzFormat],格式化函数,用于自定义显示内容,类型: (percent: number) => string | TemplateRef&lt;{ $implicit: number }>,默认值: percent => percent + '%'
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// nzPercent,百分比,类型: number,默认值: 0
        /// </summary>
        public double Percent { get; set; }
        /// <summary>
        /// [nzPercent],百分比,类型: number,默认值: 0
        /// </summary>
        public string BindPercent { get; set; }
        /// <summary>
        /// [nzShowInfo],是否显示进度数值或状态图标,默认值: true
        /// </summary>
        public bool ShowInfo { get; set; }
        /// <summary>
        /// [nzShowInfo],是否显示进度数值或状态图标,默认值: true
        /// </summary>
        public string BindShowInfo { get; set; }
        /// <summary>
        /// nzStatus,进度条状态,可选值: 'success' | 'exception' | 'active' | 'normal'
        /// </summary>
        public ProgressStatus Status { get; set; }
        /// <summary>
        /// [nzStatus],进度条状态,可选值: 'success' | 'exception' | 'active' | 'normal'
        /// </summary>
        public string BindStatus { get; set; }
        /// <summary>
        /// nzStrokeLinecap,进度条端点形状,可选值: 'round' | 'square',默认值: 'round'
        /// </summary>
        public ProgressStrokeLinecap StrokeLinecap { get; set; }
        /// <summary>
        /// [nzStrokeLinecap],进度条端点形状,可选值: 'round' | 'square',默认值: 'round'
        /// </summary>
        public string BindStrokeLinecap { get; set; }
        /// <summary>
        /// nzStrokeColor,进度条颜色，传入对象时为渐变,类型: string | { from: string; to: string: direction: string; [percent: string]: string }
        /// </summary>
        public string StrokeColor { get; set; }
        /// <summary>
        /// [nzStrokeColor],进度条颜色，传入对象时为渐变,类型: string | { from: string; to: string: direction: string; [percent: string]: string }
        /// </summary>
        public string BindStrokeColor { get; set; }
        /// <summary>
        /// nzSuccessPercent,已完成的分段百分比,类型: number,默认值: 0
        /// </summary>
        public double SuccessPercent { get; set; }
        /// <summary>
        /// [nzSuccessPercent],已完成的分段百分比,类型: number,默认值: 0
        /// </summary>
        public string BindSuccessPercent { get; set; }
        /// <summary>
        /// nzStrokeWidth,线条宽度,当 nzType="line" 时,单位为像素，默认值为8。当 nzType为 "circle" 或 "dashboard" 时,单位是进度条画布宽度的百分比，默认值为6。
        /// </summary>
        public double StrokeWidth { get; set; }
        /// <summary>
        /// [nzStrokeWidth],线条宽度,当 nzType="line" 时,单位为像素，默认值为8。当 nzType为 "circle" 或 "dashboard" 时,单位是进度条画布宽度的百分比，默认值为6。
        /// </summary>
        public string BindStrokeWidth { get; set; }
        /// <summary>
        /// nzSteps,进度条总步数,仅在 nzType="line" 时有效,类型: number
        /// </summary>
        public int Steps { get; set; }
        /// <summary>
        /// [nzSteps],进度条总步数,仅在 nzType="line" 时有效,类型: number
        /// </summary>
        public string BindSteps { get; set; }
        /// <summary>
        /// nzWidth,画布宽度,单位为像素，当 nzType为 "circle" 或 "dashboard" 时有效,默认值为132。
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// [nzWidth],画布宽度,单位为像素，当 nzType为 "circle" 或 "dashboard" 时有效,默认值为132。
        /// </summary>
        public string BindWidth { get; set; }
        /// <summary>
        /// nzGapDegree,仪表盘进度条缺口角度,可取值 0 ~ 360，当 nzType="dashboard" 时有效，默认值为0。
        /// </summary>
        public double GapDegree { get; set; }
        /// <summary>
        /// [nzGapDegree],仪表盘进度条缺口角度,可取值 0 ~ 360，当 nzType="dashboard" 时有效，默认值为0。
        /// </summary>
        public string BindGapDegree { get; set; }
        /// <summary>
        /// nzGapPosition,表盘进度条缺口位置,当 nzType="dashboard" 时有效，可选值: 'top' | 'right' | 'bottom' | 'left',默认值: 'top'
        /// </summary>
        public ProgressGapPosition GapPosition { get; set; }
        /// <summary>
        /// [nzGapPosition],表盘进度条缺口位置,当 nzType="dashboard" 时有效，可选值: 'top' | 'right' | 'bottom' | 'left',默认值: 'top'
        /// </summary>
        public string BindGapPosition { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ProgressRender( config );
        }
    }
}