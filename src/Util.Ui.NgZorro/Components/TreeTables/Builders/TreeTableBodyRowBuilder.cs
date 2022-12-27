using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;

namespace Util.Ui.NgZorro.Components.TreeTables.Builders {
    /// <summary>
    /// 树形表格主体行标签生成器
    /// </summary>
    public class TreeTableBodyRowBuilder : TableBodyRowBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化树形表格主体行标签生成器
        /// </summary>
        public TreeTableBodyRowBuilder( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 配置行默认属性
        /// </summary>
        protected override void ConfigDefault() {
            this.NgIf( $"{TableExtendId}.isShow(row)" );
        }
    }
}