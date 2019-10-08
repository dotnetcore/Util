using System.Linq;
using Util.Ui.Angular.Enums;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Tables.Configs;
using Util.Ui.Zorro.TreeTables.Builders;

namespace Util.Ui.Zorro.TreeTables.Renders {
    /// <summary>
    /// 树形表格列渲染器
    /// </summary>
    public class ColumnRender : Util.Ui.Zorro.Tables.Renders.ColumnRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 共享配置
        /// </summary>
        private readonly TableShareConfig _shareConfig;

        /// <summary>
        /// 初始化树形表格列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ColumnRender( Config config ) : base( config ) {
            _config = config;
            _shareConfig = _config.Context.GetValueFromItems<TableShareConfig>( TableConfig.TableShareKey );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override Util.Ui.Builders.TagBuilder GetTagBuilder() {
            var builder = new TreeTableColumnBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TreeTableColumnBuilder builder ) {
            ConfigId( builder );
            ConfigColumn( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置列
        /// </summary>
        private void ConfigColumn( TreeTableColumnBuilder builder ) {
            if( _config.Content.IsEmpty() == false )
                return;
            var type = _config.GetValue<TreeTableColumnType?>( UiConst.Type );
            var column = _config.GetValue( UiConst.Column );
            switch( type ) {
                case TreeTableColumnType.Bool:
                    AddBoolColumn( builder, column );
                    return;
                case TreeTableColumnType.Date:
                    AddDateColumn( builder, column );
                    return;
                default:
                    AddDefaultColumn( builder, column );
                    return;
            }
        }

        /// <summary>
        /// 添加默认列
        /// </summary>
        protected void AddDefaultColumn( TreeTableColumnBuilder builder, string column ) {
            if( column.IsEmpty() )
                return;
            if ( IsFirstColumn() ) {
                var tableWrapperId = _shareConfig?.TableWrapperId;
                builder.SetColumn( tableWrapperId,$"row.{column}",20 );
                return;
            }
            var length = _config.GetValue<int?>( UiConst.Truncate );
            if( length == null ) {
                builder.AppendContent( $"{{{{row.{column}}}}}" );
                return;
            }
            builder.Truncate( column, length.SafeValue() );
        }

        /// <summary>
        /// 是否第一列
        /// </summary>
        private bool IsFirstColumn() {
            var column = _config.GetValue( UiConst.Column );
            var firstColumn = _shareConfig.Columns.FirstOrDefault();
            return column.IsEmpty() == false && column == firstColumn?.Column;
        }
    }
}