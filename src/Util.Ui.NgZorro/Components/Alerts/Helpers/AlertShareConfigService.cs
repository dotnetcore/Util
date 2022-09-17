using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Alerts.Configs;

namespace Util.Ui.NgZorro.Components.Alerts.Helpers {
    /// <summary>
    /// 警告提示共享服务
    /// </summary>
    public class AlertShareConfigService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 警告提示共享配置
        /// </summary>
        private AlertShareConfig _shareConfig;

        /// <summary>
        /// 初始化输入框组合共享服务
        /// </summary>
        /// <param name="config">配置</param>
        public AlertShareConfigService( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 设置自动创建ng-template
        /// </summary>
        /// <param name="value">是否自动创建</param>
        public void AutoCreateTemplate( bool value ) {
            _shareConfig.IsAutoCreateTemplate = value;
        }

        /// <summary>
        /// 初始化表单共享配置
        /// </summary>
        public void Init() {
            InitShareConfig();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitShareConfig() {
            _shareConfig = GetShareConfig();
            _config.SetValueToItems( _shareConfig );
        }

        /// <summary>
        /// 获取共享配置
        /// </summary>
        private AlertShareConfig GetShareConfig() {
            return _config.GetValueFromItems<AlertShareConfig>() ?? new AlertShareConfig( GetId() );
        }

        /// <summary>
        /// 获取标识
        /// </summary>
        private string GetId() {
            return _config.GetValue( UiConst.Id );
        }
    }
}
