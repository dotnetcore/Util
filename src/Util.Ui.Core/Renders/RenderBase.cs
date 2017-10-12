using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Renders {
    /// <summary>
    /// 渲染器
    /// </summary>
    public abstract class RenderBase<TTagBuilder, TConfig> : IRender
        where TTagBuilder : TagBuilder
        where TConfig : IConfig {
        /// <summary>
        /// 标签生成器
        /// </summary>
        private TTagBuilder _builder;
        /// <summary>
        /// 组件配置
        /// </summary>
        private readonly TConfig _config;

        /// <summary>
        /// 初始化渲染器
        /// </summary>
        /// <param name="config">组件配置</param>
        protected RenderBase( TConfig config ) {
            _config = config;
        }

        /// <summary>
        /// 标签生成器
        /// </summary>
        private TTagBuilder Builder => _builder ?? ( _builder = GetTagBuilder() );

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected abstract TTagBuilder GetTagBuilder();

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public void Render( TextWriter writer, HtmlEncoder encoder ) {
            Render( Builder, _config );
            Builder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">组件配置</param>
        protected virtual void Render( TTagBuilder builder, TConfig config ) {
        }

        /// <summary>
        /// 输出组件Html
        /// </summary>
        public override string ToString() {
            return Builder.ToString();
        }
    }
}
