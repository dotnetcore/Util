using Util.Ui.Angular.Base;
using Util.Ui.Angular.Enums;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
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
        protected override TagBuilder GetTagBuilder() {
            var builder = new TableColumnBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigColumn( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置列
        /// </summary>
        private void ConfigColumn( TagBuilder builder ) {
            var type = _config.GetValue<TableColumnType?>( UiConst.Type );
            var column = _config.GetValue( UiConst.Column );
            switch( type ) {
                case TableColumnType.Checkbox:
                    ConfigCheckbox( builder );
                    return;
                case TableColumnType.Bool:
                    //AddBoolCell( cellBuilder, column );
                    return;
                case TableColumnType.Date:
                    AddDateColumn( builder, column );
                    return;
                default:
                    AddDefaultColumn( builder,column );
                    return;
            }
        }

        /// <summary>
        /// 配置复选框
        /// </summary>
        private void ConfigCheckbox( TagBuilder builder ) {
            if( _config.GetValue<TableColumnType?>( UiConst.Type ) != TableColumnType.Checkbox )
                return;
            var tableId = _config.Context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey )?.TableId;
            builder.AddAttribute( "nzShowCheckbox" );
            builder.AddAttribute( "(click)", "$event.stopPropagation()" );
            builder.AddAttribute( "(nzCheckedChange)", $"{tableId}_wrapper.checkedSelection.toggle(row)" );
            builder.AddAttribute( "[nzChecked]", $"{tableId}_wrapper.checkedSelection.isSelected(row)" );
        }

        /// <summary>
        /// 添加日期类型列
        /// </summary>
        private void AddDateColumn( TagBuilder builder, string column ) {
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
        private void AddDefaultColumn( TagBuilder builder,string column ) {
            if( column.IsEmpty() )
                return;
            builder.AppendContent( $"{{{{row.{column}}}}}" );
        }
    }
}