using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Enums;

namespace Util.Ui.Material.Buttons.Renders {
    /// <summary>
    /// 链接渲染器
    /// </summary>
    public class AnchorRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化链接渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public AnchorRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new AnchorBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigText( builder );
            ConfigStyle( builder );
            ConfigColor( builder );
            ConfigDisabled( builder );
            ConfigTooltip( builder );
            ConfigLink( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
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
        /// 配置链接
        /// </summary>
        private void ConfigLink( TagBuilder builder ) {
            builder.Link( _config );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(click)", _config.GetValue( UiConst.OnClick ) );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            if( _config.Contains( UiConst.Text ) || _config.Contains( AngularConst.BindText ) )
                return;
            builder.SetContent( _config.Content );
        }
    }
}