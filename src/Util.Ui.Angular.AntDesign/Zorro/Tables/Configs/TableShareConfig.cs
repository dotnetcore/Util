using System.Collections.Generic;

namespace Util.Ui.Zorro.Tables.Configs {
    /// <summary>
    /// 表格共享配置
    /// </summary>
    public class TableShareConfig {
        /// <summary>
        /// 初始化表格共享配置
        /// </summary>
        /// <param name="tableId">表格标识</param>
        public TableShareConfig( string tableId ) {
            TableId = tableId;
            Titles = new List<string>();
            AutoCreateRow = true;
            AutoCreateHead = true;
        }

        /// <summary>
        /// 表格标识
        /// </summary>
        public string TableId { get; }

        /// <summary>
        /// 标题集合
        /// </summary>
        public List<string> Titles { get; }

        /// <summary>
        /// 是否自动创建行
        /// </summary>
        public bool AutoCreateRow { get; set; }

        /// <summary>
        /// 是否自动创建表头
        /// </summary>
        public bool AutoCreateHead { get; set; }

        /// <summary>
        /// 是否自动创建表头复选框
        /// </summary>
        public bool AutoCreateHeadCheckbox { get; set; }
    }
}
