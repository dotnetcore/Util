using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Buttons.Builders;
using Util.Ui.Zorro.Enums;

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
            ConfigColor( builder );
            ConfigDisabled( builder );
            ConfigTooltip( builder );
            ConfigEvents( builder );
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        private void ConfigText( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Text, _config.GetValue( UiConst.Text ) );
            builder.AddAttribute( "[text]", _config.GetValue( AngularConst.BindText ) );
        }

        /// <summary>
        /// 配置按钮类型
        /// </summary>
        private void ConfigType( TagBuilder builder ) {
            builder.AddAttribute( "[isSubmit]", _config.GetBoolValue( AngularConst.IsSubmit ) );
        }

        /// <summary>
        /// 配置颜色
        /// </summary>
        private void ConfigColor( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Color, _config.GetValue<Color?>( UiConst.Color )?.Description() );
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
    }
}
