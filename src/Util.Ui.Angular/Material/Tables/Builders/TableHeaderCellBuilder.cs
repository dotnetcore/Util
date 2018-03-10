using Util.Ui.Builders;

namespace Util.Ui.Material.Tables.Builders {
    /// <summary>
    /// Material表格列头生成器
    /// </summary>
    public class TableHeaderCellBuilder : TagBuilder {
        /// <summary>
        /// 初始化表格列头生成器
        /// </summary>
        public TableHeaderCellBuilder() : base( "mat-header-cell" ) {
            AddAttribute( "*matHeaderCellDef" );
        }
    }
}