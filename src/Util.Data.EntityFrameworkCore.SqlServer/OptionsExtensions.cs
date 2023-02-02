using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Util.Configs;

namespace Util.Data.EntityFrameworkCore {
    /// <summary>
    /// Sql Server工作单元操作扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 配置Sql Server工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        /// <param name="setupAction">工作单元配置操作</param>
        /// <param name="sqlServerSetupAction">Sql Server配置操作</param>
        /// <param name="condition">条件,设置为false,跳过配置</param>
        public static Options UseSqlServerUnitOfWork<TService, TImplementation>( this Options options, string connection, Action<DbContextOptionsBuilder> setupAction = null,
            Action<SqlServerDbContextOptionsBuilder> sqlServerSetupAction = null,bool? condition = null )
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService {
            return options.UseSqlServerUnitOfWork<TService, TImplementation>( connection, null, setupAction, sqlServerSetupAction, condition );
        }

        /// <summary>
        /// 配置Sql Server工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接</param>
        /// <param name="setupAction">工作单元配置操作</param>
        /// <param name="sqlServerSetupAction">Sql Server配置操作</param>
        /// <param name="condition">条件,设置为false,跳过配置</param>
        public static Options UseSqlServerUnitOfWork<TService, TImplementation>( this Options options, DbConnection connection, Action<DbContextOptionsBuilder> setupAction = null,
            Action<SqlServerDbContextOptionsBuilder> sqlServerSetupAction = null, bool? condition = null )
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService {
            return options.UseSqlServerUnitOfWork<TService, TImplementation>( null, connection, setupAction, sqlServerSetupAction, condition );
        }

        /// <summary>
        /// 配置Sql Server工作单元
        /// </summary>
        private static Options UseSqlServerUnitOfWork<TService, TImplementation>( this Options options, string connectionString, DbConnection connection, Action<DbContextOptionsBuilder> setupAction = null,
            Action<SqlServerDbContextOptionsBuilder> sqlServerSetupAction = null, bool? condition = null )
            where TService : class, IUnitOfWork
            where TImplementation : UnitOfWorkBase, TService {
            options.AddExtension( new SqlServerOptionsExtension<TService, TImplementation>( connectionString, connection, setupAction, sqlServerSetupAction, condition ) );
            return options;
        }
    }
}
