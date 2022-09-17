using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表加载更多标签生成器
    /// </summary>
    public class ListLoadMoreBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表加载更多标签生成器
        /// </summary>
        public ListLoadMoreBuilder( Config config ) : base( "nz-list-load-more" ) {
            _config = config;
        }
    }
}