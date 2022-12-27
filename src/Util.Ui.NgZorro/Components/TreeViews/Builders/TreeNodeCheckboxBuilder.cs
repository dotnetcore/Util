using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.TreeViews.Builders {
    /// <summary>
    /// 树节点复选框标签生成器
    /// </summary>
    public class TreeNodeCheckboxBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化树节点复选框标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeNodeCheckboxBuilder( Config config ) : base( config,"nz-tree-node-checkbox" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否勾选
        /// </summary>
        public TreeNodeCheckboxBuilder Checked() {
            AttributeIfNotEmpty( "[nzChecked]", _config.GetBoolValue( UiConst.Checked ) );
            AttributeIfNotEmpty( "[nzChecked]", _config.GetValue( AngularConst.BindChecked ) );
            return this;
        }

        /// <summary>
        /// 配置是否半选
        /// </summary>
        public TreeNodeCheckboxBuilder Indeterminate() {
            AttributeIfNotEmpty( "[nzIndeterminate]", _config.GetValue( UiConst.Indeterminate ) );
            return this;
        }

        /// <summary>
        /// 配置是否禁用
        /// </summary>
        public TreeNodeCheckboxBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TreeNodeCheckboxBuilder Events() {
            AttributeIfNotEmpty( "(nzClick)", _config.GetValue( UiConst.OnClick ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Checked().Indeterminate().Disabled().Events();
        }
    }
}