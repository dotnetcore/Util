using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.TreeViews.Builders {
    /// <summary>
    /// 树节点可选项标签生成器
    /// </summary>
    public class TreeNodeOptionBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化树节点可选项标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeNodeOptionBuilder( Config config ) : base( config,"nz-tree-node-option" ) {
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
            base.Config();
            Selected().Disabled().Events();
        }
    }
}