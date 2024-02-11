using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.NgZorro.Components.Forms.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms; 

/// <summary>
/// 查询表单,生成的标签为&lt;form nz-form&gt;&lt;/form&gt;
/// </summary>
[HtmlTargetElement( "util-search-form" )]
public class SearchFormTagHelper : FormTagHelper {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// 扩展属性, 初始显示的查询条件数量,默认值: 3, 超过该数量的查询条件将被隐藏,注意: 该数量不包含操作
    /// </summary>
    public int ShowNumber { get; set; }
    /// <summary>
    /// 扩展属性,每行显示几列,仅对 xxl 宽度有效,默认值: 4 , 可选值: 4,6
    /// </summary>
    public int ColumnsNumber { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new FormShareService( _config );
        service.SetSearchForm();
        service.Init();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new FormRender( _config );
    }
}