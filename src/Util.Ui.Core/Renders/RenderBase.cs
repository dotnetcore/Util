using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Renders {
    /// <summary>
    /// 渲染器
    /// </summary>
    public abstract class RenderBase<TTagBuilder, TConfig> : IRender
        where TTagBuilder : ITagBuilder
        where TConfig : IConfig {
        /// <summary>
        /// 标签生成器
        /// </summary>
        private readonly TTagBuilder _builder;
        /// <summary>
        /// 组件配置
        /// </summary>
        private readonly TConfig _config;

        /// <summary>
        /// 初始化渲染器
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">组件配置</param>
        protected RenderBase( TTagBuilder builder, TConfig config ) {
            _builder = builder;
            _config = config;
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public void Render( TextWriter writer, HtmlEncoder encoder ) {
            RenderOptions();
            Render( _builder, _config );
            _builder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 渲染基础配置
        /// </summary>
        private void RenderOptions() {
            _builder.Id( _config.Id );
            if ( !string.IsNullOrWhiteSpace( _config.Text ) )
                _builder.InnerHtml.Append( _config.Text );
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">组件配置</param>
        protected virtual void Render( TTagBuilder builder, TConfig config ) {
        }
    }
}
