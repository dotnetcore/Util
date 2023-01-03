using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Collapses.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Collapses.Renders {
    /// <summary>
    /// 折叠面板渲染器
    /// </summary>
    public class CollapsePanelRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化折叠面板渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CollapsePanelRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CollapsePanelBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new CollapsePanelRender( _config.Copy() );
        }
    }
}