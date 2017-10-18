using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;

namespace Util.Ui.Material.Buttons.Configs {
    /// <summary>
    /// 按钮配置
    /// </summary>
    public class ButtonConfig : Config {
        /// <summary>
        /// 初始化按钮配置
        /// </summary>
        public ButtonConfig() {
        }

        /// <summary>
        /// 初始化按钮配置
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        /// <param name="output">TagHelper输出</param>
        /// <param name="content">标签内容</param>
        public ButtonConfig( TagHelperContext context, TagHelperOutput output, IHtmlContent content ) : base( context, output, content ) {
        }
    }
}
