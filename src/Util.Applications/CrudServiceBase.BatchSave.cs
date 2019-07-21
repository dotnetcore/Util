using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Logs.Extensions;

namespace Util.Applications {
    /// <summary>
    /// 增删改查服务 - 批量Save
    /// </summary>
    public abstract partial class CrudServiceBase<TEntity, TDto, TRequest, TCreateRequest, TUpdateRequest, TQueryParameter, TKey> {
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="creationList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        public virtual async Task<List<TDto>> SaveAsync( List<TDto> creationList, List<TDto> updateList,List<TDto> deleteList ) {
            if( creationList == null && updateList == null && deleteList == null )
                return new List<TDto>();
            creationList = creationList ?? new List<TDto>();
            updateList = updateList ?? new List<TDto>();
            deleteList = deleteList ?? new List<TDto>();
            FilterList( creationList, updateList, deleteList );
            var addEntities = ToEntities( creationList );
            var updateEntities = ToEntities( updateList );
            var deleteEntities = ToEntities( deleteList );
            SaveBefore( addEntities, updateEntities, deleteEntities );
            await AddListAsync( addEntities );
            await UpdateListAsync( updateEntities );
            await DeleteListAsync( deleteEntities );
            await CommitAsync();
            SaveAfter( addEntities, updateEntities, deleteEntities );
            return GetResult( addEntities, updateEntities );
        }

        /// <summary>
        /// 过滤列表
        /// </summary>
        private void FilterList( List<TDto> creationList, List<TDto> updateList, List<TDto> deleteList ) {
            FilterByDeleteList( creationList, deleteList );
            FilterByDeleteList( updateList, deleteList );
        }

        /// <summary>
        /// 过滤需要删除的项
        /// </summary>
        private void FilterByDeleteList( List<TDto> list, List<TDto> deleteList ) {
            for( int i = 0; i < list.Count; i++ ) {
                var item = list[i];
                if( deleteList.Any( d => d.Id == item.Id ) )
                    list.Remove( item );
            }
        }

        /// <summary>
        /// 转换为实体集合
        /// </summary>
        private List<TEntity> ToEntities( List<TDto> dtos ) {
            return dtos.Select( ToEntityFromDto ).Distinct().ToList();
        }

        /// <summary>
        /// 保存前操作
        /// </summary>
        /// <param name="creationList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        protected virtual void SaveBefore( List<TEntity> creationList, List<TEntity> updateList, List<TEntity> deleteList ) {
        }

        /// <summary>
        /// 添加列表
        /// </summary>
        private async Task AddListAsync( List<TEntity> list ) {
            if( list.Count == 0 )
                return;
            Log.Content( "创建实体：" );
            foreach ( var entity in list )
                await CreateAsync( entity );
        }

        /// <summary>
        /// 更新列表
        /// </summary>
        private async Task UpdateListAsync( List<TEntity> list ) {
            if( list.Count == 0 )
                return;
            Log.Content( "修改实体：" );
            foreach( var entity in list )
                await UpdateAsync( entity );
        }

        /// <summary>
        /// 删除列表
        /// </summary>
        private async Task DeleteListAsync( List<TEntity> list ) {
            if( list.Count == 0 )
                return;
            Log.Content( "删除实体：" );
            foreach( var entity in list )
                await DeleteChildsAsync( entity );
        }

        /// <summary>
        /// 删除子节点集合
        /// </summary>
        protected virtual async Task DeleteChildsAsync( TEntity parent ) {
            await DeleteEntityAsync( parent );
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        protected async Task DeleteEntityAsync( TEntity entity ) {
            await _repository.RemoveAsync( entity.Id );
            AddLog( entity );
        }

        /// <summary>
        /// 提交
        /// </summary>
        private async Task CommitAsync() {
            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// 保存后操作
        /// </summary>
        protected virtual void SaveAfter( List<TEntity> creationList, List<TEntity> updateList, List<TEntity> deleteList ) {
            WriteLog( $"保存{EntityDescription}成功" );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        protected virtual List<TDto> GetResult( List<TEntity> creationList, List<TEntity> updateList ) {
            return creationList.Concat( updateList ).Select( ToDto ).ToList();
        }
    }
}
