using System;
using EasyCaching.InMemory;
using Microsoft.Extensions.DependencyInjection;
using Util.Caches;
using Util.Caches.EasyCaching;
using Util.Locks.Default;

namespace Util.Tests.Locks {
    /// <summary>
    /// 业务锁测试服务
    /// </summary>
    public class LockTestService {
        /// <summary>
        /// 业务锁
        /// </summary>
        private readonly DefaultLock _lock;

        /// <summary>
        /// 初始化业务锁测试服务
        /// </summary>
        public LockTestService() {
            var services = new ServiceCollection();
            services.AddEasyCaching();
            services.AddDefaultInMemoryCache();
            var serviceProvider = services.BuildServiceProvider();
            var cache = serviceProvider.GetService<ICache>();
            _lock = new DefaultLock( cache );
        }

        /// <summary>
        /// 执行
        /// </summary>
        public string Execute( string key, TimeSpan? expiration = null ) {
            var result = _lock.Lock( key, expiration );
            return result ? "ok" : "fail";
        }

        /// <summary>
        /// 解锁
        /// </summary>
        public void UnLock() {
            _lock.UnLock();
        }
    }
}
