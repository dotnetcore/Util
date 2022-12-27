using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Menus.Builders {
    /// <summary>
    /// 菜单项标签生成器
    /// </summary>
    public class MenuItemBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化菜单项标签生成器
        /// </summary>
        public MenuItemBuilder( Config config ) : base( config,"li" ) {
            _config = config;
            base.Attribute( "nz-menu-item" );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public MenuItemBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置选中
        /// </summary>
        public MenuItemBuilder Selected() {
            AttributeIfNotEmpty( "[nzSelected]", _config.GetBoolValue( UiConst.Selected ) );
            AttributeIfNotEmpty( "[nzSelected]", _config.GetValue( AngularConst.BindSelected ) );
            return this;
        }

        /// <summary>
        /// 配置危险状态
        /// </summary>
        public MenuItemBuilder Danger() {
            AttributeIfNotEmpty( "[nzDanger]", _config.GetBoolValue( UiConst.Danger ) );
            AttributeIfNotEmpty( "[nzDanger]", _config.GetValue( AngularConst.BindDanger ) );
            return this;
        }

        /// <summary>
        /// 配置匹配路由
        /// </summary>
        public MenuItemBuilder MatchRouter() {
            AttributeIfNotEmpty( "[nzMatchRouter]", _config.GetBoolValue( UiConst.MatchRouter ) );
            AttributeIfNotEmpty( "[nzMatchRouter]", _config.GetValue( AngularConst.BindMatchRouter ) );
            AttributeIfNotEmpty( "[nzMatchRouterExact]", _config.GetBoolValue( UiConst.MatchRouterExact ) );
            AttributeIfNotEmpty( "[nzMatchRouterExact]", _config.GetValue( AngularConst.BindMatchRouterExact ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public MenuItemBuilder Events() {
            this.OnClick( _config );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Disabled().Selected().Danger().MatchRouter().Events();
        }
    }
}