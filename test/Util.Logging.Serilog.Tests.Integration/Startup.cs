using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Util.Logging.Serilog;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;
using serilog = Serilog;

namespace Util.Logging.Tests {
    /// <summary>
    /// ��������
    /// </summary>
    public class Startup {
        /// <summary>
        /// ��������
        /// </summary>
        public void ConfigureHost( IHostBuilder hostBuilder ) {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            hostBuilder.ConfigureDefaults( null )
                .AddUtil( options => options.UseSerilog() );
        }

        /// <summary>
        /// �����˳�ʱ�ͷ���־ʵ��,���ڽ��Seq�޷�д�������
        /// </summary>
        private void CurrentDomain_ProcessExit( object sender, EventArgs e ) {
            var log = (serilog.Core.Logger)serilog.Log.Logger;
            log.Dispose();
        }

        /// <summary>
        /// ���÷���
        /// </summary>
        public void ConfigureServices( IServiceCollection services ) {
            services.AddSingleton<ILogContextAccessor, LogContextAccessor>();
        }

        /// <summary>
        /// ������־�ṩ����
        /// </summary>
        public void Configure( ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor ) {
            loggerFactory.AddProvider( new XunitTestOutputLoggerProvider( accessor,(s,logLevel) => logLevel >= LogLevel.Trace ) );
        }
    }
}
