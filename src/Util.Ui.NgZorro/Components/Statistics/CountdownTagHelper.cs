using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Statistics.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Statistics; 

/// <summary>
/// 倒计时,生成的标签为&lt;nz-countdown>&lt;/nz-countdown>
/// </summary>
[HtmlTargetElement( "util-countdown" )]
public class CountdownTagHelper : StatisticTagHelper {
    /// <summary>
    /// nzFormat,格式化字符串，默认值: 'HH:mm:ss',格式说明：年(Y) 月(M) 日(D) 时(H) 分(m) 秒(s) 毫秒(S)
    /// </summary>
    public string Format { get; set; }
    /// <summary>
    /// [nzFormat],格式化字符串，默认值: 'HH:mm:ss',格式说明：年(Y) 月(M) 日(D) 时(H) 分(m) 秒(s) 毫秒(S)
    /// </summary>
    public string BindFormat { get; set; }
    /// <summary>
    /// (nzCountdownFinish),倒计时完成事件, 类型: EventEmitter&lt;void>
    /// </summary>
    public string OnCountdownFinish { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new CountdownRender( config );
    }
}