using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Autocompletes.Builders {
    /// <summary>
    /// 自动完成项标签生成器
    /// </summary>
    public class AutoOptionBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化自动完成项标签生成器
        /// </summary>
        public AutoOptionBuilder( Config config ) : base( "nz-auto-option" ) {
            _config = config;
        }

        /// <summary>
        /// 配置值
        /// </summary>
        public AutoOptionBuilder Value() {
            AttributeIfNotEmpty( "nzValue", _config.GetValue( UiConst.Value ) );
            AttributeIfNotEmpty( "[nzValue]", _config.GetValue( AngularConst.BindValue ) );
            return this;
        }

        /// <summary>
        /// 配置标签
        /// </summary>
        public AutoOptionBuilder Label() {
            AttributeIfNotEmpty( "nzLabel", _config.GetValue( UiConst.Label ) );
            AttributeIfNotEmpty( "[nzLabel]", _config.GetValue( AngularConst.BindLabel ) );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public AutoOptionBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            Value().Label().Disabled();
        }
    }
}