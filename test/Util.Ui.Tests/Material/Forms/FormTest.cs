using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Extensions;
using Util.Ui.Material.Forms;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Forms {
    /// <summary>
    /// 表单测试
    /// </summary>
    public class FormTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表单
        /// </summary>
        private readonly Form _form;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public FormTest( ITestOutputHelper output ) {
            _output = output;
            _form = new Form( new StringWriter(), HtmlEncoder.Default );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( Form form ) {
            form.Begin();
            var result = form.ToString();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<form>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( _form ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute_1() {
            var result = new String();
            result.Append( "<form a=\"\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( _form.Attribute( "a" ) ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute_2() {
            var result = new String();
            result.Append( "<form a=\"1\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( _form.Attribute( "a", "1" ) ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<form id=\"a\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( _form.Id( "a" ) ) );
        }
    }
}