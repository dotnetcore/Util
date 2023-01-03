using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Layouts.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Layouts.Renders {
    /// <summary>
    /// 内容区布局渲染器
    /// </summary>
    public class ContentRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化内容区布局渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ContentRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ContentBuilder(_config);
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new ContentRender( _config.Copy() );
        }
    }
}