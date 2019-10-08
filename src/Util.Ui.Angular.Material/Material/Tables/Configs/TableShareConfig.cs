using System.Collections.Generic;

namespace Util.Ui.Material.Tables.Configs {
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
            Columns = new List<string>();
            AutoCreateRow = true;
        }

        /// <summary>
        /// 表格标识
        /// </summary>
        public string TableId { get; }

        /// <summary>
        /// 列集合
        /// </summary>
        public List<string> Columns { get; }

        /// <summary>
        /// 是否自动创建行
        /// </summary>
        public bool AutoCreateRow { get; set; }
    }
}
