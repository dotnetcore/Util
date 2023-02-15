using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Components.Tables.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Tables {
    /// <summary>
    /// 表头单元格,生成的标签为&lt;th>&lt;/th>
    /// </summary>
    [HtmlTargetElement( "util-th" )]
    public class TableHeadColumnTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 扩展属性,设置排序属性
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 标题,扩展属性,支持i18n
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// operation标题,扩展属性,是否显示operation标题文本,默认文本为'Operation',i18n文本为'util.operation'
        /// </summary>
        public bool TitleOperation { get; set; }
        /// <summary>
        /// 表格列类型,扩展属性
        /// </summary>
        public TableColumnType Type { get; set; }
        /// <summary>
        /// [nzShowCheckbox],是否显示复选框
        /// </summary>
        public bool ShowCheckbox { get; set; }
        /// <summary>
        /// [nzShowCheckbox],是否显示复选框
        /// </summary>
        public string BindShowCheckbox { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用复选框
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用复选框
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [nzIndeterminate],复选框是否中间状态
        /// </summary>
        public string Indeterminate { get; set; }
        /// <summary>
        /// [nzChecked],是否选中复选框
        /// </summary>
        public bool Checked { get; set; }
        /// <summary>
        /// [nzChecked],是否选中复选框
        /// </summary>
        public string BindChecked { get; set; }
        /// <summary>
        /// [(nzChecked)],是否选中复选框
        /// </summary>
        public string BindonChecked { get; set; }
        /// <summary>
        /// [nzShowRowSelection],是否显示下拉选择
        /// </summary>
        public bool ShowRowSelection { get; set; }
        /// <summary>
        /// [nzShowRowSelection],是否显示下拉选择
        /// </summary>
        public string BindShowRowSelection { get; set; }
        /// <summary>
        /// [nzSelections],下拉选择的内容,类型: Array&lt;{ text: string, onSelect: any }>
        /// </summary>
        public string Selections { get; set; }
        /// <summary>
        /// [nzShowSort],是否显示排序
        /// </summary>
        public bool ShowSort { get; set; }
        /// <summary>
        /// [nzShowSort],是否显示排序
        /// </summary>
        public string BindShowSort { get; set; }
        /// <summary>
        /// [nzSortFn],排序函数，前端排序传入函数，服务端排序传入 true,函数定义: (a: any, b: any, sortOrder?: string) => number,说明:参考 Array.sort 的 compareFunction
        /// </summary>
        public string SortFn { get; set; }
        /// <summary>
        /// [nzSortDirections],支持的排序方式，取值为 'ascend', 'descend', null,类型: Array&lt;'ascend' | 'descend' | null>,默认值: ['ascend', 'descend', null]
        /// </summary>
        public string SortDirections { get; set; }
        /// <summary> 
        /// nzSortOrder,当前排序方向,可选值: 'ascend' | 'descend',默认值: 'ascend'
        /// </summary>
        public string SortOrder { get; set; }
        /// <summary> 
        /// [nzSortOrder],当前排序方向,可选值: 'ascend' | 'descend',默认值: 'ascend'
        /// </summary>
        public string BindSortOrder { get; set; }
        /// <summary> 
        /// [(nzSortOrder)],当前排序方向,可选值: 'ascend' | 'descend',默认值: 'ascend'
        /// </summary>
        public string BindonSortOrder { get; set; }
        /// <summary>
        /// [nzShowFilter],是否显示过滤
        /// </summary>
        public bool ShowFilter { get; set; }
        /// <summary>
        /// [nzShowFilter],是否显示过滤
        /// </summary>
        public string BindShowFilter { get; set; }
        /// <summary>
        /// [nzFilterFn],过滤函数，前端排序过滤传入函数，服务端排序传入 true,函数定义: (value: any, data: any) => boolean
        /// </summary>
        public string FilterFn { get; set; }
        /// <summary>
        /// [nzFilters],过滤器内容，类型: Array&lt;{ text: string; value: any; byDefault?: boolean }>
        /// </summary>
        public string Filters { get; set; }
        /// <summary>
        /// [nzFilterMultiple],是否多选过滤器,默认值: true
        /// </summary>
        public bool FilterMultiple { get; set; }
        /// <summary>
        /// [nzFilterMultiple],是否多选过滤器,默认值: true
        /// </summary>
        public string BindFilterMultiple { get; set; }
        /// <summary>
        /// nzWidth,列宽度,表头未分组时可用,设置数值,则默认单位为px，范例：100，表示100px，也可以使用百分比,范例: 20%
        /// </summary>
        public string Width { get; set; }
        /// <summary>
        /// [nzWidth],列宽度,表头未分组时可用,可以使用像素值，也可以使用百分比
        /// </summary>
        public string BindWidth { get; set; }
        /// <summary>
        /// [nzLeft],左侧距离，用于固定左侧列，当为 true 时自动计算，为 false 时停止固定,类型: string | boolean,默认值: false
        /// </summary>
        public bool Left { get; set; }
        /// <summary>
        /// [nzLeft],左侧距离，用于固定左侧列，当为 true 时自动计算，为 false 时停止固定,类型: string | boolean,默认值: false
        /// </summary>
        public string BindLeft { get; set; }
        /// <summary>
        /// [nzRight],右侧距离，用于固定右侧列，当为 true 时自动计算，为 false 时停止固定,类型: string | boolean,默认值: false
        /// </summary>
        public bool Right { get; set; }
        /// <summary>
        /// [nzRight],右侧距离，用于固定右侧列，当为 true 时自动计算，为 false 时停止固定,类型: string | boolean,默认值: false
        /// </summary>
        public string BindRight { get; set; }
        /// <summary>
        /// nzAlign,设置列内容的对齐方式,可选值: 'left' | 'right' | 'center'
        /// </summary>
        public TableHeadColumnAlign Align { get; set; }
        /// <summary>
        /// [nzAlign],设置列内容的对齐方式,可选值: 'left' | 'right' | 'center'
        /// </summary>
        public string BindAlign { get; set; }
        /// <summary>
        /// [nzBreakWord],是否折行显示,默认值: false
        /// </summary>
        public bool BreakWord { get; set; }
        /// <summary>
        /// [nzBreakWord],是否折行显示,默认值: false
        /// </summary>
        public string BindBreakWord { get; set; }
        /// <summary>
        /// [nzEllipsis],超过宽度将自动省略，暂不支持和排序筛选一起使用,仅当表格布局为 nzTableLayout="fixed" 时可用,默认值: false
        /// </summary>
        public bool Ellipsis { get; set; }
        /// <summary>
        /// [nzEllipsis],超过宽度将自动省略，暂不支持和排序筛选一起使用,仅当表格布局为 nzTableLayout="fixed" 时可用,默认值: false
        /// </summary>
        public string BindEllipsis { get; set; }
        /// <summary>
        /// colSpan,列跨度,每单元格中扩展列的数量
        /// </summary>
        public int Colspan { get; set; }
        /// <summary>
        /// [colSpan],列跨度,每单元格中扩展列的数量
        /// </summary>
        public string BindColspan { get; set; }
        /// <summary>
        /// rowSpan,行跨度,每单元格中扩展行的数量
        /// </summary>
        public int Rowspan { get; set; }
        /// <summary>
        /// [rowSpan],行跨度,每单元格中扩展行的数量
        /// </summary>
        public string BindRowspan { get; set; }
        /// <summary>
        /// nzColumnKey,当前列标识，用于服务端筛选和排序使用
        /// </summary>
        public string ColumnKey { get; set; }
        /// <summary>
        /// [nzColumnKey],当前列标识，用于服务端筛选和排序使用
        /// </summary>
        public string BindColumnKey { get; set; }
        /// <summary>
        /// (nzCheckedChange),复选框选中状态变化事件,类型: EventEmitter&lt;boolean>
        /// </summary>
        public string OnCheckedChange { get; set; }
        /// <summary>
        /// (nzSortOrderChange),排序方向变化事件,类型: EventEmitter&lt;'descend' | 'ascend' | null>
        /// </summary>
        public string OnSortOrderChange { get; set; }
        /// <summary>
        /// (nzFilterChange),过滤条件变化事件,类型: EventEmitter&lt;any[] | any>
        /// </summary>
        public string OnFilterChange { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new TableHeadColumnService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new TableHeadColumnRender( _config );
        }
    }
}