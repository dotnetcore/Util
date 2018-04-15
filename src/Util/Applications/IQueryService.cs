using Util.Applications.Dtos;
using Util.Applications.Operations;
using Util.Datas.Queries;

namespace Util.Applications {
    /// <summary>
    /// 查询服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface IQueryService<TDto, in TQueryParameter> : IService, 
        IGetAll<TDto>, IGetById<TDto>, IPagerQuery<TDto, TQueryParameter>,
        IGetAllAsync<TDto>, IGetByIdAsync<TDto>, IPagerQueryAsync<TDto, TQueryParameter>
        where TDto : IResponse, new()
        where TQueryParameter : IQueryParameter {
    }
}