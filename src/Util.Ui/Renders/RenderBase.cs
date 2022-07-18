using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;

namespace Util.Ui.Renders {
    /// <summary>
    /// 渲染器
    /// </summary>
    public abstract class RenderBase : IHtmlContent {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 标签生成器
        /// </summary>
        private TagBuilder _builder;

        /// <summary>
        /// 初始化渲染器
        /// </summary>
        /// <param name="config">配置</param>
        protected RenderBase( Config config ) {
            _config = config;
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
            ConfigBuilder( Builder );
            Builder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 配置标签生成器
        /// </summary>
        /// <param name="builder">标签生成器</param>
        protected virtual void ConfigBuilder( TagBuilder builder ) {
            ConfigStyle( builder );
            ConfigClass( builder );
            ConfigHidden( builder );
            ConfigOutputAttributes( builder );
        }

        /// <summary>
        /// 配置样式
        /// </summary>
        /// <param name="builder">标签生成器</param>
        protected virtual void ConfigStyle( TagBuilder builder ) {
            builder.Style( _config );
        }

        /// <summary>
        /// 配置样式类
        /// </summary>
        /// <param name="builder">标签生成器</param>
        protected virtual void ConfigClass( TagBuilder builder ) {
            builder.Class( _config );
        }

        /// <summary>
        /// 配置隐藏
        /// </summary>
        /// <param name="builder">标签生成器</param>
        protected virtual void ConfigHidden( TagBuilder builder ) {
            builder.Hidden( _config );
        }

        /// <summary>
        /// 配置输出属性
        /// </summary>
        /// <param name="builder">标签生成器</param>
        protected virtual void ConfigOutputAttributes( TagBuilder builder ) {
            builder.Attributes( _config.OutputAttributes );
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
