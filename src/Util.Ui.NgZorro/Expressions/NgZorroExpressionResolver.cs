using Util.Ui.Configs;
using Util.Ui.Expressions;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Expressions {
    /// <summary>
    /// NgZorro模型表达式解析器
    /// </summary>
    public class NgZorroExpressionResolver : ExpressionResolver {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化NgZorro模型表达式解析器
        /// </summary>
        /// <param name="config">配置</param>
        public NgZorroExpressionResolver( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取默认模型名称
        /// </summary>
        protected override string GetDefaultModel() {
            var config = GetTableColumnShareConfig();
            if ( config == null )
                return "model";
            return "row";
        }

        /// <summary>
        /// 获取表格列共享配置
        /// </summary>
        public TableColumnShareConfig GetTableColumnShareConfig() {
            return _config.GetValueFromItems<TableColumnShareConfig>();
        }
    }
}
