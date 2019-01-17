using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Datas.Sql.Queries.Configs;
using Util.Domains.Repositories;
using Util.Helpers;

namespace Util.Datas.Sql.Queries {
    /// <summary>
    /// Sql查询对象
    /// </summary>
    public abstract class SqlQueryBase : ISqlQuery {
        /// <summary>
        /// 数据库
        /// </summary>
        private readonly IDatabase _database;

        /// <summary>
        /// 初始化Sql查询对象
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="database">数据库</param>
        protected SqlQueryBase( ISqlBuilder sqlBuilder, IDatabase database = null ) {
            Builder = sqlBuilder ?? throw new ArgumentNullException( nameof( sqlBuilder ) );
            _database = database;
        }

        /// <summary>
        /// Sql查询配置
        /// </summary>
        protected SqlQueryConfig SqlQueryConfig { get; set; }
        /// <summary>
        /// Sql生成器
        /// </summary>
        protected ISqlBuilder Builder { get; }
        /// <summary>
        /// 参数列表
        /// </summary>
        protected IDictionary<string, object> Params => Builder.GetParams();

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="configAction">配置操作</param>
        public void Config( Action<SqlQueryConfig> configAction ) {
            SqlQueryConfig = new SqlQueryConfig();
            configAction?.Invoke( SqlQueryConfig );
        }

        /// <summary>
        /// 清空并初始化
        /// </summary>
        public void Clear() {
            Builder.Clear();
        }

        /// <summary>
        /// 在执行之后清空Sql和参数
        /// </summary>
        protected void ClearAfterExecution() {
            if( SqlQueryConfig == null )
                SqlQueryConfig = GetConfig();
            if( SqlQueryConfig.IsClearAfterExecution == false )
                return;
            Clear();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        private SqlQueryConfig GetConfig() {
            try {
                var options = Ioc.Create<IOptionsSnapshot<SqlQueryConfig>>();
                return options.Value;
            }
            catch {
                return new SqlQueryConfig();
            }
        }

        /// <summary>
        /// 获取调试Sql语句
        /// </summary>
        public string GetDebugSql() {
            return Builder.ToDebugSql();
        }

        /// <summary>
        /// Sql语句
        /// </summary>
        protected string GetSql() {
            return Builder.ToSql();
        }

        /// <summary>
        /// 获取Sql生成器
        /// </summary>
        public ISqlBuilder GetBuilder() {
            return Builder;
        }

        /// <summary>
        /// 获取单值
        /// </summary>
        /// <param name="connection">数据库连接</param>
        public abstract object ToScalar( IDbConnection connection );
        /// <summary>
        /// 获取单值
        /// </summary>
        /// <param name="connection">数据库连接</param>
        public abstract Task<object> ToScalarAsync( IDbConnection connection );
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public abstract TResult To<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public abstract Task<TResult> ToAsync<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public abstract List<TResult> ToList<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public abstract Task<List<TResult>> ToListAsync<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public abstract PagerList<TResult> ToPagerList<TResult>( IPager parameter, IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="page">页数</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="connection">数据库连接</param>
        public abstract PagerList<TResult> ToPagerList<TResult>( int page, int pageSize, IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public abstract Task<PagerList<TResult>> ToPagerListAsync<TResult>( IPager parameter, IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="page">页数</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="connection">数据库连接</param>
        public abstract Task<PagerList<TResult>> ToPagerListAsync<TResult>( int page, int pageSize, IDbConnection connection = null );
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="func">获取列表操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public abstract PagerList<TResult> PagerQuery<TResult>( Func<List<TResult>> func, IPager parameter, IDbConnection connection = null );
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="func">获取列表操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public abstract Task<PagerList<TResult>> PagerQueryAsync<TResult>( Func<Task<List<TResult>>> func,IPager parameter, IDbConnection connection = null );

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="func">查询操作</param>
        /// <param name="connection">数据库连接</param>
        public TResult Query<TResult>( Func<IDbConnection, string, IDictionary<string, object>, TResult> func, IDbConnection connection = null ) {
            var sql = GetSql();
            WriteTraceLog( sql, Params, GetDebugSql() );
            var result = func( GetConnection( connection ), sql, Params );
            ClearAfterExecution();
            return result;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="func">查询操作</param>
        /// <param name="connection">数据库连接</param>
        public async Task<TResult> QueryAsync<TResult>( Func<IDbConnection, string, IDictionary<string, object>, Task<TResult>> func, IDbConnection connection = null ) {
            var sql = GetSql();
            WriteTraceLog( sql, Params, GetDebugSql() );
            var result = await func( GetConnection( connection ), sql, Params );
            ClearAfterExecution();
            return result;
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="connection">数据库连接</param>
        protected IDbConnection GetConnection( IDbConnection connection ) {
            if( connection != null )
                return connection;
            connection = _database?.GetConnection();
            if( connection == null )
                throw new ArgumentNullException( nameof( connection ) );
            return connection;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="debugSql">调试Sql语句</param>
        protected abstract void WriteTraceLog( string sql, IDictionary<string, object> parameters, string debugSql );
    }
}
