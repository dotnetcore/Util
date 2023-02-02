using Util.Applications.Trees;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;

namespace Util.Ui.NgZorro.Components.TreeTables.Builders {
    /// <summary>
    /// 树形表格标签生成器
    /// </summary>
    public class TreeTableBuilder : TableBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化树形表格标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeTableBuilder( Config config ) : base( config ) {
            _config = config;
        }

        /// <inheritdoc />
        public override TableHeadBuilder CreateTableHeadBuilder() {
            return new TreeTableHeadBuilder( _config.CopyRemoveId() );
        }

        /// <inheritdoc />
        public override TableBodyBuilder CreateTableBodyBuilder() {
            return new TreeTableBodyBuilder( _config.CopyRemoveId() );
        }

        /// <summary>
        /// 配置加载地址
        /// </summary>
        public TreeTableBuilder LoadUrl() {
            AttributeIfNotEmpty( "loadUrl", _config.GetValue( UiConst.LoadUrl ) );
            AttributeIfNotEmpty( "[loadUrl]", _config.GetValue( AngularConst.BindLoadUrl ) );
            return this;
        }

        /// <summary>
        /// 配置查询地址
        /// </summary>
        public TreeTableBuilder QueryUrl() {
            AttributeIfNotEmpty( "queryUrl", _config.GetValue( UiConst.QueryUrl ) );
            AttributeIfNotEmpty( "[queryUrl]", _config.GetValue( AngularConst.BindQueryUrl ) );
            return this;
        }

        /// <summary>
        /// 配置加载子节点地址
        /// </summary>
        public TreeTableBuilder LoadChildrenUrl() {
            AttributeIfNotEmpty( "loadChildrenUrl", _config.GetValue( UiConst.LoadChildrenUrl ) );
            AttributeIfNotEmpty( "[loadChildrenUrl]", _config.GetValue( AngularConst.BindLoadChildrenUrl ) );
            return this;
        }

        /// <summary>
        /// 配置加载模式
        /// </summary>
        public TreeTableBuilder LoadMode() {
            var mode = _config.GetValue<LoadMode?>( UiConst.LoadMode );
            if ( mode == Applications.Trees.LoadMode.Sync )
                ShowPagination( "false" );
            AttributeIfNotEmpty( "loadMode", mode?.Value().SafeString() );
            return this;
        }

        /// <summary>
        /// 配置展开
        /// </summary>
        public TreeTableBuilder ExpandAll() {
            AttributeIfNotEmpty( "[isExpandAll]", _config.GetBoolValue( UiConst.ExpandAll ) );
            return this;
        }

        /// <summary>
        /// 配置根节点异步加载模式是否展开子节点
        /// </summary>
        public TreeTableBuilder ExpandForRootAsync() {
            AttributeIfNotEmpty( "[isExpandForRootAsync]", _config.GetBoolValue( UiConst.ExpandForRootAsync ) );
            return this;
        }

        /// <summary>
        /// 配置仅能选择叶节点
        /// </summary>
        public TreeTableBuilder CheckLeafOnly() {
            AttributeIfNotEmpty( "[isCheckLeafOnly]", _config.GetBoolValue( UiConst.CheckLeafOnly ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public new TreeTableBuilder Events() {
            AttributeIfNotEmpty( "[onLoadChildrenBefore]", _config.GetValue( UiConst.OnLoadChildrenBefore ) );
            AttributeIfNotEmpty( "(onLoadChildren)", _config.GetValue( UiConst.OnLoadChildren ) );
            AttributeIfNotEmpty( "(onExpand)", _config.GetValue( UiConst.OnExpand ) );
            AttributeIfNotEmpty( "(onCollapse)", _config.GetValue( UiConst.OnCollapse ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            LoadUrl().QueryUrl().LoadChildrenUrl()
                .LoadMode().ExpandAll().ExpandForRootAsync().CheckLeafOnly()
                .Events();
        }

        /// <inheritdoc />
        protected override void ConfigExtend() {
            Attribute( "x-tree-table-extend" );
            Attribute( $"#{ExtendId}", "xTreeTableExtend" );
            ConfigDefault();
        }
    }
}