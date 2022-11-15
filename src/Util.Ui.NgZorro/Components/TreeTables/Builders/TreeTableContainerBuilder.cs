using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.TreeTables.Builders {
    /// <summary>
    /// 树形表格主体行容器标签生成器
    /// </summary>
    public class TreeTableContainerBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 树形表格主体行标签生成器
        /// </summary>
        private readonly TreeTableBodyRowBuilder _rowBuilder;

        /// <summary>
        /// 初始化树形表格主体行容器标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="rowBuilder">树形表格主体行标签生成器</param>
        public TreeTableContainerBuilder( Config config, TreeTableBodyRowBuilder rowBuilder ) : base( config, "ng-container" ) {
            _config = config;
            _rowBuilder = rowBuilder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            _rowBuilder.Config();
            AppendContent( _rowBuilder );
        }
    }
}
