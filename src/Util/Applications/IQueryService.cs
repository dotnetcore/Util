using System.Collections.Generic;
using Util.Domains.Repositories;

namespace Util.Applications {
    /// <summary>
    /// 查询服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询实体类型</typeparam>
    public interface IQueryService<TDto, in TQuery> where TDto : new() {
        /// <summary>
        /// 获取全部
        /// </summary>
        List<TDto> GetAll();
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        TDto GetById( object id );
        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A"</param>
        List<TDto> GetByIds( string ids );
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询实体</param>
        List<TDto> Query( TQuery query );
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询实体</param>
        PagerList<TDto> PagerQuery( TQuery query );
    }
}