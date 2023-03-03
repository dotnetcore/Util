using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Tests.Samples.Templates.Builders {
    /// <summary>
    /// ng-template标签生成器
    /// </summary>
    public class TemplateBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化ng-template标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TemplateBuilder( Config config ) : base( config, "ng-template" ) {
            _config = config;
        }

        /// <summary>
        /// 配置选项卡是否延迟加载
        /// </summary>
        public TemplateBuilder Tab() {
            Tab( _config.GetValue<bool?>( UiConst.Tab ) == true );
            return this;
        }

        /// <summary>
        /// 配置选项卡是否延迟加载
        /// </summary>
        public TemplateBuilder Tab( bool value ) {
            AttributeIf( "nz-tab", value );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Tab();
        }
    }
}
