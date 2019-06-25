using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Cards.Builders;

namespace Util.Ui.Zorro.Cards.Renders {
    /// <summary>
    /// 卡片渲染器
    /// </summary>
    public class CardRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化卡片渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CardRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CardBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigTitle( builder );
            ConfigShowBorder( builder );
            ConfigActions( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigTitle( TagBuilder builder ) {
            builder.AddAttribute( "nzTitle", _config.GetValue( UiConst.Title ) );
        }

        /// <summary>
        /// 配置显示边框
        /// </summary>
        private void ConfigShowBorder( TagBuilder builder ) {
            builder.AddAttribute( "[nzBordered]", _config.GetBoolValue( UiConst.ShowBorder ) );
        }

        /// <summary>
        /// 配置操作组
        /// </summary>
        private void ConfigActions( TagBuilder builder ) {
            builder.AddAttribute( "[nzActions]", _config.GetValue( UiConst.Actions ) );
        }
    }
}