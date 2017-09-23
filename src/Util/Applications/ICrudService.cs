using System.Collections.Generic;
using Util.Applications.Dtos;
using Util.Datas.Queries;

namespace Util.Applications {
    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface ICrudService<TDto, in TQueryParameter> : IQueryService<TDto, TQueryParameter> 
        where TDto : IDto,new()
        where TQueryParameter : IQueryParameter {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        void Save( TDto dto );
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="addList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        List<TDto> Save( List<TDto> addList, List<TDto> updateList, List<TDto> deleteList );
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        void Delete( string ids );
    }
}
