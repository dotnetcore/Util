using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Upload {
    /// <summary>
    /// 上传测试 - 扩展测试
    /// </summary>
    public partial class UploadTagHelperTest {
        /// <summary>
        /// 测试禁用扩展
        /// </summary>
        [Fact]
        public void TestEnableExtend_False() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, false );
            _wrapper.SetContextAttribute( UiConst.Required, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-upload>" );
            result.Append( GetButton() );
            result.Append( "</nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" );
            var result = new StringBuilder();
            result.Append( "<nz-upload #u_id=\"xUploadExtend\" (nzChange)=\"u_id.handleChange($event)\" x-upload-extend=\"\" " );
            result.Append( "[(model)]=\"code\" [(nzFileList)]=\"u_id.files\" [nzFilter]=\"u_id.filters\">" );
            result.Append( GetButton() );
            result.Append( "</nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "a" );
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "b" );
            var result = new StringBuilder();
            result.Append( "<nz-upload #u_id=\"xUploadExtend\" (modelChange)=\"b\" (nzChange)=\"u_id.handleChange($event)\" x-upload-extend=\"\" " );
            result.Append( "[(model)]=\"a\" [(nzFileList)]=\"u_id.files\" [nzFilter]=\"u_id.filters\">" );
            result.Append( GetButton() );
            result.Append( "</nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNotBindFileList() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" );
            _wrapper.SetContextAttribute( AngularConst.NotBindFileList, true );
            var result = new StringBuilder();
            result.Append( "<nz-upload #u_id=\"xUploadExtend\" (nzChange)=\"u_id.handleChange($event)\" x-upload-extend=\"\" [(model)]=\"code\" [nzFilter]=\"u_id.filters\">" );
            result.Append( GetButton() );
            result.Append( "</nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否清除文件列表
        /// </summary>
        [Fact]
        public void TestClearFiles() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" );
            _wrapper.SetContextAttribute( UiConst.ClearFiles, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-upload #u_id=\"xUploadExtend\" (nzChange)=\"u_id.handleChange($event)\" x-upload-extend=\"\" " );
            result.Append( "[(model)]=\"code\" [(nzFileList)]=\"u_id.files\" [isClearFiles]=\"true\" [nzFilter]=\"u_id.filters\">" );
            result.Append( GetButton() );
            result.Append( "</nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型数据转换为上传文件列表的延迟时间
        /// </summary>
        [Fact]
        public void TestModelToFilesDebounceTime() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" );
            _wrapper.SetContextAttribute( UiConst.ModelToFilesDebounceTime, 10 );
            var result = new StringBuilder();
            result.Append( "<nz-upload #u_id=\"xUploadExtend\" (nzChange)=\"u_id.handleChange($event)\" x-upload-extend=\"\" " );
            result.Append( "[(model)]=\"code\" [(nzFileList)]=\"u_id.files\" [modelToFilesDebounceTime]=\"10\" [nzFilter]=\"u_id.filters\">" );
            result.Append( GetButton() );
            result.Append( "</nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试上传完成事件
        /// </summary>
        [Fact]
        public void TestOnUploadComplete() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" );
            _wrapper.SetContextAttribute( UiConst.OnUploadComplete, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-upload #u_id=\"xUploadExtend\" (nzChange)=\"u_id.handleChange($event)\" (onUploadComplete)=\"a\" x-upload-extend=\"\" " );
            result.Append( "[(model)]=\"code\" [(nzFileList)]=\"u_id.files\" [nzFilter]=\"u_id.filters\">" );
            result.Append( GetButton() );
            result.Append( "</nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}