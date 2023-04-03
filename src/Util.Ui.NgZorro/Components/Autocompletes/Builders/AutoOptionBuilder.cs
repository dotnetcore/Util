using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.Extensions;

namespace Util.Ui.NgZorro.Components.Autocompletes.Builders {
    /// <summary>
    /// 自动完成项标签生成器
    /// </summary>
    public class AutoOptionBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化自动完成项标签生成器
        /// </summary>
        public AutoOptionBuilder( Config config ) : base( config,"nz-auto-option" ) {
            _config = config;
        }

        /// <summary>
        /// 配置值
        /// </summary>
        public AutoOptionBuilder Value() {
            AttributeIfNotEmpty( "nzValue", _config.GetValue( UiConst.Value ) );
            BindValue( _config.GetValue( AngularConst.BindValue ) );
            return this;
        }

        /// <summary>
        /// 配置值
        /// </summary>
        public AutoOptionBuilder BindValue( string value ) {
            AttributeIfNotEmpty( "[nzValue]", value );
            return this;
        }

        /// <summary>
        /// 配置标签
        /// </summary>
        public AutoOptionBuilder Label() {
            AttributeIfNotEmpty( "nzLabel", _config.GetValue( UiConst.Label ) );
            BindLabel( _config.GetValue( AngularConst.BindLabel ) );
            return this;
        }

        /// <summary>
        /// 配置标签
        /// </summary>
        public AutoOptionBuilder BindLabel( string value ) {
            AttributeIfNotEmpty( "[nzLabel]", value );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public AutoOptionBuilder Disabled() {
            Disabled( _config.GetBoolValue( UiConst.Disabled ) );
            Disabled( _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public AutoOptionBuilder Disabled( string value ) {
            AttributeIfNotEmpty( "[nzDisabled]", value );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Value().Label().Disabled();
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent(Config config) {
            if ( config.Content.IsEmpty() == false ) {
                config.Content.AppendTo( this );
                return;
            }
            var label = config.GetValue( UiConst.Label );
            if ( string.IsNullOrWhiteSpace( label ) == false ) {
                AppendContent( label );
                return;
            }
            var bindLabel = config.GetValue( AngularConst.BindLabel );
            if ( string.IsNullOrWhiteSpace( bindLabel ) )
                return;
            AppendContent( $"{{{{{bindLabel}}}}}" );
        }
    }
}