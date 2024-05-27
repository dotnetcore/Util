using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.DatePickers.Helpers;
using Util.Ui.NgZorro.Components.DatePickers.Renders;
using Util.Ui.NgZorro.Components.Inputs.Helpers;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.DatePickers; 

/// <summary>
/// 日期范围选择,生成的标签为&lt;nz-range-picker&gt;&lt;/nz-range-picker&gt;
/// </summary>
[HtmlTargetElement( "util-range-picker" )]
public class RangePickerTagHelper : DatePickerTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// nzDefaultPickerValue,默认面板日期,类型: Date[]
    /// </summary>
    public string DefaultPickerValue { get; set; }
    /// <summary>
    /// [nzDefaultPickerValue],默认面板日期,类型: Date[]
    /// </summary>
    public string BindDefaultPickerValue { get; set; }
    /// <summary>
    /// [nzDisabledTime],不可选择时间函数,类型：(current: Date, partial: 'start' | 'end') => { nzDisabledHours, nzDisabledMinutes, nzDisabledSeconds }
    /// </summary>
    public string DisabledTime { get; set; }
    /// <summary>
    /// [nzRanges],预设时间范围，类型：{ [ key: string ]: Date[] } | { [ key: string ]: () => Date[] }
    /// </summary>
    public string Ranges { get; set; }
    /// <summary>
    /// nzSeparator,分隔符,默认值：'~'
    /// </summary>
    public string Separator { get; set; }
    /// <summary>
    /// [nzSeparator],分隔符,默认值：'~'
    /// </summary>
    public string BindSeparator { get; set; }
    /// <summary>
    /// [(beginDate)],扩展属性, 双向绑定起始日期
    /// </summary>
    public string BeginDate { get; set; }
    /// <summary>
    /// [(endDate)],扩展属性, 双向绑定结束日期
    /// </summary>
    public string EndDate { get; set; }
    /// <summary>
    /// 起始日期属性表达式
    /// </summary>
    public ModelExpression ForBegin { get; set; }
    /// <summary>
    /// 结束日期属性表达式
    /// </summary>
    public ModelExpression ForEnd { get; set; }
    /// <summary>
    /// (nzOnCalendarChange),待选日期变化事件, 类型: EventEmitter&lt;Date[]>
    /// </summary>
    public string OnCalendarChange { get; set; }
    /// <summary>
    /// (nzOnOk),点击确定按钮事件, 类型: EventEmitter&lt;Date[]>
    /// </summary>
    public string OnOk { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var rangePickerService = new RangePickerService( _config );
        rangePickerService.Init();
        var service = new InputService( _config );
        service.Init();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new RangePickerRender( _config );
    }
}