using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Inputs.Helpers {
    /// <summary>
    /// 输入框组合共享服务
    /// </summary>
    public class InputGroupShareService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 输入框组合共享配置
        /// </summary>
        private InputGroupShareConfig _shareConfig;

        /// <summary>
        /// 初始化输入框组合共享服务
        /// </summary>
        /// <param name="config">配置</param>
        public InputGroupShareService( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 设置自动创建nz-input-group
        /// </summary>
        /// <param name="value">是否自动创建</param>
        public void AutoCreateInputGroup( bool value ) {
            if ( _shareConfig.AutoCreateInputGroup == false )
                return;
            _shareConfig.AutoCreateInputGroup = value;
        }

        /// <summary>
        /// 初始化表单共享配置
        /// </summary>
        public void Init() {
            InitShareConfig();
            SetShareConfig();
            AutoCreateInputGroup();
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
        private InputGroupShareConfig GetShareConfig() {
            return _config.GetValueFromItems<InputGroupShareConfig>() ?? new InputGroupShareConfig();
        }

        /// <summary>
        /// 设置共享配置
        /// </summary>
        private void SetShareConfig() {
            _shareConfig.AddOnBefore = _config.GetValue( UiConst.AddOnBefore );
            _shareConfig.BindAddOnBefore = _config.GetValue( AngularConst.BindAddOnBefore );
            _shareConfig.AddOnAfter = _config.GetValue( UiConst.AddOnAfter );
            _shareConfig.BindAddOnAfter = _config.GetValue( AngularConst.BindAddOnAfter );
            _shareConfig.AddOnBeforeIcon = _config.GetValue<AntDesignIcon?>( UiConst.AddOnBeforeIcon );
            _shareConfig.BindAddOnBeforeIcon = _config.GetValue( AngularConst.BindAddOnBeforeIcon );
            _shareConfig.AddOnAfterIcon = _config.GetValue<AntDesignIcon?>( UiConst.AddOnAfterIcon );
            _shareConfig.BindAddOnAfterIcon = _config.GetValue( AngularConst.BindAddOnAfterIcon );
            _shareConfig.Prefix = _config.GetValue( UiConst.Prefix );
            _shareConfig.BindPrefix = _config.GetValue( AngularConst.BindPrefix );
            _shareConfig.Suffix = _config.GetValue( UiConst.Suffix );
            _shareConfig.BindSuffix = _config.GetValue( AngularConst.BindSuffix );
            _shareConfig.PrefixIcon = _config.GetValue<AntDesignIcon?>( UiConst.PrefixIcon );
            _shareConfig.BindPrefixIcon = _config.GetValue( AngularConst.BindPrefixIcon );
            _shareConfig.SuffixIcon = _config.GetValue<AntDesignIcon?>( UiConst.SuffixIcon );
            _shareConfig.BindSuffixIcon = _config.GetValue( AngularConst.BindSuffixIcon );
        }

        /// <summary>
        /// 自动创建nz-input-group
        /// </summary>
        private void AutoCreateInputGroup() {
            if ( IsAutoCreateInputGroup() == false )
                return;
            AutoCreateInputGroup( true );
        }

        /// <summary>
        /// 是否自动创建nz-input-group
        /// </summary>
        private bool IsAutoCreateInputGroup() {
            if ( string.IsNullOrWhiteSpace( _shareConfig.AddOnBefore ) == false )
                return true;
            if ( string.IsNullOrWhiteSpace( _shareConfig.BindAddOnBefore ) == false )
                return true;
            if ( string.IsNullOrWhiteSpace( _shareConfig.AddOnAfter ) == false )
                return true;
            if ( string.IsNullOrWhiteSpace( _shareConfig.BindAddOnAfter ) == false )
                return true;
            if ( _shareConfig.AddOnBeforeIcon != null )
                return true;
            if ( string.IsNullOrWhiteSpace( _shareConfig.BindAddOnBeforeIcon ) == false )
                return true;
            if ( _shareConfig.AddOnAfterIcon != null )
                return true;
            if ( string.IsNullOrWhiteSpace( _shareConfig.BindAddOnAfterIcon ) == false )
                return true;
            if ( string.IsNullOrWhiteSpace( _shareConfig.Prefix ) == false )
                return true;
            if ( string.IsNullOrWhiteSpace( _shareConfig.BindPrefix ) == false )
                return true;
            if ( string.IsNullOrWhiteSpace( _shareConfig.Suffix ) == false )
                return true;
            if ( string.IsNullOrWhiteSpace( _shareConfig.BindSuffix ) == false )
                return true;
            if ( _shareConfig.PrefixIcon != null )
                return true;
            if ( string.IsNullOrWhiteSpace( _shareConfig.BindPrefixIcon ) == false )
                return true;
            if ( _shareConfig.SuffixIcon != null )
                return true;
            if ( string.IsNullOrWhiteSpace( _shareConfig.BindSuffixIcon ) == false )
                return true;
            return false;
        }
    }
}
