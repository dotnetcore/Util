using Util.Data.EntityFrameworkCore.Models;
using Util.Domain.Repositories;

namespace Util.Data.EntityFrameworkCore.Repositories {
    /// <summary>
    /// 标签仓储
    /// </summary>
    public interface ITagRepository : IRepository<Tag> {
    }
}