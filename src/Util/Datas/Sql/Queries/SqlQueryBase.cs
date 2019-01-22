using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Util.Datas.Sql.Queries.Configs;
using Util.Domains.Repositories;
using Util.Helpers;

namespace Util.Datas.Sql.Queries {
    /// <summary>
    /// Sql查询对象
    /// </summary>
    public abstract class SqlQueryBase : ISqlQuery {
        /// <summary>
        /// 初始化Sql查询对象
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="database">数据库</param>
        /// <param name="sqlQueryOptions">Sql查询配置</param>
        protected SqlQueryBase( ISqlBuilder sqlBuilder, IDatabase database = null, SqlQueryOptions sqlQueryOptions = null ) {
            Builder = sqlBuilder ?? throw new ArgumentNullException( nameof( sqlBuilder ) );
            Database = database;
            SqlQueryOptions = sqlQueryOptions;
        }

        /// <summary>
        /// Sql生成器
        /// </summary>
        protected ISqlBuilder Builder { get; }
        /// <summary>
        /// 数据库
        /// </summary>
        protected IDatabase Database { get; }
        /// <summary>
        /// Sql查询配置
        /// </summary>
        protected SqlQueryOptions SqlQueryOptions { get; set; }
        /// <summary>
        /// 参数列表
        /// </summary>
        protected IReadOnlyDictionary<string, object> Params => Builder.GetParams();

        /// <summary>
        /// 复制Sql查询对象
        /// </summary>
        public abstract ISqlQuery Clone();

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="configAction">配置操作</param>
        public void Config( Action<SqlQueryOptions> configAction ) {
            SqlQueryOptions = new SqlQueryOptions();
            configAction?.Invoke( SqlQueryOptions );
        }

        /// <summary>
        /// 清空并初始化
        /// </summary>
        public ISqlQuery Clear() {
            Builder.Clear();
            return this;
        }

        /// <summary>
        /// 在执行之后清空Sql和参数
        /// </summary>
        protected void ClearAfterExecution() {
            if( SqlQueryOptions == null )
                SqlQueryOptions = GetConfig();
            if( SqlQueryOptions.IsClearAfterExecution == false )
                return;
            Clear();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        private SqlQueryOptions GetConfig() {
            try {
                var options = Ioc.Create<IOptionsSnapshot<SqlQueryOptions>>();
                return options.Value;
            }
            catch {
                return new SqlQueryOptions();
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
        public abstract object ToScalar( IDbConnection connection = null );
        /// <summary>
        /// 获取单值
        /// </summary>
        /// <param name="connection">数据库连接</param>
        public abstract Task<object> ToScalarAsync( IDbConnection connection = null );
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
        public abstract PagerList<TResult> ToPagerList<TResult>( IPager parameter = null, IDbConnection connection = null );
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
        public abstract Task<PagerList<TResult>> ToPagerListAsync<TResult>( IPager parameter = null, IDbConnection connection = null );
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
        public abstract Task<PagerList<TResult>> PagerQueryAsync<TResult>( Func<Task<List<TResult>>> func, IPager parameter, IDbConnection connection = null );

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="func">查询操作</param>
        /// <param name="connection">数据库连接</param>
        public TResult Query<TResult>( Func<IDbConnection, string, IReadOnlyDictionary<string, object>, TResult> func, IDbConnection connection = null ) {
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
        public async Task<TResult> QueryAsync<TResult>( Func<IDbConnection, string, IReadOnlyDictionary<string, object>, Task<TResult>> func, IDbConnection connection = null ) {
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
            connection = Database?.GetConnection();
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
        protected abstract void WriteTraceLog( string sql, IReadOnlyDictionary<string, object> parameters, string debugSql );

        /// <summary>
        /// 获取分页参数
        /// </summary>
        /// <param name="parameter">分页参数</param>
        protected IPager GetPage( IPager parameter ) {
            if( parameter != null )
                return parameter;
            return Builder.Pager;
        }

        /// <summary>
        /// 获取行数Sql生成器
        /// </summary>
        protected ISqlBuilder GetCountBuilder() {
            var builder = Builder.Clone();
            ClearCountBuilder( builder );
            if( builder.IsGroup )
                return GetCountBuilderByGroup( builder );
            return GetCountBuilderByNoGroup( builder );
        }

        /// <summary>
        /// 清理行数Sql生成器
        /// </summary>
        private void ClearCountBuilder( ISqlBuilder builder ) {
            builder.ClearSelect();
            builder.ClearOrderBy();
            builder.ClearPageParams();
        }

        /// <summary>
        /// 获取行数Sql生成器 - 分组
        /// </summary>
        private ISqlBuilder GetCountBuilderByGroup( ISqlBuilder countBuilder ) {
            return countBuilder.New().Count()
                .AppendFrom( countBuilder.AppendSelect( countBuilder.GroupColumns ), "t" );
        }

        /// <summary>
        /// 获取行数Sql生成器 - 未分组
        /// </summary>
        private ISqlBuilder GetCountBuilderByNoGroup( ISqlBuilder countBuilder ) {
            return countBuilder.Count();
        }
    }
}
