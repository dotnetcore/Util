using Util.Data.EntityFrameworkCore.Models;
using Util.Domain.Repositories;

namespace Util.Data.EntityFrameworkCore.Repositories {
    /// <summary>
    /// 操作日志仓储
    /// </summary>
    public interface IOperationLogRepository : IRepository<OperationLog,long> {
    }
}