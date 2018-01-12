using System.IO;
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
        public void RenderStartTag( TextWriter writer ) {
            Builder.RenderStartTag( writer );
        }

        /// <summary>
        /// 渲染结束标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public void RenderEndTag( TextWriter writer ) {
            Builder.RenderEndTag( writer );
        }

        /// <summary>
        /// 输出组件Html
        /// </summary>
        public override string ToString() {
            return Builder.ToString();
        }
    }
}
