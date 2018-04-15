using Util.Applications.Aspects;
using Util.Applications.Dtos;
using Util.Validations.Aspects;

namespace Util.Applications.Operations {
    /// <summary>
    /// 修改操作
    /// </summary>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    public interface IUpdate<in TUpdateRequest> where TUpdateRequest : IRequest, new() {
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        [UnitOfWork]
        void Update( [Valid] TUpdateRequest request );
    }
}