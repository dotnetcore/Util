using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Forms {
    /// <summary>
    /// 表单控件测试
    /// </summary>
    public class FormControlTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表单控件
        /// </summary>
        private readonly FormControlTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public FormControlTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new FormControlTagHelper();
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
            result.Append( "<nz-form-control></nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-form-control #a=\"\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试跨度
        /// </summary>
        [Fact]
        public void TestSpan() {
            var attributes = new TagHelperAttributeList { { UiConst.Span, 2 } };
            var result = new String();
            result.Append( "<nz-form-control [nzSpan]=\"2\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试偏移量
        /// </summary>
        [Fact]
        public void TestOffset() {
            var attributes = new TagHelperAttributeList { { UiConst.Offset, 2 } };
            var result = new String();
            result.Append( "<nz-form-control [nzOffset]=\"2\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}