using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Drawers.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Drawers.Renders {
    /// <summary>
    /// 抽屉渲染器
    /// </summary>
    public class DrawerRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化抽屉渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DrawerRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DrawerBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new DrawerRender( _config.Copy() );
        }
    }
}