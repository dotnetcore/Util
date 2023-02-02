using System.Threading.Tasks;
using Util.Aop;
using Util.Applications.Dtos;
using Util.Data.Trees;
using Util.Validation;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public interface ITreeService<TDto, in TQuery> : ITreeService<TDto, TDto, TDto, TQuery>
        where TDto : ITreeNode, new()
        where TQuery : ITreeQueryParameter {
    }

    /// <summary>
    /// 树形服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public interface ITreeService<TDto, in TCreateRequest, in TUpdateRequest, in TQuery> : ITreeQueryService<TDto, TQuery>
        where TDto : ITreeNode, new()
        where TCreateRequest : IRequest, new()
        where TUpdateRequest : IDto,new()
        where TQuery : ITreeQueryParameter {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        Task<string> CreateAsync( [NotNull][Valid] TCreateRequest request );
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        Task UpdateAsync( [NotNull][Valid] TUpdateRequest request );
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的标识列表，范例："1,2"</param>
        Task DeleteAsync( string ids );
        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">标识列表</param>
        Task EnableAsync( string ids );
        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="ids">标识列表</param>
        Task DisableAsync( string ids );
    }
}