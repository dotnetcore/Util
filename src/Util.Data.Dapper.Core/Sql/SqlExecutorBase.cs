using System;
using System.Threading.Tasks;
using Dapper;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql执行器
    /// </summary>
    public abstract class SqlExecutorBase : SqlQueryBase, ISqlExecutor {

        #region 构造方法

        /// <summary>
        /// 初始化Sql执行器
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">Sql配置</param>
        /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
        protected SqlExecutorBase( IServiceProvider serviceProvider, SqlOptions options, IDatabase database ) : base( serviceProvider,options, database ) {
        }

        #endregion

        #region ExecuteAsync(执行增删改操作)

        /// <summary>
        /// 执行增删改操作
        /// </summary>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        public virtual async Task<int> ExecuteAsync( int? timeout = null ) {
            int result = 0;
            try {
                if ( ExecuteBefore() == false )
                    return 0;
                var connection = GetConnection();
                result = await connection.ExecuteAsync( GetSql(), Params, GetTransaction(), timeout );
                return result;
            }
            catch ( Exception ) {
                RollbackTransaction();
                throw;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        #endregion

        #region ExecuteProcedureAsync(执行存储过程增删改操作)

        /// <summary>
        /// 执行存储过程增删改操作
        /// </summary>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        public async Task<int> ExecuteProcedureAsync( string procedure, int? timeout = null ) {
            int result = 0;
            try {
                if( ExecuteBefore() == false )
                    return default;
                SetSql( GetProcedure( procedure ) );
                var connection = GetConnection();
                result = await connection.ExecuteAsync( GetSql(), Params, GetTransaction(), timeout, GetProcedureCommandType() );
                return result;
            }
            catch ( Exception ) {
                RollbackTransaction();
                throw;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        #endregion
    }
}
