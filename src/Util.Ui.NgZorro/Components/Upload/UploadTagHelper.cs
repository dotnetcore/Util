using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Upload.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Upload {
    /// <summary>
    /// 上传,生成的标签为&lt;nz-upload>&lt;/nz-upload>
    /// </summary>
    [HtmlTargetElement( "util-upload" )]
    public class UploadTagHelper : FormControlContainerTagHelperBase {
        /// <summary>
        /// nzAccept,接受上传的文件类型,范例: '.doc,.docx,application/msword'
        /// </summary>
        public string Accept { get; set; }
        /// <summary>
        /// [nzAccept],接受上传的文件类型,范例: '.doc,.docx,application/msword'
        /// </summary>
        public string BindAccept { get; set; }
        /// <summary>
        /// nzAction,上传地址,必选参数,类型: string | ((file: NzUploadFile) => string | Observable&lt;string>)
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// [nzAction],上传地址,必选参数,类型: string | ((file: NzUploadFile) => string | Observable&lt;string>)
        /// </summary>
        public string BindAction { get; set; }
        /// <summary>
        /// [nzDirectory],是否支持上传文件夹,默认值: false
        /// </summary>
        public bool Directory { get; set; }
        /// <summary>
        /// [nzDirectory],是否支持上传文件夹,默认值: false
        /// </summary>
        public string BindDirectory { get; set; }
        /// <summary>
        /// [nzBeforeUpload],上传前钩子函数,参数为上传的文件，返回 false 停止上传,注意：务必使用 => 定义处理方法,函数定义: (file: NzUploadFile, fileList: NzUploadFile[]) => boolean | Observable&lt;boolean>
        /// </summary>
        public string BeforeUpload { get; set; }
        /// <summary>
        /// [nzCustomRequest],自定义上传实现,覆盖默认上传行为，注意：务必使用 => 定义处理方法,函数定义: (item) => Subscription
        /// </summary>
        public string CustomRequest { get; set; }
        /// <summary>
        /// [nzData],上传参数,可以是返回上传参数的方法，注意：务必使用 => 定义处理方法,类型: Object | ((file: NzUploadFile) => Object | Observable&lt;{}>)
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [nzFileList],文件列表,类型: NzUploadFile[]
        /// </summary>
        public string FileList { get; set; }
        /// <summary>
        /// [(nzFileList)],文件列表,类型: NzUploadFile[]
        /// </summary>
        public string BindonFileList { get; set; }
        /// <summary>
        /// [nzLimit],限制单次最多上传数量,nzMultiple 打开时有效,0 表示不限,默认值: 0
        /// </summary>
        public int Limit { get; set; }
        /// <summary>
        /// [nzLimit],限制单次最多上传数量,nzMultiple 打开时有效,0 表示不限,默认值: 0
        /// </summary>
        public string BindLimit { get; set; }
        /// <summary>
        /// [nzSize],限制文件大小,单位：KB,0 表示不限,默认值: 0
        /// </summary>
        public double Size { get; set; }
        /// <summary>
        /// [nzSize],限制文件大小,单位：KB,0 表示不限,默认值: 0
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// nzFileType,限制文件类型,范例: image/png,image/jpeg,image/gif,image/bmp
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// [nzFileType],限制文件类型,范例: image/png,image/jpeg,image/gif,image/bmp
        /// </summary>
        public string BindFileType { get; set; }
        /// <summary>
        /// [nzFilter],自定义过滤器,类型: UploadFilter[]
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// [nzHeaders],设置上传的请求头部,类型: Object | ((file: NzUploadFile) => Object | Observable&lt;{}>),范例: { authorization: 'authorization-text' }
        /// </summary>
        public string Headers { get; set; }
        /// <summary>
        /// nzListType,上传列表的内建样式,可选值: 'text' | 'picture' | 'picture-card',默认值: 'text'
        /// </summary>
        public UploadListType ListType { get; set; }
        /// <summary>
        /// [nzListType],上传列表的内建样式,可选值: 'text' | 'picture' | 'picture-card',默认值: 'text'
        /// </summary>
        public string BindListType { get; set; }
        /// <summary>
        /// [nzMultiple],是否支持多选文件,开启后按住 ctrl 可选择多个文件,默认值: false
        /// </summary>
        public bool Multiple { get; set; }
        /// <summary>
        /// [nzMultiple],是否支持多选文件,开启后按住 ctrl 可选择多个文件,默认值: false
        /// </summary>
        public string BindMultiple { get; set; }
        /// <summary>
        /// nzName,发送到服务端的文件参数名,默认值: 'file'
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// [nzName],发送到服务端的文件参数名,默认值: 'file'
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// [nzShowUploadList],是否显示上传列表,类型: boolean | { showPreviewIcon?: boolean, showRemoveIcon?: boolean, showDownloadIcon?: boolean },默认值: true
        /// </summary>
        public bool ShowUploadList { get; set; }
        /// <summary>
        /// [nzShowUploadList],是否显示上传列表,类型: boolean | { showPreviewIcon?: boolean, showRemoveIcon?: boolean, showDownloadIcon?: boolean },默认值: true
        /// </summary>
        public string BindShowUploadList { get; set; }
        /// <summary>
        /// [nzShowButton],是否显示上传按钮,默认值: true
        /// </summary>
        public bool ShowButton { get; set; }
        /// <summary>
        /// [nzShowButton],是否显示上传按钮,默认值: true
        /// </summary>
        public string BindShowButton { get; set; }
        /// <summary>
        /// [nzWithCredentials],上传时是否携带cookie,默认值: false
        /// </summary>
        public bool WithCredentials { get; set; }
        /// <summary>
        /// [nzWithCredentials],上传时是否携带cookie,默认值: false
        /// </summary>
        public string BindWithCredentials { get; set; }
        /// <summary>
        /// [nzOpenFileDialogOnClick],点击是否打开文件对话框,默认值: true
        /// </summary>
        public bool OpenFileDialogOnClick { get; set; }
        /// <summary>
        /// [nzOpenFileDialogOnClick],点击是否打开文件对话框,默认值: true
        /// </summary>
        public string BindOpenFileDialogOnClick { get; set; }
        /// <summary>
        /// [nzPreview],点击文件链接或点击预览图标时的回调函数,注意：务必使用 => 定义处理方法,类型: (file: NzUploadFile) => void
        /// </summary>
        public string Preview { get; set; }
        /// <summary>
        /// [nzPreviewFile],自定义文件预览实现函数,注意：务必使用 => 定义处理方法,类型: (file: NzUploadFile) => Observable&lt;dataURL: string>
        /// </summary>
        public string PreviewFile { get; set; }
        /// <summary>
        /// [nzPreviewIsImage],预览文件是否有效图片函数,用于图片URL为非标准格式,注意：务必使用 => 定义处理方法,类型: (file: NzUploadFile) => boolean
        /// </summary>
        public string PreviewIsImage { get; set; }
        /// <summary>
        /// [nzRemove],点击移除文件时的回调函数,返回值为 false 不移除,注意：务必使用 => 定义处理方法,类型: (file: NzUploadFile) => boolean | Observable&lt;boolean>
        /// </summary>
        public string Remove { get; set; }
        /// <summary>
        /// [nzDownload],点击下载文件时的回调函数,如果没有指定，则默认跳转到文件 url 对应的标签页,类型: (file: NzUploadFile) => void
        /// </summary>
        public string Download { get; set; }
        /// <summary>
        /// [nzTransformFile],在上传之前转换文件函数,类型: (file: NzUploadFile) => NzUploadTransformFileType
        /// </summary>
        public string TransformFile { get; set; }
        /// <summary>
        /// [nzIconRender],图标渲染模板,自定义显示图标,类型: TemplateRef&lt;{ $implicit: NzUploadFile }>
        /// </summary>
        public string IconRender { get; set; }
        /// <summary>
        /// [nzFileListRender],文件列表渲染模板,自定义显示整个列表,类型: TemplateRef&lt;{ $implicit: NzUploadFile[] }>
        /// </summary>
        public string FileListRender { get; set; }
        /// <summary>
        /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
        /// </summary>
        public bool SpaceItem { get; set; }
        /// <summary>
        /// (nzChange),上传文件改变事件,类型: EventEmitter&lt;NzUploadChangeParam>
        /// </summary>
        public string OnChange { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new UploadRender( config );
        }
    }
}