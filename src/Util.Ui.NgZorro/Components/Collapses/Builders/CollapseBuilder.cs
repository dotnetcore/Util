using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Collapses.Builders {
    /// <summary>
    /// 折叠标签生成器
    /// </summary>
    public class CollapseBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化折叠标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public CollapseBuilder( Config config ) : base( config,"nz-collapse" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否手风琴
        /// </summary>
        public CollapseBuilder Accordion() {
            AttributeIfNotEmpty( "[nzAccordion]", _config.GetBoolValue( UiConst.Accordion ) );
            AttributeIfNotEmpty( "[nzAccordion]", _config.GetValue( AngularConst.BindAccordion ) );
            return this;
        }

        /// <summary>
        /// 配置是否有边框
        /// </summary>
        public CollapseBuilder Bordered() {
            AttributeIfNotEmpty( "[nzBordered]", _config.GetBoolValue( UiConst.Bordered ) );
            AttributeIfNotEmpty( "[nzBordered]", _config.GetValue( AngularConst.BindBordered ) );
            return this;
        }

        /// <summary>
        /// 配置是否幽灵面板
        /// </summary>
        public CollapseBuilder Ghost() {
            AttributeIfNotEmpty( "[nzGhost]", _config.GetBoolValue( UiConst.Ghost ) );
            AttributeIfNotEmpty( "[nzGhost]", _config.GetValue( AngularConst.BindGhost ) );
            return this;
        }

        /// <summary>
        /// 配置图标位置
        /// </summary>
        public CollapseBuilder ExpandIconPosition() {
            AttributeIfNotEmpty( "nzExpandIconPosition", _config.GetValue<CollapseIconPosition?>( UiConst.ExpandIconPosition )?.Description() );
            AttributeIfNotEmpty( "[nzExpandIconPosition]", _config.GetValue( AngularConst.BindExpandIconPosition ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Accordion().Bordered().Ghost().ExpandIconPosition();
        }
    }
}