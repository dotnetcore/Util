using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Util.Configs;

namespace Util.Data.Sql {
    /// <summary>
    /// PostgreSql Sql执行器配置扩展
    /// </summary>
    public class PostgreSqlExecutorOptionsExtension<TService, TImplementation> : OptionsExtensionBase
        where TService : ISqlExecutor 
        where TImplementation : PostgreSqlExecutorBase, TService {
        /// <summary>
        /// Sql配置
        /// </summary>
        private readonly SqlOptions _options;

        /// <summary>
        /// 初始化PostgreSql Sql执行器配置扩展
        /// </summary>
        /// <param name="options">Sql配置</param>
        public PostgreSqlExecutorOptionsExtension( SqlOptions options ) {
            _options = options;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            services.TryAddTransient( typeof( TService ), typeof( TImplementation ) );
            services.TryAddSingleton( typeof( SqlOptions<TImplementation> ), ( sp ) => _options );
        }
    }
}
