using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;

namespace Util.Ui.NgZorro.Components.Checkboxes.Builders {
    /// <summary>
    /// 复选框标签生成器
    /// </summary>
    public class CheckboxBuilder : FormControlBuilderBase<CheckboxBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化复选框标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public CheckboxBuilder( Config config ) : base( config,"label" ) {
            _config = config;
            base.Attribute( "nz-checkbox" );
        }

        /// <summary>
        /// 配置自动获取焦点
        /// </summary>
        public CheckboxBuilder AutoFocus() {
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetBoolValue( UiConst.AutoFocus ) );
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetValue( AngularConst.BindAutoFocus ) );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public CheckboxBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置中间状态
        /// </summary>
        public CheckboxBuilder Indeterminate() {
            AttributeIfNotEmpty( "[nzIndeterminate]", _config.GetValue( UiConst.Indeterminate ) );
            return this;
        }

        /// <summary>
        /// 配置选中状态
        /// </summary>
        public CheckboxBuilder Checked() {
            AttributeIfNotEmpty( "[nzChecked]", _config.GetValue( UiConst.Checked ) );
            return this;
        }

        /// <summary>
        /// 配置值
        /// </summary>
        public CheckboxBuilder Value() {
            AttributeIfNotEmpty( "nzValue", _config.GetBoolValue( UiConst.Value ) );
            AttributeIfNotEmpty( "[nzValue]", _config.GetValue( AngularConst.BindValue ) );
            return this;
        }

        /// <summary>
        /// 配置标签
        /// </summary>
        public CheckboxBuilder Label() {
            if( _config.Contains( UiConst.Label ) ) {
                SetContent( _config.GetValue( UiConst.Label ) );
                return this;
            }
            var bindLabel = _config.GetValue( AngularConst.BindLabel );
            if( string.IsNullOrWhiteSpace( bindLabel ) )
                return this;
            SetContent( $"{{{{{bindLabel}}}}}" );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public CheckboxBuilder Events() {
            AttributeIfNotEmpty( "(nzCheckedChange)", _config.GetValue( UiConst.OnCheckedChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().Name().AutoFocus().Disabled().Indeterminate().Checked()
                .Value().Label().Events();
        }
    }
}
