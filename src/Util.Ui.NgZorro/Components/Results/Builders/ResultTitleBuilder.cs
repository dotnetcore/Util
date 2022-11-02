using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Results.Builders {
    /// <summary>
    /// 结果标题标签生成器
    /// </summary>
    public class ResultTitleBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化结果标题标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ResultTitleBuilder( Config config ) : base( config,"div" ) {
            _config = config;
            base.Attribute( "nz-result-title" );
        }
    }
}