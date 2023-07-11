using Util.Configs;

namespace Util.Data.EntityFrameworkCore;

/// <summary>
/// Oracle工作单元操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置Oracle工作单元
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    /// <param name="setupAction">工作单元配置操作</param>
    /// <param name="oracleSetupAction">Oracle配置操作</param>
    /// <param name="condition">条件,设置为false,跳过配置</param>
    public static IAppBuilder AddOracleUnitOfWork<TService, TImplementation>( this IAppBuilder builder, string connection, Action<DbContextOptionsBuilder> setupAction = null,
        Action<OracleDbContextOptionsBuilder> oracleSetupAction = null, bool? condition = null )
        where TService : class, IUnitOfWork
        where TImplementation : UnitOfWorkBase, TService {
        return builder.AddOracleUnitOfWork<TService, TImplementation>( connection, null, setupAction, oracleSetupAction, condition );
    }

    /// <summary>
    /// 配置Oracle工作单元
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接</param>
    /// <param name="setupAction">工作单元配置操作</param>
    /// <param name="oracleSetupAction">Oracle配置操作</param>
    /// <param name="condition">条件,设置为false,跳过配置</param>
    public static IAppBuilder AddOracleUnitOfWork<TService, TImplementation>( this IAppBuilder builder, DbConnection connection, Action<DbContextOptionsBuilder> setupAction = null,
        Action<OracleDbContextOptionsBuilder> oracleSetupAction = null, bool? condition = null )
        where TService : class, IUnitOfWork
        where TImplementation : UnitOfWorkBase, TService {
        return builder.AddOracleUnitOfWork<TService, TImplementation>( null, connection, setupAction, oracleSetupAction, condition );
    }

    /// <summary>
    /// 配置Oracle工作单元
    /// </summary>
    private static IAppBuilder AddOracleUnitOfWork<TService, TImplementation>( this IAppBuilder builder, string connectionString, DbConnection connection, Action<DbContextOptionsBuilder> setupAction,
        Action<OracleDbContextOptionsBuilder> oracleSetupAction, bool? condition )
        where TService : class, IUnitOfWork
        where TImplementation : UnitOfWorkBase, TService {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            void Action( DbContextOptionsBuilder options ) {
                setupAction?.Invoke( options );
                if ( connectionString.IsEmpty() == false ) {
                    options.UseOracle( connectionString, oracleSetupAction );
                    return;
                }
                if ( connection != null ) {
                    options.UseOracle( connection, oracleSetupAction );
                }
            }
            services.AddDbContext<TImplementation>( Action );
            if ( condition == false )
                return;
            services.AddDbContext<TService, TImplementation>( Action );
        } );
        return builder;
    }
}