using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Buttons.Builders;
using Util.Ui.Material.Commons.Builders;
using Util.Ui.Renders;
using Util.Ui.Material.Enums;

namespace Util.Ui.Material.Buttons.Renders {
    /// <summary>
    /// 按钮渲染器
    /// </summary>
    public class ButtonRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化按钮渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ButtonRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ButtonWrapperBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigText( builder );
            ConfigType( builder );
            ConfigStyle( builder );
            ConfigColor( builder );
            ConfigDisabled( builder );
            ConfigTooltip( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        private void ConfigId( TagBuilder builder ) {
            if( _config.Contains( UiConst.Id ) )
                builder.AddAttribute( $"#{_config.GetValue( UiConst.Id )}", "", false );
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        private void ConfigText( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Text, _config.GetValue( UiConst.Text ) );
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        private void ConfigType( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Type, _config.GetValue( UiConst.Type ).ToLower() );
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        private void ConfigStyle( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Style, _config.GetValue<ButtonStyle?>( UiConst.Styles )?.Description() );
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
            builder.AddAttribute( UiConst.Tooltip, _config.GetValue( UiConst.Tooltip ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(onClick)", _config.GetValue( UiConst.OnClick ) );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        private void ConfigContent( TagBuilder builder ) {
            if ( _config.Content == null )
                return;
            var template = new TemplateBuilder();
            template.SetContent( _config.Content );
            builder.SetContent( template );
        }
    }
}
