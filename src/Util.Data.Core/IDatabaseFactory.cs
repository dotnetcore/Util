namespace Util.Data {
    /// <summary>
    /// 数据库工厂
    /// </summary>
    public interface IDatabaseFactory {
        /// <summary>
        /// 创建数据库信息
        /// </summary>
        /// <param name="connection">数据库连接字符串</param>
        IDatabase Create( string connection );
    }
}
