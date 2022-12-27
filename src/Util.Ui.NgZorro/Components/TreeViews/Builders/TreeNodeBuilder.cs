using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.TreeViews.Builders {
    /// <summary>
    /// 树节点标签生成器
    /// </summary>
    public class TreeNodeBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化树节点标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeNodeBuilder( Config config ) : base( config,"nz-tree-node" ) {
            _config = config;
        }

        /// <summary>
        /// 配置树节点定义指令
        /// </summary>
        public TreeNodeBuilder TreeNodeDef() {
            AttributeIfNotEmpty( "*nzTreeNodeDef", _config.GetValue( UiConst.TreeNodeDef ) );
            return this;
        }

        /// <summary>
        /// 配置树节点内边距
        /// </summary>
        public TreeNodeBuilder TreeNodePadding() {
            AttributeIf( "nzTreeNodePadding", _config.GetValue<bool>( UiConst.TreeNodePadding ) );
            return this;
        }

        /// <summary>
        /// 配置树节点内边距
        /// </summary>
        public TreeNodeBuilder TreeNodeIndentLine() {
            AttributeIf( "nzTreeNodeIndentLine", _config.GetValue<bool>( UiConst.TreeNodeIndentLine ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            TreeNodeDef().TreeNodePadding().TreeNodeIndentLine();
        }
    }
}