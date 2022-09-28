using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Descriptions.Helpers {
    /// <summary>
    /// 描述列表项服务
    /// </summary>
    public class DescriptionItemService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化描述列表项服务
        /// </summary>
        /// <param name="config">配置</param>
        public DescriptionItemService( Config config ) {
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
            var loader = new DescriptionItemExpressionLoader();
            loader.Load( _config );
        }
    }
}
