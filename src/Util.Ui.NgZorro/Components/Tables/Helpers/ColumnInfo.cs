namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 列配置信息
    /// </summary>
    public class ColumnInfo {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string Column { get; set; }
        /// <summary>
        /// 是否排序
        /// </summary>
        public bool IsSort { get; set; }
        /// <summary>
        /// 是否序号
        /// </summary>
        public bool IsLineNumber { get; set; }
        /// <summary>
        /// 是否复选框
        /// </summary>
        public bool IsCheckbox { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// 获取排序字段
        /// </summary>
        public string GetOrder() {
            if( IsSort )
                return Column;
            return null;
        }
    }
}
