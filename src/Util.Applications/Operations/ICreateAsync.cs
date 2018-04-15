using System.Threading.Tasks;
using Util.Applications.Aspects;
using Util.Applications.Dtos;
using Util.Validations.Aspects;

namespace Util.Applications.Operations {
    /// <summary>
    /// 创建操作
    /// </summary>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    public interface ICreateAsync<in TCreateRequest> where TCreateRequest : IRequest, new() {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        [UnitOfWork]
        Task<string> CreateAsync( [Valid] TCreateRequest request );
    }
}