using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Cards.Builders {
    /// <summary>
    /// 网格内嵌卡片标签生成器
    /// </summary>
    public class CardGridBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化网格内嵌卡片标签生成器
        /// </summary>
        public CardGridBuilder( Config config ) : base( "div" ) {
            base.Attribute( "nz-card-grid" );
            _config = config;
        }

        /// <summary>
        /// 配置鼠标滑过时是否可浮起
        /// </summary>
        public CardGridBuilder Hoverable() {
            AttributeIfNotEmpty( "[nzHoverable]", _config.GetBoolValue( UiConst.Hoverable ) );
            AttributeIfNotEmpty( "[nzHoverable]", _config.GetValue( AngularConst.BindHoverable ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            Hoverable();
        }
    }
}