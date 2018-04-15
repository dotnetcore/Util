using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Applications.Dtos;

namespace Util.Applications.Operations {
    /// <summary>
    /// 获取指定标识实体
    /// </summary>
    public interface IGetByIdAsync<TDto> where TDto : IResponse, new() {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        Task<TDto> GetByIdAsync( object id );
        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        Task<List<TDto>> GetByIdsAsync( string ids );
    }
}