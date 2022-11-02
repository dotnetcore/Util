using System.Threading.Tasks;
using Util.Applications.Dtos;
using Util.Applications.Trees;
using Util.Data;
using Util.Data.Trees;

namespace Util.Applications.Controllers {
    /// <summary>
    /// 树形表格控制器
    /// </summary>
    /// <typeparam name="TDto">参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeTableControllerBase<TDto, TQuery> : TreeTableControllerBase<TDto, TDto, TDto, TQuery>
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 初始化树形表格控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected TreeTableControllerBase( ITreeService<TDto, TQuery> service ) : base( service ) {
        }
    }

    /// <summary>
    /// 树形表格控制器
    /// </summary>
    /// <typeparam name="TDto">参数类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeTableControllerBase<TDto, TCreateRequest, TUpdateRequest, TQuery> : TreeControllerBase<TDto, TCreateRequest, TUpdateRequest,TQuery>
        where TDto : class, ITreeNode, new()
        where TCreateRequest : IRequest, new()
        where TUpdateRequest : IDto, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 树形服务
        /// </summary>
        private readonly ITreeService<TDto, TCreateRequest, TUpdateRequest, TQuery> _service;

        /// <summary>
        /// 初始化树形表格控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected TreeTableControllerBase( ITreeService<TDto, TCreateRequest, TUpdateRequest, TQuery> service ) : base( service ) {
            _service = service;
        }

        /// <summary>
        /// 转换为树形结果
        /// </summary>
        protected override dynamic ToResult( PageList<TDto> data, bool async = false ) {
            return data.Convert( new TreeTableResult<TDto>( data.Data, async ).GetResult() );
        }

        /// <summary>
        /// 异步查询
        /// </summary>
        protected override async Task<PageList<TDto>> AsyncQuery( TQuery query ) {
            return await _service.PageQueryAsync( query );
        }
    }
}
