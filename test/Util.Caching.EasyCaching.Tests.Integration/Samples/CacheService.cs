using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Helpers;

namespace Util.Caching.EasyCaching.Samples {
    /// <summary>
    /// 缓存测试服务
    /// </summary>
    public class CacheService : ICacheService {
        /// <summary>
        /// 获取值
        /// </summary>
        public string GetValue() {
            return Id.Create();
        }

        /// <summary>
        /// 获取值 - 带一个简单参数
        /// </summary>
        public string GetValue( int id ) {
            return $"{Id.Create()}:{id}";
        }

        /// <summary>
        /// 异步获取值
        /// </summary>
        public async Task<string> GetValueAsync() {
            await Task.Delay( 1 );
            return Id.Create();
        }

        /// <summary>
        /// 获取对象集合
        /// </summary>
        public List<Item> GetItems() {
            return new List<Item> { new ( "a", Id.Create() ), new( "a", Id.Create() ) };
        }

        /// <summary>
        /// 获取对象集合
        /// </summary>
        public async Task<List<Item>> GetItemsAsync( int id, string name, Item item, List<Item> items ) {
            await Task.Delay( 1 );
            var result = new List<Item>();
            items.ForEach( t => {
                var value = $"{id}-{name}-{item.Text}-{item.Value}-{t.Text}-{t.Value}";
                result.Add( new Item( "",value ) );
            } );
            return result;
        }
    }
}
