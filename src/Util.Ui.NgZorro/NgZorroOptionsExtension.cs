using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Configs;
using Util.Ui.Razor;

namespace Util.Ui.NgZorro {
    /// <summary>
    /// NgZorro配置扩展
    /// </summary>
    public class NgZorroOptionsExtension : OptionsExtensionBase {
        /// <summary>
        /// NgZorro配置操作
        /// </summary>
        private readonly Action<NgZorroOptions> _setupAction;
        /// <summary>
        /// NgZorro配置
        /// </summary>
        private readonly NgZorroOptions _options;

        /// <summary>
        /// 初始化NgZorro配置扩展
        /// </summary>
        /// <param name="setupAction">NgZorro配置操作</param>
        public NgZorroOptionsExtension( Action<NgZorroOptions> setupAction ) {
            _setupAction = setupAction;
            _options = new NgZorroOptions();
            setupAction?.Invoke( _options );
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            services.AddRazorPages().AddRazorRuntimeCompilation().AddConventions();
            ConfigSpaStaticFiles( services );
            ConfigRazorOptions( services );
            ConfigNgZorroOptions( services );
        }

        /// <summary>
        /// 配置Spa静态文件
        /// </summary>
        private void ConfigSpaStaticFiles( IServiceCollection services ) {
            services.AddSpaStaticFiles( configuration => {
                configuration.RootPath = _options.RootPath;
            } );
        }

        /// <summary>
        /// 配置Razor
        /// </summary>
        private void ConfigRazorOptions( IServiceCollection services ) {
            void Action( RazorOptions t ) => t.IsGenerateHtml = _options.IsGenerateHtml;
            services.Configure( (Action<RazorOptions>)Action );
        }

        /// <summary>
        /// 配置Ngzor
        /// </summary>
        private void ConfigNgZorroOptions( IServiceCollection services ) {
            if ( _setupAction != null )
                services.Configure( _setupAction );
        }
    }
}
