using Util.Configs;

namespace Util.Data.EntityFrameworkCore;

/// <summary>
/// Sql Server工作单元操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置Sql Server工作单元
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    /// <param name="setupAction">工作单元配置操作</param>
    /// <param name="sqlServerSetupAction">Sql Server配置操作</param>
    /// <param name="condition">条件,设置为false,跳过配置</param>
    public static IAppBuilder AddSqlServerUnitOfWork<TService, TImplementation>( this IAppBuilder builder, string connection, Action<DbContextOptionsBuilder> setupAction = null,
        Action<SqlServerDbContextOptionsBuilder> sqlServerSetupAction = null, bool? condition = null )
        where TService : class, IUnitOfWork
        where TImplementation : UnitOfWorkBase, TService {
        return builder.AddSqlServerUnitOfWork<TService, TImplementation>( connection, null, setupAction, sqlServerSetupAction, condition );
    }

    /// <summary>
    /// 配置Sql Server工作单元
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接</param>
    /// <param name="setupAction">工作单元配置操作</param>
    /// <param name="sqlServerSetupAction">Sql Server配置操作</param>
    /// <param name="condition">条件,设置为false,跳过配置</param>
    public static IAppBuilder AddSqlServerUnitOfWork<TService, TImplementation>( this IAppBuilder builder, DbConnection connection, Action<DbContextOptionsBuilder> setupAction = null,
        Action<SqlServerDbContextOptionsBuilder> sqlServerSetupAction = null, bool? condition = null )
        where TService : class, IUnitOfWork
        where TImplementation : UnitOfWorkBase, TService {
        return builder.AddSqlServerUnitOfWork<TService, TImplementation>( null, connection, setupAction, sqlServerSetupAction, condition );
    }

    /// <summary>
    /// 配置Sql Server工作单元
    /// </summary>
    private static IAppBuilder AddSqlServerUnitOfWork<TService, TImplementation>( this IAppBuilder builder, string connectionString, DbConnection connection, Action<DbContextOptionsBuilder> setupAction = null,
        Action<SqlServerDbContextOptionsBuilder> sqlServerSetupAction = null, bool? condition = null )
        where TService : class, IUnitOfWork
        where TImplementation : UnitOfWorkBase, TService {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            void Action( DbContextOptionsBuilder options ) {
                setupAction?.Invoke( options );
                if ( connectionString.IsEmpty() == false ) {
                    options.UseSqlServer( connectionString, sqlServerSetupAction );
                    return;
                }
                if ( connection != null ) {
                    options.UseSqlServer( connection, sqlServerSetupAction );
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