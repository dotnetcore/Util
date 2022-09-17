using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表头部标签生成器
    /// </summary>
    public class ListHeaderBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表头部标签生成器
        /// </summary>
        public ListHeaderBuilder( Config config ) : base( "nz-list-header" ) {
            _config = config;
        }
    }
}