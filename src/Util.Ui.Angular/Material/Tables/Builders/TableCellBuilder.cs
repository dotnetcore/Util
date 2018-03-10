using Util.Ui.Builders;

namespace Util.Ui.Material.Tables.Builders {
    /// <summary>
    /// Material表格单元格生成器
    /// </summary>
    public class TableCellBuilder : TagBuilder {
        /// <summary>
        /// 初始化表格单元格生成器
        /// </summary>
        public TableCellBuilder() : base( "mat-cell" ) {
            AddAttribute( "*matCellDef", "let row" );
        }
    }
}