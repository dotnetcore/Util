using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.Builders;
using Util.Ui.Material.Tables.Builders;
using Util.Ui.Material.Tables.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Material.Tables.Renders {
    /// <summary>
    /// 列渲染器
    /// </summary>
    public class ColumnRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly ColumnConfig _config;
        /// <summary>
        /// 表格标识
        /// </summary>
        private readonly string _tableId;
        /// <summary>
        /// 是否自动创建列头
        /// </summary>
        private readonly bool _autoCreateHeaderCell;
        /// <summary>
        /// 是否自动创建单元格
        /// </summary>
        private readonly bool _autoCreateCell;

        /// <summary>
        /// 初始化列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ColumnRender( ColumnConfig config ) : base( config ) {
            _config = config;
            _tableId = config.TableId;
            _autoCreateHeaderCell = config.AutoCreateHeaderCell();
            _autoCreateCell = config.AutoCreateCell();
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ContainerBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigType( builder );
            ConfigHeader( builder );
            ConfigColumn( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        private void ConfigType( TagBuilder builder ) {
            ConfigLineNumber();
            ConfigCheckbox( builder );
        }

        /// <summary>
        /// 配置行号
        /// </summary>
        private void ConfigLineNumber() {
            if( _config.GetValue<TableColumnType?>( UiConst.Type ) != TableColumnType.LineNumber )
                return;
            _config.SetAttribute( UiConst.Column, "lineNumber" );
            if( _config.Contains( UiConst.Title ) == false )
                _config.SetAttribute( UiConst.Title, "ID" );
        }

        /// <summary>
        /// 配置复选框
        /// </summary>
        private void ConfigCheckbox( TagBuilder builder ) {
            if( _config.GetValue<TableColumnType?>( UiConst.Type ) != TableColumnType.Checkbox )
                return;
            _config.SetAttribute( UiConst.Column, "selectCheckbox" );
            ConfigCheckboxHeader( builder );
            ConfigCheckboxCell( builder );
        }

        /// <summary>
        /// 配置复选框列头
        /// </summary>
        private void ConfigCheckboxHeader( TagBuilder builder ) {
            var checkBoxBuilder = new CheckBoxBuilder();
            checkBoxBuilder.AddAttribute( "(change)", $"$event?{_tableId}.masterToggle():null" );
            checkBoxBuilder.AddAttribute( "[disabled]", $"!{_tableId}.dataSource.data.length" );
            checkBoxBuilder.AddAttribute( "[checked]", $"{_tableId}.isMasterChecked()" );
            checkBoxBuilder.AddAttribute( "[indeterminate]", $"{_tableId}.isMasterIndeterminate()" );
            var headerCellBuilder = new HeaderCellBuilder();
            headerCellBuilder.AppendContent( checkBoxBuilder );
            builder.AppendContent( headerCellBuilder );
        }

        /// <summary>
        /// 配置复选框单元格
        /// </summary>
        private void ConfigCheckboxCell( TagBuilder builder ) {
            var checkBoxBuilder = new CheckBoxBuilder();
            checkBoxBuilder.AddAttribute( "(click)", "$event.stopPropagation()" );
            checkBoxBuilder.AddAttribute( "(change)", $"$event?{_tableId}.selection.toggle(row):null" );
            checkBoxBuilder.AddAttribute( "[checked]", $"{_tableId}.selection.isSelected(row)" );
            var cellBuilder = new CellBuilder();
            cellBuilder.AppendContent( checkBoxBuilder );
            builder.AppendContent( cellBuilder );
        }

        /// <summary>
        /// 配置列头
        /// </summary>
        private void ConfigHeader( TagBuilder builder ) {
            if( _config.Contains( UiConst.Title ) == false )
                return;
            if( _autoCreateHeaderCell == false )
                return;
            var headerCellBuilder = new HeaderCellBuilder();
            ConfigTitle( headerCellBuilder );
            ConfigSort( headerCellBuilder );
            builder.AppendContent( headerCellBuilder );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigTitle( TagBuilder headerCellBuilder ) {
            headerCellBuilder.AppendContent( _config.GetValue( UiConst.Title ) );
        }

        /// <summary>
        /// 配置排序
        /// </summary>
        private void ConfigSort( TagBuilder headerCellBuilder ) {
            if( _config.GetValue<bool?>( UiConst.Sort ) != true )
                return;
            if( _config.GetValue<TableColumnType?>( UiConst.Type ) == TableColumnType.LineNumber )
                return;
            headerCellBuilder.AddAttribute( "mat-sort-header" );
        }

        /// <summary>
        /// 配置列
        /// </summary>
        private void ConfigColumn( TagBuilder builder ) {
            if( _config.Contains( UiConst.Column ) == false )
                return;
            builder.AddAttribute( "matColumnDef", _config.GetValue( UiConst.Column ) );
            AddCell( builder );
        }

        /// <summary>
        /// 添加单元格配置
        /// </summary>
        private void AddCell( TagBuilder builder ) {
            if( _autoCreateCell == false )
                return;
            var cellBuilder = new CellBuilder();
            cellBuilder.AppendContent( $"{{{{ row.{_config.GetValue( UiConst.Column )} }}}}" );
            builder.AppendContent( cellBuilder );
        }
    }
}