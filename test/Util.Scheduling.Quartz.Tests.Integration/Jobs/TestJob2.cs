using System.Threading.Tasks;
using Util.Tests.Fakes;
using Util.Tests.Repositories;
using Util.Tests.UnitOfWorks;

namespace Util.Scheduling.Quartz.Tests.Jobs {
    /// <summary>
    /// 后台任务1
    /// </summary>
    public class TestJob2 : JobBase {
        /// <inheritdoc />
        protected override void ConfigDetail( IJobInfo job ) {
            job.Name( "test2" );
        }

        /// <inheritdoc />
        protected override void ConfigTrigger( IJobTrigger trigger ) {
            trigger.Name( "test2" ).RepeatCount( 2 ).IntervalInSeconds( 1 );
        }

        /// <inheritdoc />
        protected override async Task Execute( QuartzExecutionContext context ) {
            var unitOfWork = context.GetService<ITestUnitOfWork>();
            var repository = context.GetService<ICustomerRepository>();
            var customer = CustomerFakeService.GetCustomer();
            customer.Name = "TestJob2";
            await repository.AddAsync( customer );
            await unitOfWork.CommitAsync();
        }
    }
}
