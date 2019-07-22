using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Applications.Dtos;

namespace Util.Applications.Operations {
    /// <summary>
    /// 批量保存操作
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    public interface IBatchSaveAsync<TDto>
        where TDto : IDto, new() {
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="creationList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        Task<List<TDto>> SaveAsync( List<TDto> creationList, List<TDto> updateList, List<TDto> deleteList );
    }
}