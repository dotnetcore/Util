using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Lists.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Lists {
    /// <summary>
    /// 导航列表图标测试
    /// </summary>
    public class NavListIconTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 导航列表图标
        /// </summary>
        private readonly NavListIconTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public NavListIconTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new NavListIconTagHelper();
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
        /// 测试Material图标
        /// </summary>
        [Fact]
        public void TestMaterialIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.MaterialIcon, MaterialIcon.Add } };
            var result = new String();
            result.Append( "<mat-icon mat-list-icon=\"\">add</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试Material图标绑定
        /// </summary>
        [Fact]
        public void TestBindMaterialIcon() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindMaterialIcon, "a" } };
            var result = new String();
            result.Append( "<mat-icon mat-list-icon=\"\">{{a}}</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试Material图标标识
        /// </summary>
        [Fact]
        public void TestMaterialIcon_Id() {
            var attributes = new TagHelperAttributeList { { UiConst.MaterialIcon, MaterialIcon.Add },{ UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-icon #a=\"\" mat-list-icon=\"\">add</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试Material图标大小
        /// </summary>
        [Fact]
        public void TestMaterialIcon_Size() {
            var attributes = new TagHelperAttributeList { { UiConst.MaterialIcon, MaterialIcon.Add }, { UiConst.Size, IconSize.Large2X } };
            var result = new String();
            result.Append( "<mat-icon class=\"fa-2x\" mat-list-icon=\"\">add</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试Material图标位置
        /// </summary>
        [Fact]
        public void TestMaterialIcon_Position() {
            var attributes = new TagHelperAttributeList { { UiConst.MaterialIcon, MaterialIcon.Add }, { UiConst.Position, XPosition.Right } };
            var result = new String();
            result.Append( "<mat-icon>add</mat-icon>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试FontAwesome图标
        /// </summary>
        [Fact]
        public void TestFontAwesomeIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.FontAwesomeIcon, FontAwesomeIcon.Bus } };
            var result = new String();
            result.Append( "<i class=\"fa fa-bus\" mat-list-icon=\"\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试FontAwesome图标
        /// </summary>
        [Fact]
        public void TestBindFontAwesomeIcon() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindFontAwesomeIcon, "a" } };
            var result = new String();
            result.Append( "<i class=\"fa {{a}}\" mat-list-icon=\"\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试FontAwesome图标大小
        /// </summary>
        [Fact]
        public void TestFontAwesomeIcon_Size() {
            var attributes = new TagHelperAttributeList { { UiConst.FontAwesomeIcon, FontAwesomeIcon.Bus }, { UiConst.Size, IconSize.Large2X } };
            var result = new String();
            result.Append( "<i class=\"fa-2x fa fa-bus\" mat-list-icon=\"\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}