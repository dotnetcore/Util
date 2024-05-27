using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.DatePickers.Renders;
using Util.Ui.NgZorro.Components.Inputs.Helpers;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.DatePickers; 

/// <summary>
/// 日期选择,生成的标签为&lt;nz-date-picker&gt;&lt;/nz-date-picker&gt;
/// </summary>
[HtmlTargetElement( "util-date-picker" )]
public class DatePickerTagHelper : DatePickerTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// nzDefaultPickerValue,默认面板日期,类型: Date
    /// </summary>
    public string DefaultPickerValue { get; set; }
    /// <summary>
    /// [nzDefaultPickerValue],默认面板日期,类型: Date
    /// </summary>
    public string BindDefaultPickerValue { get; set; }
    /// <summary>
    /// [nzDisabledTime],不可选择时间函数,类型：(current: Date) => { nzDisabledHours, nzDisabledMinutes, nzDisabledSeconds }
    /// </summary>
    public string DisabledTime { get; set; }
    /// <summary>
    /// [nzShowToday],是否显示“今天”按钮,注意：仅在 nzMode="date" 时有效
    /// </summary>
    public string ShowToday { get; set; }
    /// <summary>
    /// [nzShowNow],是否显示“此刻”按钮,注意：仅在 nzMode="date"，且 [nzShowTime]="true" 时有效
    /// </summary>
    public string ShowNow { get; set; }
    /// <summary>
    /// (nzOnOk),点击确定按钮事件, 类型: EventEmitter&lt;Date>
    /// </summary>
    public string OnOk { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new InputService( _config );
        service.Init();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new DatePickerRender( _config );
    }
}