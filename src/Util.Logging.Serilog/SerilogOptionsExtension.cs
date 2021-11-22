using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Util.Configs;

namespace Util.Logging.Serilog {
    /// <summary>
    /// Serilog日志操作配置扩展
    /// </summary>
    public class SerilogOptionsExtension : IOptionsExtension {
        /// <summary>
        /// 是否清除日志提供程序
        /// </summary>
        private readonly bool _isClearProviders;

        /// <summary>
        /// 初始化Serilog日志操作配置扩展
        /// </summary>
        /// <param name="isClearProviders">是否清除日志提供程序</param>
        public SerilogOptionsExtension( bool isClearProviders ) {
            _isClearProviders = isClearProviders;
        }

        /// <summary>
        /// 添加服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public void AddServices( IServiceCollection services ) {
            services.AddLogging( loggingBuilder => {
                if( _isClearProviders )
                    loggingBuilder.ClearProviders();
                var configuration = services.GetConfiguration();
                Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .Enrich.WithLogLevel()
                    .Enrich.WithLogContext()
                    .ReadFrom.Configuration( configuration )
                    .ConfigLogLevel( configuration )
                    .CreateLogger();
                loggingBuilder.AddSerilog();
            } );
        }
    }
}
