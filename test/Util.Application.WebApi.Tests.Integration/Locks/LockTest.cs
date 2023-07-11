using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Caching;
using Util.Helpers;
using Xunit;

namespace Util.Applications.Locks {
    /// <summary>
    /// 业务锁测试
    /// </summary>
    public class LockTest : IDisposable {
        /// <summary>
        /// 业务锁测试服务
        /// </summary>
        private readonly LockTestService _service;
        /// <summary>
        /// 缓存
        /// </summary>
        private readonly ICache _cache;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public LockTest( LockTestService service, ICache cache) {
            _service = service;
            _cache = cache;
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Time.Reset();
            _service.UnLockAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 执行一个服务
        /// </summary>
        [Fact]
        public async Task Test_1() {
            Assert.Equal( "ok",await _service.ExecuteAsync( "lock:Test_1" ) );
        }

        /// <summary>
        /// 测试解锁
        /// </summary>
        [Fact]
        public async Task Test_2() {
            var key = "lock:Test_2";
            await _cache.RemoveAsync( key );

            //执行，被锁定
            await _service.ExecuteAsync( key );

            //未解锁，无法执行
            var result = new List<string>();
            await Util.Helpers.Thread.ParallelForAsync( async () => result.Add( await _service.ExecuteAsync( key ) ), 20 );
            Assert.Empty( result.FindAll( t => t == "ok" ) );

            //解锁
            await _service.UnLockAsync();

            //再次执行
            await Util.Helpers.Thread.ParallelForAsync( async () => result.Add( await _service.ExecuteAsync( key ) ), 20 );
            Assert.Single( result.FindAll( t => t == "ok" ));
        }

        /// <summary>
        /// 延迟1秒才允许执行 - 设置延迟时间后，UnLock无效
        /// </summary>
        [Fact]
        public async Task Test_3() {
            var key = "lock:Test_3";
            Assert.Equal( "ok", await _service.ExecuteAsync( key, TimeSpan.FromSeconds( 1 ) ) );
            await _service.UnLockAsync();
            Assert.Equal( "fail",await _service.ExecuteAsync( key ) );
            await Task.Delay( 1500 );
            Assert.Equal( "ok",await _service.ExecuteAsync( key ) );
        }
    }
}
