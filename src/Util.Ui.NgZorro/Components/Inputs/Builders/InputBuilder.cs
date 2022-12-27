using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Components.Base;

namespace Util.Ui.NgZorro.Components.Inputs.Builders {
    /// <summary>
    /// 输入框标签生成器
    /// </summary>
    public class InputBuilder : FormControlBuilderBase<InputBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化输入框标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public InputBuilder( Config config ) : base( config, "input", Microsoft.AspNetCore.Mvc.Rendering.TagRenderMode.SelfClosing ) {
            base.Attribute( "nz-input" );
            _config = config;
        }

        /// <summary>
        /// 配置占位符
        /// </summary>
        public virtual InputBuilder Placeholder() {
            AttributeIfNotEmpty( "placeholder", _config.GetValue( UiConst.Placeholder ) );
            AttributeIfNotEmpty( "[placeholder]", _config.GetValue( AngularConst.BindPlaceholder ) );
            return this;
        }
        
        /// <summary>
        /// 配置禁用
        /// </summary>
        public InputBuilder Disabled() {
            AttributeIfNotEmpty( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[disabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置只读
        /// </summary>
        public InputBuilder Readonly() {
            AttributeIfNotEmpty( "[readOnly]", _config.GetBoolValue( UiConst.Readonly ) );
            AttributeIfNotEmpty( "[readOnly]", _config.GetValue( AngularConst.BindReadonly ) );
            return this;
        }

        /// <summary>
        /// 配置输入框大小
        /// </summary>
        public InputBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<InputSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置输入框类型
        /// </summary>
        public InputBuilder Type() {
            AttributeIfNotEmpty( "type", _config.GetValue<InputType?>( UiConst.Type )?.Description() );
            AttributeIfNotEmpty( "[type]", _config.GetValue( AngularConst.BindType ) );
            return this;
        }

        /// <summary>
        /// 配置自动完成
        /// </summary>
        public InputBuilder Autocomplete() {
            AttributeIfNotEmpty( "[nzAutocomplete]", _config.GetValue( UiConst.Autocomplete ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public InputBuilder Events() {
            AttributeIfNotEmpty( "(input)", _config.GetValue( UiConst.OnInput ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().Name().Placeholder().Disabled().Readonly().Size()
                .Type().Autocomplete().Events();
        }
    }
}