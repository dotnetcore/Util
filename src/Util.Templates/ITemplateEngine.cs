using System.Threading.Tasks;

namespace Util.Templates {
    /// <summary>
    /// 模板引擎
    /// </summary>
    public interface ITemplateEngine {
        /// <summary>
        /// 渲染模板
        /// </summary>
        /// <param name="template">模板字符串</param>
        /// <param name="data">模板数据</param>
        string Render( string template, object data = null );
        /// <summary>
        /// 渲染模板
        /// </summary>
        /// <param name="template">模板字符串</param>
        /// <param name="data">模板数据</param>
        Task<string> RenderAsync( string template, object data = null );
    }
}
