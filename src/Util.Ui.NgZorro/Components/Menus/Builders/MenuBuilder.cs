using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Menus.Builders {
    /// <summary>
    /// 菜单标签生成器
    /// </summary>
    public class MenuBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化菜单标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public MenuBuilder( Config config ) : base( config, "ul" ) {
            _config = config;
            base.Attribute( "nz-menu" );
        }

        /// <summary>
        /// 配置模式
        /// </summary>
        public MenuBuilder Model() {
            AttributeIfNotEmpty( "nzMode", _config.GetValue<MenuMode?>( UiConst.Mode )?.Description() );
            AttributeIfNotEmpty( "[nzMode]", _config.GetValue( AngularConst.BindMode ) );
            return this;
        }

        /// <summary>
        /// 配置允许选中
        /// </summary>
        public MenuBuilder Selectable() {
            AttributeIfNotEmpty( "[nzSelectable]", _config.GetBoolValue( UiConst.Selectable ) );
            AttributeIfNotEmpty( "[nzSelectable]", _config.GetBoolValue( AngularConst.BindSelectable ) );
            return this;
        }

        /// <summary>
        /// 配置主题
        /// </summary>
        public MenuBuilder Theme() {
            AttributeIfNotEmpty( "nzTheme", _config.GetValue<MenuTheme?>( UiConst.Theme )?.Description() );
            AttributeIfNotEmpty( "[nzTheme]", _config.GetValue( AngularConst.BindTheme ) );
            return this;
        }

        /// <summary>
        /// 配置内嵌模式折叠状态
        /// </summary>
        public MenuBuilder InlineCollapsed() {
            AttributeIfNotEmpty( "[nzInlineCollapsed]", _config.GetBoolValue( UiConst.InlineCollapsed ) );
            AttributeIfNotEmpty( "[nzInlineCollapsed]", _config.GetValue( AngularConst.BindInlineCollapsed ) );
            return this;
        }

        /// <summary>
        /// 配置内嵌模式缩进宽度
        /// </summary>
        public MenuBuilder InlineIndent() {
            AttributeIfNotEmpty( "[nzInlineIndent]", _config.GetValue( UiConst.InlineIndent ) );
            AttributeIfNotEmpty( "[nzInlineIndent]", _config.GetValue( AngularConst.BindInlineIndent ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public MenuBuilder Events() {
            AttributeIfNotEmpty( "(nzClick)", _config.GetValue( UiConst.OnClick ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Model().Selectable().Theme()
                .InlineCollapsed().InlineIndent()
                .Events();
        }
    }
}