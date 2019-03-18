using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Buttons.Builders;
using Util.Ui.Material.Enums;

namespace Util.Ui.Material.Buttons.Renders {
    /// <summary>
    /// 按钮包装器渲染器
    /// </summary>
    public class ButtonWrapperRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;
        /// <summary>
        /// 模板生成器
        /// </summary>
        private readonly TemplateBuilder _templateBuilder;

        /// <summary>
        /// 初始化按钮包装器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ButtonWrapperRender( IConfig config ) : base( config ) {
            _config = config;
            _templateBuilder = new TemplateBuilder();
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public override void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            if ( _config.Contains( UiConst.Text ) || _config.Content == null || _config.Content.IsEmptyOrWhiteSpace ) {
                base.WriteTo( writer, encoder );
                return;
            }
            _templateBuilder.SetContent( _config.Content );
            Builder.SetContent( _templateBuilder );
            base.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 渲染起始标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public override void RenderStartTag( TextWriter writer ) {
            InitBuilder( Builder );
            Builder.SetContent( _templateBuilder );
            Builder.RenderStartTag( writer );
            _templateBuilder.RenderStartTag( writer );
        }

        /// <summary>
        /// 渲染结束标签
        /// </summary>
        /// <param name="writer">流写入器</param>
        public override void RenderEndTag( TextWriter writer ) {
            _templateBuilder.RenderEndTag( writer );
            Builder.RenderEndTag( writer );
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
            ConfigWaiting( builder );
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        private void ConfigText( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Text, _config.GetValue( UiConst.Text ) );
            builder.AddAttribute( "[text]", _config.GetValue( AngularConst.BindText ) );
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
        /// 配置等待状态
        /// </summary>
        private void ConfigWaiting( TagBuilder builder ) {
            builder.AddAttribute( "waitingText", _config.GetValue( UiConst.WaitingText ) );
            builder.AddAttribute( "waitingMatIcon", _config.GetValue<MaterialIcon?>( UiConst.WaitingIcon )?.Description() );
        }
    }
}
