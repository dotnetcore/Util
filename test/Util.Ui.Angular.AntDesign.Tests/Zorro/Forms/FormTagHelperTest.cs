using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Forms {
    /// <summary>
    /// 表单测试
    /// </summary>
    public class FormTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表单
        /// </summary>
        private readonly FormTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public FormTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new FormTagHelper();
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
            result.Append( "<form nz-form=\"\"></form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<form #a=\"ngForm\" nz-form=\"\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试提交事件
        /// </summary>
        [Fact]
        public void TestOnSubmit() {
            var attributes = new TagHelperAttributeList { { UiConst.OnSubmit, "a" } };
            var result = new String();
            result.Append( "<form (ngSubmit)=\"a\" nz-form=\"\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}