using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.NgZorro.Components.Buttons.Builders;
using Util.Ui.NgZorro.Components.Inputs.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Upload.Builders; 

/// <summary>
/// 上传标签生成器
/// </summary>
public class UploadBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 标识
    /// </summary>
    private string _id;

    /// <summary>
    /// 初始化上传标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public UploadBuilder( Config config ) : base( config,"nz-upload" ) {
        _config = config;
    }

    /// <summary>
    /// 扩展标识
    /// </summary>
    protected string ExtendId => $"u_{GetId()}";

    /// <summary>
    /// 获取标识
    /// </summary>
    protected string GetId() {
        if ( _id.IsEmpty() == false )
            return _id;
        _id = _config.GetValue( UiConst.Id );
        if ( _id.IsEmpty() )
            _id = Util.Helpers.Id.Create();
        return _id;
    }

    /// <summary>
    /// 配置接受上传的文件类型
    /// </summary>
    public UploadBuilder Accept() {
        AttributeIfNotEmpty( "nzAccept", _config.GetValue( UiConst.Accept ) );
        AttributeIfNotEmpty( "[nzAccept]", _config.GetValue( AngularConst.BindAccept ) );
        return this;
    }

    /// <summary>
    /// 配置上传地址
    /// </summary>
    public UploadBuilder Action() {
        AttributeIfNotEmpty( "nzAction", _config.GetValue( UiConst.Action ) );
        AttributeIfNotEmpty( "[nzAction]", _config.GetValue( AngularConst.BindAction ) );
        return this;
    }

    /// <summary>
    /// 配置是否支持上传文件夹
    /// </summary>
    public UploadBuilder Directory() {
        AttributeIfNotEmpty( "[nzDirectory]", _config.GetValue( UiConst.Directory ) );
        return this;
    }

    /// <summary>
    /// 配置上传前钩子函数
    /// </summary>
    public UploadBuilder BeforeUpload() {
        AttributeIfNotEmpty( "[nzBeforeUpload]", _config.GetValue( UiConst.BeforeUpload ) );
        return this;
    }

    /// <summary>
    /// 配置自定义上传实现
    /// </summary>
    public UploadBuilder CustomRequest() {
        AttributeIfNotEmpty( "[nzCustomRequest]", _config.GetValue( UiConst.CustomRequest ) );
        return this;
    }

    /// <summary>
    /// 配置上传参数
    /// </summary>
    public UploadBuilder Data() {
        AttributeIfNotEmpty( "[nzData]", _config.GetValue( UiConst.Data ) );
        return this;
    }

    /// <summary>
    /// 配置禁用
    /// </summary>
    public UploadBuilder Disabled() {
        AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( UiConst.Disabled ) );
        return this;
    }

    /// <summary>
    /// 配置文件列表
    /// </summary>
    public UploadBuilder FileList() {
        AttributeIfNotEmpty( "[nzFileList]", _config.GetValue( UiConst.FileList ) );
        AttributeIfNotEmpty( "[(nzFileList)]", _config.GetValue( AngularConst.BindonFileList ) );
        return this;
    }

    /// <summary>
    /// 配置限制单次最多上传数量
    /// </summary>
    public UploadBuilder Limit() {
        AttributeIfNotEmpty( "[nzLimit]", _config.GetValue( UiConst.Limit ) );
        AttributeIfNotEmpty( "[nzLimit]", _config.GetValue( AngularConst.BindLimit ) );
        return this;
    }

    /// <summary>
    /// 配置限制文件大小
    /// </summary>
    public UploadBuilder Size() {
        AttributeIfNotEmpty( "[nzSize]", _config.GetValue( UiConst.Size ) );
        AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
        return this;
    }

    /// <summary>
    /// 配置限制文件类型
    /// </summary>
    public UploadBuilder FileType() {
        AttributeIfNotEmpty( "nzFileType", _config.GetValue( UiConst.FileType ) );
        AttributeIfNotEmpty( "[nzFileType]", _config.GetValue( AngularConst.BindFileType ) );
        return this;
    }

    /// <summary>
    /// 配置过滤器
    /// </summary>
    public UploadBuilder Filter() {
        return Filter( _config.GetValue( UiConst.Filter ) );
    }

    /// <summary>
    /// 配置过滤器
    /// </summary>
    public UploadBuilder Filter( string filter ) {
        AttributeIfNotEmpty( "[nzFilter]", filter );
        return this;
    }

    /// <summary>
    /// 配置请求头部
    /// </summary>
    public UploadBuilder Headers() {
        AttributeIfNotEmpty( "[nzHeaders]", _config.GetValue( UiConst.Headers ) );
        return this;
    }

    /// <summary>
    /// 配置列表类型
    /// </summary>
    public UploadBuilder ListType() {
        AttributeIfNotEmpty( "nzListType", _config.GetValue<UploadListType?>( UiConst.ListType )?.Description() );
        AttributeIfNotEmpty( "[nzListType]", _config.GetValue( AngularConst.BindListType ) );
        return this;
    }

    /// <summary>
    /// 配置是否支持多选文件
    /// </summary>
    public UploadBuilder Multiple() {
        AttributeIfNotEmpty( "[nzMultiple]", _config.GetValue( UiConst.Multiple ) );
        return this;
    }

    /// <summary>
    /// 配置参数名
    /// </summary>
    public UploadBuilder Name() {
        AttributeIfNotEmpty( "nzName", _config.GetValue( UiConst.Name ) );
        AttributeIfNotEmpty( "[nzName]", _config.GetValue( AngularConst.BindName ) );
        return this;
    }

    /// <summary>
    /// 配置是否显示上传列表
    /// </summary>
    public UploadBuilder ShowUploadList() {
        AttributeIfNotEmpty( "[nzShowUploadList]", _config.GetValue( UiConst.ShowUploadList ) );
        return this;
    }

    /// <summary>
    /// 配置是否显示上传按钮
    /// </summary>
    public UploadBuilder ShowButton() {
        AttributeIfNotEmpty( "[nzShowButton]", _config.GetValue( UiConst.ShowButton ) );
        return this;
    }

    /// <summary>
    /// 配置上传时是否携带cookie
    /// </summary>
    public UploadBuilder WithCredentials() {
        AttributeIfNotEmpty( "[nzWithCredentials]", _config.GetValue( UiConst.WithCredentials ) );
        return this;
    }

    /// <summary>
    /// 配置点击是否打开文件对话框
    /// </summary>
    public UploadBuilder OpenFileDialogOnClick() {
        AttributeIfNotEmpty( "[nzOpenFileDialogOnClick]", _config.GetValue( UiConst.OpenFileDialogOnClick ) );
        return this;
    }

    /// <summary>
    /// 配置点击预览函数
    /// </summary>
    public UploadBuilder Preview() {
        AttributeIfNotEmpty( "[nzPreview]", _config.GetValue( UiConst.Preview ) );
        return this;
    }

    /// <summary>
    /// 配置自定义文件预览函数
    /// </summary>
    public UploadBuilder PreviewFile() {
        AttributeIfNotEmpty( "[nzPreviewFile]", _config.GetValue( UiConst.PreviewFile ) );
        return this;
    }

    /// <summary>
    /// 配置预览文件是否有效图片函数
    /// </summary>
    public UploadBuilder PreviewIsImage() {
        AttributeIfNotEmpty( "[nzPreviewIsImage]", _config.GetValue( UiConst.PreviewIsImage ) );
        return this;
    }

    /// <summary>
    /// 配置移除文件函数
    /// </summary>
    public UploadBuilder Remove() {
        AttributeIfNotEmpty( "[nzRemove]", _config.GetValue( UiConst.Remove ) );
        return this;
    }

    /// <summary>
    /// 配置下载文件函数
    /// </summary>
    public UploadBuilder Download() {
        AttributeIfNotEmpty( "[nzDownload]", _config.GetValue( UiConst.Download ) );
        return this;
    }

    /// <summary>
    /// 配置转换文件函数
    /// </summary>
    public UploadBuilder TransformFile() {
        AttributeIfNotEmpty( "[nzTransformFile]", _config.GetValue( UiConst.TransformFile ) );
        return this;
    }

    /// <summary>
    /// 配置图标渲染模板
    /// </summary>
    public UploadBuilder IconRender() {
        AttributeIfNotEmpty( "[nzIconRender]", _config.GetValue( UiConst.IconRender ) );
        return this;
    }

    /// <summary>
    /// 配置文件列表渲染模板
    /// </summary>
    public UploadBuilder FileListRender() {
        AttributeIfNotEmpty( "[nzFileListRender]", _config.GetValue( UiConst.FileListRender ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public UploadBuilder Events() {
        AttributeIfNotEmpty( "(nzChange)", _config.GetValue( UiConst.OnChange ) );
        AttributeIfNotEmpty( "(modelChange)", _config.GetValue( UiConst.OnModelChange ) );
        AttributeIfNotEmpty( "(onUploadComplete)", _config.GetValue( UiConst.OnUploadComplete ) );
        return this;
    }

    /// <summary>
    /// 配置模型绑定
    /// </summary>
    public UploadBuilder Model() {
        AttributeIfNotEmpty( "[(model)]", _config.GetValue( AngularConst.NgModel ) );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.ConfigBase( _config );
        Accept().Action().Directory().BeforeUpload().CustomRequest()
            .Data().Disabled().FileList().Limit().Size().FileType().Filter()
            .Headers().ListType().Multiple().Name()
            .ShowUploadList().ShowButton().WithCredentials().OpenFileDialogOnClick()
            .Preview().PreviewFile().PreviewIsImage()
            .Remove().Download().TransformFile()
            .IconRender().FileListRender()
            .Events();
        Model();
        AddButton();
        EnableExtend();
    }

    /// <summary>
    /// 添加按钮
    /// </summary>
    private void AddButton() {
        var buttonBuilder = new ButtonBuilder( _config );
        buttonBuilder.Attribute( "nz-button" );
        buttonBuilder.Icon( AntDesignIcon.Upload );
        buttonBuilder.AppendContentByI18n( I18nKeys.Upload );
        AppendContent( buttonBuilder );
    }

    /// <summary>
    /// 启用扩展
    /// </summary>
    public UploadBuilder EnableExtend() {
        if ( IsEnableExtend() == false )
            return this;
        Attribute( $"#{ExtendId}", "xUploadExtend" );
        Attribute( "x-upload-extend" );
        AddInput();
        SetFileList();
        HandleChange();
        ClearFiles();
        ModelToFilesDebounceTime();
        SetFilter();
        return this;
    }

    /// <summary>
    /// 是否启用基础扩展
    /// </summary>
    public bool IsEnableExtend() {
        if ( GetEnableExtend() == false ) {
            return false;
        }
        return GetEnableExtend() == true ||
               IsContainsModel() ||
               GetRequired() == true;
    }

    /// <summary>
    /// 获取启用扩展属性
    /// </summary>
    protected bool? GetEnableExtend() {
        return _config.GetValue<bool?>( UiConst.EnableExtend );
    }

    /// <summary>
    /// 是否包含模型绑定
    /// </summary>
    protected bool IsContainsModel() {
        return _config.GetValue( AngularConst.NgModel ).IsEmpty() == false;
    }

    /// <summary>
    /// 获取是否必填项
    /// </summary>
    protected bool? GetRequired() {
        return _config.GetValue<bool?>( UiConst.Required );
    }

    /// <summary>
    /// 添加输入框,用于支持验证
    /// </summary>
    protected void AddInput() {
        if ( GetRequired() != true )
            return;
        var inputBuilder = new InputBuilder( _config );
        inputBuilder.Attribute( "style", "display: none" );
        inputBuilder.Name( $"input_{GetId()}" )
            .ValidationExtend()
            .BindNgModel( $"{ExtendId}.inputValue" )
            .Attribute( "[required]","true" );
        PostBuilder = inputBuilder;
    }

    /// <summary>
    /// 配置文件列表
    /// </summary>
    public void SetFileList() {
        if( _config.GetValue<bool>( AngularConst.NotBindFileList ) )
            return;
        if ( _config.Contains( UiConst.FileList ) )
            return;
        if ( _config.Contains( AngularConst.BindonFileList ) )
            return;
        Attribute( "[(nzFileList)]", $"{ExtendId}.files" );
    }

    /// <summary>
    /// 配置文件状态变更处理函数
    /// </summary>
    public void HandleChange() {
        if( _config.Contains( UiConst.OnChange ) )
            return;
        Attribute( "(nzChange)", $"{ExtendId}.handleChange($event)" );
    }

    /// <summary>
    /// 配置是否清除文件列表
    /// </summary>
    public void ClearFiles() {
        AttributeIfNotEmpty( "[isClearFiles]", _config.GetValue( UiConst.ClearFiles ) );
    }

    /// <summary>
    /// 配置模型数据转换为上传文件列表的延迟时间
    /// </summary>
    public void ModelToFilesDebounceTime() {
        AttributeIfNotEmpty( "[modelToFilesDebounceTime]", _config.GetValue( UiConst.ModelToFilesDebounceTime ) );
    }

    /// <summary>
    /// 配置过滤器
    /// </summary>
    public void SetFilter() {
        if( _config.Contains( UiConst.Filter ) )
            return;
        Filter( $"{ExtendId}.filters" );
    }
}