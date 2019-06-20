using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Forms.Configs;

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
            var shareConfig = GetShareConfig();
            ConfigSpan( shareConfig );
        }

        /// <summary>
        /// 获取共享配置
        /// </summary>
        private GridShareConfig GetShareConfig() {
            return _config.Context?.GetValueFromItems<GridShareConfig>( GridShareConfig.Key );
        }

        /// <summary>
        /// 配置跨度
        /// </summary>
        private void ConfigSpan( GridShareConfig shareConfig ) {
            var span = _config.GetValue( UiConst.Span );
            if( span.IsEmpty() )
                span = shareConfig?.ControlSpan;
            _builder.AddAttribute( GetSpanName(), span );
        }

        /// <summary>
        /// 获取span的键名
        /// </summary>
        protected virtual string GetSpanName() {
            return "span";
        }
    }
}
