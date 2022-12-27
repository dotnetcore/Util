using System.Collections.Generic;

namespace Util.Data.Metadata {
    /// <summary>
    /// 数据库信息
    /// </summary>
    public class DatabaseInfo {
        /// <summary>
        /// 初始化数据库信息
        /// </summary>
        public DatabaseInfo() {
            Tables = new List<TableInfo>();
        }

        /// <summary>
        /// 数据库标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 数据库名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 表信息集合
        /// </summary>
        public List<TableInfo> Tables { get; }
    }
}
