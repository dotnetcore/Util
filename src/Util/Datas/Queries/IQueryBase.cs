using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Datas.Queries {
    /// <summary>
    /// 查询对象
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IQueryBase<TEntity> : ICriteria<TEntity> where TEntity : class, IAggregateRoot {
        /// <summary>
        /// 获取排序
        /// </summary>
        string GetOrderBy();
        /// <summary>
        /// 获取分页参数
        /// </summary>
        IPager GetPager();
    }
}
