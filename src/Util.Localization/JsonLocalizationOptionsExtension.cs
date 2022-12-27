using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Util.Configs;
using Util.Localization.Json;

namespace Util.Localization {
    /// <summary>
    /// Json本地化配置扩展
    /// </summary>
    public class JsonLocalizationOptionsExtension : OptionsExtensionBase {
        /// <summary>
        /// 资源路径
        /// </summary>
        private readonly string _resourcesPath;

        /// <summary>
        /// 初始化Json本地化配置扩展
        /// </summary>
        /// <param name="resourcesPath">资源路径</param>
        public JsonLocalizationOptionsExtension( string resourcesPath ) {
            _resourcesPath = resourcesPath;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            services.RemoveAll( typeof( IStringLocalizerFactory ) );
            services.RemoveAll( typeof( IStringLocalizer<> ) );
            services.RemoveAll( typeof( IStringLocalizer ) );
            services.TryAddSingleton<IPathResolver, PathResolver>();
            services.TryAddSingleton<IStringLocalizerFactory,JsonStringLocalizerFactory>();
            services.TryAddTransient( typeof( IStringLocalizer<> ), typeof( StringLocalizer<> ) );
            services.TryAddTransient( typeof( IStringLocalizer ), typeof( StringLocalizer ) );
            services.Configure<LocalizationOptions>( options => options.ResourcesPath = _resourcesPath );
        }
    }
}
