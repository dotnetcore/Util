using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Material.Buttons.TagHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Buttons {
    /// <summary>
    /// 按钮TagHelper测试
    /// </summary>
    public class ButtonTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 按钮
        /// </summary>
        private readonly ButtonTagHelper _button;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ButtonTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _button = new ButtonTagHelper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( ButtonTagHelper button, TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            var context = new TagHelperContext( "", contextAttributes ?? new TagHelperAttributeList(), new Dictionary<object, object>(), Id.Guid() );
            var output = new TagHelperOutput( "", outputAttributes ?? new TagHelperAttributeList(), ( useCachedResult, encoder ) => Task.FromResult( content ?? new DefaultTagHelperContent() ) );
            button.Process( context, output );
            var writer = new StringWriter();
            output.WriteTo( writer, HtmlEncoder.Default );
            var result = writer.ToString();
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
            var attributes = new TagHelperAttributeList { { "a", "" } };
            var result = new String();
            result.Append( "<button a=\"\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button, outputAttributes: attributes ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute_2() {
            var attributes = new TagHelperAttributeList { { "a", "1" } };
            var result = new String();
            result.Append( "<button a=\"1\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button, outputAttributes: attributes ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute_3() {
            var contextAttributes = new TagHelperAttributeList { { "id", "1" }, { "a", "2" } };
            var outputAttributes = new TagHelperAttributeList { { "a", "2" } };
            var result = new String();
            result.Append( "<button a=\"2\" id=\"1\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button, contextAttributes, outputAttributes ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { "id", "a" } };
            var result = new String();
            result.Append( "<button id=\"a\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button, attributes ) );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            TagHelperContent content = new DefaultTagHelperContent();
            content.SetContent( "a" );
            var result = new String();
            result.Append( "<button mat-raised-button=\"mat-raised-button\">a</button>" );
            Assert.Equal( result.ToString(), GetResult( _button,content: content ) );
        }

        /// <summary>
        /// 测试扁平风格
        /// </summary>
        [Fact]
        public void TestPlain() {
            var attributes = new TagHelperAttributeList { { "asp-plain", "true" } };
            var result = new String();
            result.Append( "<button mat-button=\"mat-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button, attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { "asp-click", "a" } };
            var result = new String();
            result.Append( "<button (click)=\"a\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( _button, attributes ) );
        }
    }
}
