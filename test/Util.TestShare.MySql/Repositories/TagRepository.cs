using Util.Data.EntityFrameworkCore;
using Util.Tests.Models;
using Util.Tests.UnitOfWorks;

namespace Util.Tests.Repositories {
    /// <summary>
    /// 标签仓储
    /// </summary>
    public class TagRepository : RepositoryBase<Tag>,ITagRepository {
        /// <summary>
        /// 初始化标签仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public TagRepository( ITestUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}