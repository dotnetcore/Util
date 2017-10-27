using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Util.Ui.Services {
    /// <summary>
    /// Ui上下文
    /// </summary>
    public interface IContext {
        /// <summary>
        /// HtmlHelper
        /// </summary>
        IHtmlHelper Helper { get; }
        /// <summary>
        /// Html编码
        /// </summary>
        HtmlEncoder Encoder { get; }
    }
}
