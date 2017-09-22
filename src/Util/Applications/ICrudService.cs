using System.Collections.Generic;

namespace Util.Applications {
    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询实体类型</typeparam>
    public interface ICrudService<TDto, in TQuery> : IQueryService<TDto, TQuery> where TDto : new() {
        /// <summary>
        /// 创建实体
        /// </summary>
        TDto Create();
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
        /// <param name="ids">用逗号分隔的Id列表，范例："83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A"</param>
        void Delete( string ids );
    }
}
