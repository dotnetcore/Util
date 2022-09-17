using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表分页标签生成器
    /// </summary>
    public class ListPaginationBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表分页标签生成器
        /// </summary>
        public ListPaginationBuilder( Config config ) : base( "nz-list-pagination" ) {
            _config = config;
        }
    }
}