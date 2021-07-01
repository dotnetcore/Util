using System;
using Util.Dependency;
using Util.Helpers;
using Util.Infrastructure;

namespace Util.Aop.AspectCore.Tests.Infrastructure {
    /// <summary>
    /// 全局测试装置
    /// </summary>
    public class GlobalFixture : IDisposable {
        /// <summary>
        /// 全局测试初始化
        /// </summary>
        public GlobalFixture() {
            var services = Ioc.GetServices();
            services.AddAop();
            var bootstrapper = new Bootstrapper( services );
            bootstrapper.Start();
        }

        /// <summary>
        /// 全局测试清理
        /// </summary>
        public void Dispose() {
        }
    }
}
