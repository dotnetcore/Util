using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus.Builders;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Menus.Renders {
    /// <summary>
    /// 菜单渲染器
    /// </summary>
    public class MenuRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化菜单渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public MenuRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new MenuBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigModel( builder );
            ConfigSelectable( builder );
            ConfigTheme( builder );
            ConfigInlineCollapsed( builder );
            ConfigInlineIndent( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置模式
        /// </summary>
        private void ConfigModel( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzMode", _config.GetValue<MenuMode?>( UiConst.Mode )?.Description() );
            builder.AttributeIfNotEmpty( "[nzMode]", _config.GetValue( AngularConst.BindMode ) );
        }

        /// <summary>
        /// 配置允许选中
        /// </summary>
        private void ConfigSelectable( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzSelectable]", _config.GetBoolValue( UiConst.Selectable ) );
            builder.AttributeIfNotEmpty( "[nzSelectable]", _config.GetBoolValue( AngularConst.BindSelectable ) );
        }

        /// <summary>
        /// 配置主题
        /// </summary>
        private void ConfigTheme( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzTheme", _config.GetValue<MenuTheme?>( UiConst.Theme )?.Description() );
            builder.AttributeIfNotEmpty( "[nzTheme]", _config.GetValue( AngularConst.BindTheme ) );
        }

        /// <summary>
        /// 配置内嵌模式折叠状态
        /// </summary>
        private void ConfigInlineCollapsed( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzInlineCollapsed]", _config.GetBoolValue( UiConst.InlineCollapsed ) );
            builder.AttributeIfNotEmpty( "[nzInlineCollapsed]", _config.GetValue( AngularConst.BindInlineCollapsed ) );
        }

        /// <summary>
        /// 配置内嵌模式缩进宽度
        /// </summary>
        private void ConfigInlineIndent( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzInlineIndent]", _config.GetValue( UiConst.InlineIndent ) );
            builder.AttributeIfNotEmpty( "[nzInlineIndent]", _config.GetValue( AngularConst.BindInlineIndent ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "(nzClick)", _config.GetValue( UiConst.OnClick ) );
        }
    }
}