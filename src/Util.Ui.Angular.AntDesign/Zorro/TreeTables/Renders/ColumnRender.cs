using System.Linq;
using Util.Ui.Angular.Enums;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tables.Builders;
using Util.Ui.Zorro.Tables.Configs;
using TextColumnBuilder = Util.Ui.Zorro.TreeTables.Builders.TextColumnBuilder;

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
        /// 初始化树形表格列渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ColumnRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 创建列生成器
        /// </summary>
        protected override TagBuilder CreateColumnBuilder() {
            var shareConfig = _config.GetValueFromItems<ColumnShareConfig>();
            var type = _config.GetValue<TreeTableColumnType?>( UiConst.Type );
            var tableWrapperId = GetTableShareConfig()?.TableWrapperId;
            var tableId = shareConfig?.TableId;
            var editTableId = shareConfig?.EditTableId;
            var column = _config.GetValue( UiConst.Column );
            var templateId = shareConfig?.TemplateId;
            var format = _config.GetValue( UiConst.DateFormat );
            var length = _config.GetValue<int?>( UiConst.Truncate );
            var isEdit = ( shareConfig?.IsEdit ).SafeValue();
            switch( type ) {
                case TreeTableColumnType.Bool:
                    return new BoolColumnBuilder( column, _config.Content );
                case TreeTableColumnType.Date:
                    return new DateColumnBuilder( column, format, _config.Content );
                default:
                    return new TextColumnBuilder( column, length, _config.Content, IsFirstColumn(), tableWrapperId );
            }
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        private TableShareConfig GetTableShareConfig() {

            return _config.GetValueFromItems<TableShareConfig>();
        }

        /// <summary>
        /// 是否第一列
        /// </summary>
        private bool IsFirstColumn() {
            var column = _config.GetValue( UiConst.Column );
            var firstColumn = GetTableShareConfig()?.Columns.FirstOrDefault();
            return column.IsEmpty() == false && column == firstColumn?.Column;
        }
    }
}