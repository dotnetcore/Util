using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;

namespace Util.Ui.NgZorro.Components.TreeTables.Builders {
    /// <summary>
    /// 树形表头行标签生成器
    /// </summary>
    public class TreeTableHeadRowBuilder : TableHeadRowBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化树形表格主体行标签生成器
        /// </summary>
        public TreeTableHeadRowBuilder( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 创建表头单元格标签生成器
        /// </summary>
        public override TableHeadColumnBuilder CreateTableHeadColumnBuilder() {
            return new TreeTableHeadColumnBuilder( _config.CopyRemoveId(), GetTableHeadColumnShareConfig() );
        }
    }
}