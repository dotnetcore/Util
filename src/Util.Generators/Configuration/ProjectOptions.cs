using Util.Data;

namespace Util.Generators.Configuration {
    /// <summary>
    /// 项目配置项
    /// </summary>
    public class ProjectOptions {
        /// <summary>
        /// 初始化项目配置项
        /// </summary>
        public ProjectOptions() {
            Client = new ClientOptions();
        }

        /// <summary>
        /// 项目名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DbType { get; set; }
        /// <summary>
        /// 目标数据库类型
        /// </summary>
        public DatabaseType? TargetDbType { get; set; }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 工作单元名称
        /// </summary>
        public string UnitOfWorkName { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 是否启用Utc
        /// </summary>
        public bool Utc { get; set; }
        /// <summary>
        /// 是否启用多语言
        /// </summary>
        public bool I18n { get; set; }
        /// <summary>
        /// Web Api项目端口
        /// </summary>
        public string ApiPort { get; set; }
        /// <summary>
        /// 项目类型
        /// </summary>
        public ProjectType? ProjectType { get; set; }
        /// <summary>
        /// 客户端配置项
        /// </summary>
        public ClientOptions Client { get; set; }
        /// <summary>
        /// 扩展
        /// </summary>
        public object Extend { get; set; }
    }
}
