using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Applications.Trees;
using Util.Datas.Queries.Trees;

namespace Util.Webs.Controllers.Trees {
    /// <summary>
    /// 树形控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract partial class ControllerBase<TDto, TQuery, TParentId> : WebApiControllerBase
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter<TParentId> {
        /// <summary>
        /// 树型服务
        /// </summary>
        private readonly ITreeService<TDto, TQuery, TParentId> _service;

        /// <summary>
        /// 初始化树型控制器
        /// </summary>
        /// <param name="service">树型服务</param>
        protected ControllerBase( ITreeService<TDto, TQuery, TParentId> service ) {
            _service = service;
        }

        /// <summary>
        /// 获取加载模式
        /// </summary>
        protected virtual LoadMode GetLoadMode() {
            return LoadMode.Sync;
        }

        /// <summary>
        /// 获取单个实例
        /// </summary>
        /// <remarks> 
        /// 调用范例: 
        /// GET
        /// /api/customer/1 
        /// </remarks>
        /// <param name="id">标识</param>
        [HttpGet( "{id}" )]
        public virtual async Task<IActionResult> GetAsync( string id ) {
            var result = await _service.GetByIdAsync( id );
            return Success( result );
        }

        /// <summary>
        /// 删除，注意：该方法用于删除单个实体，批量删除请使用POST提交，否则可能失败
        /// </summary>
        /// <remarks>
        /// 调用范例:
        /// DELETE
        /// /api/customer/1
        /// </remarks>
        /// <param name="id">标识</param>
        [HttpDelete( "{id}" )]
        public virtual async Task<IActionResult> DeleteAsync( string id ) {
            await _service.DeleteAsync( id );
            return Success();
        }

        /// <summary>
        /// 批量删除，注意：body参数需要添加引号，"'1,2,3'"而不是"1,2,3"
        /// </summary>
        /// <remarks>
        /// 调用范例:
        /// POST   
        /// /api/customer/delete
        /// body: "'1,2,3'"
        /// </remarks>
        /// <param name="ids">标识列表，多个Id用逗号分隔，范例：1,2,3</param>
        [HttpPost( "delete" )]
        public virtual async Task<IActionResult> BatchDeleteAsync( [FromBody] string ids ) {
            await _service.DeleteAsync( ids );
            return Success();
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">标识列表</param>
        [HttpPost( "enable" )]
        public virtual async Task<IActionResult> Enable( [FromBody] string ids ) {
            await _service.EnableAsync( ids );
            var result = await _service.FindByIdsAsync( ids );
            return Success( result );
        }

        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="ids">标识列表</param>
        [HttpPost( "disable" )]
        public virtual async Task<IActionResult> Disable( [FromBody] string ids ) {
            await _service.DisableAsync( ids );
            var result = await _service.FindByIdsAsync( ids );
            return Success( result );
        }

        /// <summary>
        /// 交换排序
        /// </summary>
        /// /// <remarks>
        /// 调用范例:
        /// POST   
        /// /api/customer/SwapSort
        /// body: "'1,2'"
        /// </remarks>
        /// <param name="ids">两个Id的标识列表，用逗号分隔，范例：1,2</param>
        [HttpPost( "SwapSort" )]
        public virtual async Task<IActionResult> SwapSortAsync( [FromBody] string ids ) {
            var idList = ids.ToGuidList();
            if( idList.Count < 2 )
                return Fail( "交换排序失败" );
            await _service.SwapSortAsync( idList[0], idList[1] );
            return Success();
        }

        /// <summary>
        /// 修正排序
        /// </summary> 
        /// <param name="parameter">查询参数</param>
        [HttpPost( "fix" )]
        public virtual async Task<IActionResult> FixAsync( [FromBody] TQuery parameter ) {
            if ( parameter == null )
                return Fail( "查询参数不能为空" );
            await _service.FixSortIdAsync( parameter );
            return Success();
        }
    }
}
