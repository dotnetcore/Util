using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tabs.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Tabs.Renders {
    /// <summary>
    /// 标签渲染器
    /// </summary>
    public class TabRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化标签渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TabRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TabBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TabRender( _config.Copy() );
        }
    }
}