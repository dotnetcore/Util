using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Icons.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.Tests.Material.Icons {
    /// <summary>
    /// 图标测试
    /// </summary>
    public class IconTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 图标
        /// </summary>
        private readonly IconTagHelper _icon;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public IconTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _icon = new IconTagHelper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( IconTagHelper icon, TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            var context = new TagHelperContext( "", contextAttributes ?? new TagHelperAttributeList(), new Dictionary<object, object>(), Id.Guid() );
            var output = new TagHelperOutput( "", outputAttributes ?? new TagHelperAttributeList(), ( useCachedResult, encoder ) => Task.FromResult( content ?? new DefaultTagHelperContent() ) );
            icon.Process( context, output );
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
            Assert.Empty( GetResult( _icon ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标
        /// </summary>
        [Fact]
        public void TestFontAwesomeIcon() {
            var attributes = new TagHelperAttributeList { { Util.Ui.Configs.UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var result = new String();
            result.Append( "<i class=\"fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( _icon, attributes ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute() {
            var contextAttributes = new TagHelperAttributeList { { Util.Ui.Configs.UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var outputAttributes = new TagHelperAttributeList { { "a", "1" } };
            var result = new String();
            result.Append( "<i a=\"1\" class=\"fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( _icon, contextAttributes, outputAttributes ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { "id", "a" }, { Util.Ui.Configs.UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var result = new String();
            result.Append( "<i class=\"fa fa-android\" id=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult( _icon, attributes ) );
        }

        /// <summary>
        /// 测试设置Material图标
        /// </summary>
        [Fact]
        public void TestMaterialIcon() {
            var attributes = new TagHelperAttributeList { { Util.Ui.Configs.UiConst.MaterialIcon, MaterialIcon.Android } };
            var result = new String();
            result.Append( "<mat-icon>android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( _icon, attributes ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标大小
        /// </summary>
        [Fact]
        public void TestIconSize_FontAwesome() {
            var attributes = new TagHelperAttributeList { { UiConst.IconSize , IconSize.Large2X }, { Util.Ui.Configs.UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var result = new String();
            result.Append( "<i class=\"fa-2x fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( _icon, attributes ) );
        }

        /// <summary>
        /// 测试设置Material图标大小
        /// </summary>
        [Fact]
        public void TestIconSize_Material() {
            var attributes = new TagHelperAttributeList { { UiConst.IconSize, IconSize.Large2X }, { Util.Ui.Configs.UiConst.MaterialIcon, MaterialIcon.Android } };
            var result = new String();
            result.Append( "<mat-icon class=\"fa-2x\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( _icon, attributes ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标旋转
        /// </summary>
        [Fact]
        public void TestSpin_FontAwesome_True() {
            var attributes = new TagHelperAttributeList { { UiConst.Spin, true }, { Util.Ui.Configs.UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var result = new String();
            result.Append( "<i class=\"fa-spin fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( _icon, attributes ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标旋转
        /// </summary>
        [Fact]
        public void TestSpin_FontAwesome_False() {
            var attributes = new TagHelperAttributeList { { UiConst.Spin, false }, { Util.Ui.Configs.UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var result = new String();
            result.Append( "<i class=\"fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( _icon, attributes ) );
        }

        /// <summary>
        /// 测试设置Material图标旋转
        /// </summary>
        [Fact]
        public void TestSpin_Material() {
            var attributes = new TagHelperAttributeList { { UiConst.Spin, true }, { Util.Ui.Configs.UiConst.MaterialIcon, MaterialIcon.Android } };
            var result = new String();
            result.Append( "<mat-icon class=\"fa-spin\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( _icon, attributes ) );
        }
    }
}
