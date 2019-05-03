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
        /// 宽度，单位：px
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// [url],请求地址
        /// </summary>
        public string BindUrl { get; set; }
        /// <summary>
        /// 查询参数
        /// </summary>
        public string QueryParam { get; set; }
        /// <summary>
        /// 数据源
        /// </summary>
        public string DatasSource { get; set; }
        /// <summary>
        /// 默认项文本，默认项显示在列表的第一行
        /// </summary>
        public string DefaultOptionText { get; set; }
        /// <summary>
        /// 启用多选
        /// </summary>
        public bool Multiple { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new SelectRender( new SelectConfig( context ) );
        }
    }
}
