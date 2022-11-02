using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Data;
using Util.Data.Queries;

namespace Util.Applications {
    /// <summary>
    /// 查询服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public interface IQueryService<TDto, in TQuery> : IService
        where TDto : new()
        where TQuery : IPage {
        /// <summary>
        /// 获取全部实体
        /// </summary>
        Task<List<TDto>> GetAllAsync();
        /// <summary>
        /// 通过标识获取实体
        /// </summary>
        /// <param name="id">实体标识</param>
        Task<TDto> GetByIdAsync( object id );
        /// <summary>
        /// 通过标识列表获取实体列表
        /// </summary>
        /// <param name="ids">用逗号分隔的标识列表，范例："1,2"</param>
        Task<List<TDto>> GetByIdsAsync( string ids );
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="param">查询参数</param>
        Task<List<TDto>> QueryAsync( TQuery param );
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="param">查询参数</param>
        Task<PageList<TDto>> PageQueryAsync( TQuery param );
    }
}