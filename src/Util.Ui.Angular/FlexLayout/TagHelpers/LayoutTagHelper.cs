using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.FlexLayout.Enums;
using Util.Ui.FlexLayout.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.FlexLayout.TagHelpers {
    /// <summary>
    /// 布局容器
    /// </summary>
    [HtmlTargetElement( "util-layout" )]
    public class LayoutTagHelper : TagHelperBase {
        /// <summary>
        /// 布局方向
        /// </summary>
        public LayoutDirection Direction { get; set; }
        /// <summary>
        /// 布局方向，xs代表 max-width: 599px
        /// </summary>
        public string DirectionXs { get; set; }
        /// <summary>
        /// 布局方向，sm代表 (min-width: 600px) and (max-width: 959px)
        /// </summary>
        public string DirectionSm { get; set; }
        /// <summary>
        /// 布局方向，md代表 (min-width: 960px) and (max-width: 1279px)
        /// </summary>
        public string DirectionMd { get; set; }
        /// <summary>
        /// 布局方向，lg代表 (min-width: 1280px) and (max-width: 1919px)
        /// </summary>
        public string DirectionLg { get; set; }
        /// <summary>
        /// 布局方向，xl代表 (min-width: 1920px) and (max-width: 5000px)
        /// </summary>
        public string DirectionXl { get; set; }
        /// <summary>
        /// 布局方向，lt-sm代表 max-width: 599px
        /// </summary>
        public string DirectionLtSm { get; set; }
        /// <summary>
        /// 布局方向，lt-md代表 max-width: 959px
        /// </summary>
        public string DirectionLtMd { get; set; }
        /// <summary>
        /// 布局方向，lt-lg代表 max-width: 1279px
        /// </summary>
        public string DirectionLtLg { get; set; }
        /// <summary>
        /// 布局方向，lt-xl代表 max-width: 1919px
        /// </summary>
        public string DirectionLtXl { get; set; }
        /// <summary>
        /// 布局方向，gt-xs代表 min-width: 600px
        /// </summary>
        public string DirectionGtXs { get; set; }
        /// <summary>
        /// 布局方向，gt-sm代表 min-width: 960px
        /// </summary>
        public string DirectionGtSm { get; set; }
        /// <summary>
        /// 布局方向，gt-md代表 min-width: 1280px
        /// </summary>
        public string DirectionGtMd { get; set; }
        /// <summary>
        /// 布局方向，gt-lg代表 min-width: 1920px
        /// </summary>
        public string DirectionGtLg { get; set; }
        /// <summary>
        /// X轴水平对齐方式
        /// </summary>
        public XAlign XAlign { get; set; }
        /// <summary>
        /// Y轴垂直对齐方式
        /// </summary>
        public YAlign YAlign { get; set; }
        /// <summary>
        /// 单元格间隙，范例：20px
        /// </summary>
        public string Gap { get; set; }
        /// <summary>
        /// 尺寸调整策略，格式：增大比例 缩小比例 基础尺寸，前两个参数默认值为1，可省略，范例1：1 1 auto，范例2：20px，代表1 1 20px
        /// </summary>
        public string Flex { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new LayoutRender( new Config( context ) );
        }
    }
}