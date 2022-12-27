using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.TreeViews.Builders {
    /// <summary>
    /// 树视图标签生成器
    /// </summary>
    public class TreeViewBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化树视图标签生成器
        /// </summary>
        public TreeViewBuilder( Config config ) : base( config,"nz-tree-view" ) {
            _config = config;
        }

        /// <summary>
        /// 配置树控制器
        /// </summary>
        public TreeViewBuilder TreeControl() {
            AttributeIfNotEmpty( "[nzTreeControl]", _config.GetValue( UiConst.TreeControl ) );
            return this;
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        public TreeViewBuilder DataSource() {
            AttributeIfNotEmpty( "[nzDataSource]", _config.GetValue( UiConst.Datasource ) );
            return this;
        }

        /// <summary>
        /// 配置是否文件夹样式
        /// </summary>
        public TreeViewBuilder DirectoryTree() {
            AttributeIfNotEmpty( "[nzDirectoryTree]", _config.GetBoolValue( UiConst.DirectoryTree ) );
            AttributeIfNotEmpty( "[nzDirectoryTree]", _config.GetValue( AngularConst.BindDirectoryTree ) );
            return this;
        }

        /// <summary>
        /// 配置节点是否占整行
        /// </summary>
        public TreeViewBuilder BlockNode() {
            AttributeIfNotEmpty( "[nzBlockNode]", _config.GetBoolValue( UiConst.BlockNode ) );
            AttributeIfNotEmpty( "[nzBlockNode]", _config.GetValue( AngularConst.BindBlockNode ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            TreeControl().DataSource().DirectoryTree().BlockNode();
        }
    }
}