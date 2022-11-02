using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Badges.Builders {
    /// <summary>
    /// 缎带徽标标签生成器
    /// </summary>
    public class RibbonBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化缎带徽标标签生成器
        /// </summary>
        public RibbonBuilder( Config config ) : base( config,"nz-ribbon" ) {
            _config = config;
        }

        /// <summary>
        /// 配置颜色
        /// </summary>
        public RibbonBuilder Color() {
            AttributeIfNotEmpty( "nzColor", _config.GetValue( UiConst.Color ) );
            AttributeIfNotEmpty( "[nzColor]", _config.GetValue( AngularConst.BindColor ) );
            return this;
        }

        /// <summary>
        /// 配置位置
        /// </summary>
        public RibbonBuilder Placement() {
            AttributeIfNotEmpty( "nzPlacement", _config.GetValue<RibbonPlacement?>( UiConst.Placement )?.Description() );
            AttributeIfNotEmpty( "[nzPlacement]", _config.GetValue( AngularConst.BindPlacement ) );
            return this;
        }

        /// <summary>
        /// 配置文本内容
        /// </summary>
        public RibbonBuilder Text() {
            AttributeIfNotEmpty( "nzText", _config.GetValue( UiConst.Text ) );
            AttributeIfNotEmpty( "[nzText]", _config.GetValue( AngularConst.BindText ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Color().Placement().Text();
        }
    }
}