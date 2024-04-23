using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.QrCodes.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.QrCodes;

/// <summary>
/// 二维码,生成的标签为&lt;nz-qrcode&gt;&lt;/nz-qrcode&gt;
/// </summary>
[HtmlTargetElement( "util-qrcode" )]
public class QrCodeTagHelper : AngularTagHelperBase {
    /// <summary>
    /// nzValue,值
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// [nzValue],值
    /// </summary>
    public string BindValue { get; set; }
    /// <summary>
    /// nzColor,二维码颜色, 默认值: #000
    /// </summary>
    public string Color { get; set; }
    /// <summary>
    /// [nzColor],二维码颜色, 默认值: #000
    /// </summary>
    public string BindColor { get; set; }
    /// <summary>
    /// nzBgColor,背景色, 默认值: #FFFFFF
    /// </summary>
    public string BgColor { get; set; }
    /// <summary>
    /// [nzBgColor],背景色, 默认值: #FFFFFF
    /// </summary>
    public string BindBgColor { get; set; }
    /// <summary>
    /// [nzSize],尺寸, 默认值: 160
    /// </summary>
    public string Size { get; set; }
    /// <summary>
    /// [nzPadding], 填充, 类型: number | number[] , 默认值: 0
    /// </summary>
    public string Padding { get; set; }
    /// <summary>
    /// nzIcon,图标地址
    /// </summary>
    public string Icon { get; set; }
    /// <summary>
    /// [nzIcon],图标地址
    /// </summary>
    public string BindIcon { get; set; }
    /// <summary>
    /// [nzIconSize],图标尺寸, 默认值: 40
    /// </summary>
    public string IconSize { get; set; }
    /// <summary>
    /// [nzBordered],是否显示边框, 默认值: true
    /// </summary>
    public string Bordered { get; set; }
    /// <summary>
    /// nzStatus,状态, 可选值: 'active'｜'expired' ｜'loading' , 默认值: 'active'
    /// </summary>
    public QrCodeStatus Status { get; set; }
    /// <summary>
    /// [nzStatus],状态, 可选值: 'active'｜'expired' ｜'loading' , 默认值: 'active'
    /// </summary>
    public string BindStatus { get; set; }
    /// <summary>
    /// nzLevel,容错级别, 可选值: 'L'｜'M'｜'Q'｜'H', 默认值: 'M'
    /// </summary>
    public QrCodeCorrectionLevel Level { get; set; }
    /// <summary>
    /// [nzLevel],容错级别, 可选值: 'L'｜'M'｜'Q'｜'H', 默认值: 'M'
    /// </summary>
    public string BindLevel { get; set; }
    /// <summary>
    /// (nzRefresh), "点击刷新"链接单击事件,类型: EventEmitter&lt;string>
    /// </summary>
    public string OnRefresh { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new QrCodeRender( config );
    }
}