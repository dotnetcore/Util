using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Forms.Helpers {
    /// <summary>
    /// 验证服务
    /// </summary>
    public class ValidationService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表单项共享配置
        /// </summary>
        private FormItemShareConfig _shareConfig;

        /// <summary>
        /// 初始化输入框服务
        /// </summary>
        /// <param name="config">配置</param>
        public ValidationService( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            InitFormItemShareConfig();
            if ( IsExtend() == false )
                return;
            EnableExtend();
            InitValidationExtendId();
            InitValidationTempalteId();
            InitErrorTip();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitFormItemShareConfig() {
            _shareConfig = GetShareConfig();
            _config.SetValueToItems( _shareConfig );
        }

        /// <summary>
        /// 获取表单项共享配置
        /// </summary>
        private FormItemShareConfig GetShareConfig() {
            return _config.GetValueFromItems<FormItemShareConfig>() ?? new FormItemShareConfig();
        }

        /// <summary>
        /// 是否扩展
        /// </summary>
        private bool IsExtend() {
            if ( _config.Contains( UiConst.ErrorTip ) || _config.Contains( AngularConst.BindErrorTip ) )
                return false;
            if ( HasNgModel() == false )
                return false;
            if ( HasRequired() )
                return true;
            if ( HasMinLength() )
                return true;
            if ( HasMaxLength() )
                return true;
            if ( HasPattern() )
                return true;
            if ( HasBindPattern() )
                return true;
            if ( HasEmailType() )
                return true;
            return false;
        }

        /// <summary>
        /// 是否设置ngModel属性
        /// </summary>
        private bool HasNgModel() {
            return _config.Contains( AngularConst.NgModel );
        }

        /// <summary>
        /// 是否设置必填项属性
        /// </summary>
        private bool HasRequired() {
            return _config.Contains( UiConst.Required );
        }

        /// <summary>
        /// 是否设置最小长度属性
        /// </summary>
        private bool HasMinLength() {
            return _config.Contains( UiConst.MinLength );
        }

        /// <summary>
        /// 是否设置正则表达式属性
        /// </summary>
        private bool HasPattern() {
            return _config.Contains( UiConst.Pattern );
        }

        /// <summary>
        /// 是否设置正则表达式属性
        /// </summary>
        private bool HasBindPattern() {
            return _config.Contains( AngularConst.BindPattern );
        }

        /// <summary>
        /// 是否设置最大长度属性
        /// </summary>
        private bool HasMaxLength() {
            return _config.Contains( UiConst.MaxLength );
        }

        /// <summary>
        /// 是否设置电子邮件类型属性
        /// </summary>
        private bool HasEmailType() {
            var type = _config.GetValue<InputType?>( UiConst.Type );
            return type == InputType.Email;
        }

        /// <summary>
        /// 启用验证扩展
        /// </summary>
        private void EnableExtend() {
            _shareConfig.IsValidationExtend = true;
        }

        /// <summary>
        /// 初始化验证扩展标识
        /// </summary>
        private void InitValidationExtendId() {
            _shareConfig.ValidationExtendId = GetValidationExtendId();
        }

        /// <summary>
        /// 获取验证扩展标识
        /// </summary>
        private string GetValidationExtendId() {
            var id = _config.GetValue( UiConst.Id );
            if ( id.IsEmpty() )
                id = Util.Helpers.Id.Create();
            return $"v_{id}";
        }

        /// <summary>
        /// 初始化验证模板标识
        /// </summary>
        private void InitValidationTempalteId() {
            _shareConfig.ValidationTempalteId = GetValidationTempalteId();
        }

        /// <summary>
        /// 获取验证模板标识
        /// </summary>
        private string GetValidationTempalteId() {
            var id = _config.GetValue( UiConst.Id );
            if ( id.IsEmpty() )
                id = Util.Helpers.Id.Create();
            return $"vt_{id}";
        }

        /// <summary>
        /// 初始化错误提示
        /// </summary>
        private void InitErrorTip() {
            _config.SetAttribute( AngularConst.BindErrorTip, _shareConfig.ValidationTempalteId );
        }
    }
}
