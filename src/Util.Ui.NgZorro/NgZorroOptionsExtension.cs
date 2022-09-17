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
        /// 配置操作
        /// </summary>
        private readonly Action<NgZorroOptions> _setupAction;

        /// <summary>
        /// 初始化NgZorro配置扩展
        /// </summary>
        /// <param name="setupAction">配置操作</param>
        public NgZorroOptionsExtension( Action<NgZorroOptions> setupAction) {
            _setupAction = setupAction;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            services.AddRazorPages().AddRazorRuntimeCompilation().AddConventions();
            services.AddSpaStaticFiles( configuration => {
                configuration.RootPath = "ClientApp/dist";
            } );
            if( _setupAction != null )
                services.Configure( _setupAction );
        }
    }
}
