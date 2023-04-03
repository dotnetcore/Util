using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Caching.EasyCaching.Samples;
using Xunit;

namespace Util.Caching.EasyCaching.Tests {
    /// <summary>
    /// 本地缓存拦截器测试
    /// </summary>
    public class LocalCacheAttributeTest {
        /// <summary>
        /// 缓存测试服务
        /// </summary>
        private readonly ICacheService _cacheService;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public LocalCacheAttributeTest( ICacheService cacheService ) {
            _cacheService = cacheService;
        }

        /// <summary>
        /// 测试获取值
        /// </summary>
        [Fact]
        public void TestGetValue_1() {
            var value = _cacheService.GetValue();
            var value2 = _cacheService.GetValue();
            Assert.Equal( value,value2 );
        }

        /// <summary>
        /// 测试获取值 - 带一个简单参数
        /// </summary>
        [Fact]
        public void TestGetValue_2() {
            var value1 = _cacheService.GetValue(1);
            var value11 = _cacheService.GetValue( 1 );
            var value2 = _cacheService.GetValue(2);
            Assert.Equal( value1, value11 );
            Assert.NotEqual( value1, value2 );
        }

        /// <summary>
        /// 测试获取值 - 异步
        /// </summary>
        [Fact]
        public async Task TestGetValueAsync() {
            var value = await _cacheService.GetValueAsync();
            var value2 = await _cacheService.GetValueAsync();
            Assert.Equal( value, value2 );
        }

        /// <summary>
        /// 测试获取对象集合
        /// </summary>
        [Fact]
        public void TestGetItems() {
            var value = _cacheService.GetItems();
            var value2 = _cacheService.GetItems();
            Assert.Equal( value[0].Value, value2[0].Value );
            Assert.Equal( value[1].Value, value2[1].Value );
        }

        /// <summary>
        /// 测试获取对象集合
        /// </summary>
        [Fact]
        public async Task TestGetItemsAsync() {
            var value1 = await _cacheService.GetItemsAsync(1,"a",new Item( "b",2 ),new List<Item>{ new ( "c", 3 ), new ( "d", 4 ) } );
            var value11 = await _cacheService.GetItemsAsync( 1, "a", new Item( "b", 2 ), new List<Item> { new ( "c", 3 ), new ( "d", 4 ) } );
            var value2 = await _cacheService.GetItemsAsync( 2, "a", new Item( "b", 2 ), new List<Item> { new ( "c", 3 ), new ( "d", 4 ) } );
            Assert.Equal( value1[0].Value, value11[0].Value );
            Assert.Equal( value1[1].Value, value11[1].Value );
            Assert.NotEqual( value1[0].Value, value2[0].Value );
        }
    }
}
