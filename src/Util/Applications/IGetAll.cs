using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Applications.Dtos;

namespace Util.Applications {
    /// <summary>
    /// 获取全部数据
    /// </summary>
    public interface IGetAll<TDto> where TDto : IDto, new() {
        /// <summary>
        /// 获取全部
        /// </summary>
        List<TDto> GetAll();
        /// <summary>
        /// 获取全部
        /// </summary>
        Task<List<TDto>> GetAllAsync();
    }
}
