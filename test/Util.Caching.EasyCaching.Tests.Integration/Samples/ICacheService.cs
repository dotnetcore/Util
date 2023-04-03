using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dependency;

namespace Util.Caching.EasyCaching.Samples {
    /// <summary>
    /// 缓存测试服务
    /// </summary>
    public interface ICacheService : ITransientDependency {
        /// <summary>
        /// 获取值
        /// </summary>
        [LocalCache]
        string GetValue();
        /// <summary>
        /// 获取值 - 带一个简单参数
        /// </summary>
        [LocalCache]
        string GetValue( int id );
        /// <summary>
        /// 异步获取值
        /// </summary>
        [LocalCache]
        Task<string> GetValueAsync();
        /// <summary>
        /// 获取对象集合
        /// </summary>
        [LocalCache]
        List<Item> GetItems();
        /// <summary>
        /// 获取对象集合
        /// </summary>
        [LocalCache]
        Task<List<Item>> GetItemsAsync( int id, string name , Item item, List<Item> items );
    }
}
