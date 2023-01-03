using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Buttons.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Buttons.Renders {
    /// <summary>
    /// 按钮组渲染器
    /// </summary>
    public class ButtonGroupRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化按钮组渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ButtonGroupRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ButtonGroupBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new ButtonGroupRender( _config.Copy() );
        }
    }
}
