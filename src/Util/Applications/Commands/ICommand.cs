using System.Threading.Tasks;
using Util.Applications.Dtos;

namespace Util.Applications.Commands {
    /// <summary>
    /// 命令
    /// </summary>
    /// <typeparam name="TRequest">请求类型</typeparam>
    /// <typeparam name="TResponse">响应类型</typeparam>
    public interface ICommand<in TRequest, TResponse> where TRequest : IRequest where TResponse : IResponse {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="request">请求参数</param>
        TResponse Execute( TRequest request );
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="request">请求参数</param>
        Task<TResponse> ExecuteAsync( TRequest request );
    }
}
