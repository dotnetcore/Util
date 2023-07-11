using Util.Configs;
using Util.Data.Sql;

namespace Util.Data.Dapper.Sql;

/// <summary>
/// PostgreSql数据库操作扩展
/// </summary>
public static class AppBuilderExtensions {

    #region AddPgSqlQuery(配置PostgreSql Sql查询对象)

    /// <summary>
    /// 配置PostgreSql Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddPgSqlQuery( this IAppBuilder builder ) {
        return builder.AddPgSqlQuery( "" );
    }

    /// <summary>
    /// 配置PostgreSql Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddPgSqlQuery( this IAppBuilder builder, string connection ) {
        return builder.AddPgSqlQuery<ISqlQuery, PostgreSqlQuery>( connection );
    }

    /// <summary>
    /// 配置PostgreSql Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddPgSqlQuery( this IAppBuilder builder, Action<SqlOptions> setupAction ) {
        return builder.AddPgSqlQuery<ISqlQuery, PostgreSqlQuery>( setupAction );
    }

    /// <summary>
    /// 配置PostgreSql Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddPgSqlQuery<TService, TImplementation>( this IAppBuilder builder, string connection )
        where TService : ISqlQuery
        where TImplementation : PostgreSqlQueryBase, TService {
        return builder.AddPgSqlQuery<TService, TImplementation>( t => t.ConnectionString( connection ) );
    }

    /// <summary>
    /// 配置PostgreSql Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddPgSqlQuery<TService, TImplementation>( this IAppBuilder builder, Action<SqlOptions> setupAction )
        where TService : ISqlQuery
        where TImplementation : PostgreSqlQueryBase, TService {
        var options = new SqlOptions<TImplementation>();
        setupAction?.Invoke( options );
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            AppContext.SetSwitch( "Npgsql.EnableStoredProcedureCompatMode", true );
            services.TryAddTransient( typeof( TService ), typeof( TImplementation ) );
            services.TryAddSingleton( typeof( SqlOptions<TImplementation> ), ( sp ) => options );
        } );
        return builder;
    }

    #endregion

    #region AddPgSqlExecutor(配置PostgreSql Sql执行器)

    /// <summary>
    /// 配置PostgreSql Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddPgSqlExecutor( this IAppBuilder builder ) {
        return builder.AddPgSqlExecutor( "" );
    }

    /// <summary>
    /// 配置PostgreSql Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddPgSqlExecutor( this IAppBuilder builder, string connection ) {
        return builder.AddPgSqlExecutor<ISqlExecutor, PostgreSqlExecutor>( connection );
    }

    /// <summary>
    /// 配置PostgreSql Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddPgSqlExecutor( this IAppBuilder builder, Action<SqlOptions> setupAction ) {
        return builder.AddPgSqlExecutor<ISqlExecutor, PostgreSqlExecutor>( setupAction );
    }

    /// <summary>
    /// 配置PostgreSql Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddPgSqlExecutor<TService, TImplementation>( this IAppBuilder builder, string connection )
        where TService : ISqlExecutor
        where TImplementation : PostgreSqlExecutorBase, TService {
        return builder.AddPgSqlExecutor<TService, TImplementation>( t => t.ConnectionString( connection ) );
    }

    /// <summary>
    /// 配置PostgreSql Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddPgSqlExecutor<TService, TImplementation>( this IAppBuilder builder, Action<SqlOptions> setupAction )
        where TService : ISqlExecutor
        where TImplementation : PostgreSqlExecutorBase, TService {
        var options = new SqlOptions<TImplementation>();
        setupAction?.Invoke( options );
        builder.Host.ConfigureServices( ( context, services ) => {
            AppContext.SetSwitch( "Npgsql.EnableStoredProcedureCompatMode", true );
            services.TryAddTransient( typeof( TService ), typeof( TImplementation ) );
            services.TryAddSingleton( typeof( SqlOptions<TImplementation> ), ( sp ) => options );
        } );
        return builder;
    }

    #endregion
}