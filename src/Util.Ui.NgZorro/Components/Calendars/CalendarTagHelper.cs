using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Calendars.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Calendars {
    /// <summary>
    /// 日历,生成的标签为&lt;nz-calendar>&lt;/nz-calendar>
    /// </summary>
    [HtmlTargetElement( "util-calendar" )]
    public class CalendarTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [(ngModel)],模型双向绑定
        /// </summary>
        public string NgModel { get; set; }
        /// <summary>
        /// [ngModel],模型绑定
        /// </summary>
        public string BindNgModel { get; set; }
        /// <summary>
        /// nzMode,显示模式,可选值: 'month' | 'year',默认值: 'month'
        /// </summary>
        public CalendarMode Mode { get; set; }
        /// <summary>
        /// [nzMode],显示模式,可选值: 'month' | 'year',默认值: 'month'
        /// </summary>
        public string BindMode { get; set; }
        /// <summary>
        /// [(nzMode)],显示模式,可选值: 'month' | 'year',默认值: 'month'
        /// </summary>
        public string BindonMode { get; set; }
        /// <summary>
        /// [nzFullscreen],是否全屏显示,默认值: true
        /// </summary>
        public bool Fullscreen { get; set; }
        /// <summary>
        /// [nzFullscreen],是否全屏显示,默认值: true
        /// </summary>
        public string BindFullscreen { get; set; }
        /// <summary>
        /// [nzDateCell],自定义渲染日期单元格模板，模版内容会被追加到单元格,类型: TemplateRef&lt;Date>
        /// </summary>
        public string DateCell { get; set; }
        /// <summary>
        /// [nzDateFullCell],自定义渲染日期单元格模板，模版内容覆盖单元格,类型: TemplateRef&lt;Date>
        /// </summary>
        public string DateFullCell { get; set; }
        /// <summary>
        /// [nzMonthCell],自定义渲染月单元格模板，模版内容会被追加到单元格,类型: TemplateRef&lt;Date>
        /// </summary>
        public string MonthCell { get; set; }
        /// <summary>
        /// [nzMonthFullCell],自定义渲染月单元格模板，模版内容覆盖单元格,类型: TemplateRef&lt;Date>
        /// </summary>
        public string MonthFullCell { get; set; }
        /// <summary>
        /// [nzDisabledDate],不可选择日期函数,类型: (current: Date) => boolean
        /// </summary>
        public string DisabledDate { get; set; }
        /// <summary>
        /// (nzPanelChange),面板变化事件,类型: EventEmitter&lt;{ date: Date, mode: 'month' | 'year' }>
        /// </summary>
        public string OnPanelChange { get; set; }
        /// <summary>
        /// (nzSelectChange),选择日期变化事件,类型: EventEmitter&lt;Date>
        /// </summary>
        public string OnSelectChange { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new CalendarRender( config );
        }
    }
}