
namespace Util.Scheduling.Hangfire.Sample.Jobs {
    /// <summary>
    /// 测试任务1
    /// </summary>
    public class TestJob1 : JobBase {

        public TestJob1() {
        }

        public TestJob1( string id ) {
            Data = id;
        }

        /// <inheritdoc />
        protected override void ConfigDetail( IJobInfo job ) {
            job.Id( "abc" );
        }

        /// <inheritdoc />
        protected override void ConfigTrigger( IJobTrigger trigger ) {
            trigger.Minutely();
        }

        /// <inheritdoc />
        protected override Task Execute( HangfireExecutionContext context ) {
            var log = context.GetService<ILogger<TestJob1>>();
            var id = context.GetData<string>();
            log?.LogDebug( $"time:{DateTime.Now},id:{id}");
            return Task.CompletedTask;
        }
    }
}
