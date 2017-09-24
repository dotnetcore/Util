using System;
using System.Collections.Generic;
using Util.Applications.Dtos;
using Util.Datas.Queries;
using Util.Domains;

namespace Util.Applications {
    /// <summary>
    /// 增删改查服务 - 批量Save
    /// </summary>
    public abstract partial class CrudServiceBase<TEntity, TDto, TRequest, TQueryParameter, TKey>
        where TEntity : class, IAggregateRoot<TEntity, TKey>
        where TDto : IDto, new()
        where TRequest : IRequest, IKey, new()
        where TQueryParameter : IQueryParameter {
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="addList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        public List<TDto> Save( List<TRequest> addList, List<TRequest> updateList, List<TRequest> deleteList ) {
            throw new NotImplementedException();
        }
    }
}
