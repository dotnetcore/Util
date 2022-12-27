using System.Data;
using Util.Data.Sql.Database;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql执行器操作扩展
    /// </summary>
    public static class SqlExecutorExtensions {

        #region GetConnection(获取数据库连接)

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="source">源</param>
        public static IDbConnection GetConnection( this ISqlExecutor source ) {
            source.CheckNull( nameof( source ) );
            if ( source is IConnectionManager manager )
                return manager.GetConnection();
            return null;
        }

        #endregion

        #region SetConnection(设置数据库连接)

        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="connection">数据库连接</param>
        public static ISqlExecutor SetConnection( this ISqlExecutor source, IDbConnection connection ) {
            source.CheckNull( nameof( source ) );
            if( source is IConnectionManager manager )
                manager.SetConnection( connection );
            return source;
        }

        #endregion

        #region GetTransaction(获取数据库事务)

        /// <summary>
        /// 获取数据库事务
        /// </summary>
        /// <param name="source">源</param>
        public static IDbTransaction GetTransaction( this ISqlExecutor source ) {
            source.CheckNull( nameof( source ) );
            if( source is ITransactionManager manager )
                return manager.GetTransaction();
            return null;
        }

        #endregion

        #region SetTransaction(设置数据库事务)

        /// <summary>
        /// 设置数据库事务
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="transaction">数据库事务</param>
        public static ISqlExecutor SetTransaction( this ISqlExecutor source, IDbTransaction transaction ) {
            source.CheckNull( nameof( source ) );
            if( source is ITransactionManager manager )
                manager.SetTransaction( transaction );
            return source;
        }

        #endregion

        #region BeginTransaction(开始事务)

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <param name="source">源</param>
        public static IDbTransaction BeginTransaction( this ISqlExecutor source ) {
            source.CheckNull( nameof( source ) );
            if( source is ITransactionManager manager )
                return manager.BeginTransaction();
            return null;
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="isolationLevel">事务隔离级别</param>
        public static IDbTransaction BeginTransaction( this ISqlExecutor source, IsolationLevel isolationLevel ) {
            source.CheckNull( nameof( source ) );
            if( source is ITransactionManager manager )
                return manager.BeginTransaction( isolationLevel );
            return null;
        }

        #endregion

        #region CommitTransaction(提交事务)

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="source">源</param>
        public static ISqlExecutor CommitTransaction( this ISqlExecutor source ) {
            source.CheckNull( nameof( source ) );
            if( source is ITransactionManager manager )
                manager.CommitTransaction();
            return source;
        }

        #endregion

        #region RollbackTransaction(回滚事务)

        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="source">源</param>
        public static ISqlExecutor RollbackTransaction( this ISqlExecutor source ) {
            source.CheckNull( nameof( source ) );
            if( source is ITransactionManager manager )
                manager.RollbackTransaction();
            return source;
        }

        #endregion

        #region Clear(清理)

        /// <summary>
        /// 清理
        /// </summary>
        /// <param name="source">源</param>
        public static ISqlExecutor Clear( this ISqlExecutor source ) {
            source.CheckNull( nameof( source ) );
            source.SqlBuilder.Clear();
            return source;
        }

        #endregion
    }
}
