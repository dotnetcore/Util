using System.Net.Http;

namespace Util.Http {
    /// <summary>
    /// Http响应消息扩展
    /// </summary>
    public static class HttpResponseMessageExtensions {
        /// <summary>
        /// 获取内容类型
        /// </summary>
        /// <param name="response">Http响应消息</param>
        public static string GetContentType( this HttpResponseMessage response )  {
            return response?.Content.Headers.ContentType?.MediaType;
        }
    }
}
