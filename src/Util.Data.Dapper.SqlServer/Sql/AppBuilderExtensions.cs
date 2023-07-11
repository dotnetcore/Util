using Util.Configs;
using Util.Data.Sql;

namespace Util.Data.Dapper.Sql;

/// <summary>
/// Sql Server数据库操作扩展
/// </summary>
public static class AppBuilderExtensions {

    #region AddSqlServerSqlQuery(配置Sql Server Sql查询对象)

    /// <summary>
    /// 配置Sql Server Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddSqlServerSqlQuery( this IAppBuilder builder ) {
        return builder.AddSqlServerSqlQuery( "" );
    }

    /// <summary>
    /// 配置Sql Server Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddSqlServerSqlQuery( this IAppBuilder builder, string connection ) {
        return builder.AddSqlServerSqlQuery<ISqlQuery, SqlServerSqlQuery>( connection );
    }

    /// <summary>
    /// 配置Sql Server Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddSqlServerSqlQuery( this IAppBuilder builder, Action<SqlOptions> setupAction ) {
        return builder.AddSqlServerSqlQuery<ISqlQuery, SqlServerSqlQuery>( setupAction );
    }

    /// <summary>
    /// 配置Sql Server Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddSqlServerSqlQuery<TService, TImplementation>( this IAppBuilder builder, string connection )
        where TService : ISqlQuery
        where TImplementation : SqlServerSqlQueryBase, TService {
        return builder.AddSqlServerSqlQuery<TService, TImplementation>( t => t.ConnectionString( connection ) );
    }

    /// <summary>
    /// 配置Sql Server Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddSqlServerSqlQuery<TService, TImplementation>( this IAppBuilder builder, Action<SqlOptions> setupAction )
        where TService : ISqlQuery
        where TImplementation : SqlServerSqlQueryBase, TService {
        var options = new SqlOptions<TImplementation>();
        setupAction?.Invoke( options );
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.TryAddTransient( typeof( TService ), typeof( TImplementation ) );
            services.TryAddSingleton( typeof( SqlOptions<TImplementation> ), ( sp ) => options );
        } );
        return builder;
    }

    #endregion

    #region AddSqlServerSqlExecutor(配置Sql Server Sql执行器)

    /// <summary>
    /// 配置Sql Server Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddSqlServerSqlExecutor( this IAppBuilder builder ) {
        return builder.AddSqlServerSqlExecutor( "" );
    }

    /// <summary>
    /// 配置Sql Server Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddSqlServerSqlExecutor( this IAppBuilder builder, string connection ) {
        return builder.AddSqlServerSqlExecutor<ISqlExecutor, SqlServerSqlExecutor>( connection );
    }

    /// <summary>
    /// 配置Sql Server Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddSqlServerSqlExecutor( this IAppBuilder builder, Action<SqlOptions> setupAction ) {
        return builder.AddSqlServerSqlExecutor<ISqlExecutor, SqlServerSqlExecutor>( setupAction );
    }

    /// <summary>
    /// 配置Sql Server Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddSqlServerSqlExecutor<TService, TImplementation>( this IAppBuilder builder, string connection )
        where TService : ISqlExecutor
        where TImplementation : SqlServerSqlExecutorBase, TService {
        return builder.AddSqlServerSqlExecutor<TService, TImplementation>( t => t.ConnectionString( connection ) );
    }

    /// <summary>
    /// 配置Sql Server Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddSqlServerSqlExecutor<TService, TImplementation>( this IAppBuilder builder, Action<SqlOptions> setupAction )
        where TService : ISqlExecutor
        where TImplementation : SqlServerSqlExecutorBase, TService {
        var options = new SqlOptions<TImplementation>();
        setupAction?.Invoke( options );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.TryAddTransient( typeof( TService ), typeof( TImplementation ) );
            services.TryAddSingleton( typeof( SqlOptions<TImplementation> ), ( sp ) => options );
        } );
        return builder;
    }

    #endregion
}