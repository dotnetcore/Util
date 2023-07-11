using Util.Configs;
using Util.Data.Sql;

namespace Util.Data.Dapper.Sql;

/// <summary>
/// MySql数据库操作扩展
/// </summary>
public static class AppBuilderExtensions {

    #region AddMySqlQuery(配置MySql Sql查询对象)

    /// <summary>
    /// 配置MySql Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddMySqlQuery( this IAppBuilder builder ) {
        return builder.AddMySqlQuery( "" );
    }

    /// <summary>
    /// 配置MySql Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddMySqlQuery( this IAppBuilder builder, string connection ) {
        return builder.AddMySqlQuery<ISqlQuery, MySqlQuery>( connection );
    }

    /// <summary>
    /// 配置MySql Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddMySqlQuery( this IAppBuilder builder, Action<SqlOptions> setupAction ) {
        return builder.AddMySqlQuery<ISqlQuery, MySqlQuery>( setupAction );
    }

    /// <summary>
    /// 配置MySql Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddMySqlQuery<TService, TImplementation>( this IAppBuilder builder, string connection )
        where TService : ISqlQuery
        where TImplementation : MySqlQueryBase, TService {
        return builder.AddMySqlQuery<TService, TImplementation>( t => t.ConnectionString( connection ) );
    }

    /// <summary>
    /// 配置MySql Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddMySqlQuery<TService, TImplementation>( this IAppBuilder builder, Action<SqlOptions> setupAction )
        where TService : ISqlQuery
        where TImplementation : MySqlQueryBase, TService {
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

    #region AddMySqlExecutor(配置MySql Sql执行器)

    /// <summary>
    /// 配置MySql Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddMySqlExecutor( this IAppBuilder builder ) {
        return builder.AddMySqlExecutor( "" );
    }

    /// <summary>
    /// 配置MySql Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddMySqlExecutor( this IAppBuilder builder, string connection ) {
        return builder.AddMySqlExecutor<ISqlExecutor, MySqlExecutor>( connection );
    }

    /// <summary>
    /// 配置MySql Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddMySqlExecutor( this IAppBuilder builder, Action<SqlOptions> setupAction ) {
        return builder.AddMySqlExecutor<ISqlExecutor, MySqlExecutor>( setupAction );
    }

    /// <summary>
    /// 配置MySql Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddMySqlExecutor<TService, TImplementation>( this IAppBuilder builder, string connection )
        where TService : ISqlExecutor
        where TImplementation : MySqlExecutorBase, TService {
        return builder.AddMySqlExecutor<TService, TImplementation>( t => t.ConnectionString( connection ) );
    }

    /// <summary>
    /// 配置MySql Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddMySqlExecutor<TService, TImplementation>( this IAppBuilder builder, Action<SqlOptions> setupAction )
        where TService : ISqlExecutor
        where TImplementation : MySqlExecutorBase, TService {
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