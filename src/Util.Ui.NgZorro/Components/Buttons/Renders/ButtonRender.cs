using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Buttons.Builders;
using Util.Ui.NgZorro.Components.Links.Builders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Buttons.Renders {
    /// <summary>
    /// 按钮渲染器
    /// </summary>
    public class ButtonRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化按钮渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ButtonRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = CreateTagBuilder();
            builder.Attribute( "nz-button" );
            builder.Config();
            return builder;
        }

        /// <summary>
        /// 创建标签生成器
        /// </summary>
        private TagBuilder CreateTagBuilder() {
            if( GetButtonType() == "link" )
                return new ABuilder( _config );
            return new ButtonBuilder( _config );
        }

        /// <summary>
        /// 获取按钮类型
        /// </summary>
        private string GetButtonType() {
            return _config.GetValue<ButtonType?>( UiConst.Type )?.Description();
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new ButtonRender( _config.Copy() );
        }
    }
}
