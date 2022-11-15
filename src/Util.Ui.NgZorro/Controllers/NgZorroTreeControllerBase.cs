using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Util.Applications.Controllers;
using Util.Applications.Trees;
using Util.Data.Trees;
using Util.Ui.NgZorro.Services;

namespace Util.Ui.NgZorro.Controllers {
    /// <summary>
    /// NgZorro树形控制器
    /// </summary>
    /// <typeparam name="TDto">参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class NgZorroTreeControllerBase<TDto, TQuery> : TreeControllerBase<TDto, TQuery>
        where TDto : TreeDtoBase<TDto>, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 树形服务
        /// </summary>
        private readonly ITreeService<TDto, TQuery> _service;

        /// <summary>
        /// 初始化树形控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected NgZorroTreeControllerBase( ITreeService<TDto,TQuery> service ) : base(service) {
            _service = service;
        }

        /// <summary>
        /// 树形查询
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual async Task<IActionResult> TreeQueryAsync( TQuery query ) {
            var service = new TreeQueryService<TDto, TQuery>( _service, GetLoadMode(), GetOperation( query ),
                GetMaxPageSize(), IsFirstLoad(), IsExpandForRootAsync(), QueryBefore, QueryAfter );
            var result = await service.QueryAsync( query );
            return Success( result );
        }
    }
}
