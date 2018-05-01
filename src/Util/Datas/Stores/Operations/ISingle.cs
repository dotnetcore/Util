using System;
using System.Linq.Expressions;
using Util.Domains;

namespace Util.Datas.Stores.Operations {
    /// <summary>
    /// 查找单个实体
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface ISingle<TEntity, in TKey> where TEntity : class, IKey<TKey> {
        /// <summary>
        /// 查找单个实体
        /// </summary>
        /// <param name="predicate">条件</param>
        TEntity Single( Expression<Func<TEntity, bool>> predicate );
    }
}