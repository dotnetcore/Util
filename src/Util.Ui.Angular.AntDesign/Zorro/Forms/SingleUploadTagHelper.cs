using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Forms.Renders;

namespace Util.Ui.Zorro.Forms {
    /// <summary>
    /// 单文件上传
    /// </summary>
    [HtmlTargetElement( "util-single-upload" )]
    public class SingleUploadTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// [nzName],发到服务端的文件参数名
        /// </summary>
        public string Name { get; set; }
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
        /// [nzHeaders],上传请求头部或返回上传请求头部的方法
        /// </summary>
        public string Headers { get; set; }
        /// <summary>
        /// [nzWithCredentials],上传是否携带cookie,默认值: false
        /// </summary>
        public bool WithCredentials { get; set; }
        /// <summary>
        /// [nzDisabled],禁用，默认值: false
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 必填项
        /// </summary>
        public string Required { get; set; }
        /// <summary>
        /// 必填项错误消息
        /// </summary>
        public string RequiredMessage { get; set; }
        /// <summary>
        /// nzListType,上传列表的内建样式
        /// </summary>
        public UploadListType ListType { get; set; }
        /// <summary>
        /// [nzShowButton],是否显示上传按钮，默认值: true
        /// </summary>
        public string ShowButton { get; set; }
        /// <summary>
        /// [nzShowUploadList],是否显示上传列表，还能控制是否显示预览图标和删除图标，默认值: true
        /// </summary>
        public string ShowUploadList { get; set; }
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
        /// 图片文件类型限制列表
        /// </summary>
        public List<ImageType> ImageTypes { get; set; }
        /// <summary>
        /// 文档文件类型限制列表
        /// </summary>
        public List<DocumentType> DocumentTypes { get; set; }
        /// <summary>
        /// [nzSize],文件大小限制，单位：KB
        /// </summary>
        public double Size { get; set; }
        /// <summary>
        /// [nzFilter],自定义过滤器，将覆盖默认过滤器设置
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// [nzBeforeUpload],上传前操作，返回 false 停止上传
        /// </summary>
        public string BeforeUpload { get; set; }
        /// <summary>
        /// [nzPreview],点击文件链接或预览图标时的回调操作
        /// </summary>
        public string Preview { get; set; }
        /// <summary>
        /// [nzRemove],移除文件时的回调操作，返回 false 不移除
        /// </summary>
        public string Remove { get; set; }
        /// <summary>
        /// [nzCustomRequest],自定义上传操作
        /// </summary>
        public string CustomRequest { get; set; }
        /// <summary>
        /// (nzChange),上传状态改变事件,范例：on-change="change($event)"
        /// </summary>
        public string OnChange { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new SingleUploadRender( new Config( context ) );
        }
    }
}