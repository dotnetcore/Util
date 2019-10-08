namespace Util.Ui.Builders {
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
            this.AppendContent( title );
        }
    }
}
