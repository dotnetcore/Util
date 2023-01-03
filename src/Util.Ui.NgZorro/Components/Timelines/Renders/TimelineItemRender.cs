using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Timelines.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Timelines.Renders {
    /// <summary>
    /// 时间轴节点渲染器
    /// </summary>
    public class TimelineItemRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化时间轴节点渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TimelineItemRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TimelineItemBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TimelineItemRender( _config.Copy() );
        }
    }
}