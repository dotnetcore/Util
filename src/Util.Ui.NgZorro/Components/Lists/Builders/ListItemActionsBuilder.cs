using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表项操作标签生成器
    /// </summary>
    public class ListItemActionsBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表项操作标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ListItemActionsBuilder( Config config ) : base( config,"ul" ) {
            _config = config;
            base.Attribute( "nz-list-item-actions" );
        }
    }
}