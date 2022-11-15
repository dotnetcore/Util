using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;

namespace Util.Ui.NgZorro.Components.TreeTables.Builders {
    /// <summary>
    /// 树形表头标签生成器
    /// </summary>
    public class TreeTableHeadBuilder : TableHeadBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化树形表头标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeTableHeadBuilder( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 创建表头行标签生成器
        /// </summary>
        public override TableHeadRowBuilder CreateTableHeadRowBuilder() {
            return new TreeTableHeadRowBuilder( _config.CopyRemoveId() );
        }
    }
}