using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Autocompletes.Builders {
    /// <summary>
    /// 自动完成选项组标签生成器
    /// </summary>
    public class AutoOptionGroupBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化自动完成选项组标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public AutoOptionGroupBuilder( Config config ) : base( config, "nz-auto-optgroup" ) {
            _config = config;
        }

        /// <summary>
        /// 配置组名
        /// </summary>
        public AutoOptionGroupBuilder Label() {
            Label( _config.GetValue( UiConst.Label ) );
            return BindLabel( _config.GetValue( AngularConst.BindLabel ) );
        }

        /// <summary>
        /// 配置组名
        /// </summary>
        public AutoOptionGroupBuilder Label( string value ) {
            AttributeIfNotEmpty( "nzLabel", value );
            return this;
        }

        /// <summary>
        /// 配置组名
        /// </summary>
        public AutoOptionGroupBuilder BindLabel( string value ) {
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