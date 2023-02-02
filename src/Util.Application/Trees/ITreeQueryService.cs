using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Data.Queries;

namespace Util.Applications.Trees {
    /// <summary>
    /// 查询服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public interface ITreeQueryService<TDto, in TQuery> : IQueryService<TDto, TQuery>
        where TDto : new()
        where TQuery : IPage {
        /// <summary>
        /// 通过父标识列表获取节点集合
        /// </summary>
        /// <param name="parentIds">父标识列表,以逗号分隔标识</param>
        Task<List<TDto>> GetByParentIds( string parentIds );
    }
}