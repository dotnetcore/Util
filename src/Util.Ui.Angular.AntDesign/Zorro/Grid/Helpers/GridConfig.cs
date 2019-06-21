using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Zorro.Grid.Helpers {
    /// <summary>
    /// 栅格配置操作
    /// </summary>
    public class GridConfig {
        /// <summary>
        /// 标签生成器
        /// </summary>
        private readonly TagBuilder _builder;
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化栅格配置操作
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">配置</param>
        public GridConfig( TagBuilder builder, Config config ) {
            _builder = builder;
            _config = config;
        }

        /// <summary>
        /// 配置布局
        /// </summary>
        public void Config() {
            ConfigSpan();
        }

        /// <summary>
        /// 配置跨度
        /// </summary>
        private void ConfigSpan() {
            _builder.AddAttribute( GetSpanName(), GridHelper.GetControlSpan( _config ) );
        }

        /// <summary>
        /// 获取span的键名
        /// </summary>
        protected virtual string GetSpanName() {
            return "span";
        }
    }
}
