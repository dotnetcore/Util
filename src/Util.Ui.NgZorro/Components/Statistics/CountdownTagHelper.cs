using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Statistics.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Statistics {
    /// <summary>
    /// 倒计时,生成的标签为&lt;nz-countdown>&lt;/nz-countdown>
    /// </summary>
    [HtmlTargetElement( "util-countdown" )]
    public class CountdownTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzFormat,格式化字符串，默认值: 'HH:mm:ss',格式说明：年(Y) 月(M) 日(D) 时(H) 分(m) 秒(s) 毫秒(S)
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// [nzFormat],格式化字符串，默认值: 'HH:mm:ss',格式说明：年(Y) 月(M) 日(D) 时(H) 分(m) 秒(s) 毫秒(S)
        /// </summary>
        public string BindFormat { get; set; }
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
        /// nzValue,时间戳格式的目标时间,类型: string | number
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// [nzValue],时间戳格式的目标时间,类型: string | number
        /// </summary>
        public string BindValue { get; set; }
        /// <summary>
        /// [nzValueTemplate],自定义模板展示时间,类型: TemplateRef&lt;{ $implicit: number }>
        /// </summary>
        public string ValueTemplate { get; set; }
        /// <summary>
        /// (nzCountdownFinish),倒计时完成事件
        /// </summary>
        public string OnCountdownFinish { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new CountdownRender( config );
        }
    }
}