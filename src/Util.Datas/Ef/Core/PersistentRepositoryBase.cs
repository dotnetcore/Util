using System.Threading.Tasks;
using Util.Datas.Persistence;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Datas.Ef.Core {
    /// <summary>
    /// 仓储 - 配合持久化对象
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class PersistentRepositoryBase<TEntity, TPo, TKey> : ICompactRepository<TEntity, TKey>
        where TEntity : class, IAggregateRoot
        where TPo : class,IPersistentObject<TKey> {
        /// <summary>
        /// 持久化存储
        /// </summary>
        private readonly IPersistentStore<TPo, TKey> _store;

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="store">持久化存储</param>
        protected PersistentRepositoryBase( IPersistentStore<TPo, TKey> store ) {
            _store = store;
        }

        /// <summary>
        /// 将持久化对象转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected abstract TEntity ToEntity( TPo po );

        /// <summary>
        /// 将实体转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected abstract TPo ToPo( TEntity entity );

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public TEntity Find( object id ) {
            return ToEntity( _store.Find( id ) );
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public async Task<TEntity> FindAsync( object id ) {
            return ToEntity( await _store.FindAsync( id ) );
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Add( TEntity entity ) {
            _store.Add( ToPo( entity ) );
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task AddAsync( TEntity entity ) {
            await _store.AddAsync( ToPo( entity ) );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Update( TEntity entity ) {
            _store.Update( ToPo( entity ) );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="newEntity">新实体</param>
        /// <param name="oldEntity">旧实体</param>
        public void Update( TEntity newEntity, TEntity oldEntity ) {
            _store.Update( ToPo( newEntity ), ToPo( oldEntity ) );
        }
    }
}
