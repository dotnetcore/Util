using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Cards.Renders;

namespace Util.Ui.Zorro.Cards {
    /// <summary>
    /// 卡片
    /// </summary>
    [HtmlTargetElement( "util-card")]
    public class CardTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzTitle,标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzBordered],是否显示边框，默认值：true
        /// </summary>
        public bool ShowBorder { get; set; }
        /// <summary>
        /// [nzActions],卡片操作组，位于卡片底部
        /// </summary>
        public string Actions { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new CardRender( new Config( context ) );
        }
    }
}