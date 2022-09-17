using Util.Ui.NgZorro.Components.Tables.Helpers;

namespace Util.Ui.NgZorro.Components.Tables.Configs {
    /// <summary>
    /// 表格列共享配置
    /// </summary>
    public class TableColumnShareConfig {
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _tableShareConfig;

        /// <summary>
        /// 初始化表格列共享配置
        /// </summary>
        /// <param name="tableShareConfig">表格共享配置</param>
        public TableColumnShareConfig( TableShareConfig tableShareConfig ) {
            _tableShareConfig = tableShareConfig;
        }

        /// <summary>
        /// 表格扩展标识
        /// </summary>
        public string TableExtendId => _tableShareConfig.TableExtendId;

        /// <summary>
        /// 获取序号列标题
        /// </summary>
        public string GetLineNumberTitle() {
            return _tableShareConfig.GetLineNumberTitle();
        }

        /// <summary>
        /// 添加列
        /// </summary>
        /// <param name="column">列信息</param>
        public void AddColumn( ColumnInfo column ) {
            if ( column == null )
                return;
            _tableShareConfig.Columns.Add( column );
            EnableExtend( column );
        }

        /// <summary>
        /// 启用扩展
        /// </summary>
        private void EnableExtend( ColumnInfo column ) {
            if( column.IsLineNumber || column.IsCheckbox )
                _tableShareConfig.IsEnableExtend = true;
        }

        /// <summary>
        /// 启用自动省略
        /// </summary>
        public void EnableEllipsis() {
            _tableShareConfig.IsEnableEllipsis = true;
        }
    }
}
