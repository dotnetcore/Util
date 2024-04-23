using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.WaterMarks.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.WaterMarks;

/// <summary>
/// 水印,生成的标签为&lt;nz-water-mark&gt;&lt;/nz-water-mark&gt;
/// </summary>
[HtmlTargetElement( "util-water-mark" )]
public class WaterMarkTagHelper : AngularTagHelperBase {
    /// <summary>
    /// nzContent,水印文字内容, 类型: string ｜ string[]
    /// </summary>
    public string Content { get; set; }
    /// <summary>
    /// [nzContent],水印文字内容, 类型: string ｜ string[]
    /// </summary>
    public string BindContent { get; set; }
    /// <summary>
    /// [nzWidth],水印宽度, 默认值: 120
    /// </summary>
    public string Width { get; set; }
    /// <summary>
    /// [nzHeight],水印高度, 默认值: 64
    /// </summary>
    public string Height { get; set; }
    /// <summary>
    /// [nzRotate],旋转角度, 默认值: -22
    /// </summary>
    public string Rotate { get; set; }
    /// <summary>
    /// [nzZIndex],水印元素的 z-index, 默认值: 9
    /// </summary>
    public string ZIndex { get; set; }
    /// <summary>
    /// nzImage,水印图片地址
    /// </summary>
    public string Image { get; set; }
    /// <summary>
    /// [nzImage],水印图片地址
    /// </summary>
    public string BindImage { get; set; }
    /// <summary>
    /// [nzFont],文字样式
    /// </summary>
    public string Font { get; set; }
    /// <summary>
    /// [nzFont],字体颜色, 默认值: rgba(0,0,0,.15)
    /// </summary>
    public string FontColor { get; set; }
    /// <summary>
    /// [nzFont],字体大小, 默认值: 16
    /// </summary>
    public double FontSize { get; set; }
    /// <summary>
    /// [nzFont],字体粗细, 可选值: normal ｜ light ｜ weight ｜ number,  默认值: normal
    /// </summary>
    public string FontWeight { get; set; }
    /// <summary>
    /// [nzFont],字体类型, 默认值: sans-serif
    /// </summary>
    public string FontFamily { get; set; }
    /// <summary>
    /// [nzFont],字体样式, 可选值: 	none ｜ normal ｜ italic ｜ oblique, 默认值: normal
    /// </summary>
    public string FontStyle { get; set; }
    /// <summary>
    /// [nzGap],水印之间的间距, 类型: [number, number], 默认值: [100, 100]
    /// </summary>
    public string Gap { get; set; }
    /// <summary>
    /// [nzOffset],水印距离容器左上角的偏移量, 类型: [number, number], 默认值: [nzGap[0]/2, nzGap[1]/2]
    /// </summary>
    public string Offset { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new WaterMarkRender( config );
    }
}