using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Collapses.Builders {
    /// <summary>
    /// 折叠面板标签生成器
    /// </summary>
    public class CollapsePanelBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化折叠面板标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public CollapsePanelBuilder( Config config ) : base( config,"nz-collapse-panel" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否禁用
        /// </summary>
        public CollapsePanelBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置面板头内容
        /// </summary>
        public CollapsePanelBuilder Header() {
            AttributeIfNotEmpty( "nzHeader", _config.GetValue( UiConst.Header ) );
            AttributeIfNotEmpty( "[nzHeader]", _config.GetValue( AngularConst.BindHeader ) );
            return this;
        }

        /// <summary>
        /// 配置图标
        /// </summary>
        public CollapsePanelBuilder ExpandedIcon() {
            AttributeIfNotEmpty( "nzExpandedIcon", _config.GetValue<AntDesignIcon?>( UiConst.ExpandedIcon )?.Description() );
            AttributeIfNotEmpty( "[nzExpandedIcon]", _config.GetValue( AngularConst.BindExpandedIcon ) );
            return this;
        }

        /// <summary>
        /// 配置右上角额外内容
        /// </summary>
        public CollapsePanelBuilder Extra() {
            AttributeIfNotEmpty( "nzExtra", _config.GetValue( UiConst.Extra ) );
            AttributeIfNotEmpty( "[nzExtra]", _config.GetValue( AngularConst.BindExtra ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示箭头
        /// </summary>
        public CollapsePanelBuilder ShowArrow() {
            AttributeIfNotEmpty( "[nzShowArrow]", _config.GetBoolValue( UiConst.ShowArrow ) );
            AttributeIfNotEmpty( "[nzShowArrow]", _config.GetValue( AngularConst.BindShowArrow ) );
            return this;
        }

        /// <summary>
        /// 配置是否展开面板
        /// </summary>
        public CollapsePanelBuilder Active() {
            AttributeIfNotEmpty( "[nzActive]", _config.GetBoolValue( UiConst.Active ) );
            AttributeIfNotEmpty( "[nzActive]", _config.GetValue( AngularConst.BindActive ) );
            AttributeIfNotEmpty( "[(nzActive)]", _config.GetValue( AngularConst.BindonActive ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public CollapsePanelBuilder Events() {
            AttributeIfNotEmpty( "(nzActiveChange)", _config.GetValue( UiConst.OnActiveChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Disabled().Header().ExpandedIcon().Extra().ShowArrow().Active().Events();
        }
    }
}