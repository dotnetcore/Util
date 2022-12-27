using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.TreeViews.Builders {
    /// <summary>
    /// 虚拟滚动树视图标签生成器
    /// </summary>
    public class TreeVirtualScrollViewBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化虚拟滚动树视图标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeVirtualScrollViewBuilder( Config config ) : base( config,"nz-tree-virtual-scroll-view" ) {
            _config = config;
        }

        /// <summary>
        /// 配置树控制器
        /// </summary>
        public TreeVirtualScrollViewBuilder TreeControl() {
            AttributeIfNotEmpty( "[nzTreeControl]", _config.GetValue( UiConst.TreeControl ) );
            return this;
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        public TreeVirtualScrollViewBuilder DataSource() {
            AttributeIfNotEmpty( "[nzDataSource]", _config.GetValue( UiConst.Datasource ) );
            return this;
        }

        /// <summary>
        /// 配置是否文件夹样式
        /// </summary>
        public TreeVirtualScrollViewBuilder DirectoryTree() {
            AttributeIfNotEmpty( "[nzDirectoryTree]", _config.GetBoolValue( UiConst.DirectoryTree ) );
            AttributeIfNotEmpty( "[nzDirectoryTree]", _config.GetValue( AngularConst.BindDirectoryTree ) );
            return this;
        }

        /// <summary>
        /// 配置节点是否占整行
        /// </summary>
        public TreeVirtualScrollViewBuilder BlockNode() {
            AttributeIfNotEmpty( "[nzBlockNode]", _config.GetBoolValue( UiConst.BlockNode ) );
            AttributeIfNotEmpty( "[nzBlockNode]", _config.GetValue( AngularConst.BindBlockNode ) );
            return this;
        }

        /// <summary>
        /// 配置虚拟滚动列高
        /// </summary>
        public TreeVirtualScrollViewBuilder ItemSize() {
            AttributeIfNotEmpty( "nzItemSize", _config.GetValue( UiConst.ItemSize ) );
            AttributeIfNotEmpty( "[nzItemSize]", _config.GetValue( AngularConst.BindItemSize ) );
            return this;
        }

        /// <summary>
        /// 配置虚拟滚动缓冲区最大高度
        /// </summary>
        public TreeVirtualScrollViewBuilder MaxBufferPx() {
            AttributeIfNotEmpty( "nzMaxBufferPx", _config.GetValue( UiConst.MaxBufferPx ) );
            AttributeIfNotEmpty( "[nzMaxBufferPx]", _config.GetValue( AngularConst.BindMaxBufferPx ) );
            return this;
        }

        /// <summary>
        /// 配置虚拟滚动缓冲区最小高度
        /// </summary>
        public TreeVirtualScrollViewBuilder MinBufferPx() {
            AttributeIfNotEmpty( "nzMinBufferPx", _config.GetValue( UiConst.MinBufferPx ) );
            AttributeIfNotEmpty( "[nzMinBufferPx]", _config.GetValue( AngularConst.BindMinBufferPx ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            TreeControl().DataSource().DirectoryTree().BlockNode()
                .ItemSize().MaxBufferPx().MinBufferPx();
        }
    }
}