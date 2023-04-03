using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Util.Applications.Trees;
using Util.Data.Trees;
using Util.Applications.Properties;
using Util.Applications.Dtos;

namespace Util.Applications.Controllers {
    /// <summary>
    /// 树形控制器
    /// </summary>
    /// <typeparam name="TDto">参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeControllerBase<TDto, TQuery> : TreeControllerBase<TDto, TDto, TDto, TQuery>
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 初始化树形控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected TreeControllerBase( ITreeService<TDto, TQuery> service ) : base( service ) {
        }
    }

    /// <summary>
    /// 树形控制器
    /// </summary>
    /// <typeparam name="TDto">参数类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeControllerBase<TDto, TCreateRequest, TUpdateRequest, TQuery> : TreeQueryControllerBase<TDto, TQuery>
        where TDto : class, ITreeNode, new()
        where TCreateRequest : IRequest, new()
        where TUpdateRequest : IDto, new()
        where TQuery : class, ITreeQueryParameter {

        #region 字段

        /// <summary>
        /// 树形服务
        /// </summary>
        private readonly ITreeService<TDto, TCreateRequest, TUpdateRequest, TQuery> _service;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化树形控制器
        /// </summary>
        /// <param name="service">树形服务</param>
        protected TreeControllerBase( ITreeService<TDto, TCreateRequest, TUpdateRequest, TQuery> service ) : base( service ) {
            _service = service ?? throw new ArgumentNullException( nameof( service ) );
        }

        #endregion

        #region CreateAsync(创建)

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        protected async Task<IActionResult> CreateAsync( TCreateRequest request ) {
            if ( request == null )
                return Fail( ApplicationResource.CreateRequestIsEmpty );
            CreateBefore( request );
            var id = await _service.CreateAsync( request );
            var result = await _service.GetByIdAsync( id );
            return Success( result );
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        /// <param name="request">创建参数</param>
        protected virtual void CreateBefore( TCreateRequest request ) {
        }

        #endregion

        #region UpdateAsync(修改)

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="request">修改参数</param>
        protected async Task<IActionResult> UpdateAsync( string id, TUpdateRequest request ) {
            if ( request == null )
                return Fail( ApplicationResource.UpdateRequestIsEmpty );
            if ( id.IsEmpty() && request.Id.IsEmpty() )
                return Fail( ApplicationResource.IdIsEmpty );
            if ( request.Id.IsEmpty() )
                request.Id = id;
            UpdateBefore( request );
            await _service.UpdateAsync( request );
            var result = await _service.GetByIdAsync( request.Id );
            return Success( result );
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        /// <param name="dto">修改参数</param>
        protected virtual void UpdateBefore( TUpdateRequest dto ) {
        }

        #endregion

        #region DeleteAsync(删除)

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">标识列表</param>
        protected async Task<IActionResult> DeleteAsync( string ids ) {
            await _service.DeleteAsync( ids );
            return Success();
        }

        #endregion

        #region EnableAsync(启用)

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">标识列表</param>
        protected async Task<IActionResult> EnableAsync( string ids ) {
            EnableBefore( ids );
            await _service.EnableAsync( ids );
            return Success();
        }

        /// <summary>
        /// 启用前操作
        /// </summary>
        /// <param name="ids">标识列表</param>
        protected virtual void EnableBefore( string ids ) {
        }

        #endregion

        #region DisableAsync(禁用)

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="ids">标识列表</param>
        protected async Task<IActionResult> DisableAsync( string ids ) {
            DisableBefore( ids );
            await _service.DisableAsync( ids );
            return Success();
        }

        /// <summary>
        /// 禁用前操作
        /// </summary>
        /// <param name="ids">标识列表</param>
        protected virtual void DisableBefore( string ids ) {
        }

        #endregion
    }
}
