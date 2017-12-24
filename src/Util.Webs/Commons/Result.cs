using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Util.Webs.Commons {
    /// <summary>
    /// 返回结果
    /// </summary>
    public class Result : JsonResult {
        /// <summary>
        /// 状态码
        /// </summary>
        private readonly StateCode _code;
        /// <summary>
        /// 消息
        /// </summary>
        private readonly string _message;
        /// <summary>
        /// 数据
        /// </summary>
        private readonly dynamic _data;

        /// <summary>
        /// 初始化返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        public Result( StateCode code, string message, dynamic data = null ) : base( null ) {
            _code = code;
            _message = message;
            _data = data;
        }

        /// <summary>
        /// 执行结果
        /// </summary>
        public override Task ExecuteResultAsync( ActionContext context ) {
            this.Value = new {
                Code = _code.Value(),
                Message = _message,
                Data = _data
            };
            return base.ExecuteResultAsync( context );
        }
    }
}
