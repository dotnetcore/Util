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
    /// 多行文本框测试
    /// </summary>
    public class TextAreaTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 多行文本框
        /// </summary>
        private readonly TextAreaTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TextAreaTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TextAreaTagHelper();
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
            result.Append( "<x-textarea></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<x-textarea #a=\"\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<x-textarea name=\"a\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<x-textarea [disabled]=\"true\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestReadOnly() {
            var attributes = new TagHelperAttributeList { { UiConst.ReadOnly, true } };
            var result = new String();
            result.Append( "<x-textarea [readonly]=\"true\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            var attributes = new TagHelperAttributeList { { UiConst.Placeholder, "a" } };
            var result = new String();
            result.Append( "<x-textarea placeholder=\"a\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置绑定占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindPlaceholder, "a" } };
            var result = new String();
            result.Append( "<x-textarea [placeholder]=\"a\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgModel, "a" } };
            var result = new String();
            result.Append( "<x-textarea [(model)]=\"a\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, true } };
            var result = new String();
            result.Append( "<x-textarea [required]=\"true\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项错误消息
        /// </summary>
        [Fact]
        public void TestRequiredMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RequiredMessage, "a" } };
            var result = new String();
            result.Append( "<x-textarea requiredMessage=\"a\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小长度
        /// </summary>
        [Fact]
        public void TestMinLength() {
            var attributes = new TagHelperAttributeList { { UiConst.MinLength, 3 } };
            var result = new String();
            result.Append( "<x-textarea [minLength]=\"3\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小长度,添加指定错误消息
        /// </summary>
        [Fact]
        public void TestMinLength_Message() {
            var attributes = new TagHelperAttributeList { { UiConst.MinLengthMessage, "a" } };
            var result = new String();
            result.Append( "<x-textarea minLengthMessage=\"a\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大长度
        /// </summary>
        [Fact]
        public void TestMaxLength() {
            var attributes = new TagHelperAttributeList { { UiConst.MaxLength, 3 } };
            var result = new String();
            result.Append( "<x-textarea [maxLength]=\"3\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试正则表达式验证
        /// </summary>
        [Fact]
        public void TestRegex() {
            var attributes = new TagHelperAttributeList { { UiConst.Regex, "a" } };
            var result = new String();
            result.Append( "<x-textarea pattern=\"a\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试正则表达式验证消息
        /// </summary>
        [Fact]
        public void TestRegexMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RegexMessage, "a" } };
            var result = new String();
            result.Append( "<x-textarea patterMessage=\"a\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试栅格跨度
        /// </summary>
        [Fact]
        public void TestSpan() {
            var attributes = new TagHelperAttributeList { { UiConst.Span, 2 } };
            var result = new String();
            result.Append( "<nz-form-control [nzSpan]=\"2\">" );
            result.Append( "<x-textarea></x-textarea>" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<x-textarea (onChange)=\"a\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            var attributes = new TagHelperAttributeList { { UiConst.OnFocus, "a" } };
            var result = new String();
            result.Append( "<x-textarea (onFocus)=\"a\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            var attributes = new TagHelperAttributeList { { UiConst.OnBlur, "a" } };
            var result = new String();
            result.Append( "<x-textarea (onBlur)=\"a\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试键盘按下事件
        /// </summary>
        [Fact]
        public void TestOnKeydown() {
            var attributes = new TagHelperAttributeList { { UiConst.OnKeydown, "a" } };
            var result = new String();
            result.Append( "<x-textarea (onKeydown)=\"a\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小行数
        /// </summary>
        [Fact]
        public void TestMinRows() {
            var attributes = new TagHelperAttributeList { { UiConst.MinRows, 3 } };
            var result = new String();
            result.Append( "<x-textarea [minRows]=\"3\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大行数
        /// </summary>
        [Fact]
        public void TestMaxRows() {
            var attributes = new TagHelperAttributeList { { UiConst.MaxRows, 3 } };
            var result = new String();
            result.Append( "<x-textarea [maxRows]=\"3\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}