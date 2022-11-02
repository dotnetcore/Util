using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表加载更多标签生成器
    /// </summary>
    public class ListLoadMoreBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表加载更多标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ListLoadMoreBuilder( Config config ) : base( config,"nz-list-load-more" ) {
            _config = config;
        }
    }
}