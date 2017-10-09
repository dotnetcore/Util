using System.IO;
using System.Text.Encodings.Web;

namespace Util.Ui.Renders {
    /// <summary>
    /// 渲染器
    /// </summary>
    public interface IRender {
        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        void Render( TextWriter writer, HtmlEncoder encoder );
    }
}