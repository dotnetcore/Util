using System;
using Util.Applications.Dtos;
using Util.Datas.Queries.Trees;

namespace Util.Applications.Trees {
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
    public interface ITreeService<TDto, in TQueryParameter, TParentId> : IDeleteService<TDto, TQueryParameter>
        where TDto : class, IResponse, ITreeNode, new()
        where TQueryParameter : class, ITreeQueryParameter<TParentId> {
    }
}