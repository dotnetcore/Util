using System;
using System.Threading.Tasks;
using Util.Aspects;

namespace Util.Datas.UnitOfWorks {
    /// <summary>
    /// 工作单元
    /// </summary>
    [Ignore]
    public interface IUnitOfWork : IDisposable {
        /// <summary>
        /// 提交,返回影响的行数
        /// </summary>
        int Commit();
        /// <summary>
        /// 提交,返回影响的行数
        /// </summary>
        Task<int> CommitAsync();
    }
}
