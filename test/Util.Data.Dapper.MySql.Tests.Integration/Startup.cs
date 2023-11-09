using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Aop;
using Util.Data.Dapper.Metadata;
using Util.Data.Dapper.Sql;
using Util.Data.Dapper.Tests.Infrastructure;
using Util.Data.EntityFrameworkCore;
using Util.Data.Metadata;
using Util.Helpers;
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
                .AddMySqlQuery( Config.GetConnectionString( "connection" ) )
                .AddMySqlExecutor( Config.GetConnectionString( "connection" ) )
                .AddMySqlUnitOfWork<ITestUnitOfWork, MySqlUnitOfWork>( Config.GetConnectionString( "connection" ) )
                .AddUtil();
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        public void ConfigureServices( IServiceCollection services ) {
            services.AddTransient<IMetadataService, MySqlMetadataService>();
            services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
			services.AddSingleton<ISession, TestSession>();
            InitDatabase( services );
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        private void InitDatabase( IServiceCollection services ) {
            var unitOfWork = (MySqlUnitOfWork)services.BuildServiceProvider().GetService<ITestUnitOfWork>();
            unitOfWork.EnsureDeleted();
            unitOfWork.EnsureCreated();
            DatabaseScript.InitProcedures( unitOfWork?.Database );
        }
    }
}
