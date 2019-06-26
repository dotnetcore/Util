using Util.Ui.Builders;
using Util.Ui.Helpers;

namespace Util.Ui.Zorro.Tables.Builders {
    /// <summary>
    /// 表格标题列th生成器
    /// </summary>
    public class TableHeadColumnBuilder : TagBuilder {
        /// <summary>
        /// 初始化表格标题列th生成器
        /// </summary>
        public TableHeadColumnBuilder() : base( "th" ) {
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        public void Title( string title ) {
            AppendContent( title );
        }

        /// <summary>
        /// 添加复选框
        /// </summary>
        /// <param name="tableId">表格标识</param>
        public void AddCheckBox( string tableId ) {
            AddAttribute( "[nzShowCheckbox]", $"{tableId}_wrapper.multiple" );
            AddAttribute( "(nzCheckedChange)", $"{tableId}_wrapper.masterToggle()" );
            AddAttribute( "[nzChecked]", $"{tableId}_wrapper.isMasterChecked()" );
            AddAttribute( "[nzDisabled]", $"!{tableId}_wrapper.dataSource.length" );
            AddAttribute( "[nzIndeterminate]", $"{tableId}_wrapper.isMasterIndeterminate()" );
            AppendContent( $"{{{{{tableId}_wrapper.multiple?'':'单选'}}}}" );
        }

        /// <summary>
        /// 添加排序
        /// </summary>
        /// <param name="sortKey">排序字段</param>
        public void AddSort( string sortKey ) {
            if( sortKey.IsEmpty() )
                return;
            AddAttribute( "[nzShowSort]", "true" );
            AddAttribute( "nzSortKey", sortKey );
        }

        /// <summary>
        /// 添加宽度
        /// </summary>
        /// <param name="width">宽度</param>
        public void AddWidth( string width ) {
            AddAttribute( "nzWidth", CommonHelper.GetPixelValue( width ) );
        }
    }
}
