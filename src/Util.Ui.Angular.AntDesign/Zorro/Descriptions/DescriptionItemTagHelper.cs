using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Enums;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Descriptions.Renders;

namespace Util.Ui.Zorro.Descriptions {
    /// <summary>
    /// 描述列表项
    /// </summary>
    [HtmlTargetElement( "util-description-item")]
    public class DescriptionItemTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// nzTitle,标题
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string BindValue { get; set; }
        /// <summary>
        /// [nzSpan]，占几列，即包含列的数量
        /// </summary>
        public int Span { get; set; }
        /// <summary>
        /// 描述类型
        /// </summary>
        public LabelType Type { get; set; }
        /// <summary>
        /// 日期格式化字符串，格式说明：
        /// 1. 年 - yyyy
        /// 2. 月 - MM
        /// 3. 日 - dd
        /// 4. 时 - HH
        /// 5. 分 - mm
        /// 6. 秒 - ss
        /// 7. 毫秒 - SSS
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DescriptionItemRender( new Config( context ) );
        }
    }
}