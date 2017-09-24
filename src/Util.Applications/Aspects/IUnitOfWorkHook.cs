using Util.Datas.Ef.Aspects;

namespace Util.Applications.Aspects {
    /// <summary>
    /// 工作单元钩子
    /// </summary>
    public interface IUnitOfWorkHook {
        /// <summary>
        /// 提交工作单元
        /// </summary>
        [UnitOfWork]
        void Commit();
    }
}
