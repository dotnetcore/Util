using Util.Properties;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Enums;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Tables.Builders;
using Util.Ui.Zorro.Tables.Configs;

namespace Util.Ui.Zorro.Tables.Renders {
    /// <summary>
    /// 列渲染器
    /// </summary>
    public class ColumnRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ColumnRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override Util.Ui.Builders.TagBuilder GetTagBuilder() {
            var builder = new TableColumnBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TableColumnBuilder builder ) {
            ConfigId( builder );
            ConfigColumn( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置列
        /// </summary>
        protected virtual void ConfigColumn( TableColumnBuilder builder ) {
            if( _config.Content.IsEmpty() == false )
                return;
            var type = _config.GetValue<TableColumnType?>( UiConst.Type );
            var column = _config.GetValue( UiConst.Column );
            switch( type ) {
                case TableColumnType.LineNumber:
                    AddLineNumber( builder );
                    return;
                case TableColumnType.Checkbox:
                    AddCheckbox( builder );
                    return;
                case TableColumnType.Bool:
                    AddBoolColumn( builder, column );
                    return;
                case TableColumnType.Date:
                    AddDateColumn( builder, column );
                    return;
                default:
                    AddDefaultColumn( builder, column );
                    return;
            }
        }

        /// <summary>
        /// 添加序号
        /// </summary>
        protected void AddLineNumber( TableColumnBuilder builder ) {
            if( _config.GetValue<TableColumnType?>( UiConst.Type ) != TableColumnType.LineNumber )
                return;
            builder.AppendContent( "{{row.lineNumber}}" );
        }

        /// <summary>
        /// 添加复选框
        /// </summary>
        protected void AddCheckbox( TableColumnBuilder builder ) {
            if( _config.GetValue<TableColumnType?>( UiConst.Type ) != TableColumnType.Checkbox )
                return;
            var tableId = _config.Context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey )?.TableId;
            builder.AddAttribute( "[nzShowCheckbox]", $"{tableId}_wrapper.multiple" );
            builder.AddAttribute( "(click)", "$event.stopPropagation()" );
            builder.AddAttribute( "(nzCheckedChange)", $"{tableId}_wrapper.checkedSelection.toggle(row)" );
            builder.AddAttribute( "[nzChecked]", $"{tableId}_wrapper.checkedSelection.isSelected(row)" );
            builder.AppendContent( new TableRadioBuilder( tableId ) );
        }

        /// <summary>
        /// 添加布尔类型列
        /// </summary>
        protected void AddBoolColumn( TableColumnBuilder builder, string column ) {
            if( column.IsEmpty() )
                return;
            builder.AppendContent( $"{{{{row.{column}?'{R.Yes}':'{R.No}'}}}}" );
        }

        /// <summary>
        /// 添加日期类型列
        /// </summary>
        protected void AddDateColumn( TableColumnBuilder builder, string column ) {
            if( column.IsEmpty() )
                return;
            var format = _config.GetValue( UiConst.DateFormat );
            if( string.IsNullOrWhiteSpace( format ) )
                format = "yyyy-MM-dd";
            builder.AppendContent( $"{{{{ row.{column} | date:\"{format}\" }}}}" );
        }

        /// <summary>
        /// 添加默认列
        /// </summary>
        protected void AddDefaultColumn( TableColumnBuilder builder, string column ) {
            if( column.IsEmpty() )
                return;
            var length = _config.GetValue<int?>( UiConst.Truncate );
            if( length == null ) {
                builder.AppendContent( $"{{{{row.{column}}}}}" );
                return;
            }
            builder.Truncate( column, length.SafeValue() );
        }
    }
}