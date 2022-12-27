using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表项元信息描述标签生成器
    /// </summary>
    public class ListItemMetaDescriptionBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表项元信息描述标签生成器
        /// </summary>
        public ListItemMetaDescriptionBuilder( Config config ) : base( config,"nz-list-item-meta-description" ) {
            _config = config;
        }
    }
}