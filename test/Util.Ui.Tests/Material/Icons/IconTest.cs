using System.IO;
using System.Text.Encodings.Web;
using Util.Helpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Material.Icons;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.Tests.Material.Icons {
    /// <summary>
    /// 图标测试
    /// </summary>
    public class IconTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 图标
        /// </summary>
        private readonly Icon _icon;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public IconTest( ITestOutputHelper output ) {
            _output = output;
            _icon = new Icon();
            Config.IsValidate = false;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( Icon icon ) {
            icon.WriteTo( new StringWriter(), HtmlEncoder.Default );
            var result = icon.ToString();
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
        /// 测试设置Material图标
        /// </summary>
        [Fact]
        public void TestMaterial() {
            var result = new String();
            result.Append( "<mat-icon>android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( MaterialIcon.Android ) ) );
        }

        /// <summary>
        /// 测试设置class
        /// </summary>
        [Fact]
        public void TestClass() {
            var result = new String();
            result.Append( "<mat-icon class=\"a\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( MaterialIcon.Android ).Class("a") ) );
        }

        /// <summary>
        /// 测试设置style
        /// </summary>
        [Fact]
        public void TestStyle() {
            var result = new String();
            result.Append( "<mat-icon style=\"a\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( MaterialIcon.Android ).Style( "a" ) ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute() {
            var result = new String();
            result.Append( "<mat-icon a=\"1\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( MaterialIcon.Android ).Attribute( "a","1" ) ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<mat-icon id=\"a\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( MaterialIcon.Android ).Id( "a" ) ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标
        /// </summary>
        [Fact]
        public void TestFontAwesome() {
            var result = new String();
            result.Append( "<i class=\"fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( FontAwesomeIcon.Android ) ) );
        }

        /// <summary>
        /// 测试设置图标大小
        /// </summary>
        [Fact]
        public void TestIconSize() {
            var result = new String();
            result.Append( "<mat-icon class=\"fa-2x\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( MaterialIcon.Android ).Size(IconSize.Large2X) ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标旋转
        /// </summary>
        [Fact]
        public void TestSpin_FontAwesome_True() {
            var result = new String();
            result.Append( "<i class=\"fa-spin fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( FontAwesomeIcon.Android ).Spin() ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标旋转
        /// </summary>
        [Fact]
        public void TestSpin_FontAwesome_False() {
            var result = new String();
            result.Append( "<i class=\"fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( FontAwesomeIcon.Android ).Spin().Spin( false ) ) );
        }

        /// <summary>
        /// 测试设置Material图标旋转
        /// </summary>
        [Fact]
        public void TestSpin_Material() {
            var result = new String();
            result.Append( "<mat-icon class=\"fa-spin\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( MaterialIcon.Android ).Spin() ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标旋转
        /// </summary>
        [Fact]
        public void TestRotate_FontAwesome() {
            var result = new String();
            result.Append( "<i class=\"fa-rotate-180 fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( FontAwesomeIcon.Android ).Rotate( RotateType.Rotate180 ) ) );
        }

        /// <summary>
        /// 测试设置Material图标旋转
        /// </summary>
        [Fact]
        public void TestRotate_Material() {
            var result = new String();
            result.Append( "<mat-icon class=\"fa-rotate-180\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( MaterialIcon.Android ).Rotate( RotateType.Rotate180 ) ) );
        }

        /// <summary>
        /// 测试设置FontAwesome子图标
        /// </summary>
        [Fact]
        public void TestChild() {
            var result = new String();
            result.Append( "<span class=\"fa-stack\">" );
            result.Append( "<i class=\"fa-stack-2x fa fa-square-o\"></i>" );
            result.Append( "<i class=\"fa-stack-1x fa fa-twitter\"></i>" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( FontAwesomeIcon.SquareO ).Child( FontAwesomeIcon.Twitter ) ) );
        }

        /// <summary>
        /// 测试设置FontAwesome子图标
        /// </summary>
        [Fact]
        public void TestChild_Class() {
            var result = new String();
            result.Append( "<span class=\"fa-stack\">" );
            result.Append( "<i class=\"fa-stack-2x fa fa-square-o\"></i>" );
            result.Append( "<i class=\"a fa-stack-1x fa fa-twitter\"></i>" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult( _icon.Icon( FontAwesomeIcon.SquareO ).Child( FontAwesomeIcon.Twitter,"a" ) ) );
        }
    }
}
