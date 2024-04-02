using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.ColorPickers.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.ColorPickers;

/// <summary>
/// 颜色块,生成的标签为&lt;nz-color-block&gt;&lt;/nz-color-block&gt;
/// </summary>
[HtmlTargetElement( "util-color-block" )]
public class ColorBlockTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// nzColor, 颜色值, 默认值: #1677ff
    /// </summary>
    public string Color { get; set; }
    /// <summary>
    /// [nzColor], 颜色值, 默认值: #1677ff
    /// </summary>
    public string BindColor { get; set; }
    /// <summary>
    /// nzSize,控件尺寸, 可选值: 'default' | 'small' |  'large' , 默认值: 'default'
    /// </summary>
    public InputSize Size { get; set; }
    /// <summary>
    /// [nzSize],控件尺寸, 可选值: 'default' | 'small' |  'large' , 默认值: 'default'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// (nzOnClick),点击事件 ,类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnClick { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new ColorBlockRender( _config );
    }
}