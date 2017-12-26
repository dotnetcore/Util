using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Applications;
using Util.Applications.Dtos;
using Util.Datas.Queries;
using Util.Properties;

namespace Util.Samples.Webs.Base {
    /// <summary>
    /// Crud控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询实体类型</typeparam>
    public abstract class CrudControllerBase<TDto, TQuery> : QueryControllerBase<TDto, TQuery>
        where TQuery : IQueryParameter
        where TDto : DtoBase, new() {
        /// <summary>
        /// Crud服务
        /// </summary>
        private readonly ICrudService<TDto, TQuery> _service;

        /// <summary>
        /// 初始化Crud控制器
        /// </summary>
        /// <param name="service">Crud服务</param>
        protected CrudControllerBase( ICrudService<TDto, TQuery> service )
            : base( service ) {
            _service = service;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        [HttpPost]
        public virtual async Task<IActionResult> Save( TDto dto ) {
            SaveBefore( dto );
            await _service.SaveAsync( dto );
            return Success( R.Success );
        }

        /// <summary>
        /// 保存前操作
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected virtual void SaveBefore( TDto dto ) {
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">Id列表，多个Id用逗号分隔，范例：1,2,3</param>
        [HttpDelete( "{ids}" )]
        public virtual async Task<IActionResult> Delete( string ids ) {
            await _service.DeleteAsync( ids );
            return Success( R.DeleteSuccess );
        }
    }
}
