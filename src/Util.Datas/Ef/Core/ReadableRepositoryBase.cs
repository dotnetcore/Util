using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef.Internal;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Datas.Ef.Core {
    /// <summary>
    /// 仓储 - 可读
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class ReadableRepositoryBase<TEntity> : ReadableRepositoryBase<TEntity, Guid>, IReadableRepository<TEntity>
        where TEntity : class, IAggregateRoot<TEntity, Guid> {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected ReadableRepositoryBase( IUnitOfWork unitOfWork )
            : base( unitOfWork ) {
        }
    }

    /// <summary>
    /// 仓储 - 可读
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class ReadableRepositoryBase<TEntity, TKey> : IReadableRepository<TEntity, TKey> where TEntity : class, IAggregateRoot<TEntity, TKey> {
        /// <summary>
        /// 数据上下文包装器
        /// </summary>
        private readonly DbContextWrapper<TEntity, TKey> _wrapper;

        /// <summary>
        /// 工作单元
        /// </summary>
        protected UnitOfWorkBase UnitOfWork { get; }

        /// <summary>
        /// 实体集
        /// </summary>
        protected DbSet<TEntity> Set { get; }

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected ReadableRepositoryBase( IUnitOfWork unitOfWork ) {
            _wrapper = new DbContextWrapper<TEntity, TKey>( unitOfWork );
            UnitOfWork = _wrapper.UnitOfWork;
            Set = _wrapper.Set;
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        public IQueryable<TEntity> Find() {
            return _wrapper.Find();
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public TEntity Find( object id ) {
            return _wrapper.Find( id );
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public async Task<TEntity> FindAsync( object id ) {
            return await _wrapper.FindAsync( id );
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">条件</param>
        public TEntity Single( Expression<Func<TEntity, bool>> predicate ) {
            return _wrapper.Single( predicate );
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        public async Task<TEntity> SingleAsync( Expression<Func<TEntity, bool>> predicate ) {
            return await _wrapper.SingleAsync( predicate );
        }
    }
}
