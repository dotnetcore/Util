using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Spaces.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Spaces.Renders {
    /// <summary>
    /// 间距渲染器
    /// </summary>
    public class SpaceRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化间距渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SpaceRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new SpaceBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new SpaceRender( _config.Copy() );
        }
    }
}