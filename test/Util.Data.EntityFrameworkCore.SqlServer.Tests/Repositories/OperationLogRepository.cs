using Util.Data.EntityFrameworkCore.Models;
using Util.Data.EntityFrameworkCore.UnitOfWorks;

namespace Util.Data.EntityFrameworkCore.Repositories {
    /// <summary>
    /// 操作日志仓储
    /// </summary>
    public class OperationLogRepository : RepositoryBase<OperationLog,long>,IOperationLogRepository {
        /// <summary>
        /// 初始化操作日志仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public OperationLogRepository( ISqlServerUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}