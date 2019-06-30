using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
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
            result.Append( "<form autocomplete=\"off\" nz-form=\"\"></form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<form #a=\"ngForm\" autocomplete=\"off\" nz-form=\"\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试布局
        /// </summary>
        [Fact]
        public void TestLayout() {
            var attributes = new TagHelperAttributeList { { UiConst.Layout, FormLayout.Inline } };
            var result = new String();
            result.Append( "<form autocomplete=\"off\" nz-form=\"\" nzLayout=\"inline\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示标签冒号
        /// </summary>
        [Fact]
        public void TestShowColon() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowColon, false } };
            var result = new String();
            result.Append( "<form autocomplete=\"off\" nz-form=\"\" [nzNoColon]=\"true\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试自动完成打开
        /// </summary>
        [Fact]
        public void TestAutoComplete_On() {
            var attributes = new TagHelperAttributeList { { UiConst.AutoComplete, true } };
            var result = new String();
            result.Append( "<form autocomplete=\"on\" nz-form=\"\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试自动完成关闭
        /// </summary>
        [Fact]
        public void TestAutoComplete_Off() {
            var attributes = new TagHelperAttributeList { { UiConst.AutoComplete, false } };
            var result = new String();
            result.Append( "<form autocomplete=\"off\" nz-form=\"\">" );
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
            result.Append( "<form (ngSubmit)=\"a\" autocomplete=\"off\" nz-form=\"\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}