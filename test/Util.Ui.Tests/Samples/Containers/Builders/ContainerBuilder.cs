using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Tests.Samples.Containers.Builders {
    /// <summary>
    /// ng-container标签生成器
    /// </summary>
    public class ContainerBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化ng-container标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ContainerBuilder( Config config ) : base( "ng-container" ) {
            _config = config;
        }
    }
}
