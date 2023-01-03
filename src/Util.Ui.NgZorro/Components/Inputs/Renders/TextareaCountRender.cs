using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Inputs.Renders {
    /// <summary>
    /// 文本域计数渲染器
    /// </summary>
    public class TextareaCountRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化文本域计数渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TextareaCountRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TextareaCountBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TextareaCountRender( _config.Copy() );
        }
    }
}