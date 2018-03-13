using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Material.Grids.Builders {
    /// <summary>
    /// Mat网格列生成器
    /// </summary>
    public class GridColumnBuilder : TagBuilder {
        /// <summary>
        /// 初始化网格列生成器
        /// </summary>
        public GridColumnBuilder() : base( "mat-grid-tile" ) {
        }

        /// <summary>
        /// 添加合并列
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="name">属性名</param>
        public void AddColspan( IConfig config,string name) {
            AddAttribute( "colspan", config.GetValue( name ) );
        }
    }
}