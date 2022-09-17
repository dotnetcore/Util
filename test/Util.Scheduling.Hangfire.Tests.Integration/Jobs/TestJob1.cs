using System;
using System.Threading.Tasks;
using Util.Tests.Fakes;
using Util.Tests.Repositories;
using Util.Tests.UnitOfWorks;

namespace Util.Scheduling.Hangfire.Tests.Jobs {
    /// <summary>
    /// 后台任务1
    /// </summary>
    public class TestJob1 : JobBase {
        /// <inheritdoc />
        protected override void ConfigTrigger( IJobTrigger trigger ) {
            trigger.Delay( TimeSpan.FromSeconds( 1 ) );
        }

        /// <inheritdoc />
        protected override async Task Execute( HangfireExecutionContext context ) {
            var unitOfWork = context.GetService<ITestUnitOfWork>();
            var repository = context.GetService<ICustomerRepository>();
            var customer = CustomerFakeService.GetCustomer();
            customer.Name = "TestJob1";
            await repository.AddAsync( customer );
            await unitOfWork.CommitAsync();
        }
    }
}
