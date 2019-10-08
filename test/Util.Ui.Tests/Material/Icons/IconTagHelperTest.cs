using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Angular;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Icons.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
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
        private readonly IconTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public IconTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new IconTagHelper();
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
            Assert.Empty( GetResult() );
        }

        /// <summary>
        /// 测试设置FontAwesome图标
        /// </summary>
        [Fact]
        public void TestFontAwesomeIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var result = new String();
            result.Append( "<i class=\"fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标绑定
        /// </summary>
        [Fact]
        public void TestBindFontAwesomeIcon() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindFontAwesomeIcon, "a" } };
            var result = new String();
            result.Append( "<i class=\"fa {{a}}\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加属性
        /// </summary>
        [Fact]
        public void TestAttribute() {
            var contextAttributes = new TagHelperAttributeList { { UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var outputAttributes = new TagHelperAttributeList { { "a", "1" } };
            var result = new String();
            result.Append( "<i a=\"1\" class=\"fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( contextAttributes, outputAttributes ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标的class
        /// </summary>
        [Fact]
        public void TestClass_FontAwesome() {
            var contextAttributes = new TagHelperAttributeList { { UiConst.FontAwesomeIcon, FontAwesomeIcon.Android }, { "class", "a" } };
            var result = new String();
            result.Append( "<i class=\"a fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( contextAttributes ) );
        }

        /// <summary>
        /// 测试设置Material图标的class
        /// </summary>
        [Fact]
        public void TestClass_Material() {
            var contextAttributes = new TagHelperAttributeList { { UiConst.MaterialIcon, MaterialIcon.Android } };
            var outputAttributes = new TagHelperAttributeList { { "class", "a" } };
            var result = new String();
            result.Append( "<mat-icon class=\"a\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( contextAttributes, outputAttributes ) );
        }

        /// <summary>
        /// 测试设置style
        /// </summary>
        [Fact]
        public void TestStyle() {
            var contextAttributes = new TagHelperAttributeList { { UiConst.MaterialIcon, MaterialIcon.Android } };
            var outputAttributes = new TagHelperAttributeList { { "style", "a" } };
            var result = new String();
            result.Append( "<mat-icon style=\"a\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( contextAttributes, outputAttributes ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { "id", "a" }, { UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var result = new String();
            result.Append( "<i class=\"fa fa-android\" id=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置Material图标
        /// </summary>
        [Fact]
        public void TestMaterialIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.MaterialIcon, MaterialIcon.Android } };
            var result = new String();
            result.Append( "<mat-icon>android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置Material图标绑定
        /// </summary>
        [Fact]
        public void TestBindMaterialIcon() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindMaterialIcon, "a" } };
            var result = new String();
            result.Append( "<mat-icon>{{a}}</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标大小
        /// </summary>
        [Fact]
        public void TestIconSize_FontAwesome() {
            var attributes = new TagHelperAttributeList { { UiConst.Size, IconSize.Large2X }, { UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var result = new String();
            result.Append( "<i class=\"fa-2x fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置Material图标大小
        /// </summary>
        [Fact]
        public void TestIconSize_Material() {
            var attributes = new TagHelperAttributeList { { UiConst.Size, IconSize.Large2X }, { UiConst.MaterialIcon, MaterialIcon.Android } };
            var result = new String();
            result.Append( "<mat-icon class=\"fa-2x\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标旋转
        /// </summary>
        [Fact]
        public void TestSpin_FontAwesome_True() {
            var attributes = new TagHelperAttributeList { { UiConst.Spin, true }, { UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var result = new String();
            result.Append( "<i class=\"fa-spin fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标旋转
        /// </summary>
        [Fact]
        public void TestSpin_FontAwesome_False() {
            var attributes = new TagHelperAttributeList { { UiConst.Spin, false }, { UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var result = new String();
            result.Append( "<i class=\"fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置Material图标旋转
        /// </summary>
        [Fact]
        public void TestSpin_Material() {
            var attributes = new TagHelperAttributeList { { UiConst.Spin, true }, { UiConst.MaterialIcon, MaterialIcon.Android } };
            var result = new String();
            result.Append( "<mat-icon class=\"fa-spin\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置FontAwesome图标旋转
        /// </summary>
        [Fact]
        public void TestRotate_FontAwesome() {
            var attributes = new TagHelperAttributeList { { UiConst.Rotate, RotateType.Rotate180 }, { UiConst.FontAwesomeIcon, FontAwesomeIcon.Android } };
            var result = new String();
            result.Append( "<i class=\"fa-rotate-180 fa fa-android\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置Material图标旋转
        /// </summary>
        [Fact]
        public void TestRotate_Material() {
            var attributes = new TagHelperAttributeList { { UiConst.Rotate, RotateType.Rotate180 }, { UiConst.MaterialIcon, MaterialIcon.Android } };
            var result = new String();
            result.Append( "<mat-icon class=\"fa-rotate-180\">android</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置FontAwesome子图标
        /// </summary>
        [Fact]
        public void TestChild() {
            var attributes = new TagHelperAttributeList { { UiConst.Child, FontAwesomeIcon.Twitter }, { UiConst.FontAwesomeIcon, FontAwesomeIcon.SquareO } };
            var result = new String();
            result.Append( "<span class=\"fa-stack\">" );
            result.Append( "<i class=\"fa-stack-2x fa fa-square-o\"></i>" );
            result.Append( "<i class=\"fa-stack-1x fa fa-twitter\"></i>" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置FontAwesome子图标class
        /// </summary>
        [Fact]
        public void TestChildClass() {
            var attributes = new TagHelperAttributeList {
                { UiConst.Child, FontAwesomeIcon.Twitter },
                { UiConst.ChildClass, "a" },
                { UiConst.FontAwesomeIcon, FontAwesomeIcon.SquareO }
            };
            var result = new String();
            result.Append( "<span class=\"fa-stack\">" );
            result.Append( "<i class=\"fa-stack-2x fa fa-square-o\"></i>" );
            result.Append( "<i class=\"a fa-stack-1x fa fa-twitter\"></i>" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置FontAwesome子图标，设置大小
        /// </summary>
        [Fact]
        public void TestChild_Size() {
            var attributes = new TagHelperAttributeList {
                { UiConst.Child, FontAwesomeIcon.Twitter },
                { UiConst.Size, IconSize.Large2X },
                { UiConst.FontAwesomeIcon, FontAwesomeIcon.SquareO }
            };
            var result = new String();
            result.Append( "<span class=\"fa-2x fa-stack\">" );
            result.Append( "<i class=\"fa-stack-2x fa fa-square-o\"></i>" );
            result.Append( "<i class=\"fa-stack-1x fa fa-twitter\"></i>" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
