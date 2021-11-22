using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Util.Aop;
using Util.Applications.UnitOfWorks;
using Util.Data.EntityFrameworkCore;
using Util.Helpers;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace Util.Applications {
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
            services.AddUtil( options => {
                options.UseSqlServerUnitOfWork<ISqlServerUnitOfWork, SqlServerUnitOfWork>( Config.GetConnectionString( "connection" ) );
            } );
            InitDatabase( services );
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        private void InitDatabase( IServiceCollection services ) {
            var unitOfWork = services.BuildServiceProvider().GetService<ISqlServerUnitOfWork>();
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
