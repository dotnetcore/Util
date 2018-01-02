using System;
using System.IO;
using System.Text.Encodings.Web;
using Util.Helpers;
using Util.Ui.Extensions;
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
    public class TextBoxTest : IDisposable {
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
        private readonly TextBox _textBox;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TextBoxTest( ITestOutputHelper output ) {
            _output = output;
            _textBox = new TextBox();
            Id.SetId( "id" );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Id.Reset();
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
            result.Append( "<mat-form-field>" );
            result.Append( "<input matInput=\"matInput\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute_1() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input a=\"\" matInput=\"matInput\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.Attribute( "a" ) ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute_2() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input a=\"1\" matInput=\"matInput\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.Attribute( "a", "1" ) ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input id=\"a\" matInput=\"matInput\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.Id( "a" ) ) );
        }

        /// <summary>
        /// 测试添加名称
        /// </summary>
        [Fact]
        public void TestName() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input matInput=\"matInput\" name=\"a\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.Name( "a" ) ) );
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

        /// <summary>
        /// 测试必填项,添加指定错误消息
        /// </summary>
        [Fact]
        public void TestRequired_Message() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input #m_id=\"ngModel\" matInput=\"matInput\" required=\"true\" />" );
            result.Append( $"<mat-error *ngIf=\"m_id?.hasError( {Quote}required{Quote} )\">a</mat-error>" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.Required("a") ) );
        }

        /// <summary>
        /// 测试最小长度
        /// </summary>
        [Fact]
        public void TestMinLength() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input matInput=\"matInput\" minlength=\"3\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.MinLength(3) ) );
        }

        /// <summary>
        /// 测试最小长度,添加指定错误消息
        /// </summary>
        [Fact]
        public void TestMinLength_Message() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input #m_id=\"ngModel\" matInput=\"matInput\" minlength=\"3\" />" );
            result.Append( $"<mat-error *ngIf=\"m_id?.hasError( {Quote}minlength{Quote} )\">a</mat-error>" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.MinLength( 3,"a" ) ) );
        }

        /// <summary>
        /// 测试同时验证必填和最小长度
        /// </summary>
        [Fact]
        public void TestRequired_MinLength_Message() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input #m_id=\"ngModel\" matInput=\"matInput\" minlength=\"3\" required=\"true\" />" );
            result.Append( $"<mat-error *ngIf=\"m_id?.hasError( {Quote}required{Quote} )\">a</mat-error>" );
            result.Append( $"<mat-error *ngIf=\"m_id?.hasError( {Quote}minlength{Quote} )\">b</mat-error>" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.Required( "a" ).MinLength( 3,"b" ) ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var result = new String();
            result.Append( "<mat-form-field>" );
            result.Append( "<input matInput=\"matInput\" [(ngModel)]=\"a\" />" );
            result.Append( "</mat-form-field>" );
            Assert.Equal( result.ToString(), GetResult( _textBox.Model("a") ) );
        }
    }
}
