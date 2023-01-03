using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Descriptions.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Descriptions.Renders {
    /// <summary>
    /// 描述列表渲染器
    /// </summary>
    public class DescriptionRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化描述列表渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DescriptionRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DescriptionBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new DescriptionRender( _config.Copy() );
        }
    }
}
