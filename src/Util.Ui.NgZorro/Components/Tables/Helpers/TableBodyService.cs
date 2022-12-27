using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 表格主体服务
    /// </summary>
    public class TableBodyService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格主体共享配置
        /// </summary>
        private TableBodyShareConfig _shareConfig;
        /// <summary>
        /// 表格共享配置
        /// </summary>
        private readonly TableShareConfig _tableShareConfig;

        /// <summary>
        /// 初始化表格主体服务
        /// </summary>
        /// <param name="config">配置</param>
        public TableBodyService( Config config ) {
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
            CreateTableBodyShareConfig();
            CancelAutoCreateBody();
        }

        /// <summary>
        /// 创建表格主体共享配置
        /// </summary>
        private void CreateTableBodyShareConfig() {
            _shareConfig = new TableBodyShareConfig();
            _config.SetValueToItems( _shareConfig );
        }

        /// <summary>
        /// 取消自动创建表格主体
        /// </summary>
        private void CancelAutoCreateBody() {
            _tableShareConfig.IsAutoCreateBody = false;
        }
    }
}
