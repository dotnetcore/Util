using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Cards.Builders {
    /// <summary>
    /// 卡片元信息标签生成器
    /// </summary>
    public class CardMetaBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化卡片元信息标签生成器
        /// </summary>
        public CardMetaBuilder( Config config ) : base( "nz-card-meta" ) {
            _config = config;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public CardMetaBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置头像
        /// </summary>
        public CardMetaBuilder Avatar() {
            AttributeIfNotEmpty( "[nzAvatar]", _config.GetValue( UiConst.Avatar ) );
            return this;
        }

        /// <summary>
        /// 配置描述
        /// </summary>
        public CardMetaBuilder Description() {
            AttributeIfNotEmpty( "nzDescription", _config.GetValue( UiConst.Description ) );
            AttributeIfNotEmpty( "[nzDescription]", _config.GetValue( AngularConst.BindDescription ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            Title().Avatar().Description();
        }
    }
}