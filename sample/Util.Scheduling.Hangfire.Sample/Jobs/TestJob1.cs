using Util.Scheduling.Hangfire.Sample.Services;

namespace Util.Scheduling.Hangfire.Sample.Jobs {
    /// <summary>
    /// 测试任务1
    /// </summary>
    public class TestJob1 : JobBase {
        /// <inheritdoc />
        protected override void ConfigDetail( IJobInfo job ) {
        }

        /// <inheritdoc />
        protected override void ConfigTrigger( IJobTrigger trigger ) {
            trigger.Minutely();
        }

        /// <inheritdoc />
        protected override Task Execute( HangfireExecutionContext context ) {
            var log = context.GetService<ILogger<TestJob1>>();
            var service = context.GetService<ITestService>();
            log?.LogDebug( $"time:{DateTime.Now},id:{service.GetId()}");
            return Task.CompletedTask;
        }
    }
}
