using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Cards.Builders;

namespace Util.Ui.Material.Cards.Renders {
    /// <summary>
    /// 卡片头像渲染器
    /// </summary>
    public class CardAvatarRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化卡片头像渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CardAvatarRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CardAvatarBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigSrc( builder );
        }

        /// <summary>
        /// 配置路径
        /// </summary>
        private void ConfigSrc( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Src, _config.GetValue( UiConst.Src ) );
        }
    }
}