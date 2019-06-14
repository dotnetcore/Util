using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Dividers.Renders;

namespace Util.Ui.Zorro.Dividers {
    /// <summary>
    /// 分隔线
    /// </summary>
    [HtmlTargetElement( "util-divider")]
    public class DividerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzDashed],虚线显示，默认值：false
        /// </summary>
        public bool Dashed { get; set; }
        /// <summary>
        /// nzType,垂直显示，默认值：false
        /// </summary>
        public bool Vertical { get; set; }
        /// <summary>
        /// nzText,文字
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// nzOrientation,文字方向
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DividerRender( new Config( context ) );
        }
    }
}