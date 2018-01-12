using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Renders {
    /// <summary>
    /// 容器渲染器
    /// </summary>
    public abstract class ContainerRenderBase :IRender, IContainerRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 标签生成器
        /// </summary>
        private TagBuilder _builder;

        /// <summary>
        /// 初始化表单渲染器
        /// </summary>
        /// <param name="config">配置</param>
        protected ContainerRenderBase( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 标签生成器
        /// </summary>
        private TagBuilder Builder => _builder ?? ( _builder = GetTagBuilder() );

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected abstract TagBuilder GetTagBuilder();

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            Builder.SetContent( _config.Content );
            Builder.WriteTo( writer, encoder );
        }

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
