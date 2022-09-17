using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.TreeViews.Builders {
    /// <summary>
    /// 树节点可选项标签生成器
    /// </summary>
    public class TreeNodeOptionBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化树节点可选项标签生成器
        /// </summary>
        public TreeNodeOptionBuilder( Config config ) : base( "nz-tree-node-option" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否选中
        /// </summary>
        public TreeNodeOptionBuilder Selected() {
            AttributeIfNotEmpty( "[nzSelected]", _config.GetBoolValue( UiConst.Selected ) );
            AttributeIfNotEmpty( "[nzSelected]", _config.GetValue( AngularConst.BindSelected ) );
            return this;
        }

        /// <summary>
        /// 配置是否禁用
        /// </summary>
        public TreeNodeOptionBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TreeNodeOptionBuilder Events() {
            AttributeIfNotEmpty( "(nzClick)", _config.GetValue( UiConst.OnClick ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            Selected().Disabled().Events();
        }
    }
}