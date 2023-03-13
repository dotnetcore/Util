using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Forms.Helpers {
    /// <summary>
    /// 表单项共享服务
    /// </summary>
    public class FormItemShareService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表单项共享配置
        /// </summary>
        private FormItemShareConfig _shareConfig;

        /// <summary>
        /// 初始化表单项共享服务
        /// </summary>
        /// <param name="config">配置</param>
        public FormItemShareService( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 初始化控件Id
        /// </summary>
        public void InitId() {
            if ( _shareConfig.Id.IsEmpty() == false )
                return;
            _shareConfig.Id = _config.Id;
        }

        /// <summary>
        /// 设置自动创建nz-form-item
        /// </summary>
        /// <param name="value">是否自动创建</param>
        public void AutoCreateFormItem( bool value ) {
            if ( _shareConfig.AutoCreateFormItem == false )
                return;
            _shareConfig.AutoCreateFormItem = value;
        }

        /// <summary>
        /// 设置自动创建nz-form-label
        /// </summary>
        /// <param name="value">是否自动创建</param>
        public void AutoCreateFormLabel( bool value ) {
            if ( _shareConfig.AutoCreateFormLabel == false )
                return;
            _shareConfig.AutoCreateFormLabel = value;
        }

        /// <summary>
        /// 设置自动创建nz-form-control
        /// </summary>
        /// <param name="value">是否自动创建</param>
        public void AutoCreateFormControl( bool value ) {
            if ( _shareConfig.AutoCreateFormControl == false )
                return;
            _shareConfig.AutoCreateFormControl = value;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            InitFormItemShareConfig();
            MapToItemShareConfig();
            InitControlId();
            SetLabelText();
            SetExtra();
            SetSuccessTip();
            SetWarningTip();
            SetErrorTip();
            SetValidatingTip();
            AutoCreateFormContainer();
            DisableLabelForTableEdit();
            SetNgIf();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitFormItemShareConfig() {
            _shareConfig = GetFormItemShareConfig();
            _config.SetValueToItems( _shareConfig );
        }

        /// <summary>
        /// 获取表单项共享配置
        /// </summary>
        private FormItemShareConfig GetFormItemShareConfig() {
            return _config.GetValueFromItems<FormItemShareConfig>() ?? new FormItemShareConfig();
        }

        /// <summary>
        /// 初始化控件Id
        /// </summary>
        public void InitControlId() {
            if ( _shareConfig.AutoLabelFor != true )
                return;
            if ( _shareConfig.ControlId.IsEmpty() == false )
                return;
            _shareConfig.ControlId = GetControlId();
        }

        /// <summary>
        /// 获取控件Id
        /// </summary>
        private string GetControlId() {
            var id = _config.GetValue( AngularConst.RawId );
            if ( id.IsEmpty() == false )
                return id;
            id = _config.GetValue( UiConst.Id );
            if ( id.IsEmpty() == false )
                return $"control_{id}";
            return $"control_{Util.Helpers.Id.Create()}";
        }

        /// <summary>
        /// 将表单共享配置映射到表单项共享配置
        /// </summary>
        private void MapToItemShareConfig() {
            var formShareConfig = GetFormShareConfig();
            formShareConfig.MapTo( _shareConfig );
        }

        /// <summary>
        /// 获取表单共享配置
        /// </summary>
        private FormShareConfig GetFormShareConfig() {
            return _config.GetValueFromItems<FormShareConfig>() ?? new FormShareConfig();
        }

        /// <summary>
        /// 设置表单标签文本
        /// </summary>
        private void SetLabelText() {
            var value = _config.GetValueFromAttributes( UiConst.LabelText );
            if ( string.IsNullOrWhiteSpace( value ) )
                return;
            _shareConfig.LabelText = value;
            AutoCreateFormLabel( true );
        }

        /// <summary>
        /// 设置额外提示
        /// </summary>
        private void SetExtra() {
            if ( _config.Contains( UiConst.Extra ) || _config.Contains( AngularConst.BindExtra ) )
                _shareConfig.HasExtra = true;
        }

        /// <summary>
        /// 设置成功提示
        /// </summary>
        private void SetSuccessTip() {
            if ( _config.Contains( UiConst.SuccessTip ) || _config.Contains( AngularConst.BindSuccessTip ) )
                _shareConfig.HasSuccessTip = true;
        }

        /// <summary>
        /// 设置警告提示
        /// </summary>
        private void SetWarningTip() {
            if ( _config.Contains( UiConst.WarningTip ) || _config.Contains( AngularConst.BindWarningTip ) )
                _shareConfig.HasWarningTip = true;
        }

        /// <summary>
        /// 设置错误提示
        /// </summary>
        private void SetErrorTip() {
            if ( _config.Contains( UiConst.ErrorTip ) || _config.Contains( AngularConst.BindErrorTip ) )
                _shareConfig.HasErrorTip = true;
        }

        /// <summary>
        /// 设置校验提示
        /// </summary>
        private void SetValidatingTip() {
            if ( _config.Contains( UiConst.ValidatingTip ) || _config.Contains( AngularConst.BindValidatingTip ) )
                _shareConfig.HasValidatingTip = true;
        }

        /// <summary>
        /// 自动创建表单控件容器
        /// </summary>
        private void AutoCreateFormContainer() {
            if ( IsAutoCreateFormContainer() == false )
                return;
            AutoCreateFormItem( true );
            AutoCreateFormControl( true );
        }

        /// <summary>
        /// 是否自动创建表单控件容器
        /// </summary>
        private bool IsAutoCreateFormContainer() {
            if ( string.IsNullOrWhiteSpace( _shareConfig.LabelText ) == false )
                return true;
            if ( _shareConfig.Align != null )
                return true;
            if ( _shareConfig.BindAlign.IsEmpty() == false )
                return true;
            if ( _shareConfig.Gutter.IsEmpty() == false )
                return true;
            if ( _shareConfig.Justify != null )
                return true;
            if ( _shareConfig.BindJustify.IsEmpty() == false )
                return true;
            if ( _shareConfig.HasExtra )
                return true;
            if ( _shareConfig.HasSuccessTip )
                return true;
            if ( _shareConfig.HasWarningTip )
                return true;
            if ( _shareConfig.HasErrorTip )
                return true;
            if ( _shareConfig.HasValidatingTip )
                return true;
            if ( _shareConfig.ControlSpan.IsEmpty() == false )
                return true;
            if ( _shareConfig.ControlOffset.IsEmpty() == false )
                return true;
            if ( _shareConfig.ControlOrder.IsEmpty() == false )
                return true;
            if ( _shareConfig.ControlPull.IsEmpty() == false )
                return true;
            if ( _shareConfig.ControlPush.IsEmpty() == false )
                return true;
            if ( _shareConfig.ControlFlex.IsEmpty() == false )
                return true;
            if ( _shareConfig.ControlXs.IsEmpty() == false )
                return true;
            if ( _shareConfig.ControlXsSpan != null )
                return true;
            if ( _shareConfig.ControlXsOffset != null )
                return true;
            if ( _shareConfig.ControlXsOrder != null )
                return true;
            if ( _shareConfig.ControlXsPull != null )
                return true;
            if ( _shareConfig.ControlXsPush != null )
                return true;
            if ( _shareConfig.ControlSm.IsEmpty() == false )
                return true;
            if ( _shareConfig.ControlSmSpan != null )
                return true;
            if ( _shareConfig.ControlSmOffset != null )
                return true;
            if ( _shareConfig.ControlSmOrder != null )
                return true;
            if ( _shareConfig.ControlSmPull != null )
                return true;
            if ( _shareConfig.ControlSmPush != null )
                return true;
            if ( _shareConfig.ControlMd.IsEmpty() == false )
                return true;
            if ( _shareConfig.ControlMdSpan != null )
                return true;
            if ( _shareConfig.ControlMdOffset != null )
                return true;
            if ( _shareConfig.ControlMdOrder != null )
                return true;
            if ( _shareConfig.ControlMdPull != null )
                return true;
            if ( _shareConfig.ControlMdPush != null )
                return true;
            if ( _shareConfig.ControlLg.IsEmpty() == false )
                return true;
            if ( _shareConfig.ControlLgSpan != null )
                return true;
            if ( _shareConfig.ControlLgOffset != null )
                return true;
            if ( _shareConfig.ControlLgOrder != null )
                return true;
            if ( _shareConfig.ControlLgPull != null )
                return true;
            if ( _shareConfig.ControlLgPush != null )
                return true;
            if ( _shareConfig.ControlXl.IsEmpty() == false )
                return true;
            if ( _shareConfig.ControlXlSpan != null )
                return true;
            if ( _shareConfig.ControlXlOffset != null )
                return true;
            if ( _shareConfig.ControlXlOrder != null )
                return true;
            if ( _shareConfig.ControlXlPull != null )
                return true;
            if ( _shareConfig.ControlXlPush != null )
                return true;
            if ( _shareConfig.ControlXxl.IsEmpty() == false )
                return true;
            if ( _shareConfig.ControlXxlSpan != null )
                return true;
            if ( _shareConfig.ControlXxlOffset != null )
                return true;
            if ( _shareConfig.ControlXxlOrder != null )
                return true;
            if ( _shareConfig.ControlXxlPull != null )
                return true;
            if ( _shareConfig.ControlXxlPush != null )
                return true;
            return false;
        }

        /// <summary>
        /// 表格编辑时禁用标签
        /// </summary>
        private void DisableLabelForTableEdit() {
            var config = GetTableColumnShareConfig();
            if ( config == null )
                return;
            _shareConfig.AutoCreateFormLabel = false;
        }

        /// <summary>
        /// 获取表格列共享配置
        /// </summary>
        public TableColumnShareConfig GetTableColumnShareConfig() {
            return _config.GetValueFromItems<TableColumnShareConfig>();
        }

        /// <summary>
        /// 设置ngIf*
        /// </summary>
        private void SetNgIf() {
            var value = _config.GetValueFromAttributes( AngularConst.NgIf );
            if ( value.IsEmpty() )
                return;
            if ( _shareConfig.AutoCreateFormItem != true )
                return;
            _shareConfig.NgIf = value;
            _config.RemoveAttribute( AngularConst.NgIf );
        }
    }
}
