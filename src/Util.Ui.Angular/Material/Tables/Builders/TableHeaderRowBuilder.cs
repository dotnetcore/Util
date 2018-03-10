using Util.Ui.Builders;

namespace Util.Ui.Material.Tables.Builders {
    /// <summary>
    /// Material表格行标头生成器
    /// </summary>
    public class TableHeaderRowBuilder : TagBuilder {
        /// <summary>
        /// 初始化表格行标头生成器
        /// </summary>
        public TableHeaderRowBuilder() : base( "mat-header-row" ) {
        }

        /// <summary>
        /// 添加列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        public void AddColumns( string columns ) {
            AddAttribute( "*matHeaderRowDef", columns );
        }
    }
}