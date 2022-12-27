using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;

namespace Util.Ui.Renders {
    /// <summary>
    /// 渲染器
    /// </summary>
    public abstract class RenderBase : IHtmlContent {
        /// <summary>
        /// 标签生成器
        /// </summary>
        private TagBuilder _builder;

        /// <summary>
        /// 初始化渲染器
        /// </summary>
        protected RenderBase() {
        }

        /// <summary>
        /// 标签生成器
        /// </summary>
        protected TagBuilder Builder => _builder ??= GetTagBuilder();

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected abstract TagBuilder GetTagBuilder();

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public virtual void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            Builder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 输出组件Html
        /// </summary>
        public override string ToString() {
            using var writer = new StringWriter();
            WriteTo( writer, NullHtmlEncoder.Default );
            return writer.ToString();
        }
    }
}
