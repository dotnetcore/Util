using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Datas.Dapper;
using Util.Datas.Ef.Configs;
using Util.Datas.Ef.Core;
using Util.Datas.Enums;
using Util.Datas.UnitOfWorks;

namespace Util.Datas.Ef {
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 注册工作单元服务
        /// </summary>
        /// <typeparam name="TService">工作单元接口类型</typeparam>
        /// <typeparam name="TImplementation">工作单元实现类型</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="configAction">配置操作</param>
        /// <param name="efConfigAction">Ef配置操作</param>
        /// <param name="configuration">配置</param>
        public static IServiceCollection AddUnitOfWork<TService, TImplementation>( this IServiceCollection services,
            Action<DbContextOptionsBuilder> configAction, Action<EfConfig> efConfigAction = null, IConfiguration configuration = null )
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService {
            services.AddDbContext<TImplementation>( configAction );
            if( efConfigAction != null )
                services.Configure( efConfigAction );
            if( configuration != null )
                services.Configure<EfConfig>( configuration );
            services.TryAddScoped<TService>( t => t.GetService<TImplementation>() );
            services.AddSqlQuery<TImplementation, TImplementation>( config => config.DatabaseType = GetDbType<TImplementation>() );
            return services;
        }

        /// <summary>
        /// 获取数据库类型
        /// </summary>
        private static DatabaseType GetDbType<TUnitOfWork>() {
            var type = typeof( TUnitOfWork ).BaseType;
            if( type == typeof( Util.Datas.Ef.SqlServer.UnitOfWork ) )
                return DatabaseType.SqlServer;
            if( type == typeof( Util.Datas.Ef.MySql.UnitOfWork ) )
                return DatabaseType.MySql;
            if( type == typeof( Util.Datas.Ef.PgSql.UnitOfWork ) )
                return DatabaseType.PgSql;
            return DatabaseType.SqlServer;
        }

        /// <summary>
        /// 注册工作单元服务
        /// </summary>
        /// <typeparam name="TService">工作单元接口类型</typeparam>
        /// <typeparam name="TImplementation">工作单元实现类型</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="connection">连接字符串</param>
        /// <param name="level">Ef日志级别</param>
        public static IServiceCollection AddUnitOfWork<TService, TImplementation>( this IServiceCollection services, string connection, EfLogLevel level = EfLogLevel.Sql )
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService {
            return AddUnitOfWork<TService, TImplementation>( services, builder => {
                ConfigConnection<TImplementation>( builder, connection );
            }, config => config.EfLogLevel = level );
        }

        /// <summary>
        /// 配置连接字符串
        /// </summary>
        private static void ConfigConnection<TImplementation>( DbContextOptionsBuilder builder, string connection ) where TImplementation : UnitOfWorkBase {
            switch( GetDbType<TImplementation>() ) {
                case DatabaseType.SqlServer:
                    builder.UseSqlServer( connection );
                    return;
                case DatabaseType.MySql:
                    builder.UseMySql( connection );
                    return;
                case DatabaseType.PgSql:
                    builder.UseNpgsql( connection );
                    return;
            }
        }

        /// <summary>
        /// 注册工作单元服务
        /// </summary>
        /// <typeparam name="TService">工作单元接口类型</typeparam>
        /// <typeparam name="TImplementation">工作单元实现类型</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="connection">连接字符串</param>
        /// <param name="configuration">配置</param>
        public static IServiceCollection AddUnitOfWork<TService, TImplementation>( this IServiceCollection services, string connection, IConfiguration configuration )
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService {
            return AddUnitOfWork<TService, TImplementation>( services, builder => {
                ConfigConnection<TImplementation>( builder, connection );
            }, null, configuration );
        }
    }
}
