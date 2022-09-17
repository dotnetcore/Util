using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Cards.Builders;

namespace Util.Ui.NgZorro.Components.Cards.Renders {
    /// <summary>
    /// 卡片渲染器
    /// </summary>
    public class CardRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化卡片渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CardRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CardBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}