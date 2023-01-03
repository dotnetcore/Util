using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Cards.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Cards.Renders {
    /// <summary>
    /// 网格内嵌卡片渲染器
    /// </summary>
    public class CardGridRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化网格内嵌卡片渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CardGridRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CardGridBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new CardGridRender( _config.Copy() );
        }
    }
}