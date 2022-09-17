using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Results.Builders {
    /// <summary>
    /// 结果操作区标签生成器
    /// </summary>
    public class ResultExtraBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化结果操作区标签生成器
        /// </summary>
        public ResultExtraBuilder( Config config ) : base( "div" ) {
            _config = config;
            base.Attribute( "nz-result-extra" );
        }
    }
}