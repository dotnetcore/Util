using System.Threading.Tasks;
using Util.Tests.Fakes;
using Util.Tests.Repositories;
using Util.Tests.UnitOfWorks;

namespace Util.Scheduling.Quartz.Tests.Jobs {
    /// <summary>
    /// 后台任务1
    /// </summary>
    public class TestJob1 : JobBase {
        /// <inheritdoc />
        protected override void ConfigDetail( IJobInfo job ) {
            job.Name( "test1" );
        }

        /// <inheritdoc />
        protected override void ConfigTrigger( IJobTrigger trigger ) {
            trigger.Name( "test1" ).RepeatCount( 1 ).IntervalInSeconds( 1 );
        }

        /// <inheritdoc />
        protected override async Task Execute( QuartzExecutionContext context ) {
            var unitOfWork = context.GetService<ITestUnitOfWork>();
            var repository = context.GetService<ICustomerRepository>();
            var customer = CustomerFakeService.GetCustomer();
            customer.Name = "TestJob1";
            await repository.AddAsync( customer );
            await unitOfWork.CommitAsync();
        }
    }
}
