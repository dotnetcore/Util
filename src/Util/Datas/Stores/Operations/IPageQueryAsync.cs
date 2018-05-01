using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Datas.Stores.Operations {
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IPageQueryAsync<TEntity, in TKey> where TEntity : class, IKey<TKey> {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        Task<List<TEntity>> QueryAsync( IQueryBase<TEntity> query );
        /// <summary>
        /// 查询，不跟踪实体
        /// </summary>
        /// <param name="query">查询对象</param>
        Task<List<TEntity>> QueryAsNoTrackingAsync( IQueryBase<TEntity> query );
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        Task<PagerList<TEntity>> PagerQueryAsync( IQueryBase<TEntity> query );
        /// <summary>
        /// 分页查询，不跟踪实体
        /// </summary>
        /// <param name="query">查询对象</param>
        Task<PagerList<TEntity>> PagerQueryAsNoTrackingAsync( IQueryBase<TEntity> query );
    }
}