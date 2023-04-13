using System.Threading.Tasks;
using Util.Dependency;

namespace Util.FileStorage.Minio {
    /// <summary>
    /// Minio配置提供器
    /// </summary>
    public interface IMinioConfigProvider : ITransientDependency {
        /// <summary>
        /// 获取配置
        /// </summary>
        Task<MinioConfig> GetConfigAsync();
    }
}
