using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular;
using Util.Ui.ColorPickers.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Prime.ColorPickers {
    /// <summary>
    /// 颜色选择器测试
    /// </summary>
    public class ColorPickerTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 颜色选择器
        /// </summary>
        private readonly ColorPickerTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ColorPickerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new ColorPickerTagHelper();
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
            result.Append( "<p-colorPicker></p-colorPicker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<p-colorPicker #a=\"\"></p-colorPicker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<p-colorPicker name=\"a\"></p-colorPicker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加绑定名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindName, "a" } };
            var result = new String();
            result.Append( "<p-colorPicker [name]=\"a\"></p-colorPicker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var attributes = new TagHelperAttributeList { { UiConst.Model, "a" } };
            var result = new String();
            result.Append( "<p-colorPicker [(ngModel)]=\"a\"></p-colorPicker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<p-colorPicker [disabled]=\"true\"></p-colorPicker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试内联
        /// </summary>
        [Fact]
        public void TestInline() {
            var attributes = new TagHelperAttributeList { { UiConst.Inline, true } };
            var result = new String();
            result.Append( "<p-colorPicker inline=\"true\"></p-colorPicker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<p-colorPicker (onChange)=\"a\"></p-colorPicker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试独立
        /// </summary>
        [Fact]
        public void TestStandalone() {
            var attributes = new TagHelperAttributeList {{UiConst.Standalone, true}};
            var result = new String();
            result.Append( "<p-colorPicker [ngModelOptions]=\"{standalone: true}\"></p-colorPicker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}