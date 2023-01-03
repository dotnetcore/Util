using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Dividers.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Dividers {
    /// <summary>
    /// 分隔线,生成的标签为&lt;nz-divider&gt;&lt;/nz-divider&gt;
    /// </summary>
    [HtmlTargetElement( "util-divider")]
    public class DividerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzDashed],是否虚线
        /// </summary>
        public bool Dashed { get; set; }
        /// <summary>
        /// [nzDashed],是否虚线
        /// </summary>
        public string BindDashed { get; set; }
        /// <summary>
        /// nzType,水平还是垂直类型,默认为水平类型
        /// </summary>
        public DividerType Type { get; set; }
        /// <summary>
        /// [nzType],水平还是垂直类型,默认为水平类型
        /// </summary>
        public string BindType { get; set; }
        /// <summary>
        /// nzText,文字
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// [nzText],文字
        /// </summary>
        public string BindText { get; set; }
        /// <summary>
        /// nzOrientation,文字方向
        /// </summary>
        public DividerOrientation Orientation { get; set; }
        /// <summary>
        /// [nzOrientation],文字方向
        /// </summary>
        public string BindOrientation { get; set; }
        /// <summary>
        /// [nzPlain],文字是否显示为普通正文样式
        /// </summary>
        public bool Plain { get; set; }
        /// <summary>
        /// [nzPlain],文字是否显示为普通正文样式
        /// </summary>
        public string BindPlain { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new DividerRender( config );
        }
    }
}