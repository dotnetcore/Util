using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Util.Configs;

namespace Util.Data.EntityFrameworkCore {
    /// <summary>
    /// PostgreSql工作单元配置扩展
    /// </summary>
    public class PgSqlOptionsExtension<TService, TImplementation> : OptionsExtensionBase
        where TService : class, IUnitOfWork
        where TImplementation : UnitOfWorkBase, TService {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private readonly string _connectionString;
        /// <summary>
        /// 数据库连接
        /// </summary>
        private readonly DbConnection _connection;
        /// <summary>
        /// 工作单元配置操作
        /// </summary>
        private readonly Action<DbContextOptionsBuilder> _setupAction;
        /// <summary>
        /// PostgreSql配置操作
        /// </summary>
        private readonly Action<NpgsqlDbContextOptionsBuilder> _pgSqlSetupAction;
        /// <summary>
        /// 条件
        /// </summary>
        private readonly bool? _condition;

        /// <summary>
        /// 初始化PostgreSql工作单元配置扩展
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="connection">数据库连接</param>
        /// <param name="setupAction">工作单元配置操作</param>
        /// <param name="pgSqlSetupAction">PostgreSql配置操作</param>
        /// <param name="condition">条件</param>
        public PgSqlOptionsExtension( string connectionString, DbConnection connection, Action<DbContextOptionsBuilder> setupAction, 
            Action<NpgsqlDbContextOptionsBuilder> pgSqlSetupAction, bool? condition ) {
            _connectionString = connectionString;
            _connection = connection;
            _setupAction = setupAction;
            _pgSqlSetupAction = pgSqlSetupAction;
            _condition = condition;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            if ( _condition == false )
                return;
            services.AddDbContext<TService, TImplementation>( options => {
                _setupAction?.Invoke( options );
                if ( _connectionString.IsEmpty() == false ) {
                    options.UseNpgsql( _connectionString, _pgSqlSetupAction );
                    return;
                }
                if ( _connection != null ) {
                    options.UseNpgsql( _connection, _pgSqlSetupAction );
                }
            } );
        }
    }
}
