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
    /// 表格单元格,生成的标签为&lt;td>&lt;/td>
    /// </summary>
    [HtmlTargetElement( "util-td" )]
    public class TableColumnTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 扩展属性,是否启用排序
        /// </summary>
        public bool Sort { get; set; }
        /// <summary>
        /// 标题,扩展属性,支持i18n
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// operation标题,扩展属性,是否显示operation标题文本,默认文本为'Operation',i18n文本为'util.operation'
        /// </summary>
        public bool TitleOperation { get; set; }
        /// <summary>
        /// 列名,扩展属性
        /// </summary>
        public string Column { get; set; }
        /// <summary>
        /// 是否编辑列,扩展属性,默认值：false
        /// </summary>
        public bool IsEdit { get; set; }
        /// <summary>
        /// nzWidth,列宽度,表头未分组时可用,设置数值,则默认单位为px，范例：100，表示100px，也可以使用百分比,范例: 20%
        /// </summary>
        public string Width { get; set; }
        /// <summary>
        /// [nzShowCheckbox],是否显示复选框,注意:此属性为ng-zorro原生属性,未提供复选框联动功能,请设置表格上的show-checkbox属性
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
        /// [nzShowExpand],是否显示展开按钮
        /// </summary>
        public bool ShowExpand { get; set; }
        /// <summary>
        /// [nzShowExpand],是否显示展开按钮
        /// </summary>
        public string BindShowExpand { get; set; }
        /// <summary>
        /// [nzExpand],是否已展开
        /// </summary>
        public bool Expand { get; set; }
        /// <summary>
        /// [nzExpand],是否已展开
        /// </summary>
        public string BindExpand { get; set; }
        /// <summary>
        /// [(nzExpand)],是否已展开
        /// </summary>
        public string BindonExpand { get; set; }
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
        /// nzIndentSize,展示树形数据时，每层缩进的宽度,单位: px
        /// </summary>
        public double IndentSize { get; set; }
        /// <summary>
        /// [nzIndentSize],展示树形数据时，每层缩进的宽度,单位: px
        /// </summary>
        public string BindIndentSize { get; set; }
        /// <summary>
        /// (nzCheckedChange),复选框选中状态变化事件,类型: EventEmitter&lt;boolean>
        /// </summary>
        public string OnCheckedChange { get; set; }
        /// <summary>
        /// (nzExpandChange),展开状态变化事件,类型: EventEmitter&lt;boolean>
        /// </summary>
        public string OnExpandChange { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new TableColumnService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new TableColumnRender( _config );
        }
    }
}