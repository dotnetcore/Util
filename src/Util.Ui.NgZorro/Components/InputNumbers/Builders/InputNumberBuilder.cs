using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.InputNumbers.Builders {
    /// <summary>
    /// 数字输入框标签生成器
    /// </summary>
    public class InputNumberBuilder : FormControlBuilderBase<InputNumberBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化数字输入框标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public InputNumberBuilder( Config config ) : base( config, "nz-input-number" ) {
            _config = config;
        }

        /// <summary>
        /// 配置输入框标识
        /// </summary>
        public InputNumberBuilder InputId() {
            AttributeIfNotEmpty( "nzId", _config.GetValue( UiConst.InputId ) );
            return this;
        }
        
        /// <summary>
        /// 配置自动聚焦
        /// </summary>
        public InputNumberBuilder AutoFocus() {
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetBoolValue( UiConst.AutoFocus ) );
            AttributeIfNotEmpty( "[nzAutoFocus]", _config.GetValue( AngularConst.BindAutoFocus ) );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public InputNumberBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置最大值
        /// </summary>
        public InputNumberBuilder Max() {
            AttributeIfNotEmpty( "nzMax", _config.GetValue( UiConst.Max ) );
            AttributeIfNotEmpty( "[nzMax]", _config.GetValue( AngularConst.BindMax ) );
            return this;
        }

        /// <summary>
        /// 配置最小值
        /// </summary>
        public InputNumberBuilder Min() {
            AttributeIfNotEmpty( "nzMin", _config.GetValue( UiConst.Min ) );
            AttributeIfNotEmpty( "[nzMin]", _config.GetValue( AngularConst.BindMin ) );
            return this;
        }

        /// <summary>
        /// 配置格式化函数
        /// </summary>
        public InputNumberBuilder Formatter() {
            AttributeIfNotEmpty( "[nzFormatter]", _config.GetValue( UiConst.Formatter ) );
            return this;
        }

        /// <summary>
        /// 配置转换函数
        /// </summary>
        public InputNumberBuilder Parser() {
            AttributeIfNotEmpty( "[nzParser]", _config.GetValue( UiConst.Parser ) );
            return this;
        }

        /// <summary>
        /// 配置精度
        /// </summary>
        public InputNumberBuilder Precision() {
            AttributeIfNotEmpty( "nzPrecision", _config.GetValue( UiConst.Precision ) );
            AttributeIfNotEmpty( "[nzPrecision]", _config.GetValue( AngularConst.BindPrecision ) );
            return this;
        }

        /// <summary>
        /// 配置精度模式
        /// </summary>
        public InputNumberBuilder PrecisionMode() {
            AttributeIfNotEmpty( "nzPrecisionMode", _config.GetValue<InputNumberPrecisionMode?>( UiConst.PrecisionMode )?.Description() );
            AttributeIfNotEmpty( "[nzPrecisionMode]", _config.GetValue( AngularConst.BindPrecisionMode ) );
            return this;
        }

        /// <summary>
        /// 配置输入框大小
        /// </summary>
        public InputNumberBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<InputSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置步数
        /// </summary>
        public InputNumberBuilder Step() {
            AttributeIfNotEmpty( "nzStep", _config.GetValue( UiConst.Step ) );
            AttributeIfNotEmpty( "[nzStep]", _config.GetValue( AngularConst.BindStep ) );
            return this;
        }

        /// <summary>
        /// 配置输入模式
        /// </summary>
        public InputNumberBuilder InputMode() {
            AttributeIfNotEmpty( "nzInputMode", _config.GetValue<InputMode?>( UiConst.InputMode )?.Description() );
            AttributeIfNotEmpty( "[nzInputMode]", _config.GetValue( AngularConst.BindInputMode ) );
            return this;
        }

        /// <summary>
        /// 配置占位提示
        /// </summary>
        public InputNumberBuilder Placeholder() {
            AttributeIfNotEmpty( "nzPlaceHolder", _config.GetValue( UiConst.Placeholder ) );
            AttributeIfNotEmpty( "[nzPlaceHolder]", _config.GetValue( AngularConst.BindPlaceholder ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public InputNumberBuilder Events() {
            AttributeIfNotEmpty( "(nzFocus)", _config.GetValue( UiConst.OnFocus ) );
            AttributeIfNotEmpty( "(nzBlur)", _config.GetValue( UiConst.OnBlur ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            ConfigForm().Name().InputId().AutoFocus().Disabled().Max().Min().Formatter().Parser()
                .Precision().PrecisionMode().Size().Step().InputMode().Placeholder()
                .Events();
        }
    }
}