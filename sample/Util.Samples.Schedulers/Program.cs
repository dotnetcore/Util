using System;
using System.Threading.Tasks;
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

            //手工添加任务
            //await scheduler.AddJobAsync<TestJob1>();
            //await scheduler.AddJobAsync<TestJob2>();

            //扫描添加任务
            await scheduler.ScanJobsAsync();

            //启动调度器
            await scheduler.StartAsync();
        }
    }
}
