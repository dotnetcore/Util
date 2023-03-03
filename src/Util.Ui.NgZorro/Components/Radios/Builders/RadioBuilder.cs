using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Radios.Configs;
using Util.Ui.NgZorro.Configs;

namespace Util.Ui.NgZorro.Components.Radios.Builders {
    /// <summary>
    /// 单选框标签生成器
    /// </summary>
    public class RadioBuilder : FormControlBuilderBase<RadioBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 单选框组合共享配置
        /// </summary>
        private readonly RadioGroupShareConfig _shareConfig;

        /// <summary>
        /// 初始化单选框标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public RadioBuilder( Config config ) : base( config,"label" ) {
            _config = config;
            _shareConfig = GetShareConfig();
            base.Attribute( "nz-radio" );
        }

        /// <summary>
        /// 获取单选框组合共享配置
        /// </summary>
        private RadioGroupShareConfig GetShareConfig() {
            return _config.GetValueFromItems<RadioGroupShareConfig>() ?? new RadioGroupShareConfig();
        }

        /// <summary>
        /// 配置名称
        /// </summary>
        public override RadioBuilder Name() {
            if ( _shareConfig.IsAutoCreateRadioGroup == true )
                return this;
            return base.Name();
        }

        /// <summary>
        /// 配置自动获取焦点
        /// </summary>
        public RadioBuilder AutoFocus() {
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetBoolValue( UiConst.AutoFocus ) );
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetValue( AngularConst.BindAutoFocus ) );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public RadioBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置值
        /// </summary>
        public RadioBuilder Value() {
            AttributeIfNotEmpty( "nzValue", _config.GetBoolValue( UiConst.Value ) );
            AttributeIfNotEmpty( "[nzValue]", _config.GetValue( AngularConst.BindValue ) );
            return this;
        }

        /// <summary>
        /// 配置标签
        /// </summary>
        public RadioBuilder Label() {
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
        public RadioBuilder Events() {
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().Name().AutoFocus().Disabled().Value()
                .Label().Events();
        }

        /// <summary>
        /// 配置模型绑定
        /// </summary>
        public override RadioBuilder NgModel() {
            if ( _shareConfig.IsAutoCreateRadioGroup != true )
                base.NgModel();
            return this;
        }

        /// <summary>
        /// 数据绑定扩展
        /// </summary>
        public void Extend() {
            this.NgFor( $"let item of {_shareConfig.ExtendId}.options" );
            Attribute( "[nzValue]", "item.value" );
            Attribute( "[nzDisabled]", "item.disabled" );
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                SetContent( "{{item.text|i18n}}" );
                return;
            }
            SetContent( "{{item.text}}" );
        }

        /// <summary>
        /// 配置模型变更事件
        /// </summary>
        public override RadioBuilder OnModelChange() {
            if ( _shareConfig.IsAutoCreateRadioGroup == true )
                return this;
            return base.OnModelChange();
        }
    }
}
