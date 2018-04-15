using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Applications;
using Util.Applications.Dtos;
using Util.Datas.Queries.Trees;
using Util.Domains.Repositories;
using Util.Ui.Datas;
using Util.Ui.Extensions;
using Util.Ui.Prime.TreeTables.Datas;
using Util.Webs.Controllers;

namespace Util.Ui.Controllers {
    /// <summary>
    /// 树型控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeControllerBase<TDto, TQuery> : TreeControllerBase<TDto, TQuery, Guid?>
        where TDto : class, IResponse, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 初始化查询控制器
        /// </summary>
        /// <param name="service">查询服务</param>
        protected TreeControllerBase( ITreeService<TDto, TQuery, Guid?> service ) : base( service ) {
        }
    }

    /// <summary>
    /// 树型控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class TreeControllerBase<TDto, TQuery, TParentId> : WebApiControllerBase
        where TDto : class, IResponse, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter<TParentId> {
        /// <summary>
        /// 查询服务
        /// </summary>
        private readonly ITreeService<TDto, TQuery, TParentId> _service;

        /// <summary>
        /// 初始化查询控制器
        /// </summary>
        /// <param name="service">查询服务</param>
        protected TreeControllerBase( ITreeService<TDto, TQuery, TParentId> service ) {
            _service = service;
        }

        /// <summary>
        /// 获取加载模式
        /// </summary>
        protected virtual LoadMode LoadMode => LoadMode.Async;

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
        /// 查询
        /// </summary>
        /// <remarks> 
        /// 调用范例: 
        /// GET
        /// /api/customer?name=a
        /// </remarks>
        /// <param name="query">查询参数</param>
        [HttpGet]
        public virtual async Task<IActionResult> QueryAsync( TQuery query ) {
            QueryBefore( query );
            var result = await GetRootsAsync( query );
            return Success( result );
        }

        /// <summary>
        /// 查询前操作
        /// </summary>
        /// <param name="query">查询参数</param>
        protected virtual void QueryBefore( TQuery query ) {
        }

        /// <summary>
        /// 获取根节点列表
        /// </summary>
        protected async Task<PagerList<PrimeTreeNode<TDto>>> GetRootsAsync( TQuery query ) {
            query.Level = 1;
            var result = await _service.PagerQueryAsync( query );
            return result.Convert( result.Data.ToPrimeResult() );
        }
    }
}