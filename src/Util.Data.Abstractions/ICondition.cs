using System;
using System.Linq.Expressions;

namespace Util.Data {
    /// <summary>
    /// 查询条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface ICondition<TEntity> {
        /// <summary>
        /// 获取查询条件
        /// </summary>
        Expression<Func<TEntity, bool>> GetCondition();
    }
}
