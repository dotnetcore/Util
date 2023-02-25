using System.Threading.Tasks;
using Util.Generators.Contexts;

namespace Util.Generators.Templates {
    /// <summary>
    /// 模板
    /// </summary>
    public interface ITemplate {
        /// <summary>
        /// 模板路径
        /// </summary>
        string Path { get; }
        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="context">实体上下文</param>
        Task<string> RenderAsync( EntityContext context );
    }
}
