using Util.Applications.Dtos;
using Util.Applications.Operations;
using Util.Datas.Queries;

namespace Util.Applications {
    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface ICrudService<TDto, in TQueryParameter> : ICrudService<TDto, TDto, TQueryParameter>
        where TDto : IDto, new()
        where TQueryParameter : IQueryParameter {
    }

    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TRequest">参数类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface ICrudService<TDto, TRequest, in TQueryParameter> : ICrudService<TDto, TRequest, TRequest, TRequest, TQueryParameter>
        where TDto : IResponse, new()
        where TRequest : IRequest, IKey, new()
        where TQueryParameter : IQueryParameter {
    }

    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface ICrudService<TDto, in TCreateRequest, in TUpdateRequest, in TQueryParameter> : IQueryService<TDto, TQueryParameter>,
        ICreate<TCreateRequest>, IUpdate<TUpdateRequest>, IDelete,
        ICreateAsync<TCreateRequest>, IUpdateAsync<TUpdateRequest>, IDeleteAsync
        where TDto : IResponse, new()
        where TCreateRequest : IRequest, new()
        where TUpdateRequest : IRequest, new()
        where TQueryParameter : IQueryParameter {
    }

    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TRequest">参数类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface ICrudService<TDto, TRequest, in TCreateRequest, in TUpdateRequest, in TQueryParameter> : IQueryService<TDto, TQueryParameter>,
        ICreate<TCreateRequest>, IUpdate<TUpdateRequest>, IDelete, ISave<TRequest>, IBatchSave<TDto, TRequest>,
        ICreateAsync<TCreateRequest>, IUpdateAsync<TUpdateRequest>, IDeleteAsync, ISaveAsync<TRequest>, IBatchSaveAsync<TDto, TRequest>
        where TDto : IResponse, new()
        where TRequest : IRequest, IKey, new()
        where TCreateRequest : IRequest, new()
        where TUpdateRequest : IRequest, new()
        where TQueryParameter : IQueryParameter {
    }
}
