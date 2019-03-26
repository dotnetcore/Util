using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Forms {
    /// <summary>
    /// 文件上传控件测试
    /// </summary>
    public class UploadTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 文件上传
        /// </summary>
        private readonly UploadTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public UploadTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new UploadTagHelper();
            Config.IsValidate = false;
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
            result.Append( "<nz-upload></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-upload #a=\"\">" );
            result.Append( "</nz-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传地址
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<nz-upload nzAction=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试上传地址
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindUrl, "a" } };
            var result = new String();
            result.Append( "<nz-upload [nzAction]=\"a\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试多选
        /// </summary>
        [Fact]
        public void TestMultiple() {
            var attributes = new TagHelperAttributeList { { UiConst.Multiple, true } };
            var result = new String();
            result.Append( "<nz-upload [nzMultiple]=\"true\"></nz-upload>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}