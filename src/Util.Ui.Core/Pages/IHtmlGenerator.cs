using System.Threading.Tasks;
using Util.Dependency;

namespace Util.Ui.Pages {
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
