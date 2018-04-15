using System.Collections.Generic;
using Util.Applications.Dtos;

namespace Util.Applications.Operations {
    /// <summary>
    /// 获取指定标识实体
    /// </summary>
    public interface IGetById<TDto> where TDto : IResponse, new() {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        TDto GetById( object id );
        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        List<TDto> GetByIds( string ids );
    }
}