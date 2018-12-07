using System;
using System.Threading.Tasks;
using Quartz;
using Util.Dependency;
using Util.Schedulers.Quartz;

namespace Util.Samples.Schedulers {
    public class Program {
        /// <summary>
        /// 入口
        /// </summary>
        public static void Main( string[] args ) {
            Console.WriteLine( "调度器测试启动" );
            Bootstrapper.Run();
            Run().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        /// <summary>
        /// 运行调度器
        /// </summary>
        private static async Task Run() {
            var scheduler = new Scheduler();
            await scheduler.AddJobAsync<TestJob1>();
            await scheduler.AddJobAsync<TestJob2>();
            await scheduler.StartAsync();
        }
    }

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
            catch ( Exception ex ) {
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

    /// <summary>
    /// 测试作业2
    /// </summary>
    public class TestJob2 : JobBase {
        /// <summary>
        /// 执行
        /// </summary>
        protected override async Task Execute( IJobExecutionContext context, IScope scope ) {
            try {
                var service = scope.Create<ITestService2>();
                await service.WorldAsync();
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

    /// <summary>
    /// 测试服务1 - 通过自动扫描IScopeDependency注册
    /// </summary>
    public interface ITestService1 : IDisposable,IScopeDependency {
        Task HelloAsync();
    }

    /// <summary>
    /// 测试服务1
    /// </summary>
    public class TestService1 : ITestService1 {
        public async Task HelloAsync() {
            await Console.Out.WriteLineAsync( "Hello" );
        }
        public void Dispose() {
            Console.WriteLine( "TestService-1释放了" );
        }
    }

    /// <summary>
    /// 测试服务2 - 通过在ServiceRegister手工注册
    /// </summary>
    public interface ITestService2 : IDisposable {
        Task WorldAsync();
    }

    /// <summary>
    /// 测试服务2
    /// </summary>
    public class TestService2 : ITestService2 {
        public async Task WorldAsync() {
            await Console.Out.WriteLineAsync( "World" );
        }
        public void Dispose() {
            Console.WriteLine( "TestService-2释放了" );
        }
    }
}
