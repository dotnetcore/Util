namespace Util.Ui.Zorro.Tables.Configs {
    /// <summary>
    /// 列配置信息
    /// </summary>
    public class ColumnInfo {
        /// <summary>
        /// 初始化列配置信息
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="column">列名</param>
        public ColumnInfo( string title, string column ) {
            Title = title;
            Column = column;
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// 列名
        /// </summary>
        public string Column { get; }
        /// <summary>
        /// 是否排序
        /// </summary>
        public bool IsSort { get; set; }
        /// <summary>
        /// 是否复选框
        /// </summary>
        public bool IsCheckbox { get; set; }
        /// <summary>
        /// 是否序号
        /// </summary>
        public bool IsLineNumber { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 获取排序字段
        /// </summary>
        public string GetSortKey() {
            if( IsSort )
                return Column;
            return null;
        }
    }
}
