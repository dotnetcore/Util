using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Util.Caching.EasyCaching.Tests {
    /// <summary>
    /// EasyCaching内存缓存服务测试
    /// </summary>
    public class MemoryCacheManagerTest {

        #region 测试初始化

        /// <summary>
        /// 缓存服务
        /// </summary>
        private readonly ILocalCache _cache;

        /// <summary>
        /// 测试初始化
        /// </summary>
        /// <param name="cache">缓存服务</param>
        public MemoryCacheManagerTest( ILocalCache cache ) {
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
            var key = "TestGet_1";
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
            var result = _cache.Get<int?>( new []{ key , key2 } );
            Assert.Equal( 1,result[0] );
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
            var key = "TestGetAsync_1";
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

        #region GetByPrefix

        /// <summary>
        /// 测试通过缓存键前缀获取数据
        /// </summary>
        [Fact]
        public void TestGetByPrefix_1() {
            //变量定义
            var key = "TestGetByPrefix_11";
            var key2 = "TestGetByPrefix_12";

            //设置缓存
            _cache.Set( key, 1 );
            _cache.Set( key2, 2 );

            //验证
            var result = _cache.GetByPrefix<int?>( "TestGetByPrefix_1" ).OrderBy( t => t ).ToList();
            Assert.Equal( 1, result[0] );
            Assert.Equal( 2, result[1] );
        }

        #endregion

        #region GetByPrefixAsync

        /// <summary>
        /// 测试通过缓存键前缀获取数据
        /// </summary>
        [Fact]
        public async Task TestGetByPrefixAsync_1() {
            //变量定义
            var key = "abc:TestGetByPrefixAsync_11";
            var key2 = "abc:TestGetByPrefixAsync_12";

            //设置缓存
            await _cache.SetAsync( key, 1 );
            await _cache.SetAsync( key2, 2 );

            //验证
            var result = (await _cache.GetByPrefixAsync<int?>( "abc:" )).OrderBy( t => t ).ToList();
            Assert.Equal( 1, result[0] );
            Assert.Equal( 2, result[1] );
        }

        #endregion

        #region TrySet

        /// <summary>
        /// 测试设置缓存
        /// </summary>
        [Fact]
        public void TestTrySet_1() {
            //变量定义
            var key = "TestTrySet_1";
            var value = 1;

            //获取缓存,结果为空
            var result = _cache.Get<int?>( key );
            Assert.Null( result );

            //设置缓存1
            _cache.TrySet( key, value );
            result = _cache.Get<int?>( key );
            Assert.Equal( value, result );

            //设置缓存2,无效
            _cache.TrySet( key, 2 );
            result = _cache.Get<int?>( key );
            Assert.Equal( value, result );
        }

        /// <summary>
        /// 测试设置缓存 - 设置缓存键对象
        /// </summary>
        [Fact]
        public void TestTrySet_2() {
            //变量定义
            var key = new CacheKey( "TestTrySet_2" );
            var value = 1;

            //获取缓存,结果为空
            var result = _cache.Get<int?>( key );
            Assert.Null( result );

            //设置缓存1
            _cache.TrySet( key, value );
            result = _cache.Get<int?>( key );
            Assert.Equal( value, result );

            //设置缓存2,无效
            _cache.TrySet( key, 2 );
            result = _cache.Get<int?>( key );
            Assert.Equal( value, result );
        }

        #endregion

        #region TrySetAsync

        /// <summary>
        /// 测试设置缓存
        /// </summary>
        [Fact]
        public async Task TestTrySetAsync_1() {
            //变量定义
            var key = "TestTrySetAsync_1";
            var value = 1;

            //获取缓存,结果为空
            var result = await _cache.GetAsync<int?>( key );
            Assert.Null( result );

            //设置缓存1
            await _cache.TrySetAsync( key, value );
            result = await _cache.GetAsync<int?>( key );
            Assert.Equal( value, result );

            //设置缓存2,无效
            await _cache.TrySetAsync( key, 2 );
            result = await _cache.GetAsync<int?>( key );
            Assert.Equal( value, result );
        }

        /// <summary>
        /// 测试设置缓存 - 设置缓存键对象
        /// </summary>
        [Fact]
        public async Task TestTrySetAsync_2() {
            //变量定义
            var key = new CacheKey( "TestTrySetAsync_2" );
            var value = 1;

            //获取缓存,结果为空
            var result = await _cache.GetAsync<int?>( key );
            Assert.Null( result );

            //设置缓存1
            await _cache.TrySetAsync( key, value );
            result = await _cache.GetAsync<int?>( key );
            Assert.Equal( value, result );

            //设置缓存2,无效
            await _cache.TrySetAsync( key, 2 );
            result = await _cache.GetAsync<int?>( key );
            Assert.Equal( value, result );
        }

        #endregion

        #region Set

        /// <summary>
        /// 测试设置缓存
        /// </summary>
        [Fact]
        public void TestSet_1() {
            //变量定义
            var key = "TestSet_1";

            //获取缓存,结果为空
            var result = _cache.Get<int?>( key );
            Assert.Null( result );

            //设置缓存1
            _cache.Set( key, 1 );
            result = _cache.Get<int?>( key );
            Assert.Equal( 1, result );

            //设置缓存2,覆盖
            _cache.Set( key, 2 );
            result = _cache.Get<int?>( key );
            Assert.Equal( 2, result );
        }

        /// <summary>
        /// 测试设置缓存- 设置缓存键对象
        /// </summary>
        [Fact]
        public void TestSet_2() {
            //变量定义
            var key = new CacheKey( "TestSet_2" );

            //获取缓存,结果为空
            var result = _cache.Get<int?>( key );
            Assert.Null( result );

            //设置缓存1
            _cache.Set( key, 1 );
            result = _cache.Get<int?>( key );
            Assert.Equal( 1, result );

            //设置缓存2,覆盖
            _cache.Set( key, 2 );
            result = _cache.Get<int?>( key );
            Assert.Equal( 2, result );
        }

        /// <summary>
        /// 测试设置缓存 - 设置集合
        /// </summary>
        [Fact]
        public void TestSet_3() {
            //变量定义
            var key = "TestSet_31";
            var key2 = "TestSet_32";

            //设置缓存
            _cache.Set( new Dictionary<string,int>{{key,1}, { key2, 2 } } );

            //验证
            Assert.Equal( 1, _cache.Get<int>( key ) );
            Assert.Equal( 2, _cache.Get<int>( key2 ) );
        }

        /// <summary>
        /// 测试设置缓存 - 设置集合,设置缓存键对象
        /// </summary>
        [Fact]
        public void TestSet_4() {
            //变量定义
            var key = new CacheKey( "TestSet_41" );
            var key2 = new CacheKey( "TestSet_42" );

            //设置缓存
            _cache.Set( new Dictionary<CacheKey, int> { { key, 1 }, { key2, 2 } } );

            //验证
            Assert.Equal( 1, _cache.Get<int>( key ) );
            Assert.Equal( 2, _cache.Get<int>( key2 ) );
        }

        #endregion

        #region SetAsync

        /// <summary>
        /// 测试设置缓存
        /// </summary>
        [Fact]
        public async Task TestSetAsync_1() {
            //变量定义
            var key = "TestSetAsync_1";

            //获取缓存,结果为空
            var result = await _cache.GetAsync<int?>( key );
            Assert.Null( result );

            //设置缓存1
            await _cache.SetAsync( key, 1 );
            result = await _cache.GetAsync<int?>( key );
            Assert.Equal( 1, result );

            //设置缓存2,覆盖
            await _cache.SetAsync( key, 2 );
            result = await _cache.GetAsync<int?>( key );
            Assert.Equal( 2, result );
        }

        /// <summary>
        /// 测试设置缓存 - 设置缓存键对象
        /// </summary>
        [Fact]
        public async Task TestSetAsync_2() {
            //变量定义
            var key = new CacheKey( "TestSetAsync_2" );

            //获取缓存,结果为空
            var result = await _cache.GetAsync<int?>( key );
            Assert.Null( result );

            //设置缓存1
            await _cache.SetAsync( key, 1 );
            result = await _cache.GetAsync<int?>( key );
            Assert.Equal( 1, result );

            //设置缓存2,覆盖
            await _cache.SetAsync( key, 2 );
            result = await _cache.GetAsync<int?>( key );
            Assert.Equal( 2, result );
        }

        /// <summary>
        /// 测试设置缓存 - 设置集合
        /// </summary>
        [Fact]
        public async Task TestSetAsync_3() {
            //变量定义
            var key = "TestSetAsync_31";
            var key2 = "TestSetAsync_32";

            //设置缓存
            await _cache.SetAsync( new Dictionary<string, int> { { key, 1 }, { key2, 2 } } );

            //验证
            Assert.Equal( 1, await _cache.GetAsync<int>( key ) );
            Assert.Equal( 2, await _cache.GetAsync<int>( key2 ) );
        }

        /// <summary>
        /// 测试设置缓存 - 设置集合,设置缓存键对象
        /// </summary>
        [Fact]
        public async Task TestSetAsync_4() {
            //变量定义
            var key = new CacheKey( "TestSetAsync_41" );
            var key2 = new CacheKey( "TestSetAsync_42" );

            //设置缓存
            await _cache.SetAsync( new Dictionary<CacheKey, int> { { key, 1 }, { key2, 2 } } );

            //验证
            Assert.Equal( 1, await _cache.GetAsync<int>( key ) );
            Assert.Equal( 2, await _cache.GetAsync<int>( key2 ) );
        }

        #endregion

        #region Exists

        /// <summary>
        /// 测试缓存是否已存在
        /// </summary>
        [Fact]
        public void TestExists_1() {
            //变量定义
            var key = "TestExists_1";

            //缓存不存在
            Assert.False( _cache.Exists( key ) );

            //设置缓存
            _cache.Set( key, 1 );

            //验证
            Assert.True( _cache.Exists( key ) );
        }

        /// <summary>
        /// 测试缓存是否已存在- 设置缓存键对象
        /// </summary>
        [Fact]
        public void TestExists_2() {
            //变量定义
            var key = new CacheKey( "TestExists_2" );

            //缓存不存在
            Assert.False( _cache.Exists( key ) );

            //设置缓存
            _cache.Set( key, 1 );

            //验证
            Assert.True( _cache.Exists( key ) );
        }

        #endregion

        #region ExistsAsync

        /// <summary>
        /// 测试缓存是否已存在
        /// </summary>
        [Fact]
        public async Task TestExistsAsync_1() {
            //变量定义
            var key = "TestExistsAsync_1";

            //缓存不存在
            Assert.False( await _cache.ExistsAsync( key ) );

            //设置缓存
            await _cache.SetAsync( key, 1 );

            //验证
            Assert.True( await _cache.ExistsAsync( key ) );
        }

        /// <summary>
        /// 测试缓存是否已存在 - 设置缓存键对象
        /// </summary>
        [Fact]
        public async Task TestExistsAsync_2() {
            //变量定义
            var key = new CacheKey( "TestExistsAsync_2" );

            //缓存不存在
            Assert.False( await _cache.ExistsAsync( key ) );

            //设置缓存
            await _cache.SetAsync( key, 1 );

            //验证
            Assert.True( await _cache.ExistsAsync( key ) );
        }

        #endregion

        #region Remove

        /// <summary>
        /// 测试移除缓存
        /// </summary>
        [Fact]
        public void TestRemove_1() {
            //变量定义
            var key = "TestRemove_1";

            //设置缓存
            _cache.Set( key, 1 );
            Assert.True( _cache.Exists( key ) );

            //移除缓存
            _cache.Remove( key );

            //验证
            Assert.False( _cache.Exists( key ) );
        }

        /// <summary>
        /// 测试移除缓存 - 设置缓存键对象
        /// </summary>
        [Fact]
        public void TestRemove_2() {
            //变量定义
            var key = new CacheKey( "TestRemove_2" );

            //设置缓存
            _cache.Set( key, 1 );
            Assert.True( _cache.Exists( key ) );

            //移除缓存
            _cache.Remove( key );

            //验证
            Assert.False( _cache.Exists( key ) );
        }

        /// <summary>
        /// 测试移除缓存集合
        /// </summary>
        [Fact]
        public void TestRemove_3() {
            //变量定义
            var key = "TestRemove_31";
            var key2 = "TestRemove_32";

            //设置缓存
            _cache.Set( key, 1 );
            _cache.Set( key2, 2 );

            //移除缓存
            _cache.Remove( new[] { key, key2 } );

            //验证
            Assert.False( _cache.Exists( key ) );
            Assert.False( _cache.Exists( key2 ) );
        }

        /// <summary>
        /// 测试移除缓存集合 - 设置缓存键对象
        /// </summary>
        [Fact]
        public void TestRemove_4() {
            //变量定义
            var key = new CacheKey( "TestRemove_41" );
            var key2 = new CacheKey( "TestRemove_42" );

            //设置缓存
            _cache.Set( key, 1 );
            _cache.Set( key2, 2 );

            //移除缓存
            _cache.Remove( new[] { key, key2 } );

            //验证
            Assert.False( _cache.Exists( key ) );
            Assert.False( _cache.Exists( key2 ) );
        }

        #endregion

        #region RemoveAsync

        /// <summary>
        /// 测试移除缓存
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_1() {
            //变量定义
            var key = "TestRemoveAsync_1";

            //设置缓存
            await _cache.SetAsync( key, 1 );
            Assert.True( await _cache.ExistsAsync( key ) );

            //移除缓存
            await _cache.RemoveAsync( key );

            //验证
            Assert.False( await _cache.ExistsAsync( key ) );
        }

        /// <summary>
        /// 测试移除缓存 - 设置缓存键对象
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_2() {
            //变量定义
            var key = new CacheKey( "TestRemoveAsync_2" );

            //设置缓存
            await _cache.SetAsync( key, 1 );
            Assert.True( await _cache.ExistsAsync( key ) );

            //移除缓存
            await _cache.RemoveAsync( key );

            //验证
            Assert.False( await _cache.ExistsAsync( key ) );
        }

        /// <summary>
        /// 测试移除缓存集合
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_3() {
            //变量定义
            var key = "TestRemoveAsync_31";
            var key2 = "TestRemoveAsync_32";

            //设置缓存
            await _cache.SetAsync( key, 1 );
            await _cache.SetAsync( key2, 2 );

            //移除缓存
            await _cache.RemoveAsync( new[] { key, key2 } );

            //验证
            Assert.False( await _cache.ExistsAsync( key ) );
            Assert.False( await _cache.ExistsAsync( key2 ) );
        }

        /// <summary>
        /// 测试移除缓存集合 - 设置缓存键对象
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_4() {
            //变量定义
            var key = new CacheKey( "TestRemoveAsync_41" );
            var key2 = new CacheKey( "TestRemoveAsync_42" );

            //设置缓存
            await _cache.SetAsync( key, 1 );
            await _cache.SetAsync( key2, 2 );

            //移除缓存
            await _cache.RemoveAsync( new[] { key, key2 } );

            //验证
            Assert.False( await _cache.ExistsAsync( key ) );
            Assert.False( await _cache.ExistsAsync( key2 ) );
        }

        #endregion

        #region RemoveByPrefix

        /// <summary>
        /// 测试通过缓存键前缀移除缓存
        /// </summary>
        [Fact]
        public void RemoveByPrefix_1() {
            //变量定义
            var key = "RemoveByPrefix_11";
            var key2 = "RemoveByPrefix_12";

            //设置缓存
            _cache.Set( key, 1 );
            _cache.Set( key2, 2 );

            //验证
            Assert.True( _cache.Exists( key ) );
            Assert.True( _cache.Exists( key2 ) );

            //移除缓存
            _cache.RemoveByPrefix( "RemoveByPrefix" );

            //验证
            Assert.False( _cache.Exists( key ) );
            Assert.False( _cache.Exists( key2 ) );
        }

        #endregion

        #region RemoveByPrefixAsync

        /// <summary>
        /// 测试通过缓存键前缀移除缓存
        /// </summary>
        [Fact]
        public async Task RemoveByPrefixAsync_1() {
            //变量定义
            var key = "RemoveByPrefixAsync_11";
            var key2 = "RemoveByPrefixAsync_12";

            //设置缓存
            await _cache.SetAsync( key, 1 );
            await _cache.SetAsync( key2, 2 );

            //移除缓存
            await _cache.RemoveByPrefixAsync( "RemoveByPrefix" );

            //验证
            Assert.False( await _cache.ExistsAsync( key ) );
            Assert.False( await _cache.ExistsAsync( key2 ) );
        }

        #endregion

        #region RemoveByPattern

        /// <summary>
        /// 测试通过缓存键模式移除缓存
        /// </summary>
        [Fact]
        public void RemoveByPattern() {
            //变量定义
            var key = "RemoveByPattern_1";
            var key2 = "RemoveByPattern_2";

            //设置缓存
            _cache.Set( key, 1 );
            _cache.Set( key2, 2 );

            //移除缓存
            _cache.RemoveByPattern( "*2" );

            //验证
            Assert.True( _cache.Exists( key ) );
            Assert.False( _cache.Exists( key2 ) );
        }

        #endregion

        #region RemoveByPatternAsync

        /// <summary>
        /// 测试通过缓存键模式移除缓存
        /// </summary>
        [Fact]
        public async Task RemoveByPatternAsync() {
            //变量定义
            var key = "RemoveByPatternAsync_1";
            var key2 = "RemoveByPatternAsync_2";

            //设置缓存
            await _cache.SetAsync( key, 1 );
            await _cache.SetAsync( key2, 2 );

            //移除缓存
            await _cache.RemoveByPatternAsync( "*2" );

            //验证
            Assert.True( await _cache.ExistsAsync( key ) );
            Assert.False( await _cache.ExistsAsync( key2 ) );
        }

        #endregion

        #region Clear

        /// <summary>
        /// 测试清空缓存
        /// </summary>
        [Fact]
        public void TestClear() {
            //变量定义
            var key = "TestClear_1";
            var key2 = "TestClear_2";

            //设置缓存
            _cache.Set( key, 1 );
            _cache.Set( key2, 2 );

            //清空缓存
            _cache.Clear();

            //验证
            Assert.False( _cache.Exists( key ) );
            Assert.False( _cache.Exists( key2 ) );
        }

        #endregion

        #region ClearAsync

        /// <summary>
        /// 测试清空缓存
        /// </summary>
        [Fact]
        public async Task TestClearAsync() {
            //变量定义
            var key = "TestClear_1";
            var key2 = "TestClear_2";

            //设置缓存
            await _cache.SetAsync( key, 1 );
            await _cache.SetAsync( key2, 2 );

            //清空缓存
            await _cache.ClearAsync();

            //验证
            Assert.False( await _cache.ExistsAsync( key ) );
            Assert.False( await _cache.ExistsAsync( key2 ) );
        }

        #endregion
    }
}