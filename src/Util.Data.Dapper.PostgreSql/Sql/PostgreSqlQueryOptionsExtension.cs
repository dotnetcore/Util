using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Util.Configs;

namespace Util.Data.Sql {
    /// <summary>
    /// PostgreSql Sql查询对象配置扩展
    /// </summary>
    public class PostgreSqlQueryOptionsExtension<TService, TImplementation> : OptionsExtensionBase
        where TService : ISqlQuery 
        where TImplementation : PostgreSqlQueryBase, TService {
        /// <summary>
        /// Sql配置
        /// </summary>
        private readonly SqlOptions _options;

        /// <summary>
        /// 初始化PostgreSql Sql查询对象配置扩展
        /// </summary>
        /// <param name="options">Sql配置</param>
        public PostgreSqlQueryOptionsExtension( SqlOptions options ) {
            _options = options;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            services.TryAddTransient( typeof( TService ), typeof( TImplementation ) );
            services.TryAddSingleton( typeof( SqlOptions<TImplementation> ), ( sp ) => _options );
        }
    }
}
