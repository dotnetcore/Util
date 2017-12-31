using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;

namespace Util.Ui.Material.Icons.Configs {
    /// <summary>
    /// 图标配置
    /// </summary>
    public class IconConfig : Config {
        /// <summary>
        /// 初始化图标配置
        /// </summary>
        public IconConfig() {
        }

        /// <summary>
        /// 初始化图标配置
        /// </summary>
        /// <param name="allAttributes">全部属性集合</param>
        /// <param name="outputAttributes">输出属性集合，TagHelper中未明确定义的属性从该集合获取</param>
        /// <param name="content">内容</param>
        public IconConfig( TagHelperAttributeList allAttributes, TagHelperAttributeList outputAttributes, IHtmlContent content ) 
            : base( allAttributes, outputAttributes, content ) {
        }

        /// <summary>
        /// 验证
        /// </summary>
        public override string GetValidateMessage() {
            if ( !Contains( UiConst.FontAwesomeIcon ) && !Contains( UiConst.MaterialIcon ) )
                return "请设置FontAwesome或Material属性";
            return string.Empty;
        }
    }
}
