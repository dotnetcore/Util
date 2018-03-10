using Util.Ui.Builders;

namespace Util.Ui.Material.Tables.Builders {
    /// <summary>
    /// Material表格行生成器
    /// </summary>
    public class TableRowBuilder : TagBuilder {
        /// <summary>
        /// 初始化表格行生成器
        /// </summary>
        public TableRowBuilder() : base( "mat-row" ) {
            AddAttribute( "matRipple" ).Class( "mat-row-hover" );
        }

        /// <summary>
        /// 添加列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        public void AddColumns( string columns ) {
            AddAttribute( "*matRowDef", $"let row;columns:{columns}" );
        }
    }
}