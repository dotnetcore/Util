using Util.Configs;

namespace Util.Data.EntityFrameworkCore;

/// <summary>
/// PostgreSql工作单元操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置PostgreSql工作单元
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接字符串</param>
    /// <param name="setupAction">工作单元配置操作</param>
    /// <param name="pgSqlSetupAction">PostgreSql配置操作</param>
    /// <param name="isEnableLegacyTimestampBehavior">是否启用传统时间戳行为</param>
    /// <param name="condition">条件,设置为false,跳过配置</param>
    public static IAppBuilder AddPgSqlUnitOfWork<TService, TImplementation>( this IAppBuilder builder, string connection, Action<DbContextOptionsBuilder> setupAction = null,
            Action<NpgsqlDbContextOptionsBuilder> pgSqlSetupAction = null, bool isEnableLegacyTimestampBehavior = false, bool? condition = null )
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService {
        return builder.AddPgSqlUnitOfWork<TService, TImplementation>( connection, null, setupAction, pgSqlSetupAction, isEnableLegacyTimestampBehavior, condition );
    }

    /// <summary>
    /// 配置PostgreSql工作单元
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="connection">数据库连接</param>
    /// <param name="setupAction">工作单元配置操作</param>
    /// <param name="pgSqlSetupAction">PostgreSql配置操作</param>
    /// <param name="isEnableLegacyTimestampBehavior">是否启用传统时间戳行为</param>
    /// <param name="condition">条件,设置为false,跳过配置</param>
    public static IAppBuilder AddPgSqlUnitOfWork<TService, TImplementation>( this IAppBuilder builder, DbConnection connection, Action<DbContextOptionsBuilder> setupAction = null,
        Action<NpgsqlDbContextOptionsBuilder> pgSqlSetupAction = null, bool isEnableLegacyTimestampBehavior = false, bool? condition = null )
        where TService : class, IUnitOfWork
        where TImplementation : UnitOfWorkBase, TService {
        return builder.AddPgSqlUnitOfWork<TService, TImplementation>( null, connection, setupAction, pgSqlSetupAction, isEnableLegacyTimestampBehavior, condition );
    }

    /// <summary>
    /// 配置PostgreSql工作单元
    /// </summary>
    private static IAppBuilder AddPgSqlUnitOfWork<TService, TImplementation>( this IAppBuilder builder, string connectionString, DbConnection connection, Action<DbContextOptionsBuilder> setupAction,
        Action<NpgsqlDbContextOptionsBuilder> pgSqlSetupAction, bool isEnableLegacyTimestampBehavior, bool? condition )
        where TService : class, IUnitOfWork
        where TImplementation : UnitOfWorkBase, TService {
        AppContext.SetSwitch( "Npgsql.EnableLegacyTimestampBehavior", isEnableLegacyTimestampBehavior );
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            void Action( DbContextOptionsBuilder options ) {
                setupAction?.Invoke( options );
                if ( connectionString.IsEmpty() == false ) {
                    options.UseNpgsql( connectionString, pgSqlSetupAction );
                    return;
                }
                if ( connection != null ) {
                    options.UseNpgsql( connection, pgSqlSetupAction );
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