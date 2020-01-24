using System.Collections.Generic;
using System.Threading.Tasks;

namespace Util.Applications.Operations {
    /// <summary>
    /// 获取指定标识实体
    /// </summary>
    public interface IGetByIdAsync<TDto> where TDto : new() {
        /// <summary>
        /// 通过标识获取
        /// </summary>
        /// <param name="id">实体标识</param>
        Task<TDto> GetByIdAsync( object id );
        /// <summary>
        /// 通过标识列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        Task<List<TDto>> GetByIdsAsync( string ids );
    }
}