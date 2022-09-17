using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Helpers;

namespace Util.Ui.NgZorro.Components.Checkboxes.Helpers {
    /// <summary>
    /// 复选框服务
    /// </summary>
    public class CheckboxService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化复选框服务
        /// </summary>
        /// <param name="config">配置</param>
        public CheckboxService( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            LoadExpression();
            InitFormShareService();
            InitFormItemShareService();
        }

        /// <summary>
        /// 加载表达式
        /// </summary>
        private void LoadExpression() {
            var loader = new CheckboxExpressionLoader();
            loader.Load( _config );
        }

        /// <summary>
        /// 初始化表单共享服务
        /// </summary>
        private void InitFormShareService() {
            var service = new FormShareService( _config );
            service.Init();
        }

        /// <summary>
        /// 初始化表单项共享服务
        /// </summary>
        private void InitFormItemShareService() {
            var service = new FormItemShareService( _config );
            service.Init();
            service.InitId();
        }
    }
}
