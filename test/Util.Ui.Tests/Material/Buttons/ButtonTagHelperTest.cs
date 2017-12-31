using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Configs;
using Util.Ui.Material.Buttons.TagHelpers;
using Util.Ui.Material.Enums;
using Util.Ui.Tests.XUnitHelpers;
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
        private readonly ButtonTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ButtonTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new ButtonTagHelper();
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
            result.Append( "<button mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute_1() {
            var attributes = new TagHelperAttributeList { { "a", "" } };
            var result = new String();
            result.Append( "<button a=\"\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( outputAttributes: attributes ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute_2() {
            var attributes = new TagHelperAttributeList { { "a", "1" } };
            var result = new String();
            result.Append( "<button a=\"1\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( outputAttributes: attributes ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute_3() {
            var contextAttributes = new TagHelperAttributeList { { UiConst.Id, "1" }, { "a", "2" } };
            var outputAttributes = new TagHelperAttributeList { { "a", "2" } };
            var result = new String();
            result.Append( "<button a=\"2\" id=\"1\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( contextAttributes, outputAttributes ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<button id=\"a\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
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
            Assert.Equal( result.ToString(), GetResult( content: content ) );
        }

        /// <summary>
        /// 测试扁平风格
        /// </summary>
        [Fact]
        public void TestPlain() {
            var attributes = new TagHelperAttributeList { { UiConst.Plain, "true" } };
            var result = new String();
            result.Append( "<button mat-button=\"mat-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            var attributes = new TagHelperAttributeList { { UiConst.Color, Color.Primary } };
            var result = new String();
            result.Append( "<button color=\"primary\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<button (click)=\"a\" mat-raised-button=\"mat-raised-button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
