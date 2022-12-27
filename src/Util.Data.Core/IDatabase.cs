using System.Data;
using Util.Aop;

namespace Util.Data {
    /// <summary>
    /// 数据库信息
    /// </summary>
    [Ignore]
    public interface IDatabase {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        IDbConnection GetConnection();
    }
}
