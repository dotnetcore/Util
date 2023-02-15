using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表头单元格标签生成器
    /// </summary>
    public class TableHeadColumnBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表头列共享配置
        /// </summary>
        private readonly TableHeadColumnShareConfig _shareConfig;

        /// <summary>
        /// 初始化表头单元格标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="shareConfig">表头列共享配置</param>
        public TableHeadColumnBuilder( Config config, TableHeadColumnShareConfig shareConfig ) : base( config,"th" ) {
            _config = config;
            _shareConfig = shareConfig;
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
            ShowSort( _config.GetBoolValue( UiConst.ShowSort ) );
            ShowSort( _config.GetValue( AngularConst.BindShowSort ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示排序
        /// </summary>
        public TableHeadColumnBuilder ShowSort( string value ) {
            AttributeIfNotEmpty( "[nzShowSort]", value );
            return this;
        }

        /// <summary>
        /// 配置排序函数
        /// </summary>
        public TableHeadColumnBuilder SortFn() {
            SortFn( _config.GetValue( UiConst.SortFn ) );
            return this;
        }

        /// <summary>
        /// 配置排序函数
        /// </summary>
        public TableHeadColumnBuilder SortFn( string value ) {
            AttributeIfNotEmpty( "[nzSortFn]", value );
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
        /// 配置排序
        /// </summary>
        public TableHeadColumnBuilder Sort() {
            Sort( _config.GetValue( UiConst.Sort ) );
            return this;
        }

        /// <summary>
        /// 排序
        /// </summary>
        private void Sort( string order ) {
            if ( order.IsEmpty() )
                return;
            ShowSort( "true" );
            SortFn( "true" );
            OnSortOrderChange( $"{_shareConfig.TableExtendId}.sortChange('{order}',$event)" );
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
        /// 配置Operation标题
        /// </summary>
        public TableHeadColumnBuilder TitleOperation() {
            var value = _config.GetValue<bool?>( UiConst.TitleOperation );
            if ( value != true )
                return this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Title, I18nKeys.Operation );
                return this;
            }
            _config.SetAttribute( UiConst.Title, "Operation" );
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
        public virtual void Title( string title ) {
            var options = NgZorroOptionsService.GetOptions();
            if ( title.IsEmpty() )
                return;
            if ( options.EnableI18n ) {
                this.AppendContentByI18n( title );
                return;
            }
            AppendContent( title );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TableHeadColumnBuilder Events() {
            AttributeIfNotEmpty( "(nzCheckedChange)", _config.GetValue( UiConst.OnCheckedChange ) );
            AttributeIfNotEmpty( "(nzFilterChange)", _config.GetValue( UiConst.OnFilterChange ) );
            OnSortOrderChange( _config.GetValue( UiConst.OnSortOrderChange ) );
            return this;
        }

        /// <summary>
        /// 排序事件
        /// </summary>
        public TableHeadColumnBuilder OnSortOrderChange( string value ) {
            AttributeIfNotEmpty( "(nzSortOrderChange)", value );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            ShowCheckbox().Disabled().Indeterminate().Checked()
                .ShowRowSelection().Selections()
                .ShowSort().SortFn().SortDirections().SortOrder().Sort()
                .ShowFilter().FilterFn().Filters().FilterMultiple()
                .Width().Left().Right().Align().BreakWord().Ellipsis()
                .Colspan().Rowspan().ColumnKey()
                .TitleOperation().Title()
                .Events()
                .CheckBox().Radio().LineNumber();
        }

        /// <summary>
        /// 添加复选框
        /// </summary>
        public TableHeadColumnBuilder CheckBox() {
            if ( _shareConfig.IsShowCheckbox == false )
                return this;
            if ( _shareConfig.IsFirst == false )
                return this;
            AddCheckBox();
            return this;
        }

        /// <summary>
        /// 添加复选框
        /// </summary>
        protected virtual void AddCheckBox( string title = null ) {
            var checkboxBuilder = new TableHeadColumnBuilder( _config, _shareConfig );
            checkboxBuilder.ConfigCheckBox();
            PreBuilder = checkboxBuilder;
        }

        /// <summary>
        /// 配置复选框
        /// </summary>
        public void ConfigCheckBox() {
            Attribute( "[nzShowCheckbox]", "true" );
            Attribute( "(nzCheckedChange)", $"{_shareConfig.TableExtendId}.masterToggle()" );
            Attribute( "[nzChecked]", $"{_shareConfig.TableExtendId}.isMasterChecked()" );
            Attribute( "[nzDisabled]", $"!{_shareConfig.TableExtendId}.dataSource.length" );
            Attribute( "[nzIndeterminate]", $"{_shareConfig.TableExtendId}.isMasterIndeterminate()" );
            BindWidth( $"{_shareConfig.TableExtendId}.config.table.checkboxWidth" );
        }

        /// <summary>
        /// 添加单选框列头
        /// </summary>
        public TableHeadColumnBuilder Radio() {
            if ( _shareConfig.IsShowCheckbox )
                return this;
            if ( _shareConfig.IsShowRadio == false )
                return this;
            if ( _shareConfig.IsFirst == false )
                return this;
            AddRadio();
            return this;
        }

        /// <summary>
        /// 添加单选框列头
        /// </summary>
        protected virtual void AddRadio( string title = null ) {
            var radioBuilder = new TableHeadColumnBuilder( _config, _shareConfig );
            radioBuilder.BindWidth( $"{_shareConfig.TableExtendId}.config.table.radioWidth" );
            PreBuilder = radioBuilder;
        }

        /// <summary>
        /// 配置序号
        /// </summary>
        public TableHeadColumnBuilder LineNumber() {
            if ( _shareConfig.IsShowLineNumber == false )
                return this;
            if ( _shareConfig.IsFirst == false )
                return this;
            AddLineNumber();
            return this;
        }

        /// <summary>
        /// 添加序号
        /// </summary>
        protected virtual void AddLineNumber() {
            var lineNumberBuilder = new TableHeadColumnBuilder( _config, _shareConfig );
            lineNumberBuilder.ConfigLineNumber();
            if ( PreBuilder == null ) {
                PreBuilder = lineNumberBuilder;
                return;
            }
            PreBuilder.PostBuilder = lineNumberBuilder;
        }

        /// <summary>
        /// 配置序号
        /// </summary>
        public void ConfigLineNumber() {
            var options = NgZorroOptionsService.GetOptions();
            Title( options.EnableI18n ? "util.lineNumber" : "序号" );
            BindWidth( $"{_shareConfig.TableExtendId}.config.table.lineNumberWidth" );
        }

        /// <summary>
        /// 添加表头单元格
        /// </summary>
        /// <param name="column">列</param>
        public virtual void AddColumn( ColumnInfo column ) {
            if ( column.IsFirst ) {
                if ( _shareConfig.IsShowCheckbox )
                    AddCheckBox();
                if ( _shareConfig.IsShowCheckbox == false && _shareConfig.IsShowRadio )
                    AddRadio();
                if ( _shareConfig.IsShowLineNumber )
                    AddLineNumber();
            }
            if ( column.IsSort )
                Sort( column.Column );
            Title( column.Title );
            this.Width( column.Width );
        }
    }
}