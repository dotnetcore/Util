using Util.Data.EntityFrameworkCore.Models;
using Util.Domain.Repositories;

namespace Util.Data.EntityFrameworkCore.Repositories {
    /// <summary>
    /// 贴子仓储
    /// </summary>
    public interface IPostRepository : IRepository<Post> {
    }
}