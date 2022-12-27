using System.Data;

namespace Util.Data.Sql.Database {
    /// <summary>
    /// 数据库事务管理器
    /// </summary>
    public interface ITransactionManager {
        /// <summary>
        /// 设置数据库事务
        /// </summary>
        /// <param name="transaction">数据库事务</param>
        void SetTransaction( IDbTransaction transaction );
        /// <summary>
        /// 获取数据库事务
        /// </summary>
        IDbTransaction GetTransaction();
        /// <summary>
        /// 开始事务
        /// </summary>
        IDbTransaction BeginTransaction();
        /// <summary>
        /// 开始事务
        /// </summary>
        /// <param name="isolationLevel">事务隔离级别</param>
        IDbTransaction BeginTransaction( IsolationLevel isolationLevel );
        /// <summary>
        /// 提交事务
        /// </summary>
        void CommitTransaction();
        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollbackTransaction();
    }
}
