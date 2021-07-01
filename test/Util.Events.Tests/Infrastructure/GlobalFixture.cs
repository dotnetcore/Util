using System;
using Util.Helpers;
using Util.Infrastructure;

namespace Util.Events.Tests.Infrastructure {
    /// <summary>
    /// 全局测试装置
    /// </summary>
    public class GlobalFixture : IDisposable {
        /// <summary>
        /// 全局测试初始化
        /// </summary>
        public GlobalFixture() {
            var bootstrapper = new Bootstrapper( Ioc.GetServices() );
            bootstrapper.Start();
        }

        /// <summary>
        /// 全局测试清理
        /// </summary>
        public void Dispose() {
        }
    }
}
