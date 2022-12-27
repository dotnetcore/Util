using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表底部标签生成器
    /// </summary>
    public class ListFooterBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表底部标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ListFooterBuilder( Config config ) : base( config,"nz-list-footer" ) {
            _config = config;
        }
    }
}