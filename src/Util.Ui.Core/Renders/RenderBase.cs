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
        /// 标签生成器
        /// </summary>
        private ITagBuilder _builder;
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

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
        private ITagBuilder Builder => _builder ?? ( _builder = GetTagBuilder() );

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected abstract ITagBuilder GetTagBuilder();

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            Builder.WriteTo( writer, encoder );
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
