using Util.Data;

namespace Util.Tests.Infrastructure {
    /// <summary>
    /// 测试基类
    /// </summary>
    public abstract class TestBase {
        /// <summary>
        /// 测试初始化
        /// </summary>
        protected TestBase( IUnitOfWork unitOfWork ) {
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        protected IUnitOfWork UnitOfWork {
            get;
        }
    }
}