using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Applications.Dtos;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace Util.Applications {
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface IPagerQuery<TDto, in TQueryParameter>
        where TDto : IDto, new()
        where TQueryParameter : IQueryParameter {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        List<TDto> Query( TQueryParameter parameter );
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        Task<List<TDto>> QueryAsync( TQueryParameter parameter );
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        PagerList<TDto> PagerQuery( TQueryParameter parameter );
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        Task<PagerList<TDto>> PagerQueryAsync( TQueryParameter parameter );
    }
}