using Util.Configs;
using Util.Data.Dapper.TypeHandlers;
using Util.Data.Sql;

namespace Util.Data.Dapper.Sql;

/// <summary>
/// Oracle数据库操作扩展
/// </summary>
public static class AppBuilderExtensions {

    #region AddOracleSqlQuery(配置Oracle Sql查询对象)

    /// <summary>
    /// 配置Oracle Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddOracleSqlQuery( this IAppBuilder builder ) {
        return builder.AddOracleSqlQuery( "" );
    }

    /// <summary>
    /// 配置Oracle Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddOracleSqlQuery( this IAppBuilder builder, string connection ) {
        return builder.AddOracleSqlQuery<ISqlQuery, OracleSqlQuery>( connection );
    }

    /// <summary>
    /// 配置Oracle Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddOracleSqlQuery( this IAppBuilder builder, Action<SqlOptions> setupAction ) {
        return builder.AddOracleSqlQuery<ISqlQuery, OracleSqlQuery>( setupAction );
    }

    /// <summary>
    /// 配置Oracle Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddOracleSqlQuery<TService, TImplementation>( this IAppBuilder builder, string connection )
        where TService : ISqlQuery
        where TImplementation : OracleSqlQueryBase, TService {
        return builder.AddOracleSqlQuery<TService, TImplementation>( t => t.ConnectionString( connection ) );
    }

    /// <summary>
    /// 配置Oracle Sql查询对象
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddOracleSqlQuery<TService, TImplementation>( this IAppBuilder builder, Action<SqlOptions> setupAction )
        where TService : ISqlQuery
        where TImplementation : OracleSqlQueryBase, TService {
        var options = new SqlOptions<TImplementation>();
        setupAction?.Invoke( options );
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.TryAddTransient( typeof( TService ), typeof( TImplementation ) );
            services.TryAddSingleton( typeof( SqlOptions<TImplementation> ), ( sp ) => options );
            RegisterGuidTypeHandler();
        } );
        return builder;
    }

    /// <summary>
    /// 注册Guid类型处理器
    /// </summary>
    private static void RegisterGuidTypeHandler() {
        SqlMapper.RemoveTypeMap( typeof( Guid ) );
        SqlMapper.RemoveTypeMap( typeof( Guid? ) );
        SqlMapper.AddTypeHandler( typeof( Guid ), new GuidTypeHandler() );
    }

    #endregion

    #region AddOracleSqlExecutor(配置Oracle Sql执行器)

    /// <summary>
    /// 配置Oracle Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddOracleSqlExecutor( this IAppBuilder builder ) {
        return builder.AddOracleSqlExecutor( "" );
    }

    /// <summary>
    /// 配置Oracle Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddOracleSqlExecutor( this IAppBuilder builder, string connection ) {
        return builder.AddOracleSqlExecutor<ISqlExecutor, OracleSqlExecutor>( connection );
    }

    /// <summary>
    /// 配置Oracle Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddOracleSqlExecutor( this IAppBuilder builder, Action<SqlOptions> setupAction ) {
        return builder.AddOracleSqlExecutor<ISqlExecutor, OracleSqlExecutor>( setupAction );
    }

    /// <summary>
    /// 配置Oracle Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    public static IAppBuilder AddOracleSqlExecutor<TService, TImplementation>( this IAppBuilder builder, string connection )
        where TService : ISqlExecutor
        where TImplementation : OracleSqlExecutorBase, TService {
        return builder.AddOracleSqlExecutor<TService, TImplementation>( t => t.ConnectionString( connection ) );
    }

    /// <summary>
    /// 配置Oracle Sql执行器
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddOracleSqlExecutor<TService, TImplementation>( this IAppBuilder builder, Action<SqlOptions> setupAction )
        where TService : ISqlExecutor
        where TImplementation : OracleSqlExecutorBase, TService {
        var options = new SqlOptions<TImplementation>();
        setupAction?.Invoke( options );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.TryAddTransient( typeof( TService ), typeof( TImplementation ) );
            services.TryAddSingleton( typeof( SqlOptions<TImplementation> ), ( sp ) => options );
            RegisterGuidTypeHandler();
        } );
        return builder;
    }

    #endregion
}