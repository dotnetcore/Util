using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Aop;
using Util.Applications.Dtos;
using Util.Data.Queries;
using Util.Validation;

namespace Util.Applications {
    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public interface ICrudService<TDto, in TQuery> : ICrudService<TDto, TDto, TDto, TQuery>
        where TDto : IDto, new()
        where TQuery : IPage {
    }

    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public interface ICrudService<TDto, in TCreateRequest, in TUpdateRequest, in TQuery> : IQueryService<TDto, TQuery>
        where TDto : IDto, new()
        where TCreateRequest : IRequest, new()
        where TUpdateRequest : IDto, new()
        where TQuery : IPage {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        Task<string> CreateAsync( [NotNull] [Valid] TCreateRequest request );
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        Task UpdateAsync( [NotNull] [Valid] TUpdateRequest request );
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的标识列表，范例："1,2"</param>
        Task DeleteAsync( string ids );
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="creationList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        Task<List<TDto>> SaveAsync( List<TDto> creationList, List<TDto> updateList, List<TDto> deleteList );
    }
}
