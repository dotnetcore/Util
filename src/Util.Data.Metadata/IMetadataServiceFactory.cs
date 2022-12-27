namespace Util.Data.Metadata {
    /// <summary>
    /// 数据库元数据服务工厂
    /// </summary>
    public interface IMetadataServiceFactory {
        /// <summary>
        /// 创建数据库元数据服务
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connection">数据库连接字符串</param>
        IMetadataService Create( DatabaseType dbType, string connection );
    }
}
