using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Util.Data.EntityFrameworkCore.Trees;
using Util.Tests.Models;
using Util.Tests.UnitOfWorks;

namespace Util.Tests.Repositories {
    /// <summary>
    /// 资源仓储
    /// </summary>
    public class ResourceRepository : TreeRepositoryBase<Resource>,IResourceRepository {
        /// <summary>
        /// 初始化资源仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ResourceRepository( ITestUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="parentId">父标识</param>
        public async Task<int> GenerateSortIdAsync( Guid? parentId ) {
            var maxSortId = await Find( t => t.ParentId == parentId ).MaxAsync( t => t.SortId );
            return maxSortId.SafeValue() + 1;
        }
    }
}