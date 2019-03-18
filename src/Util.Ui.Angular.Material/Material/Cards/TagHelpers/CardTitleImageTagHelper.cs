using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.Cards.Renders;
using Util.Ui.Material.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Cards.TagHelpers {
    /// <summary>
    /// 卡片标题图片,该标签应放到 util-card-title-group 中
    /// </summary>
    [HtmlTargetElement( "util-card-title-image",TagStructure = TagStructure.WithoutEndTag)]
    public class CardTitleImageTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        /// 图片大小
        /// </summary>
        public CardTitleImageSize Size { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new CardTitleImageRender( new Config( context ) );
        }
    }
}