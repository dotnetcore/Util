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
    }
}