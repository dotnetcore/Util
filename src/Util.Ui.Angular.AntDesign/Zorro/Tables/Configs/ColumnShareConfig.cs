namespace Util.Ui.Zorro.Tables.Configs {
    /// <summary>
    /// 列共享配置
    /// </summary>
    public class ColumnShareConfig {
        /// <summary>
        /// 初始化列共享配置
        /// </summary>
        /// <param name="tableShareConfig">表格共享配置</param>
        /// <param name="column">列名</param>
        public ColumnShareConfig( TableShareConfig tableShareConfig, string column ) {
            TableId = tableShareConfig?.TableId;
            EditTableId = tableShareConfig?.EditTableId;
            RowId = tableShareConfig?.RowId;
            Column = column;
            IsCreateDisplay = true;
            IsCreateControl = true;
        }

        /// <summary>
        /// 表格标识
        /// </summary>
        public string TableId { get; }
        /// <summary>
        /// 编辑表格标识
        /// </summary>
        public string EditTableId { get; }
        /// <summary>
        /// 表格行标识
        /// </summary>
        public string RowId { get; }
        /// <summary>
        /// 列名
        /// </summary>
        public string Column { get; }
        /// <summary>
        /// 编辑模板标识
        /// </summary>
        public string TemplateId => $"{EditTableId}_{Column}";
        /// <summary>
        /// 是否编辑
        /// </summary>
        public bool IsEdit { get; set; }
        /// <summary>
        /// 是否创建显示内容，默认值：true
        /// </summary>
        public bool IsCreateDisplay { get; set; }
        /// <summary>
        /// 是否创建控件，默认值：true
        /// </summary>
        public bool IsCreateControl { get; set; }
    }
}
