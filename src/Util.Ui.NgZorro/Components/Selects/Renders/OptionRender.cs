using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Selects.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Selects.Renders {
    /// <summary>
    /// 选项渲染器
    /// </summary>
    public class OptionRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化选项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public OptionRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new OptionBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new OptionRender( _config.Copy() );
        }
    }
}