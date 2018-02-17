using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Renders {
    /// <summary>
    /// 渲染器
    /// </summary>
    public abstract class RenderBase : IRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;
        /// <summary>
        /// 标签生成器
        /// </summary>
        private TagBuilder _builder;

        /// <summary>
        /// 初始化渲染器
        /// </summary>
        /// <param name="config">配置</param>
        protected RenderBase( IConfig config ) {
            _config = config;
        }

        /// <summary>
        /// 标签生成器
        /// </summary>
        protected TagBuilder Builder => _builder ?? ( _builder = GetTagBuilder() );

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
        /// 渲染起始标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public virtual void RenderStartTag( TextWriter writer ) {
            Builder.RenderStartTag( writer );
        }

        /// <summary>
        /// 渲染结束标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public virtual void RenderEndTag( TextWriter writer ) {
            Builder.RenderEndTag( writer );
        }

        /// <summary>
        /// 输出组件Html
        /// </summary>
        public override string ToString() {
            var validateMessage = _config.Validate();
            return string.IsNullOrWhiteSpace( validateMessage ) ? Builder.ToString() : $"验证失败：{validateMessage}";
        }
    }
}
