using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Aop;
using Util.Data.Dapper.Sql;
using Util.Data.EntityFrameworkCore;
using Util.Helpers;
using Util.Logging.Serilog;
using Util.Sessions;
using Util.Tests.Infrastructure;
using Util.Tests.UnitOfWorks;
using Xunit.DependencyInjection.Logging;

namespace Util.Data.Dapper.Tests {
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup {
        /// <summary>
        /// 配置主机
        /// </summary>
        public void ConfigureHost( IHostBuilder hostBuilder ) {
            Environment.SetDevelopment();
            hostBuilder.ConfigureDefaults( null )
                .AsBuild()
                .AddAop()
                .AddSerilog()
                .AddOracleSqlQuery( Config.GetConnectionString( "connection" ) )
                .AddOracleSqlExecutor( Config.GetConnectionString( "connection" ) )
                .AddOracleUnitOfWork<ITestUnitOfWork, OracleUnitOfWork>( Config.GetConnectionString( "connection" ) )
                .AddUtil();
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        public void ConfigureServices( IServiceCollection services ) {
            services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
			services.AddSingleton<ISession, TestSession>();
            InitDatabase( services );
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        private void InitDatabase( IServiceCollection services ) {
            var unitOfWork = (OracleUnitOfWork)services.BuildServiceProvider().GetService<ITestUnitOfWork>();
            unitOfWork.EnsureDeleted();
            unitOfWork.EnsureCreated();
        }
    }
}
