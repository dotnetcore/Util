using Util.Ui.Builders;

namespace Util.Ui.Material.Tables.Builders {
    /// <summary>
    /// Material单元格生成器
    /// </summary>
    public class CellBuilder : TagBuilder {
        /// <summary>
        /// 初始化单元格生成器
        /// </summary>
        public CellBuilder() : base( "mat-cell" ) {
            AddAttribute( "*matCellDef", "let row" );
        }
    }
}