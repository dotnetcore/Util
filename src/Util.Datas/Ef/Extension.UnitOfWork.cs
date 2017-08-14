using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Util.Datas.Ef {
    /// <summary>
    /// Ef工作单元扩展
    /// </summary>
    public static class Extension {
        /// <summary>
        /// 清空缓存
        /// </summary>
        public static void ClearCache(this IUnitOfWork unitOfWork) {
            var dbContext = unitOfWork as DbContext;
            dbContext?.ChangeTracker.Entries().ToList().ForEach( entry => entry.State = EntityState.Detached );
        }
    }
}
