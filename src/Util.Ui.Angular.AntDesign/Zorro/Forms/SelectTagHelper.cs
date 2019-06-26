using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Forms.Base;
using Util.Ui.Zorro.Forms.Renders;

namespace Util.Ui.Zorro.Forms {
    /// <summary>
    /// 下拉列表
    /// </summary>
    [HtmlTargetElement( "util-select" )]
    public class SelectTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 宽度，默认单位：px，范例：100，表示100px，也可以使用百分比，范例：10%
        /// </summary>
        public string Width { get; set; }
        /// <summary>
        /// 服务端地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 服务端地址
        /// </summary>
        public string BindUrl { get; set; }
        /// <summary>
        /// 查询参数
        /// </summary>
        public string QueryParam { get; set; }
        /// <summary>
        /// 排序字段,范例: creationTime desc
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 数据源
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 默认项文本，默认项显示在列表的第一行
        /// </summary>
        public string DefaultOptionText { get; set; }
        /// <summary>
        /// 启用多选
        /// </summary>
        public bool Multiple { get; set; }
        /// <summary>
        /// [nzMaxMultipleCount],允许选中的最大数量
        /// </summary>
        public int MaxMultipleCount { get; set; }
        /// <summary>
        /// [nzAllowClear],是否显示清除按钮，默认值： true
        /// </summary>
        public bool ShowClear { get; set; }
        /// <summary>
        /// [nzShowSearch],是否允许单选时搜索，默认值： true
        /// </summary>
        public bool ShowSearch { get; set; }
        /// <summary>
        /// [nzShowArrow],是否显示下拉箭头，默认值： true
        /// </summary>
        public bool ShowArrow { get; set; }
        /// <summary>
        /// [nzServerSearch],是否服务端搜索，默认值： false
        /// </summary>
        public bool ServerSearch { get; set; }
        /// <summary>
        /// 滚动到底部是否自动加载，默认值： false
        /// </summary>
        public bool ScrollLoad { get; set; }
        /// <summary>
        /// (nzOnSearch),搜索事件
        /// </summary>
        public string OnSearch { get; set; }
        /// <summary>
        /// (nzScrollToBottom),滚动到底部事件
        /// </summary>
        public string OnScrollToBottom { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new SelectRender( new SelectConfig( context ) );
        }
    }
}
