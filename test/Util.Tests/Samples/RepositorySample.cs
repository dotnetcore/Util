using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Tests.Samples {
    /// <summary>
    /// 实体样例
    /// </summary>
    [DisplayName( "实体样例" )]
    public class EntitySample : AggregateRoot<EntitySample> {
        public EntitySample( ) : this( Guid.NewGuid() ) {
        }

        public EntitySample( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 忽略值
        /// </summary>
        [IgnoreMap]
        public string IgnoreValue { get; set; }
    }

    /// <summary>
    /// 仓储样例
    /// </summary>
    public interface IRepositorySample : IRepository<EntitySample> {
    }

    /// <summary>
    /// 仓储样例
    /// </summary>
    public class RepositorySample : IRepositorySample {

        public IQueryable<EntitySample> Find() {
            throw new NotImplementedException();
        }

        public IQueryable<EntitySample> FindAsNoTracking() {
            throw new NotImplementedException();
        }

        public IQueryable<EntitySample> Find( ICriteria<EntitySample> criteria ) {
            throw new NotImplementedException();
        }

        public IQueryable<EntitySample> Find( Expression<Func<EntitySample, bool>> predicate ) {
            throw new NotImplementedException();
        }

        public EntitySample Find( object id ) {
            return new EntitySample();
        }

        public Task<EntitySample> FindAsync( object id ) {
            throw new NotImplementedException();
        }

        public List<EntitySample> FindByIds( params Guid[] ids ) {
            throw new NotImplementedException();
        }

        public List<EntitySample> FindByIds( IEnumerable<Guid> ids ) {
            throw new NotImplementedException();
        }

        public List<EntitySample> FindByIds( string ids ) {
            throw new NotImplementedException();
        }

        public Task<List<EntitySample>> FindByIdsAsync( params Guid[] ids ) {
            throw new NotImplementedException();
        }

        public Task<List<EntitySample>> FindByIdsAsync( IEnumerable<Guid> ids, CancellationToken cancellationToken = default( CancellationToken ) ) {
            throw new NotImplementedException();
        }

        public Task<List<EntitySample>> FindByIdsAsync( IEnumerable<Guid> ids ) {
            throw new NotImplementedException();
        }

        public Task<List<EntitySample>> FindByIdsAsync( string ids ) {
            throw new NotImplementedException();
        }

        public EntitySample Single( Expression<Func<EntitySample, bool>> predicate ) {
            throw new NotImplementedException();
        }

        public Task<EntitySample> SingleAsync( Expression<Func<EntitySample, bool>> predicate, CancellationToken cancellationToken = default( CancellationToken ) ) {
            throw new NotImplementedException();
        }

        public List<EntitySample> FindAll( Expression<Func<EntitySample, bool>> predicate = null ) {
            throw new NotImplementedException();
        }

        public Task<List<EntitySample>> FindAllAsync( Expression<Func<EntitySample, bool>> predicate = null ) {
            throw new NotImplementedException();
        }

        public bool Exists( Expression<Func<EntitySample, bool>> predicate ) {
            throw new NotImplementedException();
        }

        public bool Exists( params Guid[] ids ) {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync( Expression<Func<EntitySample, bool>> predicate ) {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync( params Guid[] ids ) {
            throw new NotImplementedException();
        }

        public int Count( Expression<Func<EntitySample, bool>> predicate = null ) {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync( Expression<Func<EntitySample, bool>> predicate = null ) {
            throw new NotImplementedException();
        }

        public List<EntitySample> Query( IQueryBase<EntitySample> query ) {
            throw new NotImplementedException();
        }

        public Task<List<EntitySample>> QueryAsync( IQueryBase<EntitySample> query ) {
            throw new NotImplementedException();
        }

        public List<EntitySample> QueryAsNoTracking( IQueryBase<EntitySample> query ) {
            throw new NotImplementedException();
        }

        public Task<List<EntitySample>> QueryAsNoTrackingAsync( IQueryBase<EntitySample> query ) {
            throw new NotImplementedException();
        }

        public PagerList<EntitySample> PagerQuery( IQueryBase<EntitySample> query ) {
            throw new NotImplementedException();
        }

        public Task<PagerList<EntitySample>> PagerQueryAsync( IQueryBase<EntitySample> query ) {
            throw new NotImplementedException();
        }

        public PagerList<EntitySample> PagerQueryAsNoTracking( IQueryBase<EntitySample> query ) {
            throw new NotImplementedException();
        }

        public Task<PagerList<EntitySample>> PagerQueryAsNoTrackingAsync( IQueryBase<EntitySample> query ) {
            throw new NotImplementedException();
        }

        public IQueryable<EntitySample> OrderBy( IQueryable<EntitySample> queryable, string orderBy ) {
            throw new NotImplementedException();
        }

        public void Add( EntitySample entity ) {
        }

        public void Add( IEnumerable<EntitySample> entities ) {
            throw new NotImplementedException();
        }

        public Task AddAsync( EntitySample entity, CancellationToken cancellationToken = default( CancellationToken ) ) {
            throw new NotImplementedException();
        }

        public Task AddAsync( IEnumerable<EntitySample> entities, CancellationToken cancellationToken = default( CancellationToken ) ) {
            throw new NotImplementedException();
        }

        public Task AddAsync( EntitySample entity ) {
            throw new NotImplementedException();
        }

        public Task AddAsync( IEnumerable<EntitySample> entities ) {
            throw new NotImplementedException();
        }

        public void Update( EntitySample entity ) {
        }

        public void Update( IEnumerable<EntitySample> entities ) {
            throw new NotImplementedException();
        }

        public Task UpdateAsync( EntitySample entity ) {
            throw new NotImplementedException();
        }

        public Task UpdateAsync( IEnumerable<EntitySample> entities ) {
            throw new NotImplementedException();
        }

        public void Remove( Guid id ) {
            throw new NotImplementedException();
        }

        public Task RemoveAsync( Guid id, CancellationToken cancellationToken = default( CancellationToken ) ) {
            throw new NotImplementedException();
        }

        public Task RemoveAsync( Guid id ) {
            throw new NotImplementedException();
        }

        public void Remove( object id ) {
            throw new NotImplementedException();
        }

        public void Remove( EntitySample entity ) {
            throw new NotImplementedException();
        }

        public Task RemoveAsync( object id, CancellationToken cancellationToken = default( CancellationToken ) ) {
            throw new NotImplementedException();
        }

        public Task RemoveAsync( EntitySample entity, CancellationToken cancellationToken = default( CancellationToken ) ) {
            throw new NotImplementedException();
        }

        public Task RemoveAsync( EntitySample entity ) {
            throw new NotImplementedException();
        }

        public void Remove( IEnumerable<Guid> ids ) {
            throw new NotImplementedException();
        }

        public Task RemoveAsync( IEnumerable<Guid> ids, CancellationToken cancellationToken = default( CancellationToken ) ) {
            throw new NotImplementedException();
        }

        public Task RemoveAsync( IEnumerable<Guid> ids ) {
            throw new NotImplementedException();
        }

        public void Remove( IEnumerable<EntitySample> entities ) {
            throw new NotImplementedException();
        }

        public Task RemoveAsync( IEnumerable<EntitySample> entities, CancellationToken cancellationToken = default( CancellationToken ) ) {
            throw new NotImplementedException();
        }

        public Task RemoveAsync( IEnumerable<EntitySample> entities ) {
            throw new NotImplementedException();
        }

        public Task<EntitySample> FindAsync( object id, CancellationToken cancellationToken = default( CancellationToken ) ) {
            throw new NotImplementedException();
        }

        public EntitySample FindByIdNoTracking( Guid id ) {
            throw new NotImplementedException();
        }

        public Task<EntitySample> FindByIdNoTrackingAsync( Guid id, CancellationToken cancellationToken = default( CancellationToken ) ) {
            throw new NotImplementedException();
        }

        public List<EntitySample> FindByIdsNoTracking( params Guid[] ids ) {
            throw new NotImplementedException();
        }

        public List<EntitySample> FindByIdsNoTracking( IEnumerable<Guid> ids ) {
            throw new NotImplementedException();
        }

        public List<EntitySample> FindByIdsNoTracking( string ids ) {
            throw new NotImplementedException();
        }

        public Task<List<EntitySample>> FindByIdsNoTrackingAsync( params Guid[] ids ) {
            throw new NotImplementedException();
        }

        public Task<List<EntitySample>> FindByIdsNoTrackingAsync( IEnumerable<Guid> ids, CancellationToken cancellationToken = default( CancellationToken ) ) {
            throw new NotImplementedException();
        }

        public Task<List<EntitySample>> FindByIdsNoTrackingAsync( string ids ) {
            throw new NotImplementedException();
        }

        public List<EntitySample> FindAllNoTracking( Expression<Func<EntitySample, bool>> predicate = null ) {
            throw new NotImplementedException();
        }

        public Task<List<EntitySample>> FindAllNoTrackingAsync( Expression<Func<EntitySample, bool>> predicate = null ) {
            throw new NotImplementedException();
        }
    }
}
