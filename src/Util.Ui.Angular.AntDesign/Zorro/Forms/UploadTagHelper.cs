using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Forms.Renders;

namespace Util.Ui.Zorro.Forms {
    /// <summary>
    /// 文件上传
    /// </summary>
    [HtmlTargetElement( "util-upload" )]
    public class UploadTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 请求地址,[url]
        /// </summary>
        public string BindUrl { get; set; }
        /// <summary>
        /// 查询参数
        /// </summary>
        public string QueryParam { get; set; }
        /// <summary>
        /// 启用多选
        /// </summary>
        public bool Multiple { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new UploadRender( new Config( context ) );
        }
    }
}