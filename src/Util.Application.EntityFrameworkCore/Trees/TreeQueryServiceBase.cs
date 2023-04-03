using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Data;
using Util.Data.Trees;
using Util.Domain.Trees;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形查询服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeQueryServiceBase<TEntity, TDto, TQuery>
        : TreeQueryServiceBase<TEntity, TDto, TQuery, Guid, Guid?>
        where TEntity : class, ITreeEntity<TEntity, Guid, Guid?>, new()
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 初始化树形查询服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="repository">树形仓储</param>
        protected TreeQueryServiceBase( IServiceProvider serviceProvider, ITreeRepository<TEntity, Guid, Guid?> repository ) : base( serviceProvider, repository ) {
        }
    }

    /// <summary>
    /// 树形查询服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class TreeQueryServiceBase<TEntity, TDto, TQuery, TKey, TParentId>
        : QueryServiceBase<TEntity, TDto, TQuery, TKey>, ITreeQueryService<TDto, TQuery>
        where TEntity : class, ITreeEntity<TEntity, TKey, TParentId>, new()
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 树形仓储
        /// </summary>
        private readonly ITreeRepository<TEntity, TKey, TParentId> _repository;

        /// <summary>
        /// 初始化树形查询服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="repository">树形仓储</param>
        protected TreeQueryServiceBase( IServiceProvider serviceProvider, ITreeRepository<TEntity, TKey, TParentId> repository ) : base( serviceProvider, repository ) {
            _repository = repository;
        }

        /// <summary>
        /// 获取条件列表
        /// </summary>
        protected override IEnumerable<ICondition<TEntity>> GetConditions( TQuery parameter ) {
            return new[] { new TreeCondition<TEntity, TParentId>( parameter ) };
        }

        /// <summary>
        /// 通过父标识列表获取节点集合
        /// </summary>
        /// <param name="parentIds">父标识列表,以逗号分隔标识</param>
        public virtual async Task<List<TDto>> GetByParentIds( string parentIds ) {
            var keys = Util.Helpers.Convert.ToList<TParentId>( parentIds );
            var entities = await _repository.FindAllAsync( t => keys.Contains( t.ParentId ) );
            return entities.Select( ToDto ).ToList();
        }
    }
}
