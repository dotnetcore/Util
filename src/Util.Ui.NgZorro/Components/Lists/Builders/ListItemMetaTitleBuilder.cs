using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表项元信息标题标签生成器
    /// </summary>
    public class ListItemMetaTitleBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表项元信息标题标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ListItemMetaTitleBuilder( Config config ) : base( config, "nz-list-item-meta-title" ) {
            _config = config;
        }
    }
}