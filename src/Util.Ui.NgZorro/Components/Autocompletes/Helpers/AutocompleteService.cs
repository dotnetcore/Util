using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Selects.Helpers;

namespace Util.Ui.NgZorro.Components.Autocompletes.Helpers {
    /// <summary>
    /// 自动完成服务
    /// </summary>
    public class AutocompleteService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化自动完成服务
        /// </summary>
        /// <param name="config">配置</param>
        public AutocompleteService( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            LoadExpression();
        }

        /// <summary>
        /// 加载表达式
        /// </summary>
        private void LoadExpression() {
            var loader = new SelectExpressionLoader();
            loader.Load( _config );
        }
    }
}
