using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Cards.Builders;
using Util.Ui.Material.Enums;
using Util.Ui.Renders;

namespace Util.Ui.Material.Cards.Renders {
    /// <summary>
    /// 卡片操作渲染器
    /// </summary>
    public class CardActionRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化卡片操作渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CardActionRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CardActionBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigAlign( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置对齐方式
        /// </summary>
        private void ConfigAlign( TagBuilder builder ) {
            if( _config.Contains( UiConst.Align ) == false )
                return;
            builder.AddAttribute( UiConst.Align, _config.GetValue<XPosition>( UiConst.Align ) == XPosition.Left ? "start" : "end" );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        private void ConfigContent( TagBuilder builder ) {
            if( _config.Content == null )
                return;
            builder.SetContent( _config.Content );
        }
    }
}