using System.IO;
using System.Text.Encodings.Web;

namespace Util.Ui.Renders {
    /// <summary>
    /// 容器渲染器
    /// </summary>
    public interface IContainerRender {
        /// <summary>
        /// 渲染起始标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        void RenderStartTag( TextWriter writer, HtmlEncoder encoder );
        /// <summary>
        /// 渲染结束标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        void RenderEndTag( TextWriter writer, HtmlEncoder encoder );
    }
}
