using System.Threading.Tasks;
using System;
using Util.Domain.Trees;
using Util.Tests.Models;

namespace Util.Tests.Repositories {
    /// <summary>
    /// 资源仓储
    /// </summary>
    public interface IResourceRepository : ITreeRepository<Resource> {
        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="parentId">父标识</param>
        Task<int> GenerateSortIdAsync( Guid? parentId );
    }
}