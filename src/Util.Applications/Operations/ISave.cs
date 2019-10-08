using Util.Applications.Aspects;
using Util.Applications.Dtos;
using Util.Validations.Aspects;

namespace Util.Applications.Operations {
    /// <summary>
    /// 保存操作
    /// </summary>
    /// <typeparam name="TRequest">参数类型</typeparam>
    public interface ISave<in TRequest> where TRequest : IRequest, IKey, new() {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="request">参数</param>
        [UnitOfWork]
        void Save( [Valid] TRequest request );
    }
}