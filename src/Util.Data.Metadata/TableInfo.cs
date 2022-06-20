using System.Collections.Generic;

namespace Util.Data.Metadata {
    /// <summary>
    /// 表信息
    /// </summary>
    public class TableInfo {
        /// <summary>
        /// 初始化表信息
        /// </summary>
        public TableInfo() {
            Columns = new List<ColumnInfo>();
        }

        /// <summary>
        /// 表标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 架构
        /// </summary>
        public string Schema { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 注释
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 列信息集合
        /// </summary>
        public List<ColumnInfo> Columns { get; }
    }
}
