using System.Threading.Tasks;
using Util.Domains;

namespace Util.Datas.Stores.Operations {
    /// <summary>
    /// 通过标识判断是否存在
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IExistsAsync<TEntity, in TKey> where TEntity : class, IKey<TKey> {
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="ids">标识列表</param>
        Task<bool> ExistsAsync( params TKey[] ids );
    }
}