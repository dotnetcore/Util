using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Upload;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Upload {
    /// <summary>
    /// 上传测试
    /// </summary>
    public class UploadTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public UploadTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new UploadTagHelper().ToWrapper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<nz-upload></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload #a=\"\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试接受上传的文件类型
        /// </summary>
        [Fact]
        public void TestAccept() {
            _wrapper.SetContextAttribute( UiConst.Accept, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload nzAccept=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试接受上传的文件类型
        /// </summary>
        [Fact]
        public void TestBindAccept() {
            _wrapper.SetContextAttribute( AngularConst.BindAccept, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzAccept]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试上传地址
        /// </summary>
        [Fact]
        public void TestAction() {
            _wrapper.SetContextAttribute( UiConst.Action, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload nzAction=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试上传地址
        /// </summary>
        [Fact]
        public void TestBindAction() {
            _wrapper.SetContextAttribute( AngularConst.BindAction, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzAction]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持上传文件夹
        /// </summary>
        [Fact]
        public void TestDirectory() {
            _wrapper.SetContextAttribute( UiConst.Directory, true );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzDirectory]=\"true\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持上传文件夹
        /// </summary>
        [Fact]
        public void TestBindDirectory() {
            _wrapper.SetContextAttribute( AngularConst.BindDirectory, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzDirectory]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试上传前钩子函数
        /// </summary>
        [Fact]
        public void TestBeforeUpload() {
            _wrapper.SetContextAttribute( UiConst.BeforeUpload, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzBeforeUpload]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义上传实现
        /// </summary>
        [Fact]
        public void TestCustomRequest() {
            _wrapper.SetContextAttribute( UiConst.CustomRequest, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzCustomRequest]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试上传参数
        /// </summary>
        [Fact]
        public void TestData() {
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzData]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzDisabled]=\"true\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzDisabled]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文件列表
        /// </summary>
        [Fact]
        public void TestFileList() {
            _wrapper.SetContextAttribute( UiConst.FileList, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzFileList]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文件列表
        /// </summary>
        [Fact]
        public void TestBindonFileList() {
            _wrapper.SetContextAttribute( AngularConst.BindonFileList, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [(nzFileList)]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试限制单次最多上传数量
        /// </summary>
        [Fact]
        public void TestLimit() {
            _wrapper.SetContextAttribute( UiConst.Limit, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzLimit]=\"1\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试限制单次最多上传数量
        /// </summary>
        [Fact]
        public void TestBindLimit() {
            _wrapper.SetContextAttribute( AngularConst.BindLimit, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzLimit]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试限制文件大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzSize]=\"1\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试限制文件大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzSize]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试限制文件类型
        /// </summary>
        [Fact]
        public void TestFileType() {
            _wrapper.SetContextAttribute( UiConst.FileType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload nzFileType=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试限制文件类型
        /// </summary>
        [Fact]
        public void TestBindFileType() {
            _wrapper.SetContextAttribute( AngularConst.BindFileType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzFileType]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试过滤器
        /// </summary>
        [Fact]
        public void TestFilter() {
            _wrapper.SetContextAttribute( UiConst.Filter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzFilter]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试请求头部
        /// </summary>
        [Fact]
        public void TestHeaders() {
            _wrapper.SetContextAttribute( UiConst.Headers, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzHeaders]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表类型
        /// </summary>
        [Fact]
        public void TestListType() {
            _wrapper.SetContextAttribute( UiConst.ListType, UploadListType.PictureCard );
            var result = new StringBuilder();
            result.Append( "<nz-upload nzListType=\"picture-card\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表类型
        /// </summary>
        [Fact]
        public void TestBindListType() {
            _wrapper.SetContextAttribute( AngularConst.BindListType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzListType]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持多选文件
        /// </summary>
        [Fact]
        public void TestMultiple() {
            _wrapper.SetContextAttribute( UiConst.Multiple, true );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzMultiple]=\"true\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持多选文件
        /// </summary>
        [Fact]
        public void TestBindMultiple() {
            _wrapper.SetContextAttribute( AngularConst.BindMultiple, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzMultiple]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试参数名
        /// </summary>
        [Fact]
        public void TestName() {
            _wrapper.SetContextAttribute( UiConst.Name, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload nzName=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试参数名
        /// </summary>
        [Fact]
        public void TestBindName() {
            _wrapper.SetContextAttribute( AngularConst.BindName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzName]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示上传列表
        /// </summary>
        [Fact]
        public void TestShowUploadList() {
            _wrapper.SetContextAttribute( UiConst.ShowUploadList, true );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzShowUploadList]=\"true\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示上传列表
        /// </summary>
        [Fact]
        public void TestBindShowUploadList() {
            _wrapper.SetContextAttribute( AngularConst.BindShowUploadList, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzShowUploadList]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示上传按钮
        /// </summary>
        [Fact]
        public void TestShowButton() {
            _wrapper.SetContextAttribute( UiConst.ShowButton, true );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzShowButton]=\"true\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示上传按钮
        /// </summary>
        [Fact]
        public void TestBindShowButton() {
            _wrapper.SetContextAttribute( AngularConst.BindShowButton, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzShowButton]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试上传时是否携带cookie
        /// </summary>
        [Fact]
        public void TestWithCredentials() {
            _wrapper.SetContextAttribute( UiConst.WithCredentials, true );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzWithCredentials]=\"true\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试上传时是否携带cookie
        /// </summary>
        [Fact]
        public void TestBindWithCredentials() {
            _wrapper.SetContextAttribute( AngularConst.BindWithCredentials, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzWithCredentials]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点击是否打开文件对话框
        /// </summary>
        [Fact]
        public void TestOpenFileDialogOnClick() {
            _wrapper.SetContextAttribute( UiConst.OpenFileDialogOnClick, true );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzOpenFileDialogOnClick]=\"true\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点击是否打开文件对话框
        /// </summary>
        [Fact]
        public void TestBindOpenFileDialogOnClick() {
            _wrapper.SetContextAttribute( AngularConst.BindOpenFileDialogOnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzOpenFileDialogOnClick]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点击预览函数
        /// </summary>
        [Fact]
        public void TestPreview() {
            _wrapper.SetContextAttribute( UiConst.Preview, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzPreview]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义文件预览函数
        /// </summary>
        [Fact]
        public void TestPreviewFile() {
            _wrapper.SetContextAttribute( UiConst.PreviewFile, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzPreviewFile]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试预览文件是否有效图片函数
        /// </summary>
        [Fact]
        public void TestPreviewIsImage() {
            _wrapper.SetContextAttribute( UiConst.PreviewIsImage, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzPreviewIsImage]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试移除文件函数
        /// </summary>
        [Fact]
        public void TestRemove() {
            _wrapper.SetContextAttribute( UiConst.Remove, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzRemove]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下载文件函数
        /// </summary>
        [Fact]
        public void TestDownload() {
            _wrapper.SetContextAttribute( UiConst.Download, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzDownload]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试转换文件函数
        /// </summary>
        [Fact]
        public void TestTransformFile() {
            _wrapper.SetContextAttribute( UiConst.TransformFile, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzTransformFile]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标渲染模板
        /// </summary>
        [Fact]
        public void TestIconRender() {
            _wrapper.SetContextAttribute( UiConst.IconRender, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzIconRender]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文件列表渲染模板
        /// </summary>
        [Fact]
        public void TestFileListRender() {
            _wrapper.SetContextAttribute( UiConst.FileListRender, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload [nzFileListRender]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload>a</nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试上传文件改变事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            _wrapper.SetContextAttribute( UiConst.OnChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload (nzChange)=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<nz-upload *nzSpaceItem=\"\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}