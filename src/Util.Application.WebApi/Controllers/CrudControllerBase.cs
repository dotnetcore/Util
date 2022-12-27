using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Applications.Dtos;
using Util.Applications.Models;
using Util.Applications.Properties;
using Util.Data.Queries;

namespace Util.Applications.Controllers {
    /// <summary>
    /// Crud控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class CrudControllerBase<TDto, TQuery> : CrudControllerBase<TDto, TDto, TDto, TQuery>
        where TDto : IDto, new()
        where TQuery : IPage {
        /// <summary>
        /// 初始化Crud控制器
        /// </summary>
        /// <param name="service">Crud服务</param>
        protected CrudControllerBase( ICrudService<TDto, TQuery> service )
            : base( service ) {
        }
    }

    /// <summary>
    /// Crud控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class CrudControllerBase<TDto, TCreateRequest, TUpdateRequest, TQuery> : QueryControllerBase<TDto, TQuery>
        where TDto : IDto, new()
        where TCreateRequest : IRequest, new()
        where TUpdateRequest : IDto, new()
        where TQuery : IPage {
        /// <summary>
        /// Crud服务
        /// </summary>
        private readonly ICrudService<TDto, TCreateRequest, TUpdateRequest, TQuery> _service;

        /// <summary>
        /// 初始化Crud控制器
        /// </summary>
        /// <param name="service">Crud服务</param>
        protected CrudControllerBase( ICrudService<TDto, TCreateRequest, TUpdateRequest, TQuery> service )
            : base( service ) {
            _service = service;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        protected async Task<IActionResult> CreateAsync( TCreateRequest request ) {
            if( request == null )
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

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="request">修改参数</param>
        protected async Task<IActionResult> UpdateAsync( string id, TUpdateRequest request ) {
            if( request == null )
                return Fail( ApplicationResource.UpdateRequestIsEmpty );
            if( id.IsEmpty() && request.Id.IsEmpty() )
                return Fail( ApplicationResource.IdIsEmpty );
            if( request.Id.IsEmpty() )
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

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">标识列表</param>
        protected async Task<IActionResult> DeleteAsync( string ids ) {
            await _service.DeleteAsync( ids );
            return Success();
        }

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="request">保存参数</param>
        protected async Task<IActionResult> SaveAsync( SaveModel request ) {
            if ( request == null )
                return Fail( ApplicationResource.RequestIsEmpty );
            var creationList = Util.Helpers.Json.ToObject<List<TDto>>( request.CreationList );
            var updateList = Util.Helpers.Json.ToObject<List<TDto>>( request.UpdateList );
            var deleteList = Util.Helpers.Json.ToObject<List<TDto>>( request.DeleteList );
            await _service.SaveAsync( creationList, updateList, deleteList );
            return Success();
        }
    }
}
