using System;
using System.Threading.Tasks;
using Xunit;

namespace Util.Caching.EasyCaching.Tests {
    /// <summary>
    /// EasyCaching缓存服务测试
    /// </summary>
    public class CacheManagerTest {

        #region 测试初始化

        /// <summary>
        /// 缓存服务
        /// </summary>
        private readonly ICache _cache;

        /// <summary>
        /// 测试初始化
        /// </summary>
        /// <param name="cache">缓存服务</param>
        public CacheManagerTest( ICache cache ) {
            _cache = cache;
        }

        #endregion

        #region Get

        /// <summary>
        /// 测试获取缓存
        /// </summary>
        [Fact]
        public void TestGet_1() {
            //变量定义
            var key = "c:TestGet_1";
            var value = 1;

            //获取缓存,结果为空
            var result = _cache.Get<int?>( key );
            Assert.Null( result );

            //设置缓存
            _cache.Set( key, value );

            //验证
            result = _cache.Get<int?>( key );
            Assert.Equal( value, result );
        }

        /// <summary>
        /// 测试获取缓存 - 设置缓存键对象
        /// </summary>
        [Fact]
        public void TestGet_2() {
            //变量定义
            var key = new CacheKey( "TestGet_2" );
            var value = 1;

            //获取缓存,结果为空
            var result = _cache.Get<int?>( key );
            Assert.Null( result );

            //设置缓存
            _cache.Set( key, value );

            //验证
            result = _cache.Get<int?>( key );
            Assert.Equal( value, result );
        }

        /// <summary>
        /// 测试获取缓存 - 获取集合
        /// </summary>
        [Fact]
        public void TestGet_3() {
            //变量定义
            var key = "TestGet_31";
            var key2 = "TestGet_32";

            //设置缓存
            _cache.Set( key, 1 );
            _cache.Set( key2, 2 );

            //验证
            var result = _cache.Get<int?>( new[] { key, key2 } );
            Assert.Equal( 1, result[0] );
            Assert.Equal( 2, result[1] );
        }

        /// <summary>
        /// 测试获取缓存 - 获取集合,设置缓存键对象
        /// </summary>
        [Fact]
        public void TestGet_4() {
            //变量定义
            var key = new CacheKey( "TestGet_41" );
            var key2 = new CacheKey( "TestGet_42" );

            //设置缓存
            _cache.Set( key, 1 );
            _cache.Set( key2, 2 );

            //验证
            var result = _cache.Get<int?>( new[] { key, key2 } );
            Assert.Equal( 1, result[0] );
            Assert.Equal( 2, result[1] );
        }

        /// <summary>
        /// 测试从缓存中获取数据 - 默认8小时过期
        /// </summary>
        [Fact]
        public void TestGet_5() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = _cache.Get( "TestGet_5", () => {
                    data++;
                    return data;
                } );
            }
            Assert.Equal( 1, result );
        }

        /// <summary>
        /// 测试从缓存中获取数据 - 设置1微秒过期
        /// </summary>
        [Fact]
        public void TestGet_6() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = _cache.Get( "TestGet_6", () => {
                    data++;
                    return data;
                }, new CacheOptions { Expiration = TimeSpan.FromMicroseconds( 1 ) } );
            }
            Assert.NotEqual( 1, result );
        }

        /// <summary>
        /// 测试从缓存中获取数据 - 设置缓存键对象
        /// </summary>
        [Fact]
        public void TestGet_7() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = _cache.Get( new CacheKey( "TestGet_7" ), () => {
                    data++;
                    return data;
                } );
            }
            Assert.Equal( 1, result );
        }

        #endregion

        #region GetAsync

        /// <summary>
        /// 测试获取缓存
        /// </summary>
        [Fact]
        public async Task TestGetAsync_1() {
            //变量定义
            var key = "c:TestGetAsync_1";
            var value = 1;

            //获取缓存,结果为空
            var result = await _cache.GetAsync<int?>( key );
            Assert.Null( result );

            //设置缓存
            await _cache.SetAsync( key, value );

            //验证
            result = await _cache.GetAsync<int?>( key );
            Assert.Equal( value, result );
        }

        /// <summary>
        /// 测试获取缓存 - 设置缓存键对象
        /// </summary>
        [Fact]
        public async Task TestGetAsync_2() {
            //变量定义
            var key = new CacheKey( "TestGetAsync_2" );
            var value = 1;

            //获取缓存,结果为空
            var result = await _cache.GetAsync<int?>( key );
            Assert.Null( result );

            //设置缓存
            await _cache.SetAsync( key, value );

            //验证
            result = await _cache.GetAsync<int?>( key );
            Assert.Equal( value, result );
        }

        /// <summary>
        /// 测试获取缓存 - 获取集合
        /// </summary>
        [Fact]
        public async Task TestGetAsync_3() {
            //变量定义
            var key = "TestGetAsync_31";
            var key2 = "TestGetAsync_32";

            //设置缓存
            await _cache.SetAsync( key, 1 );
            await _cache.SetAsync( key2, 2 );

            //验证
            var result = await _cache.GetAsync<int?>( new[] { key, key2 } );
            Assert.Equal( 1, result[0] );
            Assert.Equal( 2, result[1] );
        }

        /// <summary>
        /// 测试获取缓存 - 获取集合,设置缓存键对象
        /// </summary>
        [Fact]
        public async Task TestGetAsync_4() {
            //变量定义
            var key = new CacheKey( "TestGetAsync_41" );
            var key2 = new CacheKey( "TestGetAsync_42" );

            //设置缓存
            await _cache.SetAsync( key, 1 );
            await _cache.SetAsync( key2, 2 );

            //验证
            var result = await _cache.GetAsync<int?>( new[] { key, key2 } );
            Assert.Equal( 1, result[0] );
            Assert.Equal( 2, result[1] );
        }

        /// <summary>
        /// 测试从缓存中获取数据 - 默认8小时过期
        /// </summary>
        [Fact]
        public async Task TestGetAsync_5() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = await _cache.GetAsync( "TestGetAsync_5", async () => {
                    data++;
                    return await Task.FromResult( data );
                } );
            }
            Assert.Equal( 1, result );
        }

        /// <summary>
        /// 测试从缓存中获取数据 - 设置1微秒过期
        /// </summary>
        [Fact]
        public async Task TestGetAsync_6() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = await _cache.GetAsync( "TestGetAsync_6", async () => {
                    data++;
                    return await Task.FromResult( data );
                }, new CacheOptions { Expiration = TimeSpan.FromMicroseconds( 1 ) } );
            }
            Assert.NotEqual( 1, result );
        }

        /// <summary>
        /// 测试从缓存中获取数据 - 设置缓存键对象
        /// </summary>
        [Fact]
        public async Task TestGetAsync_7() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = await _cache.GetAsync( new CacheKey( "TestGetAsync_7" ), async () => {
                    data++;
                    return await Task.FromResult( data );
                }, new CacheOptions { Expiration = TimeSpan.FromMicroseconds( 1 ) } );
            }
            Assert.NotEqual( 1, result );
        }

        #endregion
    }
}