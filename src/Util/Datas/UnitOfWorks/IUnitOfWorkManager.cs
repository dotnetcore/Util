using System.Threading.Tasks;
using Util.Dependency;

namespace Util.Datas.UnitOfWorks {
    /// <summary>
    /// 工作单元管理器
    /// </summary>
    public interface IUnitOfWorkManager : IScopeDependency {
        /// <summary>
        /// 提交
        /// </summary>
        void Commit();
        /// <summary>
        /// 提交
        /// </summary>
        Task CommitAsync();
        /// <summary>
        /// 注册工作单元
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        void Register( IUnitOfWork unitOfWork );
    }
}
