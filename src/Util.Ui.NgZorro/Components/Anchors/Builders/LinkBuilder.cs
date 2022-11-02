using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Anchors.Builders {
    /// <summary>
    /// 链接标签生成器
    /// </summary>
    public class LinkBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化链接标签生成器
        /// </summary>
        public LinkBuilder( Config config ) : base( config, "nz-link" ) {
            _config = config;
        }

        /// <summary>
        /// 配置锚点链接
        /// </summary>
        public LinkBuilder Href() {
            AttributeIfNotEmpty( "nzHref", _config.GetValue( UiConst.Href ) );
            AttributeIfNotEmpty( "[nzHref]", _config.GetValue( AngularConst.BindHref ) );
            return this;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public LinkBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Href().Title();
        }
    }
}