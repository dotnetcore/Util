using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Enums;
using Util.Ui.Zorro.Forms;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Forms {
    /// <summary>
    /// 单文件上传控件测试
    /// </summary>
    public class SingleUploadTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 单文件上传
        /// </summary>
        private readonly SingleUploadTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SingleUploadTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new SingleUploadTagHelper();
            Config.IsValidate = false;
            Id.SetId( "id" );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" [(nzFileList)]=\"m_id.files\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #a_wrapper=\"\">" );
            result.Append( "<nz-upload #a=\"\" (nzChange)=\"a_wrapper.handleChange($event)\" [(nzFileList)]=\"a_wrapper.files\" " );
            result.Append( "[nzFilter]=\"a_wrapper.filters\" [nzShowButton]=\"!a_wrapper.files||(a_wrapper.files&&a_wrapper.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传地址
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" nzAction=\"a\" [(nzFileList)]=\"m_id.files\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传地址
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindUrl, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" [(nzFileList)]=\"m_id.files\" [nzAction]=\"a\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgModel, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\" [(model)]=\"a\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" [(nzFileList)]=\"m_id.files\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" [(nzFileList)]=\"m_id.files\" [nzDisabled]=\"a\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\" [disabled]=\"a\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示上传按钮
        /// </summary>
        [Fact]
        public void TestShowButton() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowButton, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" [(nzFileList)]=\"m_id.files\" [nzFilter]=\"m_id.filters\" [nzShowButton]=\"a\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试按钮文本
        /// </summary>
        [Fact]
        public void TestButtonText() {
            var attributes = new TagHelperAttributeList { { UiConst.ButtonText, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" [(nzFileList)]=\"m_id.files\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"a\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试按钮图标
        /// </summary>
        [Fact]
        public void TestButtonIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.ButtonIcon, AntDesignIcon.Check } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" [(nzFileList)]=\"m_id.files\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"check\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试接受上传的文件类型
        /// </summary>
        [Fact]
        public void TestAccept() {
            var attributes = new TagHelperAttributeList { { UiConst.Accept, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" nzAccept=\"a\" [(nzFileList)]=\"m_id.files\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试允许上传图片文件
        /// </summary>
        [Fact]
        public void TestAcceptImage() {
            var attributes = new TagHelperAttributeList { { UiConst.AcceptImage, true } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload " );
            result.Append( "(nzChange)=\"m_id.handleChange($event)\" nzAccept=\".jpg,.jpeg,.png,.gif,.bmp\" " );
            result.Append( "[(nzFileList)]=\"m_id.files\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试允许上传文档文件
        /// </summary>
        [Fact]
        public void TestAcceptDocument() {
            var attributes = new TagHelperAttributeList { { UiConst.AcceptDocument, true } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload " );
            result.Append( "(nzChange)=\"m_id.handleChange($event)\" nzAccept=\".xls,.xlsx,.doc,.docx,.pdf,.txt\" " );
            result.Append( "[(nzFileList)]=\"m_id.files\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文件大小限制
        /// </summary>
        [Fact]
        public void TestSize() {
            var attributes = new TagHelperAttributeList { { UiConst.Size, 1.1 } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" nzSize=\"1.1\" [(nzFileList)]=\"m_id.files\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传参数
        /// </summary>
        [Fact]
        public void TestData() {
            var attributes = new TagHelperAttributeList { { UiConst.Data, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" [(nzFileList)]=\"m_id.files\" [nzData]=\"a\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传状态改变事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"a\" [(nzFileList)]=\"m_id.files\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传前事件
        /// </summary>
        [Fact]
        public void TestOnBeforeUpload() {
            var attributes = new TagHelperAttributeList { { UiConst.OnBeforeUpload, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" [(nzFileList)]=\"m_id.files\" [nzBeforeUpload]=\"a\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试过滤器
        /// </summary>
        [Fact]
        public void TestFilter() {
            var attributes = new TagHelperAttributeList { { UiConst.Filter, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" [(nzFileList)]=\"m_id.files\" " );
            result.Append( "[nzFilter]=\"a\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文件列表
        /// </summary>
        [Fact]
        public void TestFileList() {
            var attributes = new TagHelperAttributeList { { UiConst.FileList, "a" } };
            var result = new String();
            result.Append( "<nz-single-upload-wrapper #m_id=\"\">" );
            result.Append( "<nz-upload (nzChange)=\"m_id.handleChange($event)\" [(nzFileList)]=\"a\" " );
            result.Append( "[nzFilter]=\"m_id.filters\" [nzShowButton]=\"!m_id.files||(m_id.files&&m_id.files).length<1\">" );
            result.Append( "<x-button text=\"上传\">" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"upload\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            result.Append( "</nz-upload>" );
            result.Append( "</nz-single-upload-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}