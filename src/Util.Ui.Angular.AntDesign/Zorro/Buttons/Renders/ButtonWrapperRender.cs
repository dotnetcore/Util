using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Buttons.Builders;
using Util.Ui.Zorro.Enums;
using Util.Ui.Zorro.Icons.Builders;

namespace Util.Ui.Zorro.Buttons.Renders {
    /// <summary>
    /// 按钮包装器渲染器
    /// </summary>
    public class ButtonWrapperRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化按钮包装器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ButtonWrapperRender( IConfig config ) : base( config ) {
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
            ConfigStype( builder );
            ConfigDisabled( builder );
            ConfigTooltip( builder );
            ConfigLoading( builder );
            ConfigEvents( builder );
            ConfigIcon( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        private void ConfigText( TagBuilder builder ) {
            if( _config.Contains( UiConst.Text ) )
                builder.AddAttribute( UiConst.Text, _config.GetValue( UiConst.Text ),false );
            builder.AddAttribute( "[text]", _config.GetValue( AngularConst.BindText ) );
        }

        /// <summary>
        /// 配置按钮类型
        /// </summary>
        private void ConfigType( TagBuilder builder ) {
            builder.AddAttribute( "[isSubmit]", _config.GetBoolValue( AngularConst.IsSubmit ) );
        }

        /// <summary>
        /// 配置样式
        /// </summary>
        private void ConfigStype( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Color, _config.GetValue<Color?>( UiConst.Color )?.Description() );
            builder.AddAttribute( UiConst.Size, _config.GetValue<ButtonSize?>( UiConst.Size )?.Description() );
            builder.AddAttribute( UiConst.Shape, _config.GetValue<ButtonShape?>( UiConst.Shape )?.Description() );
            builder.AddAttribute( $"[{UiConst.Block}]", _config.GetBoolValue( UiConst.Block ) );
            builder.AddAttribute( $"[{UiConst.Ghost}]", _config.GetBoolValue( UiConst.Ghost ) );
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
        /// 配置加载状态
        /// </summary>
        private void ConfigLoading( TagBuilder builder ) {
            builder.AddAttribute( $"[{UiConst.Loading}]", _config.GetValue( UiConst.Loading ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(onClick)", _config.GetValue( UiConst.OnClick ) );
        }

        /// <summary>
        /// 配置图标
        /// </summary>
        private void ConfigIcon( TagBuilder builder ) {
            if( _config.Contains( UiConst.Icon ) == false )
                return;
            var template = new TemplateBuilder();
            var iconBuilder = new IconBuilder();
            iconBuilder.AddType( _config.GetValue<AntDesignIcon?>( UiConst.Icon )?.Description() );
            template.AppendContent( iconBuilder );
            builder.AppendContent( template );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            if( _config.Content == null || _config.Content.IsEmptyOrWhiteSpace )
                return;
            var template = new TemplateBuilder();
            template.AppendContent( _config.Content );
            builder.AppendContent( template );
        }
    }
}
