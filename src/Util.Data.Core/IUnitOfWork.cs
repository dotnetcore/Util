using System;
using System.Threading.Tasks;
using Util.Data.Filters;

namespace Util.Data {
    /// <summary>
    /// 工作单元
    /// </summary>
    [Util.Aop.Ignore]
    public interface IUnitOfWork : IDisposable, IFilterOperation {
        /// <summary>
        /// 提交,返回影响的行数
        /// </summary>
        Task<int> CommitAsync();
    }
}
