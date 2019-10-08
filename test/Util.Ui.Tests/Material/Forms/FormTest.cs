using System.IO;
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
            _form = new Form( new StringWriter() );
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
            result.Append( "<form></form>" );
            Assert.Equal( result.ToString(), GetResult( _form ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<form #a=\"ngForm\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( _form.Id( "a" ) ) );
        }

        /// <summary>
        /// 测试提交事件
        /// </summary>
        [Fact]
        public void TestOnSubmit() {
            var result = new String();
            result.Append( "<form (ngSubmit)=\"a\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( _form.OnSubmit( "a" ) ) );
        }
    }
}