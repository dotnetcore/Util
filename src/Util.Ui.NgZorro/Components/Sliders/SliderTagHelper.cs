using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Sliders.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Sliders {
    /// <summary>
    /// 滑动输入条,生成的标签为&lt;nz-slider&gt;&lt;/nz-slider&gt;
    /// </summary>
    [HtmlTargetElement( "util-slider" )]
    public class SliderTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [nzDots],是否只能拖拽到刻度上,默认值: false
        /// </summary>
        public bool Dots { get; set; }
        /// <summary>
        /// [nzDots],是否只能拖拽到刻度上,默认值: false
        /// </summary>
        public string BindDots { get; set; }
        /// <summary>
        /// [nzIncluded],是否包含关系,marks 不为空对象时有效，值为 true 时表示值为包含关系，false 表示并列,默认值: true
        /// </summary>
        public bool Included { get; set; }
        /// <summary>
        /// [nzIncluded],是否包含关系,marks 不为空对象时有效，值为 true 时表示值为包含关系，false 表示并列,默认值: true
        /// </summary>
        public string BindIncluded { get; set; }
        /// <summary>
        /// [nzMarks],刻度标记，key 的类型必须为 number 且取值在闭区间 [min, max] 内，每个标签可以单独设置样式,范例:{ 0: '0°C', 26: '26°C', 37: '37°C', 100: {style: {color: '#f50'},label: '&lt;strong>100°C&lt;/strong>'} }
        /// </summary>
        public string Marks { get; set; }
        /// <summary>
        /// nzMax,最大值,默认值: 100
        /// </summary>
        public double Max { get; set; }
        /// <summary>
        /// [nzMax],最大值,默认值: 100
        /// </summary>
        public string BindMax { get; set; }
        /// <summary>
        /// nzMin,最小值,默认值: 0
        /// </summary>
        public double Min { get; set; }
        /// <summary>
        /// [nzMin],最小值,默认值: 0
        /// </summary>
        public string BindMin { get; set; }
        /// <summary>
        /// [nzRange],是否启用双滑块模式,默认值: false
        /// </summary>
        public bool Range { get; set; }
        /// <summary>
        /// [nzRange],是否启用双滑块模式,默认值: false
        /// </summary>
        public string BindRange { get; set; }
        /// <summary>
        /// nzStep,步长，取值必须大于 0，并且可被 (max - min) 整除。当 marks 不为空对象时，可以设置 step 为 null，此时可选值仅有 marks 标出来的部分。默认值: 1
        /// </summary>
        public double Step { get; set; }
        /// <summary>
        /// [nzStep],步长，取值必须大于 0，并且可被 (max - min) 整除。当 marks 不为空对象时，可以设置 step 为 null，此时可选值仅有 marks 标出来的部分。默认值: 1
        /// </summary>
        public string BindStep { get; set; }
        /// <summary>
        /// [nzTipFormatter],提示格式化函数,把当前值传给该函数,并在 Tooltip 中显示它的返回值，若为 null，则隐藏 Tooltip,函数定义: (value: number) => string
        /// </summary>
        public string TipFormatter { get; set; }
        /// <summary>
        /// [nzVertical],是否垂直方向,默认值: false
        /// </summary>
        public bool Vertical { get; set; }
        /// <summary>
        /// [nzVertical],是否垂直方向,默认值: false
        /// </summary>
        public string BindVertical { get; set; }
        /// <summary>
        /// [nzReverse],是否反向,默认值: false
        /// </summary>
        public bool Reverse { get; set; }
        /// <summary>
        /// [nzReverse],是否反向,默认值: false
        /// </summary>
        public string BindReverse { get; set; }
        /// <summary>
        /// nzTooltipVisible,提示可见性,可选值: 'default' | 'always' | 'never',值为 always 时总是显示，值为 never 时在任何情况下都不显示
        /// </summary>
        public SliderTooltipVisible TooltipVisible { get; set; }
        /// <summary>
        /// [nzTooltipVisible],提示可见性,可选值: 'default' | 'always' | 'never',值为 always 时总是显示，值为 never 时在任何情况下都不显示
        /// </summary>
        public string BindTooltipVisible { get; set; }
        /// <summary>
        /// nzTooltipPlacement,提示位置,可选值: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom'
        /// </summary>
        public TooltipPlacement TooltipPlacement { get; set; }
        /// <summary>
        /// [nzTooltipPlacement],提示位置,可选值: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom'
        /// </summary>
        public string BindTooltipPlacement { get; set; }
        /// <summary>
        /// (nzOnAfterChange),变更后事件,与 onmouseup 触发时机一致，把当前值作为参数传入,类型: 	EventEmitter&lt;number[] | number>
        /// </summary>
        public string OnAfterChange { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new SliderRender( config );
        }
    }
}