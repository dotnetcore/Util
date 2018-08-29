using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Util.Datas.Sql;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Domains.Repositories;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Datas.Dapper {
    /// <summary>
    /// Dapper Sql查询对象
    /// </summary>
    public class SqlQuery : Util.Datas.Sql.Queries.SqlQueryBase {
        /// <summary>
        /// 跟踪日志名称
        /// </summary>
        public const string TraceLogName = "SqlQueryLog";

        /// <summary>
        /// 初始化Dapper Sql查询对象
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="database">数据库</param>
        public SqlQuery( ISqlBuilder sqlBuilder, IDatabase database = null ) : base( sqlBuilder, database ) {
        }

        /// <summary>
        /// 获取单值
        /// </summary>
        protected override object ToScalar( IDbConnection connection, string sql, IDictionary<string, object> parameters ) {
            WriteTraceLog( sql, parameters );
            return GetConnection( connection ).ExecuteScalar( sql, parameters );
        }

        /// <summary>
        /// 获取单值
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">参数</param>
        protected override async Task<object> ToScalarAsync( IDbConnection connection, string sql,IDictionary<string, object> parameters ) {
            WriteTraceLog( sql, parameters );
            return await GetConnection( connection ).ExecuteScalarAsync( sql, parameters );
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public override TResult To<TResult>( IDbConnection connection = null ) {
            var sql = GetSql();
            WriteTraceLog( sql, Params );
            return GetConnection( connection ).QueryFirstOrDefault<TResult>( sql, Params );
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public override async Task<TResult> ToAsync<TResult>( IDbConnection connection = null ) {
            var sql = GetSql();
            WriteTraceLog( sql, Params );
            return await GetConnection( connection ).QueryFirstOrDefaultAsync<TResult>( sql, Params );
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public override List<TResult> ToList<TResult>( IDbConnection connection = null ) {
            var sql = GetSql();
            WriteTraceLog( sql, Params );
            return GetConnection( connection ).Query<TResult>( sql, Params ).ToList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public override async Task<List<TResult>> ToListAsync<TResult>( IDbConnection connection = null ) {
            var sql = GetSql();
            WriteTraceLog( sql, Params );
            return ( await GetConnection( connection ).QueryAsync<TResult>( sql, Params ) ).ToList();
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public override PagerList<TResult> ToPagerList<TResult>( IPager parameter, IDbConnection connection = null ) {
            if( parameter.TotalCount == 0 )
                parameter.TotalCount = GetCount( connection );
            SetPager( parameter );
            return new PagerList<TResult>( parameter, ToList<TResult>( connection ) );
        }

        /// <summary>
        /// 设置分页参数
        /// </summary>
        private void SetPager( IPager parameter ) {
            Builder.OrderBy( parameter.Order );
            Builder.Page( parameter );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="page">页数</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="connection">数据库连接</param>
        public override PagerList<TResult> ToPagerList<TResult>( int page, int pageSize, IDbConnection connection = null ) {
            return ToPagerList<TResult>( new Pager( page, pageSize ), connection );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public override async Task<PagerList<TResult>> ToPagerListAsync<TResult>( IPager parameter, IDbConnection connection = null ) {
            if( parameter.TotalCount == 0 )
                parameter.TotalCount = await GetCountAsync( connection );
            SetPager( parameter );
            return new PagerList<TResult>( parameter, await ToListAsync<TResult>( connection ) );
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="page">页数</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="connection">数据库连接</param>
        public override async Task<PagerList<TResult>> ToPagerListAsync<TResult>( int page, int pageSize, IDbConnection connection = null ) {
            return await ToPagerListAsync<TResult>( new Pager( page, pageSize ), connection );
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">参数</param>
        protected override void WriteTraceLog( string sql, IDictionary<string, object> parameters ) {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            var debugSql = sql;
            foreach( var parameter in parameters )
                debugSql = debugSql.Replace( parameter.Key, SqlHelper.GetParamLiterals( parameter.Value ) );
            log.Class( GetType().FullName )
                .Caption( "SqlQuery查询调试:" )
                .Sql( "原始Sql:" )
                .Sql( $"{sql}{Common.Line}" )
                .Sql( "调试Sql:" )
                .Sql( debugSql )
                .SqlParams( parameters )
                .Trace();
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog() {
            try {
                return Log.GetLog( TraceLogName );
            }
            catch {
                return Log.Null;
            }
        }
    }
}