using System.Threading.Tasks;
using Util.Data.EntityFrameworkCore.Models;
using Util.Data.EntityFrameworkCore.Repositories;
using Util.Data.EntityFrameworkCore.UnitOfWorks;
using Util.Domain.Events;
using Util.Events;

namespace Util.Data.EntityFrameworkCore.EventHandlers {
    /// <summary>
    /// 操作日志变更事件处理器
    /// </summary>
    public class OperationLogChangedEventHandler : EventHandlerBase<EntityChangedEvent<OperationLog>> {
        /// <summary>
        /// 工作单元
        /// </summary>
        private readonly ISqlServerUnitOfWork _unitOfWork;
        /// <summary>
        /// 操作日志仓储
        /// </summary>
        private readonly IOperationLogRepository _operationLogRepository;

        /// <summary>
        /// 初始化操作日志变更事件处理器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="operationLogRepository">操作日志仓储</param>
        public OperationLogChangedEventHandler( ISqlServerUnitOfWork unitOfWork, IOperationLogRepository operationLogRepository ) {
            _unitOfWork = unitOfWork;
            _operationLogRepository = operationLogRepository;
        }

        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        public override async Task HandleAsync( EntityChangedEvent<OperationLog> @event ) {
            if ( @event.ChangeType == EntityChangeType.Deleted && @event.Entity.LogName == "EntityChangedEvent_Deleted" ) {
                var log = new OperationLog { LogName = "Test", Caption = nameof( OperationLogChangedEventHandler ), Content = @event.Entity.LogName };
                await _operationLogRepository.AddAsync( log );
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
