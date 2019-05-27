using Util.Ui.Builders;

namespace Util.Ui.Material.Tables.Builders {
    /// <summary>
    /// Material列头生成器
    /// </summary>
    public class HeaderCellBuilder : TagBuilder {
        /// <summary>
        /// 初始化列头生成器
        /// </summary>
        public HeaderCellBuilder() : base( "mat-header-cell" ) {
            AddAttribute( "*matHeaderCellDef" );
        }
    }
}