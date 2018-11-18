using System;
using System.Threading.Tasks;
using Quartz;
using Util.Schedulers.Quartz;

namespace Util.Samples.Schedulers {
    public class Program {
        /// <summary>
        /// 入口
        /// </summary>
        public static void Main( string[] args ) {
            Console.WriteLine( "调度器测试启动" );
            Run().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        /// <summary>
        /// 运行调度器
        /// </summary>
        private static async Task Run() {
            var scheduler = new Scheduler();
            await scheduler.AddJobAsync<TestJob1>();
            await scheduler.StartAsync();
        }
    }

    /// <summary>
    /// 测试作业1 - 简单输出控制台消息
    /// </summary>
    public class TestJob1 : JobBase {
        /// <summary>
        /// 执行
        /// </summary>
        public override Task Execute( IJobExecutionContext context ) {
            Console.WriteLine("Hello" );
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取重复执行间隔时间，单位：秒
        /// </summary>
        public override int? GetIntervalInSeconds() {
            return 1;
        }
    }
}
