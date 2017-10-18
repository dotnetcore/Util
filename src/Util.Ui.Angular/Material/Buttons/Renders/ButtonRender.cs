using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Buttons.Builders;
using Util.Ui.Renders;
using Util.Ui.Extensions;

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
        public ButtonRender( IConfig config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override ITagBuilder GetTagBuilder() {
            var builder = new ButtonBuilder();
            builder.AddOtherAttributes( _config );
            builder.Id( _config );
            builder.Text( _config );
            SetPlainStyle( builder );
            SetEvents( builder );
            return builder;
        }

        /// <summary>
        /// 设置扁平风格样式
        /// </summary>
        private void SetPlainStyle( ButtonBuilder builder ) {
            if ( _config.GetValue<bool>( Const.Plain ) ) {
                builder.AddAttribute( "mat-button", "mat-button" );
                return;
            }
            builder.AddAttribute( "mat-raised-button", "mat-raised-button" );
        }

        /// <summary>
        /// 设置事件
        /// </summary>
        private void SetEvents( ButtonBuilder builder ) {
            builder.AddAttribute( "(click)", _config.GetValue( Const.OnClick ) );
        }
    }
}
