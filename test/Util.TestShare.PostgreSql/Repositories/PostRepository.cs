using Util.Data.EntityFrameworkCore;
using Util.Tests.Models;
using Util.Tests.UnitOfWorks;

namespace Util.Tests.Repositories {
    /// <summary>
    /// 贴子仓储
    /// </summary>
    public class PostRepository : RepositoryBase<Post>,IPostRepository {
        /// <summary>
        /// 初始化贴子仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public PostRepository( ITestUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}