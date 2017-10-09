using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Renders;

namespace Util.Ui.Components {
    /// <summary>
    /// 组件
    /// </summary>
    public abstract class ComponentBase : OptionBase, IComponent {
        /// <summary>
        /// 写入文本流
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            RenderBefore( writer, encoder );
            Render( writer , encoder );
            RenderAfter( writer, encoder );
        }

        /// <summary>
        /// 渲染前操作
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        protected virtual void RenderBefore( TextWriter writer, HtmlEncoder encoder ) {
        }

        /// <summary>
        /// 渲染操作
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        private void Render( TextWriter writer, HtmlEncoder encoder ) {
            GetRender().Render( writer, encoder );
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        protected abstract IRender GetRender();

        /// <summary>
        /// 渲染后操作
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        protected virtual void RenderAfter( TextWriter writer, HtmlEncoder encoder ) {
        }
    }
}
