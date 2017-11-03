using System;
using System.Threading.Tasks;
using Util.Aspects;
using Util.Dependency;

namespace Util.Datas.UnitOfWorks {
    /// <summary>
    /// 工作单元
    /// </summary>
    [Ignore]
    public interface IUnitOfWork : IDisposable,IScopeDependency {
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
