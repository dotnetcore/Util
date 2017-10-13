using Microsoft.AspNetCore.Html;
using Util.Ui.Material.Buttons.Builders;
using Util.Ui.Material.Buttons.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Material.Buttons.Renders {
    /// <summary>
    /// 按钮渲染器
    /// </summary>
    public class ButtonRender : RenderBase<ButtonBuilder, ButtonConfig> {
        /// <summary>
        /// 初始化按钮渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ButtonRender( ButtonConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override ButtonBuilder GetTagBuilder() {
            return new ButtonBuilder();
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="builder">标签生成器</param>
        /// <param name="config">组件配置</param>
        protected override void Render( ButtonBuilder builder, ButtonConfig config ) {
            SetText( builder, config );
            SetStyle( builder, config );
            SetEvents( builder, config );
        }

        /// <summary>
        /// 设置文本
        /// </summary>
        private void SetText( ButtonBuilder builder, ButtonConfig config ) {
            builder.InnerHtml.SetContent( config.Text );
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        private void SetStyle( ButtonBuilder builder, ButtonConfig config ) {
            if ( config.Plain ) {
                builder.Attribute( "mat-button", "mat-button" );
                return;
            }
            builder.Attribute( "mat-raised-button", "mat-raised-button" );
        }

        /// <summary>
        /// 设置事件
        /// </summary>
        private void SetEvents( ButtonBuilder builder, ButtonConfig config ) {
            builder.Attribute( "(click)", config.OnClick );
        }
    }
}
