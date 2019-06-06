using System.Threading.Tasks;

namespace Util.Ui.Pages
{
    /// <summary>
    /// Html生成器
    /// </summary>
    public interface IHtmlGenerator
    {
        /// <summary>
        /// 构建并生成Html
        /// </summary>
        Task BuildAsync();
    }
}
