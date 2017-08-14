using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Util.Datas.Persistence {
    /// <summary>
    /// 持久化存储
    /// </summary>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    public interface IPersistentStore<TPo> : IPersistentStore<TPo, Guid> where TPo : class, IPersistentObject<Guid> {
    }

    /// <summary>
    /// 持久化存储
    /// </summary>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    /// <typeparam name="TKey">持久化对象标识类型</typeparam>
    public interface IPersistentStore<TPo, in TKey> where TPo : class, IPersistentObject<TKey> {
        /// <summary>
        /// 查找持久化对象集合
        /// </summary>
        IQueryable<TPo> Find();
        /// <summary>
        /// 查找持久化对象
        /// </summary>
        /// <param name="id">持久化对象标识</param>
        TPo Find( object id );
        /// <summary>
        /// 查找持久化对象
        /// </summary>
        /// <param name="id">持久化对象标识</param>
        Task<TPo> FindAsync( object id );
        /// <summary>
        /// 获取单个持久化对象
        /// </summary>
        /// <param name="predicate">查询条件</param>
        TPo Single( Expression<Func<TPo, bool>> predicate );
        /// <summary>
        /// 获取单个持久化对象
        /// </summary>
        /// <param name="predicate">查询条件</param>
        Task<TPo> SingleAsync( Expression<Func<TPo, bool>> predicate );
        /// <summary>
        /// 添加持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        void Add( TPo po );
        /// <summary>
        /// 添加持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        Task AddAsync( TPo po );
        /// <summary>
        /// 修改持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        void Update( TPo po );
        /// <summary>
        /// 修改持久化对象
        /// </summary>
        /// <param name="newPo">新持久化对象</param>
        /// <param name="oldPo">旧持久化对象</param>
        void Update( TPo newPo, TPo oldPo );
    }
}
