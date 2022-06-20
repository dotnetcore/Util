using System.Threading.Tasks;
using Util.Domain.Events;
using Util.Events;
using Util.Tests.Models;
using Util.Tests.Repositories;
using Util.Tests.UnitOfWorks;

namespace Util.Tests.EventHandlers {
    /// <summary>
    /// 产品创建事件处理器
    /// </summary>
    public class ProductCreatedEventHandler : EventHandlerBase<EntityCreatedEvent<Product>> {
        /// <summary>
        /// 工作单元
        /// </summary>
        private readonly ITestUnitOfWork _unitOfWork;
        /// <summary>
        /// 操作日志仓储
        /// </summary>
        private readonly IOperationLogRepository _operationLogRepository;

        /// <summary>
        /// 初始化产品创建事件处理器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="operationLogRepository">操作日志仓储</param>
        public ProductCreatedEventHandler( ITestUnitOfWork unitOfWork, IOperationLogRepository operationLogRepository ) {
            _unitOfWork = unitOfWork;
            _operationLogRepository = operationLogRepository;
        }

        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        public override async Task HandleAsync( EntityCreatedEvent<Product> @event ) {
            if( @event.Entity.Name != "EntityCreatedEvent" )
                return;
            var log = new OperationLog { Caption = @event.Entity.Name,LogName = nameof( ProductCreatedEventHandler ) };
            await _operationLogRepository.AddAsync( log );
            await _unitOfWork.CommitAsync();
        }
    }
}
