using System.IO;
using System.Text.Encodings.Web;
using Util.Helpers;
using Util.Ui.Extensions;
using Util.Ui.Material.Buttons;
using Xunit;

namespace Util.Ui.Tests.Material.Buttons {
    /// <summary>
    /// 按钮测试
    /// </summary>
    public class ButtonTest {
        /// <summary>
        /// 按钮
        /// </summary>
        private readonly Button _button;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ButtonTest() {
            _button = new Button();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( Button button ) {
            button.WriteTo( new StringWriter(), HtmlEncoder.Default );
            return button.ToString();
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
        public void TestPlain() {
            var result = new String();
            result.Append( "<button mat-button=\"mat-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button.Plain() ) );
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
    }
}
