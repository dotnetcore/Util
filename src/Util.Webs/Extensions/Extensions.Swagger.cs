using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Util.Webs.Extensions {
    /// <summary>
    /// Swagger扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 配置自定义Swagger服务
        /// </summary>
        /// <param name="builder">应用程序生成器</param>
        /// <param name="swaggerUiSetup">swaggerUI设置</param>
        public static IApplicationBuilder UseSwaggerX( this IApplicationBuilder builder,Action<SwaggerUIOptions> swaggerUiSetup = null ) {
            builder.UseSwagger();
            builder.UseSwaggerUI( options => {
                options.IndexStream = () => typeof( Extensions ).GetTypeInfo().Assembly.GetManifestResourceStream( "Util.Webs.Swaggers.index.html" );
                if ( swaggerUiSetup == null ) {
                    options.SwaggerEndpoint( "/swagger/v1/swagger.json", "api v1" );
                    return;
                }
                swaggerUiSetup( options );
            } );
            return builder;
        }
    }
}
