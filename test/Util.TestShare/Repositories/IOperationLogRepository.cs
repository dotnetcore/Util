using Util.Domain.Repositories;
using Util.Tests.Models;

namespace Util.Tests.Repositories {
    /// <summary>
    /// 操作日志仓储
    /// </summary>
    public interface IOperationLogRepository : IRepository<OperationLog,long> {
    }
}