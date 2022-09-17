using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Selects.Builders {
    /// <summary>
    /// 选项组标签生成器
    /// </summary>
    public class OptionGroupBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化选项组标签生成器
        /// </summary>
        public OptionGroupBuilder( Config config ) : base( "nz-option-group" ) {
            _config = config;
        }

        /// <summary>
        /// 配置组名
        /// </summary>
        public OptionGroupBuilder Label() {
            AttributeIfNotEmpty( "nzLabel", _config.GetValue( UiConst.Label ) );
            AttributeIfNotEmpty( "[nzLabel]", _config.GetValue( AngularConst.BindLabel ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            Label();
        }
    }
}