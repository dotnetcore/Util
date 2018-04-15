using Util.Applications.Aspects;
using Util.Applications.Dtos;
using Util.Validations.Aspects;

namespace Util.Applications.Operations {
    /// <summary>
    /// 创建操作
    /// </summary>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    public interface ICreate<in TCreateRequest> where TCreateRequest : IRequest, new() {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        [UnitOfWork]
        string Create( [Valid] TCreateRequest request );
    }
}