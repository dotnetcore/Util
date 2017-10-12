using System.IO;
using System.Text.Encodings.Web;
using Util.Helpers;
using Util.Ui.Extensions;
using Util.Ui.Material.Forms;
using Xunit;

namespace Util.Ui.Tests.Material.Forms {
    /// <summary>
    /// 文本框测试
    /// </summary>
    public class TextBoxTest {
        /// <summary>
        /// 文本框
        /// </summary>
        private readonly TextBox _textBox;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TextBoxTest() {
            _textBox = new TextBox();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TextBox textBox ) {
            textBox.WriteTo( new StringWriter(), HtmlEncoder.Default );
            return textBox.ToString();
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input matInput=\"matInput\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox ) );
        }

        /// <summary>
        /// 测试占位符
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input matInput=\"matInput\" placeholder=\"a\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.Placeholder( "a" ) ) );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestValue() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input matInput=\"matInput\" value=\"a\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.Value( "a" ) ) );
        }

        /// <summary>
        /// 测试设置为密码框
        /// </summary>
        [Fact]
        public void TestPassword() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input matInput=\"matInput\" type=\"password\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.Password() ) );
        }

        /// <summary>
        /// 测试只能输入数字
        /// </summary>
        [Fact]
        public void TestNumber() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input matInput=\"matInput\" type=\"number\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.Number() ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input matInput=\"matInput\" required=\"true\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.Required() ) );
        }
    }
}
