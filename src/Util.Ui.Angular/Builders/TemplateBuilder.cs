using Util.Ui.Configs;

namespace Util.Ui.Angular.Builders {
    /// <summary>
    /// ng-template标签生成器
    /// </summary>
    public class TemplateBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化ng-template标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TemplateBuilder( Config config ) : base( config, "ng-template" ) {
        }
    }
}
