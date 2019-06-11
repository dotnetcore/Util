using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
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
            result.Append( "<x-single-upload>" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<x-single-upload #a=\"\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文件参数名
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<x-single-upload name=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传地址
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<x-single-upload url=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传地址
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindUrl, "a" } };
            var result = new String();
            result.Append( "<x-single-upload [url]=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传参数
        /// </summary>
        [Fact]
        public void TestData() {
            var attributes = new TagHelperAttributeList { { UiConst.Data, "a" } };
            var result = new String();
            result.Append( "<x-single-upload [data]=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置上传请求头部
        /// </summary>
        [Fact]
        public void TestHeaders() {
            var attributes = new TagHelperAttributeList { { UiConst.Headers, "a" } };
            var result = new String();
            result.Append( "<x-single-upload [headers]=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgModel, "a" } };
            var result = new String();
            result.Append( "<x-single-upload [(model)]=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试携带cookie
        /// </summary>
        [Fact]
        public void TestWithCredentials() {
            var attributes = new TagHelperAttributeList { { UiConst.WithCredentials, true } };
            var result = new String();
            result.Append( "<x-single-upload [withCredentials]=\"true\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, "a" } };
            var result = new String();
            result.Append( "<x-single-upload [disabled]=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, "true" } };
            var result = new String();
            result.Append( "<x-single-upload [required]=\"true\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填消息
        /// </summary>
        [Fact]
        public void TestRequiredMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RequiredMessage, "a" } };
            var result = new String();
            result.Append( "<x-single-upload requiredMessage=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示上传按钮
        /// </summary>
        [Fact]
        public void TestShowButton() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowButton, "a" } };
            var result = new String();
            result.Append( "<x-single-upload [showButton]=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示上传列表
        /// </summary>
        [Fact]
        public void TestShowUploadList() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowUploadList, "a" } };
            var result = new String();
            result.Append( "<x-single-upload [showUploadList]=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试列表类型
        /// </summary>
        [Fact]
        public void TestListType() {
            var attributes = new TagHelperAttributeList { { UiConst.ListType, UploadListType.Default } };
            var result = new String();
            result.Append( "<x-single-upload listType=\"text\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试多选
        /// </summary>
        [Fact]
        public void TestMultiple() {
            var attributes = new TagHelperAttributeList { { UiConst.Multiple, true } };
            var result = new String();
            result.Append( "<x-single-upload [multiple]=\"true\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试按钮文本
        /// </summary>
        [Fact]
        public void TestButtonText() {
            var attributes = new TagHelperAttributeList { { UiConst.ButtonText, "a" } };
            var result = new String();
            result.Append( "<x-single-upload buttonText=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试按钮图标
        /// </summary>
        [Fact]
        public void TestButtonIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.ButtonIcon, AntDesignIcon.Check } };
            var result = new String();
            result.Append( "<x-single-upload buttonIcon=\"check\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试接受上传的文件类型
        /// </summary>
        [Fact]
        public void TestAccept() {
            var attributes = new TagHelperAttributeList { { UiConst.Accept, "a" } };
            var result = new String();
            result.Append( "<x-single-upload accept=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试允许上传图片文件
        /// </summary>
        [Fact]
        public void TestAcceptImage() {
            var attributes = new TagHelperAttributeList { { UiConst.AcceptImage, true } };
            var result = new String();
            result.Append( "<x-single-upload accept=\".jpg,.jpeg,.png,.gif,.bmp\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试允许上传文档文件
        /// </summary>
        [Fact]
        public void TestAcceptDocument() {
            var attributes = new TagHelperAttributeList { { UiConst.AcceptDocument, true } };
            var result = new String();
            result.Append( "<x-single-upload accept=\".xls,.xlsx,.doc,.docx,.pdf,.txt\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试图片文件类型限制 - Jpg
        /// </summary>
        [Fact]
        public void TestImageTypes_Jpg() {
            var attributes = new TagHelperAttributeList { { UiConst.ImageTypes, new List<ImageType> { ImageType.Jpg } } };
            var result = new String();
            result.Append( "<x-single-upload accept=\".jpg,.jpeg\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试图片文件类型限制 - Jpg + Png
        /// </summary>
        [Fact]
        public void TestImageTypes_Jpg_Png() {
            var attributes = new TagHelperAttributeList { { UiConst.ImageTypes, new List<ImageType> { ImageType.Jpg, ImageType.Png } } };
            var result = new String();
            result.Append( "<x-single-upload accept=\".jpg,.jpeg,.png\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文档文件类型限制 - Doc
        /// </summary>
        [Fact]
        public void TestDocumentTypes_Doc() {
            var attributes = new TagHelperAttributeList { { UiConst.DocumentTypes, new List<DocumentType> { DocumentType.Doc } } };
            var result = new String();
            result.Append( "<x-single-upload accept=\".doc,.docx\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文件大小限制
        /// </summary>
        [Fact]
        public void TestSize() {
            var attributes = new TagHelperAttributeList { { UiConst.Size, 1.1 } };
            var result = new String();
            result.Append( "<x-single-upload [size]=\"1.1\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传文件夹
        /// </summary>
        [Fact]
        public void TestDirectory() {
            var attributes = new TagHelperAttributeList { { UiConst.Directory, true } };
            var result = new String();
            result.Append( "<x-single-upload [directory]=\"true\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试过滤器
        /// </summary>
        [Fact]
        public void TestFilter() {
            var attributes = new TagHelperAttributeList { { UiConst.Filter, "a" } };
            var result = new String();
            result.Append( "<x-single-upload [customFilters]=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传总数量限制
        /// </summary>
        [Fact]
        public void TestTotalLimit() {
            var attributes = new TagHelperAttributeList { { UiConst.TotalLimit, 2 } };
            var result = new String();
            result.Append( "<x-single-upload [totalLimit]=\"2\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单次最大上传数量限制
        /// </summary>
        [Fact]
        public void TestLimit() {
            var attributes = new TagHelperAttributeList { { UiConst.Limit, 2 } };
            var result = new String();
            result.Append( "<x-single-upload [limit]=\"2\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传前操作
        /// </summary>
        [Fact]
        public void TestBeforeUpload() {
            var attributes = new TagHelperAttributeList { { UiConst.BeforeUpload, "a" } };
            var result = new String();
            result.Append( "<x-single-upload [beforeUpload]=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试预览操作
        /// </summary>
        [Fact]
        public void TestPreview() {
            var attributes = new TagHelperAttributeList { { UiConst.Preview, "a" } };
            var result = new String();
            result.Append( "<x-single-upload [preview]=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试移除操作
        /// </summary>
        [Fact]
        public void TestRemove() {
            var attributes = new TagHelperAttributeList { { UiConst.Remove, "a" } };
            var result = new String();
            result.Append( "<x-single-upload [remove]=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试自定义上传操作
        /// </summary>
        [Fact]
        public void TestCustomRequest() {
            var attributes = new TagHelperAttributeList { { UiConst.CustomRequest, "a" } };
            var result = new String();
            result.Append( "<x-single-upload [customRequest]=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传状态改变事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<x-single-upload (modelChange)=\"a\">" );
            result.Append( "</x-single-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}