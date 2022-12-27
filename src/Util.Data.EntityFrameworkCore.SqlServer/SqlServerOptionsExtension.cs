using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Configs;

namespace Util.Data.EntityFrameworkCore {
    /// <summary>
    /// Sql Server 工作单元配置扩展
    /// </summary>
    public class SqlServerOptionsExtension<TService, TImplementation> : OptionsExtensionBase
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
        /// Sql Server配置操作
        /// </summary>
        private readonly Action<SqlServerDbContextOptionsBuilder> _sqlServerSetupAction;

        /// <summary>
        /// 初始化Sql Server 工作单元配置扩展
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="connection">数据库连接</param>
        /// <param name="setupAction">工作单元配置操作</param>
        /// <param name="sqlServerSetupAction">Sql Server配置操作</param>
        public SqlServerOptionsExtension( string connectionString, DbConnection connection, Action<DbContextOptionsBuilder> setupAction, Action<SqlServerDbContextOptionsBuilder> sqlServerSetupAction ) {
            _connectionString = connectionString;
            _connection = connection;
            _setupAction = setupAction;
            _sqlServerSetupAction = sqlServerSetupAction;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            services.AddDbContext<TService, TImplementation>( options => {
                _setupAction?.Invoke( options );
                if ( _connectionString.IsEmpty() == false ) {
                    options.UseSqlServer( _connectionString, _sqlServerSetupAction );
                    return;
                }
                if ( _connection != null ) {
                    options.UseSqlServer( _connection, _sqlServerSetupAction );
                }
            } );
        }
    }
}
