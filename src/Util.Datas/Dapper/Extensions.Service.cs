using System;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Datas.Dapper.Handlers;
using Util.Datas.Dapper.MySql;
using Util.Datas.Dapper.Oracle;
using Util.Datas.Dapper.PgSql;
using Util.Datas.Dapper.SqlServer;
using Util.Datas.Enums;
using Util.Datas.Sql;
using Util.Datas.Sql.Configs;
using Util.Datas.Sql.Matedatas;

namespace Util.Datas.Dapper {
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 注册Sql查询服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="action">Sql查询配置</param>
        public static IServiceCollection AddSqlQuery( this IServiceCollection services, Action<SqlOptions> action = null ) {
            return AddSqlQuery( services, action, null, null );
        }

        /// <summary>
        /// 注册Sql查询服务
        /// </summary>
        /// <typeparam name="TDatabase">IDatabase实现类型，提供数据库连接</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="action">Sql查询配置</param>
        public static IServiceCollection AddSqlQuery<TDatabase>( this IServiceCollection services, Action<SqlOptions> action = null )
            where TDatabase : class, IDatabase {
            return AddSqlQuery( services, action, typeof( TDatabase ), null );
        }

        /// <summary>
        /// 注册Sql查询服务
        /// </summary>
        /// <typeparam name="TDatabase">IDatabase实现类型，提供数据库连接</typeparam>
        /// <typeparam name="TEntityMatedata">IEntityMatedata实现类型,提供实体元数据解析</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="action">Sql查询配置</param>
        public static IServiceCollection AddSqlQuery<TDatabase, TEntityMatedata>( this IServiceCollection services, Action<SqlOptions> action = null )
            where TDatabase : class, IDatabase
            where TEntityMatedata : class, IEntityMatedata {
            return AddSqlQuery( services, action, typeof( TDatabase ), typeof( TEntityMatedata ) );
        }

        /// <summary>
        /// 注册Sql查询服务
        /// </summary>
        private static IServiceCollection AddSqlQuery( IServiceCollection services, Action<SqlOptions> action, Type database, Type entityMatedata ) {
            var config = new SqlOptions();
            if( action != null ) {
                action.Invoke( config );
                services.Configure( action );
            }
            if( entityMatedata != null )
                services.TryAddScoped( typeof( IEntityMatedata ), t => t.GetService( entityMatedata ) );
            if( database != null ) {
                services.TryAddScoped( database );
                services.TryAddScoped( typeof( IDatabase ), t => t.GetService( database ) );
            }
            services.TryAddTransient<ISqlQuery, SqlQuery>();
            services.TryAddScoped<ITableDatabase, DefaultTableDatabase>();
            AddSqlBuilder( services, config );
            RegisterTypeHandlers( config );
            return services;
        }

        /// <summary>
        /// 配置Sql生成器
        /// </summary>
        private static void AddSqlBuilder( IServiceCollection services, SqlOptions config ) {
            switch( config.DatabaseType ) {
                case DatabaseType.SqlServer:
                    services.TryAddTransient<ISqlBuilder, SqlServerBuilder>();
                    return;
                case DatabaseType.PgSql:
                    services.TryAddTransient<ISqlBuilder, PgSqlBuilder>();
                    return;
                case DatabaseType.MySql:
                    services.TryAddTransient<ISqlBuilder, MySqlBuilder>();
                    return;
                case DatabaseType.Oracle:
                    services.TryAddTransient<ISqlBuilder, OracleBuilder>();
                    return;
                default:
                    throw new NotImplementedException( $"Sql生成器未实现 {config.DatabaseType.Description()} 数据库" );
            }
        }

        /// <summary>
        /// 注册类型处理器
        /// </summary>
        private static void RegisterTypeHandlers( SqlOptions config ) {
            SqlMapper.AddTypeHandler( typeof( string ), new StringTypeHandler() );
            if( config.DatabaseType == DatabaseType.Oracle )
                SqlMapper.AddTypeHandler( new GuidTypeHandler() );
        }
    }
}
