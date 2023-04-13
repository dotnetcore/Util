using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Util.Configs;

namespace Util.FileStorage.Minio {
    /// <summary>
    /// Minio文件存储操作配置扩展
    /// </summary>
    internal class MinioOptionsExtension : OptionsExtensionBase {
        /// <summary>
        /// Minio配置操作
        /// </summary>
        private readonly Action<MinioOptions> _setupAction;

        /// <summary>
        /// 初始化Minio文件存储操作配置扩展
        /// </summary>
        /// <param name="setupAction">Minio配置操作</param>
        public MinioOptionsExtension( Action<MinioOptions> setupAction ) {
            _setupAction = setupAction;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            if( _setupAction != null )
                services.Configure( _setupAction );
            services.TryAddTransient<IFileStore, MinioFileStore>();
        }
    }
}
