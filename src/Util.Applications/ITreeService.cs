using System;
using System.Collections.Generic;
using Util.Applications.Dtos;
using Util.Applications.Operations;
using Util.Datas.Queries.Trees;

namespace Util.Applications {
    /// <summary>
    /// 树型服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface ITreeService<TDto, in TQueryParameter> : ITreeService<TDto, TQueryParameter, Guid?>
        where TDto : class, IResponse, ITreeNode, new()
        where TQueryParameter : class, ITreeQueryParameter {
    }

    /// <summary>
    /// 树型服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public interface ITreeService<TDto, in TQueryParameter, TParentId> : IQueryService<TDto, TQueryParameter>,
        IDelete,IDeleteAsync
        where TDto : class, IResponse, ITreeNode, new()
        where TQueryParameter : class, ITreeQueryParameter<TParentId> {
        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        List<string> GetParentIdsFromPath( TDto dto );
    }
}