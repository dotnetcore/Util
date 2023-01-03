using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Affixes.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Affixes {
    /// <summary>
    /// 固钉,生成的标签为&lt;nz-affix&gt;&lt;/nz-affix&gt;
    /// </summary>
    [HtmlTargetElement( "util-affix" )]
    public class AffixTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzOffsetTop],顶部偏移量,距离窗口顶部达到指定偏移量后触发,默认值为0,范例: 10
        /// </summary>
        public double OffsetTop { get; set; }
        /// <summary>
        /// [nzOffsetTop],顶部偏移量,距离窗口顶部达到指定偏移量后触发,默认值为0,范例: 10
        /// </summary>
        public string BindOffsetTop { get; set; }
        /// <summary>
        /// [nzOffsetBottom],底部偏移量,距离窗口底部达到指定偏移量后触发,范例: 10
        /// </summary>
        public double OffsetBottom { get; set; }
        /// <summary>
        /// [nzOffsetBottom],底部偏移量,距离窗口底部达到指定偏移量后触发,范例: 10
        /// </summary>
        public string BindOffsetBottom { get; set; }
        /// <summary>
        /// [nzTarget],相对该目标元素进行固定,需要监听其滚动事件的元素,默认为 window
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// (nzChange),固定状态改变时触发的回调函数,事件参数为bool类型,true表示触发固定状态
        /// </summary>
        public string OnChange { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new AffixRender( config );
        }
    }
}