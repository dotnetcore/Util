using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Forms;
using Util.Webs;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Forms {
    /// <summary>
    /// 文本框测试
    /// </summary>
    public class TextBoxTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 单引号
        /// </summary>
        public const string Quote = HtmlEscape.SingleQuote27;
        /// <summary>
        /// 文本框
        /// </summary>
        private readonly TextBox _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TextBoxTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TextBox();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TextBox textBox ) {
            textBox.WriteTo( new StringWriter(), HtmlEncoder.Default );
            var result = textBox.ToString();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper #a=\"\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Id( "a" ) ) );
        }

        /// <summary>
        /// 测试添加名称
        /// </summary>
        [Fact]
        public void TestName() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper name=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Name( "a" ) ) );
        }

        /// <summary>
        /// 测试添加绑定名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper [name]=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.BindName( "a" ) ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper [disabled]=\"true\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Disable() ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled_String() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper [disabled]=\"a.B\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Disable( "a.B" ) ) );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestReadOnly() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper [readonly]=\"false\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.ReadOnly( false ) ) );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestReadOnly_String() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper [readonly]=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.ReadOnly( "a" ) ) );
        }

        /// <summary>
        /// 测试占位符
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper placeholder=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Placeholder( "a" ) ) );
        }

        /// <summary>
        /// 测试设置绑定占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper [placeholder]=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.BindPlaceholder( "a" ) ) );
        }

        /// <summary>
        /// 测试设置占位提示浮动位置
        /// </summary>
        [Fact]
        public void TestPlaceholder_Float() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper floatPlaceholder=\"never\" placeholder=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Placeholder( "a", FloatType.Never ) ) );
        }

        /// <summary>
        /// 测试设置起始提示
        /// </summary>
        [Fact]
        public void TestHint_Start() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper startHint=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Hint( "a" ) ) );
        }

        /// <summary>
        /// 测试设置结束提示
        /// </summary>
        [Fact]
        public void TestHint_End() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper endHint=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Hint( "a", true ) ) );
        }

        /// <summary>
        /// 测试设置前缀
        /// </summary>
        [Fact]
        public void TestPrefix() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper prefixText=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Prefix( "a" ) ) );
        }

        /// <summary>
        /// 测试设置后缀文本
        /// </summary>
        [Fact]
        public void TestSuffix_Text() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper suffixText=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Suffix( "a" ) ) );
        }

        /// <summary>
        /// 测试设置后缀FontAwesome图标
        /// </summary>
        [Fact]
        public void TestSuffix_FontAwesomeIcon() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper suffixFontAwesomeIcon=\"fa-apple\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Suffix( FontAwesomeIcon.Apple ) ) );
        }

        /// <summary>
        /// 测试设置后缀Material图标
        /// </summary>
        [Fact]
        public void TestSuffix_MaterialIcon() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper suffixMaterialIcon=\"android\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Suffix( MaterialIcon.Android ) ) );
        }

        /// <summary>
        /// 测试设置后缀FontAwesome图标单击事件
        /// </summary>
        [Fact]
        public void TestSuffix_FontAwesomeIcon_Click() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper (onSuffixIconClick)=\"a\" suffixFontAwesomeIcon=\"fa-apple\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Suffix( FontAwesomeIcon.Apple, "a" ) ) );
        }

        /// <summary>
        /// 测试设置后缀Material图标单击事件
        /// </summary>
        [Fact]
        public void TestSuffix_MaterialIcon_Click() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper (onSuffixIconClick)=\"a\" suffixMaterialIcon=\"android\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Suffix( MaterialIcon.Android, "a" ) ) );
        }

        /// <summary>
        /// 测试是否显示清除按钮
        /// </summary>
        [Fact]
        public void TestShowClearButton() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper [showClearButton]=\"false\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.ShowClearButton( false ) ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper [(model)]=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Model( "a" ) ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper [required]=\"true\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Required() ) );
        }

        /// <summary>
        /// 测试必填项,添加指定错误消息
        /// </summary>
        [Fact]
        public void TestRequired_Message() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper requiredMessage=\"a\" [required]=\"true\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Required( "a" ) ) );
        }

        /// <summary>
        /// 测试正则表达式验证
        /// </summary>
        [Fact]
        public void TestRegex() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper patterMessage=\"b\" pattern=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Regex( "a","b" ) ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper (onChange)=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnChange( "a" ) ) );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper (onFocus)=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnFocus( "a" ) ) );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper (onBlur)=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnBlur( "a" ) ) );
        }

        /// <summary>
        /// 测试键盘按键事件
        /// </summary>
        [Fact]
        public void TestOnKeyUp() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper (onKeyup)=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnKeyup( "a" ) ) );
        }

        /// <summary>
        /// 测试键盘按下事件
        /// </summary>
        [Fact]
        public void TestOnKeydown() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper (onKeydown)=\"a\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnKeydown( "a" ) ) );
        }

        /// <summary>
        /// 测试设置为密码框
        /// </summary>
        [Fact]
        public void TestPassword() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper type=\"password\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Password() ) );
        }

        /// <summary>
        /// 测试只能输入数字
        /// </summary>
        [Fact]
        public void TestNumber() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper type=\"number\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Number() ) );
        }

        /// <summary>
        /// 测试电子邮件验证
        /// </summary>
        [Fact]
        public void TestEmail() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper type=\"email\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Email() ) );
        }

        /// <summary>
        /// 测试设置电子邮件验证消息
        /// </summary>
        [Fact]
        public void TestEmail_Message() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper emailMessage=\"a\" type=\"email\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Email( "a" ) ) );
        }

        /// <summary>
        /// 测试最小长度
        /// </summary>
        [Fact]
        public void TestMinLength() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper [minLength]=\"3\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.MinLength( 3 ) ) );
        }

        /// <summary>
        /// 测试最小长度,添加指定错误消息
        /// </summary>
        [Fact]
        public void TestMinLength_Message() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper minLengthMessage=\"a\" [minLength]=\"3\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.MinLength( 3, "a" ) ) );
        }

        /// <summary>
        /// 测试最大长度
        /// </summary>
        [Fact]
        public void TestMaxLength() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper [maxLength]=\"3\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.MaxLength( 3 ) ) );
        }

        /// <summary>
        /// 测试最小值验证
        /// </summary>
        [Fact]
        public void TestMin() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper minMessage=\"a\" [min]=\"3\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Min( 3, "a" ) ) );
        }

        /// <summary>
        /// 测试最大值验证
        /// </summary>
        [Fact]
        public void TestMax() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper maxMessage=\"a\" [max]=\"3\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Max( 3,"a" ) ) );
        }

        /// <summary>
        /// 测试独立
        /// </summary>
        [Fact]
        public void TestStandalone() {
            var result = new String();
            result.Append( "<mat-textbox-wrapper [standalone]=\"true\"></mat-textbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Standalone() ) );
        }

        /// <summary>
        /// 测试多行文本框
        /// </summary>
        [Fact]
        public void TestToTextArea_1() {
            var result = new String();
            result.Append( "<mat-textarea-wrapper [minRows]=\"3\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.ToTextArea( 3 ) ) );
        }

        /// <summary>
        /// 测试多行文本框
        /// </summary>
        [Fact]
        public void TestToTextArea_2() {
            var result = new String();
            result.Append( "<mat-textarea-wrapper [maxRows]=\"5\" [minRows]=\"3\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.ToTextArea( 3, 5 ) ) );
        }

        /// <summary>
        /// 测试转换为日期选择框
        /// </summary>
        [Fact]
        public void TestToDatePicker_1() {
            var result = new String();
            result.Append( "<mat-datepicker-wrapper></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.ToDatePicker() ) );
        }

        /// <summary>
        /// 测试转换为日期选择框
        /// </summary>
        [Fact]
        public void TestToDatePicker_2() {
            var result = new String();
            result.Append( "<mat-datepicker-wrapper minDate=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.ToDatePicker( "a" ) ) );
        }

        /// <summary>
        /// 测试转换为日期选择框
        /// </summary>
        [Fact]
        public void TestToDatePicker_3() {
            var result = new String();
            result.Append( "<mat-datepicker-wrapper maxDate=\"b\" minDate=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.ToDatePicker( "a", "b" ) ) );
        }

        /// <summary>
        /// 测试转换为日期选择框
        /// </summary>
        [Fact]
        public void TestToDatePicker_4() {
            var result = new String();
            result.Append( "<mat-datepicker-wrapper startView=\"year\" [touchUi]=\"true\" [width]=\"1\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.ToDatePicker( 1, DateView.Year, true ) ) );
        }
    }
}
