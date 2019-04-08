using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;

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
            InitBuilder( Builder );
            Builder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 初始化生成器
        /// </summary>
        /// <param name="builder">标签生成器</param>
        protected virtual void InitBuilder( TagBuilder builder ) {
        }

        /// <summary>
        /// 渲染起始标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public virtual void RenderStartTag( TextWriter writer ) {
            InitBuilder( Builder );
            Builder.RenderStartTag( writer );
            if( Builder.HasInnerHtml )
                Builder.RenderBody( writer );
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
            using( var writer = new StringWriter() ) {
                WriteTo( writer, NullHtmlEncoder.Default );
                return string.IsNullOrWhiteSpace( validateMessage ) ? writer.ToString() : $"验证失败：{validateMessage}";
            }
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected virtual void ConfigContent( TagBuilder builder ) {
            if( _config.Content.IsEmpty() )
                return;
            builder.AppendContent( _config.Content );
        }
    }
}
