using System.Threading.Tasks;
using Xunit;

namespace Util.Caching.EasyCaching.Tests {
    /// <summary>
    /// EasyCaching缓存服务测试
    /// </summary>
    public class CacheTest {
        /// <summary>
        /// 缓存服务
        /// </summary>
        private readonly ICache _cache;

        /// <summary>
        /// 测试初始化
        /// </summary>
        /// <param name="cache">缓存服务</param>
        public CacheTest( ICache cache ) {
            _cache = cache;
        }

        /// <summary>
        /// 测试从缓存中获取数据
        /// </summary>
        [Fact]
        public void TestGet() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = _cache.Get( "a", () => {
                    data++;
                    return data;
                } );
            }
            Assert.Equal( 1,result );
        }

        /// <summary>
        /// 测试从缓存中获取数据
        /// </summary>
        [Fact]
        public async Task TestGetAsync() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = await _cache.GetAsync( "a",async () => {
                    data++;
                    return await Task.FromResult( data );
                } );
            }
            Assert.Equal( 1, result );
        }

        /// <summary>
        /// 测试添加缓存
        /// </summary>
        [Fact]
        public void TestTryAdd() {
            Assert.False( _cache.Exists( "b" ) );
            _cache.TryAdd( "b", 1 );
            Assert.True( _cache.Exists( "b" ) );
        }

        /// <summary>
        /// 测试移除缓存
        /// </summary>
        [Fact]
        public void TestRemove() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = _cache.Get( "c", () => {
                    data++;
                    return data;
                } );
                _cache.Remove( "c" );
            }
            Assert.Equal( 3, result );
        }

        /// <summary>
        /// 测试清空缓存
        /// </summary>
        [Fact]
        public void TestClear() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = _cache.Get( "d", () => {
                    data++;
                    return data;
                } );
                _cache.Clear();
            }
            Assert.Equal( 3, result );
        }
    }
}