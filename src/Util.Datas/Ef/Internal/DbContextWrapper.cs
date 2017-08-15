using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef.Core;
using Util.Domains;
using Util.Exceptions;

namespace Util.Datas.Ef.Internal {
    /// <summary>
    /// 数据上下文包装器
    /// </summary>
    internal class DbContextWrapper<TEntity, TKey> where TEntity : class, IKey<TKey>, IVersion {
        /// <summary>
        /// 初始化数据上下文包装器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DbContextWrapper( IUnitOfWork unitOfWork ) {
            UnitOfWork = (UnitOfWorkBase)unitOfWork;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public UnitOfWorkBase UnitOfWork { get; }

        /// <summary>
        /// 实体集
        /// </summary>
        public DbSet<TEntity> Set => UnitOfWork.Set<TEntity>();

        /// <summary>
        /// 查找实体
        /// </summary>
        public IQueryable<TEntity> Find() {
            return Set;
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public TEntity Find( object id ) {
            if( id == null )
                return null;
            return Set.Find( id );
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public async Task<TEntity> FindAsync( object id ) {
            if( id == null )
                return null;
            return await Set.FindAsync( id );
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">条件</param>
        public TEntity Single( Expression<Func<TEntity, bool>> predicate ) {
            return Find().FirstOrDefault( predicate );
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        public async Task<TEntity> SingleAsync( Expression<Func<TEntity, bool>> predicate ) {
            return await Find().FirstOrDefaultAsync( predicate );
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Add( TEntity entity ) {
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            Set.Add( entity );
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task AddAsync( TEntity entity ) {
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            await Set.AddAsync( entity );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Update( TEntity entity ) {
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            UnitOfWork.Entry( entity ).State = EntityState.Modified;
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="newEntity">新实体</param>
        /// <param name="oldEntity">数据库中旧的实体</param>
        public void Update( TEntity newEntity, TEntity oldEntity ) {
            if( newEntity == null )
                throw new ArgumentNullException( nameof( newEntity ) );
            if( oldEntity == null )
                throw new ArgumentNullException( nameof( oldEntity ) );
            ValidateVersion( newEntity, oldEntity );
            UnitOfWork.Entry( oldEntity ).CurrentValues.SetValues( newEntity );
        }

        //验证版本号
        private void ValidateVersion( TEntity newEntity, TEntity oldEntity ) {
            if( newEntity.Version == null )
                throw new ConcurrencyException();
            for( int i = 0; i < oldEntity.Version.Length; i++ ) {
                if( newEntity.Version[i] != oldEntity.Version[i] )
                    throw new ConcurrencyException( $"新实体:{newEntity.SafeString()},旧实体:{oldEntity.SafeString()}" );
            }
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public void Remove( TKey id ) {
            var entity = Find( id );
            Remove( entity );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public async Task RemoveAsync( TKey id ) {
            var entity = await FindAsync( id );
            await RemoveAsync( entity );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        public void Remove( TEntity entity ) {
            if( entity == null )
                return;
            entity = Find( entity.Id );
            Delete( entity );
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Delete( TEntity entity ) {
            IDelete model = entity as IDelete;
            if( model == null ) {
                Set.Remove( entity );
                return;
            }
            model.IsDeleted = true;
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task RemoveAsync( TEntity entity ) {
            if( entity == null )
                return;
            entity = await FindAsync( entity.Id );
            Delete( entity );
        }
    }
}
