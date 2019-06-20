using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Forms {
    /// <summary>
    /// 表单标签测试
    /// </summary>
    public class FormLabelTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表单标签
        /// </summary>
        private readonly FormLabelTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public FormLabelTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new FormLabelTagHelper();
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
            result.Append( "<nz-form-label></nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-form-label #a=\"\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestLabel() {
            var attributes = new TagHelperAttributeList { { UiConst.Label, "a" } };
            var result = new String();
            result.Append( "<nz-form-label>" );
            result.Append( "a" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填样式
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, "true" } };
            var result = new String();
            result.Append( "<nz-form-label [nzRequired]=\"true\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试标签for
        /// </summary>
        [Fact]
        public void TestLabelFor() {
            var attributes = new TagHelperAttributeList { { UiConst.LabelFor, "a" } };
            var result = new String();
            result.Append( "<nz-form-label nzFor=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示标签冒号
        /// </summary>
        [Fact]
        public void TestShowColon() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowColon, true } };
            var result = new String();
            result.Append( "<nz-form-label [nzNoColon]=\"false\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试跨度
        /// </summary>
        [Fact]
        public void TestSpan() {
            var attributes = new TagHelperAttributeList { { UiConst.Span, 2 } };
            var result = new String();
            result.Append( "<nz-form-label [nzSpan]=\"2\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}