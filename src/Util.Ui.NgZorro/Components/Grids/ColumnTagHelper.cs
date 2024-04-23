using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Grids.Helpers;
using Util.Ui.NgZorro.Components.Grids.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Grids; 

/// <summary>
/// 栅格列,生成的标签为&lt;div nz-col&gt;&lt;/div&gt;
/// </summary>
[HtmlTargetElement( "util-column" )]
public class ColumnTagHelper : ColumnTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// 标识
    /// </summary>
    private readonly string _id;

    /// <summary>
    /// 初始化栅格列
    /// </summary>
    public ColumnTagHelper() {
        _id = Guid.NewGuid().ToString();
    }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new ColumnService( _config );
        service.Init( _id );
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new ColumnRender( config, _id );
    }
}