using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Enums;
using Util.Ui.Zorro.Forms.Renders;

namespace Util.Ui.Zorro.Forms {
    /// <summary>
    /// 文件上传
    /// </summary>
    [HtmlTargetElement( "util-upload" )]
    public class UploadTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzAction, 上传地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// [nzAction],上传地址
        /// </summary>
        public string BindUrl { get; set; }
        /// <summary>
        /// [nzData],上传参数或返回上传参数的方法
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// [nzMultiple],启用多选
        /// </summary>
        public bool Multiple { get; set; }
        /// <summary>
        /// [nzDirectory],启用上传文件夹
        /// </summary>
        public bool Directory { get; set; }
        /// <summary>
        /// 按钮文本
        /// </summary>
        public string ButtonText { get; set; }
        /// <summary>
        /// 按钮图标
        /// </summary>
        public AntDesignIcon ButtonIcon { get; set; }
        /// <summary>
        /// nzAccept,接受上传的文件类型，在文件选择框中对显示的文件过滤
        /// </summary>
        public string Accept { get; set; }
        /// <summary>
        /// 允许上传图片，在文件选择框中显示图片文件
        /// </summary>
        public bool AcceptImage { get; set; }
        /// <summary>
        /// nzFileType,文件类型限制
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 图片文件类型限制列表
        /// </summary>
        public List<ImageType> ImageTypes { get; set; }
        /// <summary>
        /// nzSize,文件大小限制，单位：KB；0 表示不限
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new UploadRender( new Config( context ) );
        }
    }
}