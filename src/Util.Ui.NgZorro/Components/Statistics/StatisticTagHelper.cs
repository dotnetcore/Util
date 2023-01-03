using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Statistics.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Statistics {
    /// <summary>
    /// 统计,生成的标签为&lt;nz-statistic>&lt;/nz-statistic>
    /// </summary>
    [HtmlTargetElement( "util-statistic" )]
    public class StatisticTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzPrefix,设置数值的前缀,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// [nzPrefix],设置数值的前缀,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindPrefix { get; set; }
        /// <summary>
        /// nzSuffix,设置数值的后缀,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// [nzSuffix],设置数值的后缀,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindSuffix { get; set; }
        /// <summary>
        /// nzTitle,设置数值的标题,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzTitle],设置数值的标题,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindTitle { get; set; }
        /// <summary>
        /// nzValue,设置数值,类型: string | number
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// [nzValue],设置数值,类型: string | number
        /// </summary>
        public string BindValue { get; set; }
        /// <summary>
        /// [nzValueStyle],设置数值的样式,类型: Object
        /// </summary>
        public string ValueStyle { get; set; }
        /// <summary>
        /// [nzValueTemplate],自定义模板展示数值,类型: TemplateRef&lt;{ $implicit: string | number }>
        /// </summary>
        public string ValueTemplate { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new StatisticRender( config );
        }
    }
}