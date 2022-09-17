using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表项扩展标签生成器
    /// </summary>
    public class ListItemExtraBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表项扩展标签生成器
        /// </summary>
        public ListItemExtraBuilder( Config config ) : base( "nz-list-item-extra" ) {
            _config = config;
        }
    }
}