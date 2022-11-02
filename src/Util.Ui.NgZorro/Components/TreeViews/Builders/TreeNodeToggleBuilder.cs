using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.TreeViews.Builders {
    /// <summary>
    /// 树节点切换标签生成器
    /// </summary>
    public class TreeNodeToggleBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化树节点切换标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeNodeToggleBuilder( Config config ) : base( config,"nz-tree-node-toggle" ) {
            _config = config;
        }

        /// <summary>
        /// 配置空操作切换
        /// </summary>
        public TreeNodeToggleBuilder TreeNodeNoopToggle() {
            AttributeIf( "nzTreeNodeNoopToggle", _config.GetValue<bool>( UiConst.TreeNodeNoopToggle ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            TreeNodeNoopToggle();
        }
    }
}