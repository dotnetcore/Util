using System.Reflection;

namespace Util.Caching {
    /// <summary>
    /// 缓存键生成器
    /// </summary>
    public interface ICacheKeyGenerator {
        /// <summary>
        /// 创建缓存键
        /// </summary>
        /// <param name="methodInfo">方法</param>
        /// <param name="args">参数</param>
        /// <param name="prefix">缓存键前缀</param>
        string CreateCacheKey( MethodInfo methodInfo, object[] args, string prefix );
    }
}
