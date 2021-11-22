using Util.Data.EntityFrameworkCore.Models;
using Util.Data.EntityFrameworkCore.UnitOfWorks;

namespace Util.Data.EntityFrameworkCore.Repositories {
    /// <summary>
    /// 贴子仓储
    /// </summary>
    public class PostRepository : RepositoryBase<Post>,IPostRepository {
        /// <summary>
        /// 初始化贴子仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public PostRepository( IPgSqlUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}