using System.Data;
using System.Threading.Tasks;
using Dapper;
using Util.Datas.Sql;

namespace Util.Datas.Dapper.Core {
    /// <summary>
    /// Dapper Sql查询对象
    /// </summary>
    public abstract class SqlQueryBase : Util.Datas.Sql.Queries.SqlQueryBase {
        /// <summary>
        /// 初始化Dapper Sql查询对象
        /// </summary>
        /// <param name="database">数据库</param>
        protected SqlQueryBase( IDatabase database = null ) : base( database ) {
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public override TResult To<TResult>( IDbConnection connection = null ) {
            var sql = GetBuilder().ToSql();
            var parameters = GetBuilder().GetParams();
            return GetConnection( connection ).QueryFirstOrDefault<TResult>( sql, parameters );
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public override async Task<TResult> ToAsync<TResult>( IDbConnection connection = null ) {
            var sql = GetBuilder().ToSql();
            var parameters = GetBuilder().GetParams();
            return await GetConnection( connection ).QueryFirstOrDefaultAsync<TResult>( sql, parameters );
        }
    }
}