using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular;
using Util.Ui.CkEditor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.CkEditor {
    /// <summary>
    /// 富文本框编辑器测试
    /// </summary>
    public class EditorTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 富文本框编辑器
        /// </summary>
        private readonly EditorTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public EditorTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new EditorTagHelper();
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
            result.Append( "<ckeditor></ckeditor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<ckeditor #a=\"\"></ckeditor>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<ckeditor name=\"a\"></ckeditor>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加绑定名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindName, "a" } };
            var result = new String();
            result.Append( "<ckeditor [name]=\"a\"></ckeditor>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var attributes = new TagHelperAttributeList { { UiConst.Model, "a" } };
            var result = new String();
            result.Append( "<ckeditor [(ngModel)]=\"a\"></ckeditor>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传地址
        /// </summary>
        [Fact]
        public void TestUploadUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.UploadUrl, "a" } };
            var result = new String();
            result.Append( "<ckeditor [config]=\"{'filebrowserUploadUrl':'a'}\"></ckeditor>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试高度
        /// </summary>
        [Fact]
        public void TestHeight() {
            var attributes = new TagHelperAttributeList { { UiConst.UploadUrl, "a" },{ UiConst.Height, "1" } };
            var result = new String();
            result.Append( "<ckeditor [config]=\"{'filebrowserUploadUrl':'a','height':'1'}\"></ckeditor>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用过滤
        /// </summary>
        [Fact]
        public void TestDisableFilter() {
            var attributes = new TagHelperAttributeList { { UiConst.DisableFilter,true } };
            var result = new String();
            result.Append( "<ckeditor [config]=\"{'allowedContent':true}\"></ckeditor>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}