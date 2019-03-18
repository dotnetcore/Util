using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.FlexLayout.Enums;
using Util.Ui.FlexLayout.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.FlexLayout.TagHelpers {
    /// <summary>
    /// 布局项
    /// </summary>
    [HtmlTargetElement( "util-layout-item" )]
    public class LayoutItemTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 尺寸调整策略，格式：增大比例 缩小比例 基础尺寸，前两个参数默认值为1，可省略，范例1：1 1 auto，范例2：20px，代表1 1 20px
        /// </summary>
        public string Flex { get; set; }
        /// <summary>
        /// 尺寸调整策略，xs代表 max-width: 599px
        /// </summary>
        public string FlexXs { get; set; }
        /// <summary>
        /// 尺寸调整策略，sm代表 (min-width: 600px) and (max-width: 959px)
        /// </summary>
        public string FlexSm { get; set; }
        /// <summary>
        /// 尺寸调整策略，md代表 (min-width: 960px) and (max-width: 1279px)
        /// </summary>
        public string FlexMd { get; set; }
        /// <summary>
        /// 尺寸调整策略，lg代表 (min-width: 1280px) and (max-width: 1919px)
        /// </summary>
        public string FlexLg { get; set; }
        /// <summary>
        /// 尺寸调整策略，xl代表 (min-width: 1920px) and (max-width: 5000px)
        /// </summary>
        public string FlexXl { get; set; }
        /// <summary>
        /// 尺寸调整策略，lt-sm代表 max-width: 599px
        /// </summary>
        public string FlexLtSm { get; set; }
        /// <summary>
        /// 尺寸调整策略，lt-md代表 max-width: 959px
        /// </summary>
        public string FlexLtMd { get; set; }
        /// <summary>
        /// 尺寸调整策略，lt-lg代表 max-width: 1279px
        /// </summary>
        public string FlexLtLg { get; set; }
        /// <summary>
        /// 尺寸调整策略，lt-xl代表 max-width: 1919px
        /// </summary>
        public string FlexLtXl { get; set; }
        /// <summary>
        /// 尺寸调整策略，gt-xs代表 min-width: 600px
        /// </summary>
        public string FlexGtXs { get; set; }
        /// <summary>
        /// 尺寸调整策略，gt-sm代表 min-width: 960px
        /// </summary>
        public string FlexGtSm { get; set; }
        /// <summary>
        /// 尺寸调整策略，gt-md代表 min-width: 1280px
        /// </summary>
        public string FlexGtMd { get; set; }
        /// <summary>
        /// 尺寸调整策略，gt-lg代表 min-width: 1920px
        /// </summary>
        public string FlexGtLg { get; set; }
        /// <summary>
        /// 排序，数值小的排前面，默认值为0
        /// </summary>
        public new int Order { get; set; }
        /// <summary>
        /// 偏移量,单位：％、 px 、 vw 、vh，范例：10%
        /// </summary>
        public string Offset { get; set; }
        /// <summary>
        /// 对齐方式
        /// </summary>
        public FlexAlign Align { get; set; }
        /// <summary>
        /// 是否占满
        /// </summary>
        public bool Fill { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new LayoutItemRender( new Config( context ) );
        }
    }
}