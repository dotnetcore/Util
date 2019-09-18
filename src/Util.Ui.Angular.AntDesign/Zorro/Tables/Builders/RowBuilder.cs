using Util.Ui.Builders;
using Util.Ui.Extensions;

namespace Util.Ui.Zorro.Tables.Builders {
    /// <summary>
    /// 表格行生成器
    /// </summary>
    public class RowBuilder : TagBuilder {
        /// <summary>
        /// 初始化表格行生成器
        /// </summary>
        public RowBuilder() : base( "tr" ) {
        }

        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="value">值</param>
        public void Click( string value ) {
            AddAttribute( "(click)", value, append: true );
        }

        /// <summary>
        /// 配置循环变量
        /// </summary>
        /// <param name="tableId">表格标识</param>
        /// <param name="indexName">行索引名称</param>
        public void ConfigIterationVar( string tableId, string indexName = "index" ) {
            this.NgFor( $"let row of {tableId}.data;index as {indexName}" );
        }

        /// <summary>
        /// 配置行编辑模式
        /// </summary>
        /// <param name="editTableId">编辑表格标识</param>
        /// <param name="rowId">行标识</param>
        public void ConfigEdit( string editTableId, string rowId ) {
            AddAttribute( "[x-edit-row]", "row" );
            AddAttribute( $"#{rowId}", "utilEditRow" );
            AddAttribute( "(click)", $"{editTableId}.clickEdit(row.id)", append: true );
            AddAttribute( "(dblclick)", $"{editTableId}.dblClickEdit(row.id)", append: true );
        }
    }
}
