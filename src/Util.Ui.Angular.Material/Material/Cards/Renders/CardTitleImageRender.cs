using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;

namespace Util.Ui.Material.Cards.Renders {
    /// <summary>
    /// 卡片标题图片渲染器
    /// </summary>
    public class CardTitleImageRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化卡片标题图片渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CardTitleImageRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ImageBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigSize( builder );
            ConfigSrc( builder );
        }

        /// <summary>
        /// 配置大小
        /// </summary>
        private void ConfigSize( TagBuilder builder ) {
            var size = _config.GetValue<CardTitleImageSize?>( UiConst.Size ) ?? CardTitleImageSize.Middle;
            builder.AddAttribute( size.Description() );
        }

        /// <summary>
        /// 配置路径
        /// </summary>
        private void ConfigSrc( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Src, _config.GetValue( UiConst.Src ) );
        }
    }
}