using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 表格行服务
    /// </summary>
    public class TableRowService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _shareConfig;

        /// <summary>
        /// 初始化表格行服务
        /// </summary>
        /// <param name="config">配置</param>
        public TableRowService( Config config ) {
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
        /// 是否表头行
        /// </summary>
        public bool IsHeadRow => GetTableHeadShareConfig() != null;

        /// <summary>
        /// 获取表格头共享配置
        /// </summary>
        private TableHeadShareConfig GetTableHeadShareConfig() {
            return _config.GetValueFromItems<TableHeadShareConfig>();
        }

        /// <summary>
        /// 获取表格主体共享配置
        /// </summary>
        private TableBodyShareConfig GetTableBodyShareConfig() {
            return _config.GetValueFromItems<TableBodyShareConfig>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            ConfigRowId();
            CancelAutoCreateHeadRow();
            CancelAutoCreateBodyRow();
        }

        /// <summary>
        /// 配置表格主体行标识
        /// </summary>
        private void ConfigRowId() {
            if ( IsHeadRow )
                return;
            _shareConfig.SetRowId( _config.GetValue( UiConst.Id ) );
        }

        /// <summary>
        /// 取消自动创建表头行
        /// </summary>
        private void CancelAutoCreateHeadRow() {
            if ( IsHeadRow )
                _shareConfig.IsAutoCreateHeadRow = false;
        }

        /// <summary>
        /// 取消自动创建表格主体行
        /// </summary>
        private void CancelAutoCreateBodyRow() {
            if ( IsHeadRow )
                return;
            _shareConfig.IsAutoCreateBodyRow = false;
        }
    }
}
