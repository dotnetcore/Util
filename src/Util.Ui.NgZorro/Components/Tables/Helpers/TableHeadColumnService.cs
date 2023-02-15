using Util.Ui.Configs;
using Util.Ui.Expressions;
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
        private TableHeadColumnShareConfig _shareConfig;

        /// <summary>
        /// 初始化表头单元格服务
        /// </summary>
        /// <param name="config">配置</param>
        public TableHeadColumnService( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            CreateTableHeadColumnShareConfig();
            CancelAutoCreateHeadColumn();
            SetIsFirst();
            LoadExpression();
        }

        /// <summary>
        /// 创建表头列共享配置
        /// </summary>
        private void CreateTableHeadColumnShareConfig() {
            _shareConfig = new TableHeadColumnShareConfig( GetTableShareConfig());
            _config.SetValueToItems( _shareConfig );
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        private TableShareConfig GetTableShareConfig() {
            return _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
        }

        /// <summary>
        /// 取消自动创建表头单元格
        /// </summary>
        private void CancelAutoCreateHeadColumn() {
            _shareConfig.IsAutoCreateHeadColumn = false;
        }

        /// <summary>
        /// 设置第一列标识
        /// </summary>
        public void SetIsFirst() {
            _shareConfig.SetIsFirst();
        }

        /// <summary>
        /// 加载表达式
        /// </summary>
        private void LoadExpression() {
            var expressionLoader = new ExpressionLoader();
            expressionLoader.Load( _config );
        }
    }
}
