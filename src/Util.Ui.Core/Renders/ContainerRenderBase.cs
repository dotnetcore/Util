using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Builders;

namespace Util.Ui.Renders {
    /// <summary>
    /// 容器渲染器
    /// </summary>
    public abstract class ContainerRenderBase<TTagBuilder> : IContainerRender where TTagBuilder : TagBuilder {
        /// <summary>
        /// 标签生成器
        /// </summary>
        private TTagBuilder _builder;

        /// <summary>
        /// 标签生成器
        /// </summary>
        private TTagBuilder Builder => _builder ?? ( _builder = GetTagBuilder() );

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected abstract TTagBuilder GetTagBuilder();

        /// <summary>
        /// 渲染起始标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public void RenderStartTag( TextWriter writer, HtmlEncoder encoder ) {
            Builder.RenderStartTag( writer, encoder );
        }

        /// <summary>
        /// 渲染结束标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public void RenderEndTag( TextWriter writer, HtmlEncoder encoder ) {
            Builder.RenderEndTag( writer, encoder );
        }

        /// <summary>
        /// 输出组件Html
        /// </summary>
        public override string ToString() {
            return Builder.ToString();
        }
    }
}
