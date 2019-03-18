using System.Linq;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Buttons.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Menus;

namespace Util.Ui.Material.Buttons.Renders {
    /// <summary>
    /// 按钮渲染器
    /// </summary>
    public class ButtonRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly ButtonConfig _config;

        /// <summary>
        /// 初始化按钮渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ButtonRender( ButtonConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ButtonBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigText( builder );
            ConfigType( builder );
            ConfigStyle( builder );
            ConfigColor( builder );
            ConfigDisabled( builder );
            ConfigTooltip( builder );
            ConfigMenu( builder );
            ConfigCloseDialog( builder );
            ConfigContent( builder );
            ConfigEvents( builder );
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        private void ConfigText( TagBuilder builder ) {
            if( _config.Contains( UiConst.Text ) )
                builder.SetContent( _config.GetValue( UiConst.Text ) );
            if( _config.Contains( AngularConst.BindText ) )
                builder.SetContent( $"{{{{{_config.GetValue( AngularConst.BindText )}}}}}" );
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        private void ConfigType( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Type, "button" );
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        private void ConfigStyle( TagBuilder builder ) {
            if( _config.Contains( UiConst.Styles ) ) {
                builder.AddAttribute( _config.GetValue<ButtonStyle?>( UiConst.Styles )?.Description() );
                return;
            }
            builder.AddAttribute( ButtonStyle.Raised.Description() );
        }

        /// <summary>
        /// 配置颜色
        /// </summary>
        private void ConfigColor( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Color, _config.GetValue( UiConst.Color ).ToLower() );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
        }

        /// <summary>
        /// 配置提示
        /// </summary>
        private void ConfigTooltip( TagBuilder builder ) {
            builder.AddAttribute( "matTooltip", _config.GetValue( UiConst.Tooltip ) );
        }

        /// <summary>
        /// 配置菜单
        /// </summary>
        private void ConfigMenu( TagBuilder builder ) {
            builder.AddAttribute( "[matMenuTriggerFor]", _config.GetValue( MaterialConst.MenuId ) );
            AddMenus( builder );
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        private void AddMenus( TagBuilder builder ) {
            _config.Data?.Select( data => new Menu().Data( data ) ).ToList()
                .ForEach( menu => builder.AppendContent( menu ) );
        }

        /// <summary>
        /// 配置关闭弹出层
        /// </summary>
        private void ConfigCloseDialog( TagBuilder builder ) {
            if( _config.Contains( MaterialConst.CloseDialog ) )
                builder.AddAttribute( "mat-dialog-close", _config.GetValue( MaterialConst.CloseDialog ),false );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            if( _config.Contains( UiConst.Text ) || _config.Contains( AngularConst.BindText ) )
                return;
            builder.AppendContent( _config.Content );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(click)", _config.GetValue( UiConst.OnClick ) );
        }
    }
}