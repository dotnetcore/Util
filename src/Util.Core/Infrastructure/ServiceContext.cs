using Microsoft.Extensions.Hosting;
using Util.Reflections;

namespace Util.Infrastructure {
    /// <summary>
    /// 服务上下文
    /// </summary>
    public class ServiceContext {
        /// <summary>
        /// 初始化服务上下文
        /// </summary>
        /// <param name="hostBuilder">主机生成器</param>
        /// <param name="typeFinder">类型查找器</param>
        public ServiceContext( IHostBuilder hostBuilder, ITypeFinder typeFinder ) {
            HostBuilder = hostBuilder;
            TypeFinder = typeFinder;
        }

        /// <summary>
        /// 主机生成器
        /// </summary>
        public IHostBuilder HostBuilder { get; }

        /// <summary>
        /// 类型查找器
        /// </summary>
        public ITypeFinder TypeFinder { get; }
    }
}
