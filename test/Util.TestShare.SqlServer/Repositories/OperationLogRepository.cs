using Util.Data.EntityFrameworkCore;
using Util.Tests.Models;
using Util.Tests.UnitOfWorks;

namespace Util.Tests.Repositories {
    /// <summary>
    /// 操作日志仓储
    /// </summary>
    public class OperationLogRepository : RepositoryBase<OperationLog,long>,IOperationLogRepository {
        /// <summary>
        /// 初始化操作日志仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public OperationLogRepository( ITestUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}