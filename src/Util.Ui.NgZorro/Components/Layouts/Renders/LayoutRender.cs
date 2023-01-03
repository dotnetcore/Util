using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Layouts.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Layouts.Renders {
    /// <summary>
    /// 布局渲染器
    /// </summary>
    public class LayoutRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化布局渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public LayoutRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new LayoutBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new LayoutRender( _config.Copy() );
        }
    }
}