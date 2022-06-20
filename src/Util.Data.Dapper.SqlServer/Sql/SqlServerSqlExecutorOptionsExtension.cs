using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Util.Configs;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql Server Sql执行器配置扩展
    /// </summary>
    public class SqlServerSqlExecutorOptionsExtension<TService, TImplementation> : OptionsExtensionBase
        where TService : ISqlExecutor 
        where TImplementation : SqlServerSqlExecutorBase, TService {
        /// <summary>
        /// Sql配置
        /// </summary>
        private readonly SqlOptions _options;

        /// <summary>
        /// 初始化Sql Server Sql执行器配置扩展
        /// </summary>
        /// <param name="options">Sql配置</param>
        public SqlServerSqlExecutorOptionsExtension( SqlOptions options ) {
            _options = options;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            services.TryAddTransient( typeof( TService ), typeof( TImplementation ) );
            services.TryAddSingleton( typeof( SqlOptions<TImplementation> ), ( sp ) => _options );
        }
    }
}
