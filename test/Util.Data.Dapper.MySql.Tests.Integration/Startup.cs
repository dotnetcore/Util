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
    /// ��������
    /// </summary>
    public class Startup {
        /// <summary>
        /// ��������
        /// </summary>
        public void ConfigureHost( IHostBuilder hostBuilder ) {
            hostBuilder.ConfigureDefaults( null )
                .ConfigureServices( ( context, services ) => {
                    services.AddTransient<IMetadataService, MySqlMetadataService>();
                } )
                .AddUtil( options => {
                    Environment.SetDevelopment();
                    options.UseAop()
                        .UseMySqlQuery( Config.GetConnectionString( "connection" ) )
                        .UseMySqlExecutor( Config.GetConnectionString( "connection" ) )
                        .UseMySqlUnitOfWork<ITestUnitOfWork, MySqlUnitOfWork>( Config.GetConnectionString( "connection" ) );
                } );
        }

        /// <summary>
        /// ���÷���
        /// </summary>
        public void ConfigureServices( IServiceCollection services ) {
	        services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
			services.AddSingleton<ISession, TestSession>();
            InitDatabase( services );
        }

        /// <summary>
        /// ��ʼ�����ݿ�
        /// </summary>
        private void InitDatabase( IServiceCollection services ) {
            var unitOfWork = (MySqlUnitOfWork)services.BuildServiceProvider().GetService<ITestUnitOfWork>();
            unitOfWork.EnsureDeleted();
            unitOfWork.EnsureCreated();
            DatabaseScript.InitProcedures( unitOfWork?.Database );
        }
    }
}