using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Util.Aop;
using Util.Data.EntityFrameworkCore.Infrastructure;
using Util.Data.EntityFrameworkCore.UnitOfWorks;
using Util.Helpers;
using Util.Sessions;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace Util.Data.EntityFrameworkCore {
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup {
        /// <summary>
        /// 配置主机
        /// </summary>
        public void ConfigureHost( IHostBuilder hostBuilder ) {
            hostBuilder.ConfigureDefaults( null ).UseEnvironment( "Development" ).EnableAop();
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        public void ConfigureServices( IServiceCollection services ) {
            services.AddSingleton<ISession, TestSession>();
            services.AddUtil( options => {
                options.UsePgSqlUnitOfWork<IPgSqlUnitOfWork, PgSqlUnitOfWork>( Config.GetConnectionString( "connection" ) );
            } );
            InitDatabase( services );
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        private void InitDatabase( IServiceCollection services ) {
            var unitOfWork = services.BuildServiceProvider().GetService<IPgSqlUnitOfWork>();
            unitOfWork.EnsureDeleted();
            unitOfWork.EnsureCreated();
        }

        /// <summary>
        /// 配置日志提供程序
        /// </summary>
        public void Configure( ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor ) {
            loggerFactory.AddProvider( new XunitTestOutputLoggerProvider( accessor, ( s, logLevel ) => logLevel >= LogLevel.Trace ) );
        }
    }
}
