using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Containers.Builders {
    /// <summary>
    /// ng-container标签生成器
    /// </summary>
    public class ContainerBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化ng-container标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ContainerBuilder( Config config ) : base( config, "ng-container" ) {
            _config = config;
        }

        /// <summary>
        /// 配置提及建议
        /// </summary>
        public ContainerBuilder MentionSuggestion() {
            AttributeIfNotEmpty( "*nzMentionSuggestion", _config.GetValue( UiConst.MentionSuggestion ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            MentionSuggestion();
        }
    }
}
