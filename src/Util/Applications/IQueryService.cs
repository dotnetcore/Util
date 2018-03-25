using Util.Applications.Dtos;
using Util.Datas.Queries;

namespace Util.Applications {
    /// <summary>
    /// 查询服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface IQueryService<TDto, in TQueryParameter> : IService, IGetAll<TDto>, IGetById<TDto>, IPagerQuery<TDto, TQueryParameter>
        where TDto : IDto, new()
        where TQueryParameter : IQueryParameter {
    }
}