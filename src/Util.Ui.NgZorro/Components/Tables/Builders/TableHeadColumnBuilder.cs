using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表头单元格标签生成器
    /// </summary>
    public class TableHeadColumnBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _shareConfig;

        /// <summary>
        /// 初始化表头单元格标签生成器
        /// </summary>
        public TableHeadColumnBuilder( Config config ) : base( "th" ) {
            _config = config;
            _shareConfig = GetTableShareConfig();
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        private TableShareConfig GetTableShareConfig() {
            return _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
        }

        /// <summary>
        /// 配置是否显示复选框
        /// </summary>
        public TableHeadColumnBuilder ShowCheckbox() {
            AttributeIfNotEmpty( "[nzShowCheckbox]", _config.GetBoolValue( UiConst.ShowCheckbox ) );
            AttributeIfNotEmpty( "[nzShowCheckbox]", _config.GetValue( AngularConst.BindShowCheckbox ) );
            return this;
        }

        /// <summary>
        /// 配置是否禁用复选框
        /// </summary>
        public TableHeadColumnBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置复选框是否中间状态
        /// </summary>
        public TableHeadColumnBuilder Indeterminate() {
            AttributeIfNotEmpty( "[nzIndeterminate]", _config.GetValue( UiConst.Indeterminate ) );
            return this;
        }

        /// <summary>
        /// 配置是否选中复选框
        /// </summary>
        public TableHeadColumnBuilder Checked() {
            AttributeIfNotEmpty( "[nzChecked]", _config.GetBoolValue( UiConst.Checked ) );
            AttributeIfNotEmpty( "[nzChecked]", _config.GetValue( AngularConst.BindChecked ) );
            AttributeIfNotEmpty( "[(nzChecked)]", _config.GetValue( AngularConst.BindonChecked ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示下拉选择
        /// </summary>
        public TableHeadColumnBuilder ShowRowSelection() {
            AttributeIfNotEmpty( "[nzShowRowSelection]", _config.GetBoolValue( UiConst.ShowRowSelection ) );
            AttributeIfNotEmpty( "[nzShowRowSelection]", _config.GetValue( AngularConst.BindShowRowSelection ) );
            return this;
        }

        /// <summary>
        /// 配置下拉选择的内容
        /// </summary>
        public TableHeadColumnBuilder Selections() {
            AttributeIfNotEmpty( "[nzSelections]", _config.GetValue( UiConst.Selections ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示排序
        /// </summary>
        public TableHeadColumnBuilder ShowSort() {
            AttributeIfNotEmpty( "[nzShowSort]", _config.GetBoolValue( UiConst.ShowSort ) );
            AttributeIfNotEmpty( "[nzShowSort]", _config.GetValue( AngularConst.BindShowSort ) );
            return this;
        }

        /// <summary>
        /// 配置排序函数
        /// </summary>
        public TableHeadColumnBuilder SortFn() {
            AttributeIfNotEmpty( "[nzSortFn]", _config.GetValue( UiConst.SortFn ) );
            return this;
        }

        /// <summary>
        /// 配置支持的排序方式
        /// </summary>
        public TableHeadColumnBuilder SortDirections() {
            AttributeIfNotEmpty( "[nzSortDirections]", _config.GetValue( UiConst.SortDirections ) );
            return this;
        }

        /// <summary>
        /// 配置排序方向
        /// </summary>
        public TableHeadColumnBuilder SortOrder() {
            AttributeIfNotEmpty( "nzSortOrder", _config.GetValue( UiConst.SortOrder ) );
            AttributeIfNotEmpty( "[nzSortOrder]", _config.GetValue( AngularConst.BindSortOrder ) );
            AttributeIfNotEmpty( "[(nzSortOrder)]", _config.GetValue( AngularConst.BindonSortOrder ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示过滤
        /// </summary>
        public TableHeadColumnBuilder ShowFilter() {
            AttributeIfNotEmpty( "[nzShowFilter]", _config.GetBoolValue( UiConst.ShowFilter ) );
            AttributeIfNotEmpty( "[nzShowFilter]", _config.GetValue( AngularConst.BindShowFilter ) );
            return this;
        }

        /// <summary>
        /// 配置过滤函数
        /// </summary>
        public TableHeadColumnBuilder FilterFn() {
            AttributeIfNotEmpty( "[nzFilterFn]", _config.GetValue( UiConst.FilterFn ) );
            return this;
        }

        /// <summary>
        /// 配置过滤器
        /// </summary>
        public TableHeadColumnBuilder Filters() {
            AttributeIfNotEmpty( "[nzFilters]", _config.GetValue( UiConst.Filters ) );
            return this;
        }

        /// <summary>
        /// 配置是否多选过滤器
        /// </summary>
        public TableHeadColumnBuilder FilterMultiple() {
            AttributeIfNotEmpty( "[nzFilterMultiple]", _config.GetBoolValue( UiConst.FilterMultiple ) );
            AttributeIfNotEmpty( "[nzFilterMultiple]", _config.GetValue( AngularConst.BindFilterMultiple ) );
            return this;
        }

        /// <summary>
        /// 配置列宽
        /// </summary>
        public TableHeadColumnBuilder Width() {
            this.Width( _config.GetValue( UiConst.Width ) );
            BindWidth( _config.GetValue( AngularConst.BindWidth ) );
            return this;
        }

        /// <summary>
        /// 配置列宽
        /// </summary>
        public TableHeadColumnBuilder BindWidth( string value ) {
            AttributeIfNotEmpty( "[nzWidth]", value );
            return this;
        }

        /// <summary>
        /// 配置左侧距离
        /// </summary>
        public TableHeadColumnBuilder Left() {
            AttributeIfNotEmpty( "[nzLeft]", _config.GetBoolValue( UiConst.Left ) );
            AttributeIfNotEmpty( "[nzLeft]", _config.GetValue( AngularConst.BindLeft ) );
            return this;
        }

        /// <summary>
        /// 配置右侧距离
        /// </summary>
        public TableHeadColumnBuilder Right() {
            AttributeIfNotEmpty( "[nzRight]", _config.GetBoolValue( UiConst.Right ) );
            AttributeIfNotEmpty( "[nzRight]", _config.GetValue( AngularConst.BindRight ) );
            return this;
        }

        /// <summary>
        /// 配置对齐方式
        /// </summary>
        public TableHeadColumnBuilder Align() {
            AttributeIfNotEmpty( "nzAlign", _config.GetValue<TableHeadColumnAlign?>( UiConst.Align )?.Description() );
            AttributeIfNotEmpty( "[nzAlign]", _config.GetValue( AngularConst.BindAlign ) );
            return this;
        }

        /// <summary>
        /// 配置是否折行显示
        /// </summary>
        public TableHeadColumnBuilder BreakWord() {
            AttributeIfNotEmpty( "[nzBreakWord]", _config.GetBoolValue( UiConst.BreakWord ) );
            AttributeIfNotEmpty( "[nzBreakWord]", _config.GetValue( AngularConst.BindBreakWord ) );
            return this;
        }

        /// <summary>
        /// 配置自动省略
        /// </summary>
        public TableHeadColumnBuilder Ellipsis() {
            AttributeIfNotEmpty( "[nzEllipsis]", _config.GetBoolValue( UiConst.Ellipsis ) );
            AttributeIfNotEmpty( "[nzEllipsis]", _config.GetValue( AngularConst.BindEllipsis ) );
            return this;
        }

        /// <summary>
        /// 配置列跨度
        /// </summary>
        public TableHeadColumnBuilder Colspan() {
            AttributeIfNotEmpty( "colSpan", _config.GetValue( UiConst.Colspan ) );
            AttributeIfNotEmpty( "[colSpan]", _config.GetValue( AngularConst.BindColspan ) );
            return this;
        }

        /// <summary>
        /// 配置行跨度
        /// </summary>
        public TableHeadColumnBuilder Rowspan() {
            AttributeIfNotEmpty( "rowSpan", _config.GetValue( UiConst.Rowspan ) );
            AttributeIfNotEmpty( "[rowSpan]", _config.GetValue( AngularConst.BindRowspan ) );
            return this;
        }

        /// <summary>
        /// 配置列标识
        /// </summary>
        public TableHeadColumnBuilder ColumnKey() {
            AttributeIfNotEmpty( "nzColumnKey", _config.GetValue( UiConst.ColumnKey ) );
            AttributeIfNotEmpty( "[nzColumnKey]", _config.GetValue( AngularConst.BindColumnKey ) );
            return this;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public TableHeadColumnBuilder Title() {
            Title( _config.GetValue( UiConst.Title ) );
            return this;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        /// <param name="title">标题</param>
        public TableHeadColumnBuilder Title( string title ) {
            if ( title.IsEmpty() == false )
                AppendContent( title );
            return this;
        }

        /// <summary>
        /// 配置序号标题
        /// </summary>
        public TableHeadColumnBuilder LineNumber() {
            if ( GetColumnType() == TableColumnType.LineNumber )
                Title( _shareConfig.GetLineNumberTitle() );
            return this;
        }

        /// <summary>
        /// 获取列类型
        /// </summary>
        private TableColumnType? GetColumnType() {
            return _config.GetValue<TableColumnType?>( UiConst.Type );
        }

        /// <summary>
        /// 配置复选框
        /// </summary>
        public TableHeadColumnBuilder CheckBox() {
            return CheckBox( GetColumnType() == TableColumnType.Checkbox );
        }

        /// <summary>
        /// 配置复选框
        /// </summary>
        protected TableHeadColumnBuilder CheckBox( bool isCheckBox ) {
            if ( isCheckBox == false )
                return this;
            Attribute( "[nzShowCheckbox]", $"{_shareConfig.TableExtendId}.multiple" );
            Attribute( "(nzCheckedChange)", $"{_shareConfig.TableExtendId}.masterToggle()" );
            Attribute( "[nzChecked]", $"{_shareConfig.TableExtendId}.isMasterChecked()" );
            Attribute( "[nzDisabled]", $"!{_shareConfig.TableExtendId}.dataSource.length" );
            Attribute( "[nzIndeterminate]", $"{_shareConfig.TableExtendId}.isMasterIndeterminate()" );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TableHeadColumnBuilder Events() {
            AttributeIfNotEmpty( "(nzCheckedChange)", _config.GetValue( UiConst.OnCheckedChange ) );
            AttributeIfNotEmpty( "(nzSortOrderChange)", _config.GetValue( UiConst.OnSortOrderChange ) );
            AttributeIfNotEmpty( "(nzFilterChange)", _config.GetValue( UiConst.OnFilterChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            ShowCheckbox().Disabled().Indeterminate().Checked()
                .ShowRowSelection().Selections()
                .ShowSort().SortFn().SortDirections().SortOrder()
                .ShowFilter().FilterFn().Filters().FilterMultiple()
                .Width().Left().Right().Align().BreakWord().Ellipsis()
                .Colspan().Rowspan().ColumnKey()
                .Title().LineNumber().CheckBox()
                .Events();
        }

        /// <summary>
        /// 添加表头单元格组件
        /// </summary>
        /// <param name="column">列</param>
        public void AddComponents( ColumnInfo column ) {
            Title( column.Title );
            CheckBox( column.IsCheckbox );
            AddWidth( column );
        }

        /// <summary>
        /// 添加宽度
        /// </summary>
        private void AddWidth( ColumnInfo column ) {
            if ( column.IsCheckbox || column.IsLineNumber ) {
                BindWidth( column.Width );
                return;
            }
            this.Width( column.Width );
        }
    }
}