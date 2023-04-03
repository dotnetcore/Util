using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Util.Applications.Controllers;
using Util.Applications.Trees;
using Util.Data.Trees;
using Util.Ui.NgZorro.Services;

namespace Util.Ui.NgZorro.Controllers {
    /// <summary>
    /// NgZorro树形查询控制器
    /// </summary>
    /// <typeparam name="TDto">参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class NgZorroTreeQueryControllerBase<TDto, TQuery> : TreeQueryControllerBase<TDto, TQuery>
        where TDto : TreeDtoBase<TDto>, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 树形查询服务
        /// </summary>
        private readonly ITreeQueryService<TDto, TQuery> _service;

        /// <summary>
        /// 初始化树形查询控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected NgZorroTreeQueryControllerBase( ITreeQueryService<TDto,TQuery> service ) : base( service ) {
            _service = service;
        }

        /// <summary>
        /// 树形查询
        /// </summary>
        /// <param name="query">查询参数</param>
        protected async Task<IActionResult> TreeQueryAsync( TQuery query ) {
            var action = new NgZorroTreeQueryAction<TDto, TQuery>( _service, GetLoadMode(), GetOperation( query ),
                GetMaxPageSize(), IsFirstLoad(), IsExpandAll(), IsExpandForRootAsync(), GetLoadKeys( query ), QueryBefore, QueryAfter );
            var result = await action.QueryAsync( query );
            return Success( result );
        }
    }
}
