using System.Threading.Tasks;
using Util.Dependency;

namespace Util.Samples.RazorPageExtensions {
    /// <summary>
    /// Html生成器
    /// </summary>
    public interface IHtmlGenerator : IScopeDependency {
        /// <summary>
        /// 构建并生成Html
        /// </summary>
        Task BuildAsync();
    }
}