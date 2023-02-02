using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Util.Configs;

namespace Util.Data.EntityFrameworkCore {
    /// <summary>
    /// PostgreSql工作单元操作扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 配置PostgreSql工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        /// <param name="setupAction">工作单元配置操作</param>
        /// <param name="pgSqlSetupAction">PostgreSql配置操作</param>
        /// <param name="isEnableLegacyTimestampBehavior">是否启用传统时间戳行为</param>
        /// <param name="condition">条件,设置为false,跳过配置</param>
        public static Options UsePgSqlUnitOfWork<TService, TImplementation>( this Options options, string connection, Action<DbContextOptionsBuilder> setupAction = null,
            Action<NpgsqlDbContextOptionsBuilder> pgSqlSetupAction = null,bool isEnableLegacyTimestampBehavior = false, bool? condition = null )
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService {
            return options.UsePgSqlUnitOfWork<TService, TImplementation>( connection, null, setupAction, pgSqlSetupAction, isEnableLegacyTimestampBehavior, condition );
        }

        /// <summary>
        /// 配置PostgreSql工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接</param>
        /// <param name="setupAction">工作单元配置操作</param>
        /// <param name="pgSqlSetupAction">PostgreSql配置操作</param>
        /// <param name="isEnableLegacyTimestampBehavior">是否启用传统时间戳行为</param>
        /// <param name="condition">条件,设置为false,跳过配置</param>
        public static Options UsePgSqlUnitOfWork<TService, TImplementation>( this Options options, DbConnection connection, Action<DbContextOptionsBuilder> setupAction = null,
            Action<NpgsqlDbContextOptionsBuilder> pgSqlSetupAction = null, bool isEnableLegacyTimestampBehavior = false, bool? condition = null )
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService {
            return options.UsePgSqlUnitOfWork<TService, TImplementation>( null, connection, setupAction, pgSqlSetupAction, isEnableLegacyTimestampBehavior, condition );
        }

        /// <summary>
        /// 配置PostgreSql工作单元
        /// </summary>
        private static Options UsePgSqlUnitOfWork<TService, TImplementation>( this Options options, string connectionString, DbConnection connection, Action<DbContextOptionsBuilder> setupAction,
            Action<NpgsqlDbContextOptionsBuilder> pgSqlSetupAction, bool isEnableLegacyTimestampBehavior, bool? condition )
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService {
            AppContext.SetSwitch( "Npgsql.EnableLegacyTimestampBehavior", isEnableLegacyTimestampBehavior );
            options.AddExtension( new PgSqlOptionsExtension<TService, TImplementation>( connectionString, connection, setupAction, pgSqlSetupAction, condition ) );
            return options;
        }
    }
}
