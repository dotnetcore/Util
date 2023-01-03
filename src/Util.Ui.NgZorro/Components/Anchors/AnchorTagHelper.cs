using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Anchors.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Anchors {
    /// <summary>
    /// 锚点,生成的标签为&lt;nz-anchor>&lt;/nz-anchor>
    /// </summary>
    [HtmlTargetElement( "util-anchor" )]
    public class AnchorTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzAffix],是否固定模式,默认值: true
        /// </summary>
        public bool Affix { get; set; }
        /// <summary>
        /// [nzAffix],是否固定模式,默认值: true
        /// </summary>
        public string BindAffix { get; set; }
        /// <summary>
        /// nzBounds,锚点区域边界，单位：像素,默认值: 5
        /// </summary>
        public double Bounds { get; set; }
        /// <summary>
        /// [nzBounds],锚点区域边界，单位：像素,默认值: 5
        /// </summary>
        public string BindBounds { get; set; }
        /// <summary>
        /// nzOffsetTop,距离窗口顶部达到指定偏移量后触发，类型：number
        /// </summary>
        public double OffsetTop { get; set; }
        /// <summary>
        /// [nzOffsetTop],距离窗口顶部达到指定偏移量后触发，类型：number
        /// </summary>
        public string BindOffsetTop { get; set; }
        /// <summary>
        /// [nzShowInkInFixed],固定模式是否显示小圆点,默认值: false
        /// </summary>
        public bool ShowInkInFixed { get; set; }
        /// <summary>
        /// [nzShowInkInFixed],固定模式是否显示小圆点,默认值: false
        /// </summary>
        public string BindShowInkInFixed { get; set; }
        /// <summary>
        /// nzContainer,指定滚动的容器,类型: string | HTMLElement,默认值: 'window'
        /// </summary>
        public string Container { get; set; }
        /// <summary>
        /// [nzContainer],指定滚动的容器,类型: string | HTMLElement,默认值: 'window'
        /// </summary>
        public string BindContainer { get; set; }
        /// <summary>
        /// (nzClick),单击事件,类型: EventEmitter&lt;string>
        /// </summary>
        public string OnClick { get; set; }
        /// <summary>
        /// (nzScroll),	滚动事件,滚动至指定锚点时触发,类型: EventEmitter&lt;NzAnchorLinkComponent>
        /// </summary>
        public string OnScroll { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new AnchorRender( config );
        }
    }
}