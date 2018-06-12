using Util.Ui.Builders;

namespace Util.Ui.Material.Tables.Builders {
    /// <summary>
    /// Material行生成器
    /// </summary>
    public class RowBuilder : TagBuilder {
        /// <summary>
        /// 初始化行生成器
        /// </summary>
        public RowBuilder() : base( "mat-row" ) {
            Class( "mat-row-hover" );
        }

        /// <summary>
        /// 添加列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        public void AddColumns( string columns ) {
            AddAttribute( "*matRowDef", $"let row;columns:{GetColumns(columns)}" );
        }

        /// <summary>
        /// 获取列集合
        /// </summary>
        private string GetColumns( string columns ) {
            if( string.IsNullOrWhiteSpace( columns ) )
                return null;
            return columns.StartsWith( "[" ) ? columns : $"[{columns}]";
        }

        /// <summary>
        /// 添加选中样式
        /// </summary>
        /// <param name="tableId">表格标识</param>
        public void AddSelected( string tableId ) {
            AddAttribute( "[class.selected]", $"{tableId}.selectedSelection.isSelected(row)" );
            AddAttribute( "(click)", $"{tableId}.selectedSelection.select(row)" );
        }
    }
}