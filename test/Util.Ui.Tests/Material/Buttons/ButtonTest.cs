using System.IO;
using System.Text.Encodings.Web;
using Util.Helpers;
using Util.Ui.Extensions;
using Util.Ui.Material.Buttons;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.Tests.Material.Buttons {
    /// <summary>
    /// 按钮测试
    /// </summary>
    public class ButtonTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 按钮
        /// </summary>
        private readonly Button _button;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ButtonTest( ITestOutputHelper output ) {
            _output = output;
            _button = new Button();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( Button button ) {
            button.WriteTo( new StringWriter(), HtmlEncoder.Default );
            var result = button.ToString();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<button mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute_1() {
            var result = new String();
            result.Append( "<button a=\"\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button.Attribute( "a" ) ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute_2() {
            var result = new String();
            result.Append( "<button a=\"1\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button.Attribute( "a", "1" ) ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<button id=\"a\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button.Id( "a" ) ) );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            var result = new String();
            result.Append( "<button mat-raised-button=\"mat-raised-button\">a</button>" );
            Assert.Equal( result.ToString(), GetResult( _button.Text( "a" ) ) );
        }

        /// <summary>
        /// 测试扁平风格
        /// </summary>
        [Fact]
        public void TestPlain_True() {
            var result = new String();
            result.Append( "<button mat-button=\"mat-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button.Plain() ) );
        }

        /// <summary>
        /// 测试扁平风格
        /// </summary>
        [Fact]
        public void TestPlain_False() {
            var result = new String();
            result.Append( "<button mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button.Plain().Plain( false ) ) );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            var result = new String();
            result.Append( "<button color=\"primary\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button.Color( Color.Primary ) ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var result = new String();
            result.Append( "<button (click)=\"a\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button.OnClick( "a" ) ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisable() {
            var result = new String();
            result.Append( "<button disabled=\"disabled\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button.Disable() ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisable_False() {
            var result = new String();
            result.Append( "<button mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button.Disable().Disable( false ) ) );
        }
    }
}
