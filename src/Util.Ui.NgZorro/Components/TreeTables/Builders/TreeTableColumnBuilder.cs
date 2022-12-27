using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Components.Tables.Builders.Contents;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.TreeTables.Builders.Contents;

namespace Util.Ui.NgZorro.Components.TreeTables.Builders {
    /// <summary>
    /// 树形表格单元格标签生成器
    /// </summary>
    public class TreeTableColumnBuilder : TableColumnBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表格列共享配置
        /// </summary>
        private readonly TableColumnShareConfig _shareConfig;

        /// <summary>
        /// 初始化树形表格单元格标签生成器
        /// </summary>
        public TreeTableColumnBuilder( Config config, TableColumnShareConfig shareConfig ) : base( config, shareConfig ) {
            _config = config;
            _shareConfig = shareConfig;
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent() {
            var service = new TableColumnContentService( this,new TreeTableSelectCreateService() );
            service.Config();
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            ConfigDefault();
        }

        /// <summary>
        /// 配置默认属性
        /// </summary>
        protected void ConfigDefault() {
            if ( _shareConfig.IsFirst == false )
                return;
            if ( _shareConfig.IsEnableExtend == false )
                return;
            var tableExtendId = _shareConfig.TableExtendId;
            Attribute( "[nzIndentSize]", $"row.level*{tableExtendId}.config.table.indentUnitWidth" );
            Attribute( "[nzShowExpand]", $"!{tableExtendId}.isLeaf(row)" );
            Attribute( "[nzExpand]", $"{tableExtendId}.isExpand(row)" );
            Attribute( "(nzExpandChange)", $"{tableExtendId}.collapse(row,$event)" );
        }
    }
}