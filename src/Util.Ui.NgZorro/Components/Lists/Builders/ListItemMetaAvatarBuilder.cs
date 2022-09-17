using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表项元信息头像标签生成器
    /// </summary>
    public class ListItemMetaAvatarBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表项元信息头像标签生成器
        /// </summary>
        public ListItemMetaAvatarBuilder( Config config ) : base( "nz-list-item-meta-avatar" ) {
            _config = config;
        }
    }
}