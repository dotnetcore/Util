using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Util.Datas.Sql.Builders;
using Util.Datas.Sql.Configs;
using Util.Domains.Repositories;

namespace Util.Datas.Sql {
    /// <summary>
    /// Sql查询对象
    /// </summary>
    public interface ISqlQuery : ISelect, IFrom, IJoin, IWhere, IGroupBy, IOrderBy, IUnion, ICte {
        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="connection">数据库连接</param>
        ISqlQuery SetConnection( IDbConnection connection );
        /// <summary>
        /// 复制Sql查询对象
        /// </summary>
        ISqlQuery Clone();
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="configAction">配置操作</param>
        void Config( Action<SqlOptions> configAction );
        /// <summary>
        /// 获取Sql生成器
        /// </summary>
        ISqlBuilder GetBuilder();
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="func">查询操作</param>
        /// <param name="connection">数据库连接</param>
        TResult Query<TResult>( Func<IDbConnection, string, IReadOnlyDictionary<string, object>, TResult> func, IDbConnection connection = null );
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="func">查询操作</param>
        /// <param name="connection">数据库连接</param>
        Task<TResult> QueryAsync<TResult>( Func<IDbConnection, string, IReadOnlyDictionary<string, object>, Task<TResult>> func, IDbConnection connection = null );
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="func">获取列表操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        PagerList<TResult> PagerQuery<TResult>( Func<List<TResult>> func, IPager parameter, IDbConnection connection = null );
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="func">获取列表操作</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        Task<PagerList<TResult>> PagerQueryAsync<TResult>( Func<Task<List<TResult>>> func, IPager parameter, IDbConnection connection = null );
        /// <summary>
        /// 获取单值
        /// </summary>
        /// <param name="connection">数据库连接</param>
        object ToScalar( IDbConnection connection );
        /// <summary>
        /// 获取单值
        /// </summary>
        /// <param name="connection">数据库连接</param>
        Task<object> ToScalarAsync( IDbConnection connection );
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        TResult To<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        Task<TResult> ToAsync<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        List<TResult> ToList<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        Task<List<TResult>> ToListAsync<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="sql">Sql语句</param>
        /// <param name="connection">数据库连接</param>
        Task<List<TResult>> ToListAsync<TResult>( string sql, IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        PagerList<TResult> ToPagerList<TResult>( IPager parameter = null, IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="page">页数</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="connection">数据库连接</param>
        PagerList<TResult> ToPagerList<TResult>( int page, int pageSize, IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        Task<PagerList<TResult>> ToPagerListAsync<TResult>( IPager parameter = null, IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="page">页数</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="connection">数据库连接</param>
        Task<PagerList<TResult>> ToPagerListAsync<TResult>( int page, int pageSize, IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="sql">Sql语句</param>
        /// <param name="page">页数</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="connection">数据库连接</param>
        Task<PagerList<TResult>> ToPagerListAsync<TResult>( string sql, int page, int pageSize, IDbConnection connection = null );
    }
}
