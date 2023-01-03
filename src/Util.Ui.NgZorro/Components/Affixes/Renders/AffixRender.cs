using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Affixes.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Affixes.Renders {
    /// <summary>
    /// 固钉渲染器
    /// </summary>
    public class AffixRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化固钉渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public AffixRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new AffixBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new AffixRender( _config.Copy() );
        }
    }
}