using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Timelines.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Timelines {
    /// <summary>
    /// 时间轴,生成的标签为&lt;nz-timeline>&lt;/nz-timeline>
    /// </summary>
    [HtmlTargetElement( "util-timeline" )]
    public class TimelineTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzPending,指定最后一个幽灵节点是否存在或内容,类型: string | boolean | TemplateRef&lt;void>,默认值: false
        /// </summary>
        public string Pending { get; set; }
        /// <summary>
        /// [nzPending],指定最后一个幽灵节点是否存在或内容,类型: string | boolean | TemplateRef&lt;void>,默认值: false
        /// </summary>
        public string BindPending { get; set; }
        /// <summary>
        /// nzPendingDot,当最后一个幽灵节点存在時，指定其时间图点,类型: string | TemplateRef&lt;void>,默认值: &lt;i nz-icon nzType="loading">&lt;/i>
        /// </summary>
        public string PendingDot { get; set; }
        /// <summary>
        /// [nzPendingDot],当最后一个幽灵节点存在時，指定其时间图点,类型: string | TemplateRef&lt;void>,默认值: &lt;i nz-icon nzType="loading">&lt;/i>
        /// </summary>
        public string BindPendingDot { get; set; }
        /// <summary>
        /// [nzReverse],是否倒序排列,默认值: false
        /// </summary>
        public bool Reverse { get; set; }
        /// <summary>
        /// [nzReverse],是否倒序排列,默认值: false
        /// </summary>
        public string BindReverse { get; set; }
        /// <summary>
        /// nzMode,模式,可以改变时间轴和内容的相对位置,可选值: 'left' | 'alternate' | 'right' | 'custom'
        /// </summary>
        public TimelineMode Mode { get; set; }
        /// <summary>
        /// [nzMode],模式,可以改变时间轴和内容的相对位置,可选值: 'left' | 'alternate' | 'right' | 'custom'
        /// </summary>
        public string BindMode { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new TimelineRender( config );
        }
    }
}