using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 表头单元格服务
    /// </summary>
    public class TableHeadColumnService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _tableShareConfig;

        /// <summary>
        /// 初始化表头单元格服务
        /// </summary>
        /// <param name="config">配置</param>
        public TableHeadColumnService( Config config ) {
            _config = config;
            _tableShareConfig = GetTableShareConfig();
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        private TableShareConfig GetTableShareConfig() {
            return _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            CancelAutoCreateHeadColumn();
        }

        /// <summary>
        /// 取消自动创建表头单元格
        /// </summary>
        private void CancelAutoCreateHeadColumn() {
            _tableShareConfig.IsAutoCreateHeadColumn = false;
        }
    }
}
