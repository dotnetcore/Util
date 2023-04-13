using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Util.FileStorage.Minio {
    /// <summary>
    /// Minio配置提供器
    /// </summary>
    public class MinioConfigProvider : IMinioConfigProvider {
        /// <summary>
        /// Minio配置
        /// </summary>
        private readonly MinioConfig _config;

        /// <summary>
        /// 初始化Minio配置提供器
        /// </summary>
        /// <param name="options">Minio配置</param>
        public MinioConfigProvider( IOptions<MinioOptions> options ) {
            options.CheckNull( nameof( options ) );
            _config = options.Value.ToConfig();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        public Task<MinioConfig> GetConfigAsync() {
            return Task.FromResult( _config );
        }
    }
}
