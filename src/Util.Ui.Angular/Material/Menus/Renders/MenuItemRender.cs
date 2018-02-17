using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Icons.Builders;
using Util.Ui.Renders;
using SpanBuilder = Util.Ui.Builders.SpanBuilder;

namespace Util.Ui.Material.Menus.Renders {
    /// <summary>
    /// 菜单项渲染器
    /// </summary>
    public class MenuItemRender : RenderBase {
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
            builder.AddAttribute( "mat-menu-item", "", false );
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
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        private void ConfigContent( TagBuilder builder ) {
            ConfigMaterialIcon( builder );
            ConfigFontAwesomeIcon( builder );
            ConfigText( builder );
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
            iconBuilder.Class( IconSize.Large.Description() );
            iconBuilder.SetIcon( _config );
            builder.AppendContent( iconBuilder );
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        private void ConfigText( TagBuilder builder ) {
            if( _config.Contains( UiConst.Text ) == false )
                return;
            var spanBuilder = new SpanBuilder();
            spanBuilder.SetContent( _config.GetValue( UiConst.Text ) );
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
            builder.AddAttribute( "routerLink", _config.GetValue( UiConst.Link ) );
        }
    }
}