using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.Cards.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Cards.TagHelpers {
    /// <summary>
    /// 卡片头像,该标签应放到 util-card-header 中
    /// </summary>
    [HtmlTargetElement( "util-card-header-avatar", TagStructure = TagStructure.WithoutEndTag )]
    public class CardAvatarTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new CardAvatarRender( new Config( context ) );
        }
    }
}