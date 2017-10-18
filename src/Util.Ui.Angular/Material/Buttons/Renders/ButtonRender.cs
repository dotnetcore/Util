using Util.Ui.Builders;
using Util.Ui.Material.Buttons.Builders;
using Util.Ui.Material.Buttons.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Material.Buttons.Renders {
    /// <summary>
    /// 按钮渲染器
    /// </summary>
    public class ButtonRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly ButtonConfig _config;

        /// <summary>
        /// 初始化按钮渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ButtonRender( ButtonConfig config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override ITagBuilder GetTagBuilder() {
            var builder = new ButtonBuilder();
            AddAttributes( builder );
            builder.AddAttribute( "id", _config.Id );
            AddContent( builder );
            SetStyle( builder );
            SetEvents( builder );
            return builder;
        }

        /// <summary>
        /// 添加属性列表
        /// </summary>
        private void AddAttributes( ButtonBuilder builder ) {
            foreach ( var attribute in _config.GetAttributes() )
                builder.Attribute( attribute.Key, attribute.Value );
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        private void AddContent( ButtonBuilder builder ) {
            if( string.IsNullOrWhiteSpace( _config.Text ) ) {
                builder.SetContent( _config.Content );
                return;
            }
            builder.SetContent( _config.Text );
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        private void SetStyle( ButtonBuilder builder ) {
            if ( _config.Plain ) {
                builder.AddAttribute( "mat-button", "mat-button" );
                return;
            }
            builder.AddAttribute( "mat-raised-button", "mat-raised-button" );
        }

        /// <summary>
        /// 设置事件
        /// </summary>
        private void SetEvents( ButtonBuilder builder ) {
            builder.AddAttribute( "(click)", _config.OnClick );
        }
    }
}
