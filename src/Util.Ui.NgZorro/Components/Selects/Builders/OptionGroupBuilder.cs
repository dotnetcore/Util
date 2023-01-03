using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Selects.Builders {
    /// <summary>
    /// 选项组标签生成器
    /// </summary>
    public class OptionGroupBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化选项组标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public OptionGroupBuilder( Config config ) : base( config,"nz-option-group" ) {
            _config = config;
        }

        /// <summary>
        /// 配置组名
        /// </summary>
        public OptionGroupBuilder Label() {
            Label( _config.GetValue( UiConst.Label ) );
            return BindLabel( _config.GetValue( AngularConst.BindLabel ) );
        }

        /// <summary>
        /// 配置组名
        /// </summary>
        public OptionGroupBuilder Label( string value ) {
            AttributeIfNotEmpty( "nzLabel", value );
            return this;
        }

        /// <summary>
        /// 配置组名
        /// </summary>
        public OptionGroupBuilder BindLabel( string value ) {
            AttributeIfNotEmpty( "[nzLabel]", value );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Label();
        }
    }
}