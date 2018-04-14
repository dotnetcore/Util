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
        /// <param name="addList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        public List<TDto> Save( List<TRequest> addList, List<TRequest> updateList, List<TRequest> deleteList ) {
            if( addList == null && updateList == null && deleteList == null )
                return new List<TDto>();
            addList = addList ?? new List<TRequest>();
            updateList = updateList ?? new List<TRequest>();
            deleteList = deleteList ?? new List<TRequest>();
            FilterList( addList, updateList, deleteList );
            var addEntities = ToEntities( addList );
            var updateEntities = ToEntities( updateList );
            var deleteEntities = ToEntities( deleteList ); 
            SaveBefore( addEntities, updateEntities, deleteEntities );
            AddList( addEntities );
            UpdateList( updateEntities );
            DeleteList( deleteEntities );
            Commit();
            SaveAfter( addEntities, updateEntities, deleteEntities );
            return GetResult( addEntities, updateEntities );
        }

        /// <summary>
        /// 转换为实体集合
        /// </summary>
        private List<TEntity> ToEntities( List<TRequest> dtos ) {
            return dtos.Select( ToEntity ).Distinct().ToList();
        }

        /// <summary>
        /// 过滤列表
        /// </summary>
        private void FilterList( List<TRequest> addList, List<TRequest> updateList, List<TRequest> deleteList ) {
            FilterByDeleteList( addList, deleteList );
            FilterByDeleteList( updateList, deleteList );
        }

        /// <summary>
        /// 过滤需要删除的项
        /// </summary>
        private void FilterByDeleteList( List<TRequest> list, List<TRequest> deleteList ) {
            for( int i = 0; i < list.Count; i++ ) {
                var item = list[i];
                if( deleteList.Any( d => d.Id == item.Id ) )
                    list.Remove( item );
            }
        }

        /// <summary>
        /// 保存前操作
        /// </summary>
        /// <param name="addList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        protected virtual void SaveBefore( List<TEntity> addList, List<TEntity> updateList, List<TEntity> deleteList ) {
        }

        /// <summary>
        /// 添加列表
        /// </summary>
        private void AddList( List<TEntity> list ) {
            if( list.Count == 0 )
                return;
            Log.Content( "创建实体：" );
            list.ForEach( Create );
        }

        /// <summary>
        /// 更新列表
        /// </summary>
        private void UpdateList( List<TEntity> list ) {
            if( list.Count == 0 )
                return;
            Log.Content( "修改实体：" );
            list.ForEach( Update );
        }

        /// <summary>
        /// 删除列表
        /// </summary>
        private void DeleteList( List<TEntity> list ) {
            if( list.Count == 0 )
                return;
            Log.Content( "删除实体：" );
            list.ForEach( DeleteChilds );
        }

        /// <summary>
        /// 删除子节点集合
        /// </summary>
        protected virtual void DeleteChilds( TEntity parent ) {
            DeleteEntity( parent );
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        protected void DeleteEntity( TEntity entity ) {
            _repository.Remove( entity.Id );
            AddLog( entity );
        }

        /// <summary>
        /// 提交
        /// </summary>
        private void Commit() {
            _unitOfWork.Commit();
        }

        /// <summary>
        /// 保存后操作
        /// </summary>
        protected virtual void SaveAfter( List<TEntity> addList, List<TEntity> updateList, List<TEntity> deleteList ) {
            WriteLog( $"保存{EntityDescription}成功" );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        protected virtual List<TDto> GetResult( List<TEntity> addList, List<TEntity> updateList ) {
            return addList.Concat( updateList ).Select( ToDto ).ToList();
        }

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="addList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        public async Task<List<TDto>> SaveAsync( List<TRequest> addList, List<TRequest> updateList,List<TRequest> deleteList ) {
            if( addList == null && updateList == null && deleteList == null )
                return new List<TDto>();
            addList = addList ?? new List<TRequest>();
            updateList = updateList ?? new List<TRequest>();
            deleteList = deleteList ?? new List<TRequest>();
            FilterList( addList, updateList, deleteList );
            var addEntities = ToEntities( addList );
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
    }
}
