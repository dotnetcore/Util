using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Forms.TagHelpers {
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
            result.Append( "<mat-textbox-wrapper></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper #a=\"\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper name=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加绑定名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindName, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper [name]=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper [disabled]=\"true\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestReadOnly() {
            var attributes = new TagHelperAttributeList { { UiConst.ReadOnly, true } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper [readonly]=\"true\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            var attributes = new TagHelperAttributeList { { UiConst.Placeholder, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper placeholder=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置绑定占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindPlaceholder, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper [placeholder]=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示浮动位置
        /// </summary>
        [Fact]
        public void TestFloatPlaceholder() {
            var attributes = new TagHelperAttributeList { { MaterialConst.FloatPlaceholder, FloatType.Never } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper floatPlaceholder=\"never\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置起始提示
        /// </summary>
        [Fact]
        public void TestStartHint() {
            var attributes = new TagHelperAttributeList { { MaterialConst.StartHint, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper startHint=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置结束提示
        /// </summary>
        [Fact]
        public void TestEndHint() {
            var attributes = new TagHelperAttributeList { { MaterialConst.EndHint, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper endHint=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置前缀
        /// </summary>
        [Fact]
        public void TestPrefix() {
            var attributes = new TagHelperAttributeList { { UiConst.Prefix, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper prefixText=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀文本
        /// </summary>
        [Fact]
        public void TestSuffixText() {
            var attributes = new TagHelperAttributeList { { MaterialConst.SuffixText, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper suffixText=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀FontAwesome图标
        /// </summary>
        [Fact]
        public void TestSuffixFontAwesomeIcon() {
            var attributes = new TagHelperAttributeList { { MaterialConst.SuffixFontAwesomeIcon, FontAwesomeIcon.Apple } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper suffixFontAwesomeIcon=\"fa-apple\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀Material图标
        /// </summary>
        [Fact]
        public void TestSuffixMaterialIcon() {
            var attributes = new TagHelperAttributeList { { MaterialConst.SuffixMaterialIcon, MaterialIcon.Android } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper suffixMaterialIcon=\"android\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀图标单击事件
        /// </summary>
        [Fact]
        public void TestOnSuffixIconClick() {
            var attributes = new TagHelperAttributeList { { MaterialConst.OnSuffixIconClick, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper (onSuffixIconClick)=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否显示清除按钮
        /// </summary>
        [Fact]
        public void TestShowClearButton() {
            var attributes = new TagHelperAttributeList { { MaterialConst.ShowClearButton, false } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper [showClearButton]=\"false\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
        

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var attributes = new TagHelperAttributeList { { UiConst.Model, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper [(model)]=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置为密码框
        /// </summary>
        [Fact]
        public void TestType_Password() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TextBoxType.Password } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper type=\"password\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置为数字框
        /// </summary>
        [Fact]
        public void TestType_Number() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TextBoxType.Number } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper type=\"number\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置为电子邮件框
        /// </summary>
        [Fact]
        public void TestType_Email() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TextBoxType.Email } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper type=\"email\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置为多行文本框
        /// </summary>
        [Fact]
        public void TestType_Multiple() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TextBoxType.Multiple } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper type=\"text\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置为电子邮件框
        /// </summary>
        [Fact]
        public void TestEmailMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.EmailMessage, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper emailMessage=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, true } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper [required]=\"true\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项错误消息
        /// </summary>
        [Fact]
        public void TestRequiredMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RequiredMessage, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper requiredMessage=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小长度
        /// </summary>
        [Fact]
        public void TestMinLength() {
            var attributes = new TagHelperAttributeList { { UiConst.MinLength, 3 } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper [minLength]=\"3\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小长度,添加指定错误消息
        /// </summary>
        [Fact]
        public void TestMinLength_Message() {
            var attributes = new TagHelperAttributeList { { UiConst.MinLengthMessage, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper minLengthMessage=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大长度
        /// </summary>
        [Fact]
        public void TestMaxLength() {
            var attributes = new TagHelperAttributeList { { UiConst.MaxLength, 3 } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper [maxLength]=\"3\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小值验证
        /// </summary>
        [Fact]
        public void TestMin() {
            var attributes = new TagHelperAttributeList { { UiConst.Min, 3 } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper [min]=\"3\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小值,添加指定错误消息
        /// </summary>
        [Fact]
        public void TestMin_Message() {
            var attributes = new TagHelperAttributeList { { UiConst.MinMessage, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper minMessage=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大值验证
        /// </summary>
        [Fact]
        public void TestMax() {
            var attributes = new TagHelperAttributeList { { UiConst.Max, 3 } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper [max]=\"3\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大值,添加指定错误消息
        /// </summary>
        [Fact]
        public void TestMax_Message() {
            var attributes = new TagHelperAttributeList { { UiConst.MaxMessage, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper maxMessage=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试正则表达式验证
        /// </summary>
        [Fact]
        public void TestRegex() {
            var attributes = new TagHelperAttributeList { { UiConst.Regex, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper pattern=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试正则表达式验证消息
        /// </summary>
        [Fact]
        public void TestRegexMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RegexMessage, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper patterMessage=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper (onChange)=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            var attributes = new TagHelperAttributeList { { UiConst.OnFocus, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper (onFocus)=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            var attributes = new TagHelperAttributeList { { UiConst.OnBlur, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper (onBlur)=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试键盘按下事件
        /// </summary>
        [Fact]
        public void TestOnKeydown() {
            var attributes = new TagHelperAttributeList { { UiConst.OnKeydown, "a" } };
            var result = new String();
            result.Append( "<mat-textbox-wrapper (onKeydown)=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
