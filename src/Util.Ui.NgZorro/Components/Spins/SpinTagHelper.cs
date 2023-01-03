using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Spins.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Spins {
    /// <summary>
    /// 加载中,生成的标签为&lt;nz-spin>&lt;/nz-spin>
    /// </summary>
    [HtmlTargetElement( "util-spin" )]
    public class SpinTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzDelay,延迟显示加载效果的时间（防止闪烁），单位：毫秒
        /// </summary>
        public int Delay { get; set; }
        /// <summary>
        /// [nzDelay],延迟显示加载效果的时间（防止闪烁），单位：毫秒
        /// </summary>
        public string BindDelay { get; set; }
        /// <summary>
        /// [nzIndicator],加载指示符,自定义加载图标,类型: TemplateRef&lt;void>
        /// </summary>
        public string Indicator { get; set; }
        /// <summary>
        /// nzSize,大小,可选值: 'large' | 'small' | 'default',默认值: 'default'
        /// </summary>
        public SpinSize Size { get; set; }
        /// <summary>
        /// [nzSize],大小,可选值: 'large' | 'small' | 'default',默认值: 'default'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// [nzSpinning],是否旋转,默认值: true
        /// </summary>
        public bool Spinning { get; set; }
        /// <summary>
        /// [nzSpinning],是否旋转,默认值: true
        /// </summary>
        public string BindSpinning { get; set; }
        /// <summary>
        /// nzSimple,是否简单模式,如果不包裹其它元素,设置为true,默认值: false
        /// </summary>
        public bool Simple { get; set; }
        /// <summary>
        /// [nzSimple],是否简单模式,如果不包裹其它元素,设置为true,默认值: false
        /// </summary>
        public string BindSimple { get; set; }
        /// <summary>
        /// nzTip,当作为包裹元素时，可以自定义提示文字
        /// </summary>
        public string Tip { get; set; }
        /// <summary>
        /// [nzTip],当作为包裹元素时，可以自定义提示文字
        /// </summary>
        public string BindTip { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new SpinRender( config );
        }
    }
}