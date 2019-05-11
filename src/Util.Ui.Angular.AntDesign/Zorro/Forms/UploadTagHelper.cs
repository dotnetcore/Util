using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// [(ngModel)],模型绑定
        /// </summary>
        public string NgModel { get; set; }
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
        /// [nzDisabled],禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// [nzShowButton],是否显示上传按钮
        /// </summary>
        public string ShowButton { get; set; }
        /// <summary>
        /// [(nzFileList)],上传文件列表
        /// </summary>
        public string FileList { get; set; }
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
        /// 允许上传文档，在文件选择框中显示文档文件
        /// </summary>
        public bool AcceptDocument { get; set; }
        /// <summary>
        /// nzFileType,允许上传的文件类型的MIME,范例：image/png,image/jpeg,image/gif,image/bmp
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 图片文件类型限制列表
        /// </summary>
        public List<ImageType> ImageTypes { get; set; }
        /// <summary>
        /// 文档文件类型限制列表
        /// </summary>
        public List<DocumentType> DocumentTypes { get; set; }
        /// <summary>
        /// nzSize,文件大小限制，单位：KB
        /// </summary>
        public double Size { get; set; }
        /// <summary>
        /// 上传文件总数量限制，超过总数隐藏按钮
        /// </summary>
        public int TotalLimit { get; set; }
        /// <summary>
        /// nzLimit,单次上传文件数量限制
        /// </summary>
        public int Limit { get; set; }
        /// <summary>
        /// [nzFilter],过滤器
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// (nzChange),上传状态改变事件,范例：on-change="change($event)"
        /// </summary>
        public string OnChange { get; set; }
        /// <summary>
        /// [nzBeforeUpload],上传前事件，返回 false 停止上传
        /// </summary>
        public string OnBeforeUpload { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new UploadRender( new Config( context ) );
        }
    }
}