using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySqlConnector;
using Util.Configs;

namespace Util.Data.EntityFrameworkCore {
    /// <summary>
    /// MySql工作单元配置扩展
    /// </summary>
    public class MySqlOptionsExtension<TService, TImplementation> : OptionsExtensionBase
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
        /// MySql配置操作
        /// </summary>
        private readonly Action<MySqlDbContextOptionsBuilder> _mySqlSetupAction;
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
        /// <param name="mySqlSetupAction">MySql配置操作</param>
        /// <param name="condition">条件</param>
        public MySqlOptionsExtension( string connectionString, DbConnection connection, Action<DbContextOptionsBuilder> setupAction, 
            Action<MySqlDbContextOptionsBuilder> mySqlSetupAction, bool? condition ) {
            _connectionString = connectionString;
            _connection = connection;
            _setupAction = setupAction;
            _mySqlSetupAction = mySqlSetupAction;
            _condition = condition;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            if ( _condition == false )
                return;
            services.AddDbContext<TService, TImplementation>( options => {
                _setupAction?.Invoke( options );
                if ( _connectionString.IsEmpty() == false ) {
                    options.UseMySql( _connectionString, ServerVersion.AutoDetect( _connectionString ), _mySqlSetupAction );
                    return;
                }
                if ( _connection != null ) {
                    options.UseMySql( _connection, ServerVersion.AutoDetect( (MySqlConnection)_connection ), _mySqlSetupAction );
                }
            } );
        }
    }
}
