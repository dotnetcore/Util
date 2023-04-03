using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Helpers;
using Util.Ui.NgZorro.Components.Radios.Configs;
using Util.Ui.NgZorro.Components.Selects.Helpers;

namespace Util.Ui.NgZorro.Components.Radios.Helpers {
    /// <summary>
    /// 单选框服务
    /// </summary>
    public class RadioService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 单选框组合共享配置
        /// </summary>
        private RadioGroupShareConfig _shareConfig;

        /// <summary>
        /// 初始化单选框服务
        /// </summary>
        /// <param name="config">配置</param>
        public RadioService( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            InitShareConfig();
            LoadExpression();
            InitValidationService();
            InitFormShareService();
            InitFormItemShareService();
            EnableExtend();
            DisableAutoCreateRadio();
            EnableAutoCreateRadioGroup();
        }

        /// <summary>
        /// 初始化共享配置
        /// </summary>
        private void InitShareConfig() {
            _shareConfig = GetShareConfig();
            if ( _shareConfig != null )
                return;
            _shareConfig = new RadioGroupShareConfig( GetRadioId() );
            _config.SetValueToItems( _shareConfig );
        }

        /// <summary>
        /// 获取单选框标识
        /// </summary>
        private string GetRadioId() {
            return _config.GetValue( UiConst.Id );
        }

        /// <summary>
        /// 获取单选框组合共享配置
        /// </summary>
        private RadioGroupShareConfig GetShareConfig() {
            return _config.GetValueFromItems<RadioGroupShareConfig>();
        }

        /// <summary>
        /// 加载表达式
        /// </summary>
        private void LoadExpression() {
            var loader = new SelectExpressionLoader();
            loader.Load( _config );
        }

        /// <summary>
        /// 初始化验证服务
        /// </summary>
        private void InitValidationService() {
            var service = new ValidationService( _config );
            service.Init();
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

        /// <summary>
        /// 启用扩展
        /// </summary>
        private void EnableExtend() {
            if ( IsExtend() == false ) {
                _shareConfig.IsRadioExtend = false;
                return;
            }
            _shareConfig.IsRadioExtend = true;
            if ( _shareConfig.IsAutoCreateRadioGroup == false )
                return;
            _shareConfig.IsRadioGroupExtend = true;
        }

        /// <summary>
        /// 是否扩展
        /// </summary>
        private bool IsExtend() {
            if ( HasData() )
                return true;
            if ( HasUrl() )
                return true;
            return false;
        }

        /// <summary>
        /// 是否设置数据源属性
        /// </summary>
        private bool HasData() {
            return _config.Contains( UiConst.Data );
        }

        /// <summary>
        /// 是否设置Api地址
        /// </summary>
        private bool HasUrl() {
            if ( _config.Contains( UiConst.Url ) )
                return true;
            return _config.Contains( AngularConst.BindUrl );
        }

        /// <summary>
        /// 禁用自动创建单选框组合
        /// </summary>
        private void DisableAutoCreateRadio() {
            _shareConfig.IsAutoCreateRadio = false;
        }

        /// <summary>
        /// 启用自动创建单选框组合
        /// </summary>
        private void EnableAutoCreateRadioGroup() {
            if ( _shareConfig.IsAutoCreateRadioGroup == false )
                return;
            if ( IsExtend() )
                _shareConfig.IsAutoCreateRadioGroup = true;
        }
    }
}
