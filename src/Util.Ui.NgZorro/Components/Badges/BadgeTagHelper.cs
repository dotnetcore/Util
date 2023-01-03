using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Badges.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Badges {
    /// <summary>
    /// 徽标,生成的标签为&lt;nz-badge>&lt;/nz-badge>
    /// </summary>
    [HtmlTargetElement( "util-badge" )]
    public class BadgeTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzStandalone],是否独立使用
        /// </summary>
        public bool Standalone { get; set; }
        /// <summary>
        /// [nzStandalone],是否独立使用
        /// </summary>
        public string BindStandalone { get; set; }
        /// <summary>
        /// nzColor,自定义小圆点的颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// [nzColor],自定义小圆点的颜色
        /// </summary>
        public string BindColor { get; set; }
        /// <summary>
        /// nzCount,显示的数字，nzCount 大于 nzOverflowCount 时显示为 ${nzOverflowCount}+，为 0 时隐藏,类型: number | TemplateRef&lt;void>
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// [nzCount],显示的数字，nzCount 大于 nzOverflowCount 时显示为 ${nzOverflowCount}+，为 0 时隐藏,类型: number | TemplateRef&lt;void>
        /// </summary>
        public string BindCount { get; set; }
        /// <summary>
        /// [nzDot],是否不显示数字，只显示一个小红点,默认值: false
        /// </summary>
        public bool Dot { get; set; }
        /// <summary>
        /// [nzDot],是否不显示数字，只显示一个小红点,默认值: false
        /// </summary>
        public string BindDot { get; set; }
        /// <summary>
        /// [nzShowDot],是否显示小红点,默认值: true
        /// </summary>
        public bool ShowDot { get; set; }
        /// <summary>
        /// [nzShowDot],是否显示小红点,默认值: true
        /// </summary>
        public string BindShowDot { get; set; }
        /// <summary>
        /// nzOverflowCount,封顶数字，nzCount 大于 nzOverflowCount 时显示为 ${nzOverflowCount}+,默认值: 99
        /// </summary>
        public int OverflowCount { get; set; }
        /// <summary>
        /// [nzOverflowCount],封顶数字，nzCount 大于 nzOverflowCount 时显示为 ${nzOverflowCount}+,默认值: 99
        /// </summary>
        public string BindOverflowCount { get; set; }
        /// <summary>
        /// [nzShowZero],当数值为 0 时，是否显示徽标,默认值: false
        /// </summary>
        public bool ShowZero { get; set; }
        /// <summary>
        /// [nzShowZero],当数值为 0 时，是否显示徽标,默认值: false
        /// </summary>
        public string BindShowZero { get; set; }
        /// <summary>
        /// nzStatus,设置徽标为状态点,可选值: 'success' | 'processing' | 'default' | 'error' | 'warning'
        /// </summary>
        public BadgeStatus Status { get; set; }
        /// <summary>
        /// [nzStatus],设置徽标为状态点,可选值: 'success' | 'processing' | 'default' | 'error' | 'warning'
        /// </summary>
        public string BindStatus { get; set; }
        /// <summary>
        /// nzText,设置状态点的文本,仅在设置了 nzStatus 时有效,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// [nzText],设置状态点的文本,仅在设置了 nzStatus 时有效,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindText { get; set; }
        /// <summary>
        /// nzTitle,设置鼠标放在状态点上时显示的文字,为 null 时隐藏,类型: string | null,默认值: nzCount
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzTitle],设置鼠标放在状态点上时显示的文字,为 null 时隐藏,类型: string | null,默认值: nzCount
        /// </summary>
        public string BindTitle { get; set; }
        /// <summary>
        /// [nzOffset],设置状态点的位置偏移，格式为 [x, y],类型: [number, number]
        /// </summary>
        public string Offset { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new BadgeRender( config );
        }
    }
}