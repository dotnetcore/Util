using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus.Builders;

namespace Util.Ui.NgZorro.Components.Menus.Renders {
    /// <summary>
    /// 菜单项渲染器
    /// </summary>
    public class MenuItemRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化菜单项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public MenuItemRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new MenuItemBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigDisabled( builder );
            ConfigSelected( builder );
            ConfigDanger( builder );
            ConfigMatchRouter( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            builder.AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
        }

        /// <summary>
        /// 配置选中
        /// </summary>
        private void ConfigSelected( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzSelected]", _config.GetBoolValue( UiConst.Selected ) );
            builder.AttributeIfNotEmpty( "[nzSelected]", _config.GetValue( AngularConst.BindSelected ) );
        }

        /// <summary>
        /// 配置危险状态
        /// </summary>
        private void ConfigDanger( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzDanger]", _config.GetBoolValue( UiConst.Danger ) );
            builder.AttributeIfNotEmpty( "[nzDanger]", _config.GetValue( AngularConst.BindDanger ) );
        }

        /// <summary>
        /// 配置匹配路由
        /// </summary>
        private void ConfigMatchRouter( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzMatchRouter]", _config.GetBoolValue( UiConst.MatchRouter ) );
            builder.AttributeIfNotEmpty( "[nzMatchRouter]", _config.GetValue( AngularConst.BindMatchRouter ) );
            builder.AttributeIfNotEmpty( "[nzMatchRouterExact]", _config.GetBoolValue( UiConst.MatchRouterExact ) );
            builder.AttributeIfNotEmpty( "[nzMatchRouterExact]", _config.GetValue( AngularConst.BindMatchRouterExact ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.OnClick( _config );
        }
    }
}