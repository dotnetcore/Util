using System;
using System.Threading.Tasks;
using Quartz;
using Util.Dependency;
using Util.Samples.Schedulers.Services;
using Util.Schedulers.Quartz;

namespace Util.Samples.Schedulers.Jobs {
    /// <summary>
    /// 测试作业1 - 请使用 scope 参数创建实例，不要使用 Ioc.Create 方法，可能导致生命周期错误
    /// </summary>
    public class TestJob1 : JobBase {
        /// <summary>
        /// 执行
        /// </summary>
        protected override async Task Execute( IJobExecutionContext context, IScope scope ) {
            try {
                var service = scope.Create<ITestService1>();
                await service.HelloAsync();
            }
            catch( Exception ex ) {
                Console.WriteLine( ex );
            }
        }

        /// <summary>
        /// 获取重复执行间隔时间，单位：秒
        /// </summary>
        public override int? GetIntervalInSeconds() {
            return 5;
        }
    }
}
