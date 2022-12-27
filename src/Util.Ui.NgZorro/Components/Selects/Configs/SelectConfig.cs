using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Selects.Configs {
    /// <summary>
    /// 选择框配置
    /// </summary>
    public class SelectConfig : Config {
        /// <summary>
        /// 扩展标识
        /// </summary>
        public string ExtendId { get; set; }

        /// <summary>
        /// 初始化选择框配置
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        public SelectConfig( TagHelperContext context, TagHelperOutput output ) : base( context, output ) {
        }
    }
}
