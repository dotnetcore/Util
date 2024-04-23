using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Paginations.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Paginations; 

/// <summary>
/// 分页,生成的标签为&lt;nz-pagination&gt;&lt;/nz-pagination&gt;
/// </summary>
[HtmlTargetElement( "util-pagination" )]
public class PaginationTagHelper : AngularTagHelperBase {
    /// <summary>
    /// [nzTotal],总行数
    /// </summary>
    public string Total { get; set; }
    /// <summary>
    /// [nzPageIndex],当前页, 默认值: 1
    /// </summary>
    public string PageIndex { get; set; }
    /// <summary>
    /// [(nzPageIndex)],当前页, 默认值: 1
    /// </summary>
    public string BindonPageIndex { get; set; }
    /// <summary>
    /// [nzPageSize],每页显示行数, 默认值: 10
    /// </summary>
    public string PageSize { get; set; }
    /// <summary>
    /// [(nzPageSize)],每页显示行数, 默认值: 10
    /// </summary>
    public string BindonPageSize { get; set; }
    /// <summary>
    /// [nzShowSizeChanger],是否显示改变分页大小按钮, 默认值: false
    /// </summary>
    public string ShowSizeChanger { get; set; }
    /// <summary>
    /// [nzShowQuickJumper],是否显示快速跳转, 默认值: false
    /// </summary>
    public string ShowQuickJumper { get; set; }
    /// <summary>
    /// [nzDisabled],是否禁用, 默认值: false
    /// </summary>
    public string Disabled { get; set; }
    /// <summary>
    /// nzSize,分页尺寸,可选值: 'default' | 'small'
    /// </summary>
    public PaginationSize Size { get; set; }
    /// <summary>
    /// [nzSize],分页尺寸,可选值: 'default' | 'small'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// [nzShowTotal],设置显示总行数和当前数据范围的模板
    /// </summary>
    public string ShowTotal { get; set; }
    /// <summary>
    /// [nzSimple],是否显示为简单分页
    /// </summary>
    public string Simple { get; set; }
    /// <summary>
    /// [nzResponsive],响应式,根据屏幕宽度自动调整尺寸,未指定 nzSize 时有效, 默认值: false
    /// </summary>
    public string Responsive { get; set; }
    /// <summary>
    /// [nzPageSizeOptions],设置每页显示行数选择列表,默认值: [10, 20, 30, 40]
    /// </summary>
    public string PageSizeOptions { get; set; }
    /// <summary>
    /// [nzItemRender],自定义页码结构
    /// </summary>
    public string ItemRender { get; set; }
    /// <summary>
    /// [nzHideOnSinglePage],只有一页时是否隐藏分页器, 默认值: false
    /// </summary>
    public string HideOnSinglePage { get; set; }
    /// <summary>
    /// (nzPageIndexChange),页码变化事件,类型: EventEmitter&lt;number>
    /// </summary>
    public string OnPageIndexChange { get; set; }
    /// <summary>
    /// (nzPageSizeChange),每页显示行数变化事件,类型: EventEmitter&lt;number>
    /// </summary>
    public string OnPageSizeChange { get; set; }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new PaginationRender( config );
    }
}