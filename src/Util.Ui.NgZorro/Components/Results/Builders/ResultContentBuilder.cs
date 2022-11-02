using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Results.Builders {
    /// <summary>
    /// 结果内容标签生成器
    /// </summary>
    public class ResultContentBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化结果内容标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ResultContentBuilder( Config config ) : base( config,"div" ) {
            _config = config;
            base.Attribute( "nz-result-content" );
        }
    }
}