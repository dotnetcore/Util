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
            await scheduler.AddJobAsync<TestJob>();
            await scheduler.StartAsync();
        }
    }

    /// <summary>
    /// 测试作业
    /// </summary>
    public class TestJob : JobBase {
        /// <summary>
        /// 执行
        /// </summary>
        protected override async Task Execute( IJobExecutionContext context, IScope scope ) {
            try {
                var service = scope.Create<ITestService>();
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
            return 2;
        }
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    public interface ITestService : IDisposable, IScopeDependency {
        Task HelloAsync();
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService : ITestService {
        public async Task HelloAsync() {
            await Console.Out.WriteLineAsync( "Hello" );
        }
        public void Dispose() {
            Console.WriteLine( "TestService释放了" );
        }
    }
}
