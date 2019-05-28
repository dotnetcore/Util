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
    /// 文本框测试
    /// </summary>
    public class TextBoxTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 文本框
        /// </summary>
        private readonly TextBoxTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TextBoxTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TextBoxTagHelper();
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
            result.Append( "<x-textbox></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<x-textbox #a=\"\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<x-textbox name=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加绑定名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindName, "a" } };
            var result = new String();
            result.Append( "<x-textbox [name]=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<x-textbox [disabled]=\"true\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestReadOnly() {
            var attributes = new TagHelperAttributeList { { UiConst.ReadOnly, true } };
            var result = new String();
            result.Append( "<x-textbox [readonly]=\"true\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            var attributes = new TagHelperAttributeList { { UiConst.Placeholder, "a" } };
            var result = new String();
            result.Append( "<x-textbox placeholder=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置绑定占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindPlaceholder, "a" } };
            var result = new String();
            result.Append( "<x-textbox [placeholder]=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgModel, "a" } };
            var result = new String();
            result.Append( "<x-textbox [(model)]=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置为密码框
        /// </summary>
        [Fact]
        public void TestType_Password() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TextBoxType.Password } };
            var result = new String();
            result.Append( "<x-textbox type=\"password\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置为数字框
        /// </summary>
        [Fact]
        public void TestType_Number() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TextBoxType.Number } };
            var result = new String();
            result.Append( "<x-textbox></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置为多行文本框
        /// </summary>
        [Fact]
        public void TestType_Multiple() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TextBoxType.Multiple } };
            var result = new String();
            result.Append( "<x-textarea type=\"text\"></x-textarea>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置为电子邮件
        /// </summary>
        [Fact]
        public void TestType_Email() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TextBoxType.Email } };
            var result = new String();
            result.Append( "<x-textbox type=\"email\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置电子邮件错误消息
        /// </summary>
        [Fact]
        public void TestEmailMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.EmailMessage, "a" } };
            var result = new String();
            result.Append( "<x-textbox emailMessage=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, true } };
            var result = new String();
            result.Append( "<x-textbox [required]=\"true\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项错误消息
        /// </summary>
        [Fact]
        public void TestRequiredMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RequiredMessage, "a" } };
            var result = new String();
            result.Append( "<x-textbox requiredMessage=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小长度
        /// </summary>
        [Fact]
        public void TestMinLength() {
            var attributes = new TagHelperAttributeList { { UiConst.MinLength, 3 } };
            var result = new String();
            result.Append( "<x-textbox [minLength]=\"3\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小长度,添加指定错误消息
        /// </summary>
        [Fact]
        public void TestMinLength_Message() {
            var attributes = new TagHelperAttributeList { { UiConst.MinLengthMessage, "a" } };
            var result = new String();
            result.Append( "<x-textbox minLengthMessage=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大长度
        /// </summary>
        [Fact]
        public void TestMaxLength() {
            var attributes = new TagHelperAttributeList { { UiConst.MaxLength, 3 } };
            var result = new String();
            result.Append( "<x-textbox [maxLength]=\"3\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小值验证
        /// </summary>
        [Fact]
        public void TestMin() {
            var attributes = new TagHelperAttributeList { { UiConst.Min, 3 } };
            var result = new String();
            result.Append( "<x-textbox [min]=\"3\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小值,添加指定错误消息
        /// </summary>
        [Fact]
        public void TestMin_Message() {
            var attributes = new TagHelperAttributeList { { UiConst.MinMessage, "a" } };
            var result = new String();
            result.Append( "<x-textbox minMessage=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大值验证
        /// </summary>
        [Fact]
        public void TestMax() {
            var attributes = new TagHelperAttributeList { { UiConst.Max, 3 } };
            var result = new String();
            result.Append( "<x-textbox [max]=\"3\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大值,添加指定错误消息
        /// </summary>
        [Fact]
        public void TestMax_Message() {
            var attributes = new TagHelperAttributeList { { UiConst.MaxMessage, "a" } };
            var result = new String();
            result.Append( "<x-textbox maxMessage=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试正则表达式验证
        /// </summary>
        [Fact]
        public void TestRegex() {
            var attributes = new TagHelperAttributeList { { UiConst.Regex, "a" } };
            var result = new String();
            result.Append( "<x-textbox pattern=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试正则表达式验证消息
        /// </summary>
        [Fact]
        public void TestRegexMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RegexMessage, "a" } };
            var result = new String();
            result.Append( "<x-textbox patterMessage=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<x-textbox (onChange)=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            var attributes = new TagHelperAttributeList { { UiConst.OnFocus, "a" } };
            var result = new String();
            result.Append( "<x-textbox (onFocus)=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            var attributes = new TagHelperAttributeList { { UiConst.OnBlur, "a" } };
            var result = new String();
            result.Append( "<x-textbox (onBlur)=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试键盘按下事件
        /// </summary>
        [Fact]
        public void TestOnKeydown() {
            var attributes = new TagHelperAttributeList { { UiConst.OnKeydown, "a" } };
            var result = new String();
            result.Append( "<x-textbox (onKeydown)=\"a\"></x-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
