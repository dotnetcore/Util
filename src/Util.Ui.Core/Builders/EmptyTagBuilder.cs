using System.IO;
using System.Text.Encodings.Web;

namespace Util.Ui.Builders {
    /// <summary>
    /// 空标签生成器
    /// </summary>
    public class EmptyTagBuilder : ITagBuilder {
        /// <summary>
        /// 写入流
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">Html编码</param>
        public void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
        }

        /// <summary>
        /// 输出
        /// </summary>
        public override string ToString() {
            return string.Empty;
        }
    }
}
