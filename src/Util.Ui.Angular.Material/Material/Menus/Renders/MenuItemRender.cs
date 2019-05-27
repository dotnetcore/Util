using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Icons.Builders;

namespace Util.Ui.Material.Menus.Renders {
    /// <summary>
    /// 菜单项渲染器
    /// </summary>
    public class MenuItemRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化菜单项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public MenuItemRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = CreateBuilder();
            builder.AddAttribute( "mat-menu-item" );
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 创建标签生成器
        /// </summary>
        private TagBuilder CreateBuilder() {
            if( _config.Contains( UiConst.Link ) )
                return new AnchorBuilder();
            return new ButtonBuilder();
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigContent( builder );
            ConfigDisabled( builder );
            ConfigEvents( builder );
            ConfigLink( builder );
            ConfigMenu( builder );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            ConfigMaterialIcon( builder );
            ConfigFontAwesomeIcon( builder );
            ConfigLabel( builder );
        }

        /// <summary>
        /// 配置Material图标
        /// </summary>
        private void ConfigMaterialIcon( TagBuilder builder ) {
            if( _config.Contains( UiConst.MaterialIcon ) == false )
                return;
            var iconBuilder = new MaterialIconBuilder();
            iconBuilder.SetIcon( _config );
            builder.AppendContent( iconBuilder );
        }

        /// <summary>
        /// 配置FontAwesome图标
        /// </summary>
        private void ConfigFontAwesomeIcon( TagBuilder builder ) {
            if( _config.Contains( UiConst.FontAwesomeIcon ) == false )
                return;
            var iconBuilder = new FontAwesomeIconBuilder();
            iconBuilder.SetIcon( _config );
            builder.AppendContent( iconBuilder );
        }

        /// <summary>
        /// 配置标签
        /// </summary>
        private void ConfigLabel( TagBuilder builder ) {
            if( _config.Contains( UiConst.Label ) == false )
                return;
            var spanBuilder = new SpanBuilder();
            spanBuilder.SetContent( _config.GetValue( UiConst.Label ) );
            builder.AppendContent( spanBuilder );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(click)", _config.GetValue( UiConst.OnClick ) );
        }

        /// <summary>
        /// 配置链接
        /// </summary>
        private void ConfigLink( TagBuilder builder ) {
            builder.Link( _config );
        }

        /// <summary>
        /// 配置子菜单
        /// </summary>
        private void ConfigMenu( TagBuilder builder ) {
            builder.AddAttribute( "[matMenuTriggerFor]", _config.GetValue( MaterialConst.MenuId ) );
        }
    }
}