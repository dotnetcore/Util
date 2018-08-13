using System.Data;
using System.Threading.Tasks;
using Dapper;
using Util.Datas.Sql;
using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Dapper {
    /// <summary>
    /// Dapper Sql查询对象
    /// </summary>
    public class SqlQuery : Util.Datas.Sql.Queries.SqlQueryBase {
        /// <summary>
        /// Sql生成器
        /// </summary>
        private readonly ISqlBuilder _sqlBuilder;

        /// <summary>
        /// 初始化Dapper Sql查询对象
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="database">数据库</param>
        public SqlQuery( ISqlBuilder sqlBuilder, IDatabase database = null ) : base( database ) {
            _sqlBuilder = sqlBuilder;
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        protected override ISqlBuilder CreateBuilder() {
            return _sqlBuilder;
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