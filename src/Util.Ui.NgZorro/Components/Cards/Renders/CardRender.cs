using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Cards.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Cards.Renders {
    /// <summary>
    /// 卡片渲染器
    /// </summary>
    public class CardRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化卡片渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CardRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CardBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new CardRender( _config.Copy() );
        }
    }
}