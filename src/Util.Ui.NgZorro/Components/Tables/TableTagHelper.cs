using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Components.Tables.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Tables; 

/// <summary>
/// 表格,生成的标签为&lt;nz-table>&lt;/nz-table>
/// </summary>
[HtmlTargetElement( "util-table" )]
public class TableTagHelper : AngularTagHelperBase {
    /// <summary>
    /// 配置
    /// </summary>
    private Config _config;
    /// <summary>
    /// 扩展属性,表格标识,保存表格设置参数时作为存储键, 必须全局唯一
    /// </summary>
    public string Key { get; set; }
    /// <summary>
    /// 扩展属性,是否启用自动创建嵌套结构,默认为 true
    /// </summary>
    public bool EnableAutoCreate { get; set; }
    /// <summary>
    /// 扩展属性,是否启用扩展指令,当设置Api地址时自动启用,默认为 false
    /// </summary>
    public bool EnableExtend { get; set; }
    /// <summary>
    /// 扩展属性[(queryParam)],查询参数
    /// </summary>
    public string QueryParam { get; set; }
    /// <summary>
    /// 扩展属性 url,Api地址
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// 扩展属性 [url],Api地址
    /// </summary>
    public string BindUrl { get; set; }
    /// <summary>
    /// 扩展属性 deleteUrl,删除地址，注意：由于支持批量删除，所以采用Post提交，如果未设置该属性,则使用Url属性构造删除地址,范例：/api/test/delete
    /// </summary>
    public string DeleteUrl { get; set; }
    /// <summary>
    /// 扩展属性 [deleteUrl],删除地址，注意：由于支持批量删除，所以采用Post提交，如果未设置该属性,则使用Url属性构造删除地址,范例：/api/test/delete
    /// </summary>
    public string BindDeleteUrl { get; set; }
    /// <summary>
    /// 扩展属性 [autoLoad],初始化时是否自动加载数据，默认为true,设置成false则手工加载
    /// </summary>
    public bool AutoLoad { get; set; }
    /// <summary>
    /// 扩展属性,是否显示复选框,已提供复选框联动功能
    /// </summary>
    public bool ShowCheckbox { get; set; }
    /// <summary>
    /// 扩展属性,是否显示单选框
    /// </summary>
    public bool ShowRadio { get; set; }
    /// <summary>
    /// 扩展属性,是否显示序号
    /// </summary>
    public bool ShowLineNumber { get; set; }
    /// <summary>
    /// 扩展属性,固定左侧复选框列,当设置ShowCheckbox为true有效
    /// </summary>
    public string CheckboxLeft { get; set; }
    /// <summary>
    /// 扩展属性,固定左侧单选框列,当设置ShowRadio为true有效
    /// </summary>
    public string RadioLeft { get; set; }
    /// <summary>
    /// 扩展属性,固定左侧序号列,当设置ShowLineNumber为true有效
    /// </summary>
    public string LineNumberLeft { get; set; }
    /// <summary>
    /// 扩展属性 [checkedKeys],选中的标识列表，用于还原选中的复选框或单选框，可以是单个Id或Id数组，范例：'1' 或 ['1','2']
    /// </summary>
    public string CheckedKeys { get; set; }
    /// <summary>
    /// 扩展属性 order,排序条件,范例: creationTime desc
    /// </summary>
    public string Sort { get; set; }
    /// <summary>
    /// 扩展属性 [order],排序条件,范例: creationTime desc
    /// </summary>
    public string BindSort { get; set; }
    /// <summary>
    /// 扩展属性,点击表格行时是否选中该行,可同时选中多行,选中行被添加名为 table-row-selected 的 class类名, 默认值: false
    /// </summary>
    public bool SelectOnClickRow { get; set; }
    /// <summary>
    /// 扩展属性,点击表格行时是否选中该行,仅选中该行,取消其它选中的行,选中行被添加名为 table-row-selected 的 class类名, 默认值: false
    /// </summary>
    public bool SelectOnlyOnClickRow { get; set; }
    /// <summary>
    /// 扩展属性, 点击表格行时是否选中复选框或单选框, 默认值: false
    /// </summary>
    public bool CheckOnClickRow { get; set; }
    /// <summary>
    /// [nzData],数据,类型: any[]
    /// </summary>
    public string Data { get; set; }
    /// <summary>
    /// [nzFrontPagination],是否前端分页,默认值: true
    /// </summary>
    public string FrontPagination { get; set; }
    /// <summary>
    /// [nzTotal],数据总行数,当服务端渲染时传入
    /// </summary>
    public string Total { get; set; }
    /// <summary>
    /// [nzPageIndex],当前页
    /// </summary>
    public string PageIndex { get; set; }
    /// <summary>
    /// [(nzPageIndex)],当前页
    /// </summary>
    public string BindonPageIndex { get; set; }
    /// <summary>
    /// [nzPageSize],每页显示行数
    /// </summary>
    public string PageSize { get; set; }
    /// <summary>
    /// [(nzPageSize)],每页显示行数
    /// </summary>
    public string BindonPageSize { get; set; }
    /// <summary>
    /// [nzShowPagination],是否显示分页,默认值: true
    /// </summary>
    public string ShowPagination { get; set; }
    /// <summary>
    /// nzPaginationPosition,指定分页显示的位置,可选值: 'top' | 'bottom' | 'both',默认值: 'bottom'
    /// </summary>
    public TablePaginationPosition PaginationPosition { get; set; }
    /// <summary>
    /// [nzPaginationPosition],指定分页显示的位置,可选值: 'top' | 'bottom' | 'both',默认值: 'bottom'
    /// </summary>
    public string BindPaginationPosition { get; set; }
    /// <summary>
    /// nzPaginationType,指定分页显示的尺寸,可选值: 'default' | 'small',默认值: 'default'
    /// </summary>
    public TablePaginationSize PaginationType { get; set; }
    /// <summary>
    /// [nzPaginationType],指定分页显示的尺寸,可选值: 'default' | 'small',默认值: 'default'
    /// </summary>
    public string BindPaginationType { get; set; }
    /// <summary>
    /// [nzBordered],是否显示外边框和列边框,默认值: false
    /// </summary>
    public string Bordered { get; set; }
    /// <summary>
    /// [nzOuterBordered],是否显示外边框,默认值: false
    /// </summary>
    public string OuterBordered { get; set; }
    /// <summary>
    /// [nzWidthConfig],表头分组时指定每列宽度，与 th 的 [nzWidth] 不可混用,类型: string[],默认值: []
    /// </summary>
    public string WidthConfig { get; set; }
    /// <summary>
    /// nzSize,表格大小,可选值: 'middle' | 'small' | 'default',默认值: 'default'
    /// </summary>
    public TableSize Size { get; set; }
    /// <summary>
    /// [nzSize],表格大小,可选值: 'middle' | 'small' | 'default',默认值: 'default'
    /// </summary>
    public string BindSize { get; set; }
    /// <summary>
    /// [nzLoading],是否加载状态,默认值: false
    /// </summary>
    public string Loading { get; set; }
    /// <summary>
    /// [nzLoadingIndicator],加载指示符,类型: TemplateRef&lt;void>
    /// </summary>
    public string LoadingIndicator { get; set; }
    /// <summary>
    /// [nzLoadingDelay],延迟显示加载效果的时间（防止闪烁）,默认值: 0
    /// </summary>
    public string LoadingDelay { get; set; }
    /// <summary>
    /// [nzScroll],用于支持横向或纵向滚动,设置滚动区域的宽高度,范例: { x: "300px", y: "300px" }
    /// </summary>
    public string Scroll { get; set; }
    /// <summary>
    /// 扩展属性 [nzScroll], 内容区滚动高度,用于支持固定表头，范例：400，表示 [nzScroll]="{ y: '400px' }"
    /// </summary>
    public string ScrollHeight { get; set; }
    /// <summary>
    /// 扩展属性 [nzScroll], 滚动宽度,用于支持固定列，范例：400，表示 [nzScroll]="{ x: '400px' }"
    /// </summary>
    public string ScrollWidth { get; set; }
    /// <summary>
    /// nzTitle,表格标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// [nzTitle],表格标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindTitle { get; set; }
    /// <summary>
    /// nzFooter,表格底部,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string Footer { get; set; }
    /// <summary>
    /// [nzFooter],表格底部,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindFooter { get; set; }
    /// <summary>
    /// nzNoResult,无数据时显示内容,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string NoResult { get; set; }
    /// <summary>
    /// [nzNoResult],无数据时显示内容,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindNoResult { get; set; }
    /// <summary>
    /// [nzPageSizeOptions],每页行数选择列表,类型: number[],默认值: [ 10, 20, 30, 40, 50 ]
    /// </summary>
    public string PageSizeOptions { get; set; }
    /// <summary>
    /// [nzShowQuickJumper],是否显示分页快速跳转,默认值: false
    /// </summary>
    public string ShowQuickJumper { get; set; }
    /// <summary>
    /// [nzShowSizeChanger],是否显示改变分页大小按钮,默认值: false,当启用扩展时自动设置为 true
    /// </summary>
    public string ShowSizeChanger { get; set; }
    /// <summary>
    /// [nzShowTotal],设置显示总行数和当前数据范围的模板,类型: TemplateRef&lt;{ $implicit: number, range: [ number, number ] }>
    /// </summary>
    public string ShowTotal { get; set; }
    /// <summary>
    /// [nzItemRender],自定义页码结构,类型: TemplateRef&lt;{ $implicit: 'page' | 'prev' | 'next', page: number }>
    /// </summary>
    public string ItemRender { get; set; }
    /// <summary>
    /// [nzHideOnSinglePage],只有一页时是否隐藏分页器,默认值: false
    /// </summary>
    public string HideOnSinglePage { get; set; }
    /// <summary>
    /// [nzSimple],是否显示简单分页
    /// </summary>
    public string Simple { get; set; }
    /// <summary>
    /// [nzTemplateMode],是否模板模式,无需将数据传递给 nzData,默认值: false
    /// </summary>
    public string TemplateMode { get; set; }
    /// <summary>
    /// [nzVirtualItemSize],虚拟滚动时每一列的高度,单位:像素,默认值: 0
    /// </summary>
    public string VirtualItemSize { get; set; }
    /// <summary>
    /// [nzVirtualMaxBufferPx],虚拟滚动缓冲区最大高度,单位:像素,默认值: 200
    /// </summary>
    public string VirtualMaxBufferPx { get; set; }
    /// <summary>
    /// [nzVirtualMinBufferPx],虚拟滚动缓冲区最小高度，低于该值时将加载新结构,单位:像素,默认值: 100
    /// </summary>
    public string VirtualMinBufferPx { get; set; }
    /// <summary>
    /// [nzVirtualForTrackBy],虚拟滚动数据 TrackByFunction 函数，类型: TrackByFunction&lt;T>
    /// </summary>
    public string VirtualForTrackBy { get; set; }
    /// <summary>
    /// nzTableLayout,表格布局,可选值: 'fixed' | 'auto'
    /// </summary>
    public TableLayout Layout { get; set; }
    /// <summary>
    /// [nzTableLayout],表格布局,可选值: 'fixed' | 'auto'
    /// </summary>
    public string BindLayout { get; set; }
    /// <summary>
    /// [nzCustomColumn],自定义列, 控制表格列的展示与排序, 类型: NzCustomColumn[], 注意: 开启后 nzWidthConfig 和 th 的 nzWidth 将不生效
    /// </summary>
    public string CustomColumn { get; set; }
    /// <summary>
    /// 扩展属性,是否启用表格设置,将启用表格设置的全部功能, 默认值: false
    /// </summary>
    public bool EnableTableSettings { get; set; }
    /// <summary>
    /// 扩展属性,是否启用自定义列,默认值: false
    /// </summary>
    public bool EnableCustomColumn { get; set; }
    /// <summary>
    /// 扩展属性,是否启用拖动调整列宽,默认值: false
    /// </summary>
    public bool EnableResizable { get; set; }
    /// <summary>
    /// 扩展属性,是否启用固定列,默认值: false
    /// </summary>
    public bool EnableFixedColumn { get; set; }
    /// <summary>
    /// 扩展属性 [isBatch],是否批量编辑, false表示单行编辑模式,true表示批量编辑模式,一次性保存所有更改, 默认值: false
    /// </summary>
    public bool IsBatchEdit { get; set; }
    /// <summary>
    /// (nzPageIndexChange),页码变化事件,类型: EventEmitter&lt;number>
    /// </summary>
    public string OnPageIndexChange { get; set; }
    /// <summary>
    /// (nzPageSizeChange),每页显示行数变化事件,类型: EventEmitter&lt;number>
    /// </summary>
    public string OnPageSizeChange { get; set; }
    /// <summary>
    /// (nzCurrentPageDataChange),当前页数据变化事件,类型: EventEmitter&lt;any[]>
    /// </summary>
    public string OnCurrentPageDataChange { get; set; }
    /// <summary>
    /// (nzQueryParams),查询参数变化事件,当服务端分页、筛选、排序时，用于获得参数，类型: EventEmitter&lt;NzTableQueryParams>
    /// </summary>
    public string OnQueryParams { get; set; }
    /// <summary>
    /// 扩展事件 (onLoad),数据加载完成事件,类型: EventEmitter&lt;any>,参数为服务端返回结果
    /// </summary>
    public string OnLoad { get; set; }
    /// <summary>
    /// 扩展事件,行单击事件，使用row访问行对象，范例：on-click-row="click(row)"
    /// </summary>
    public string OnClickRow { get; set; }

    /// <inheritdoc />
    protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
        _config = new Config( context, output );
        var service = new TableService( _config );
        service.Init();
    }

    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        _config.Content = content;
        return new TableRender( _config );
    }
}