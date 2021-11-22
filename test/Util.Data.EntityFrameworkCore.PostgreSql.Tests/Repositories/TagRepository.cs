using Util.Data.EntityFrameworkCore.Models;
using Util.Data.EntityFrameworkCore.UnitOfWorks;

namespace Util.Data.EntityFrameworkCore.Repositories {
    /// <summary>
    /// 标签仓储
    /// </summary>
    public class TagRepository : RepositoryBase<Tag>,ITagRepository {
        /// <summary>
        /// 初始化标签仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public TagRepository( IPgSqlUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}