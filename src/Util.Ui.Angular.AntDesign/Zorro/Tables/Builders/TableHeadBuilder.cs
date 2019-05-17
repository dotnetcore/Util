using Util.Ui.Builders;

namespace Util.Ui.Zorro.Tables.Builders {
    /// <summary>
    /// 表格头thead生成器
    /// </summary>
    public class TableHeadBuilder : TagBuilder {
        /// <summary>
        /// 初始化表格头thead生成器
        /// </summary>
        public TableHeadBuilder() : base( "thead" ) {
        }

        /// <summary>
        /// 添加排序变更事件处理
        /// </summary>
        /// <param name="onSortChange">排序变更事件处理函数</param>
        public void AddSortChange( string onSortChange ) {
            AddAttribute( "(nzSortChange)", onSortChange );
        }
    }
}
