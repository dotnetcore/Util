using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Menus.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Menus {
    /// <summary>
    /// 菜单测试
    /// </summary>
    public class MenuTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 菜单
        /// </summary>
        private readonly MenuTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public MenuTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new MenuTagHelper();
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
            result.Append( "<mat-menu #menu=\"matMenu\"><ng-template matMenuContent=\"\"></ng-template></mat-menu>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-menu #a=\"matMenu\"><ng-template matMenuContent=\"\"></ng-template></mat-menu>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试X位置
        /// </summary>
        [Fact]
        public void TestXPosition() {
            var attributes = new TagHelperAttributeList { { UiConst.XPosition, XPosition.Right } };
            var result = new String();
            result.Append( "<mat-menu #menu=\"matMenu\" xPosition=\"after\"><ng-template matMenuContent=\"\"></ng-template></mat-menu>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试Y位置
        /// </summary>
        [Fact]
        public void TestYPosition() {
            var attributes = new TagHelperAttributeList { { UiConst.YPosition, YPosition.Below } };
            var result = new String();
            result.Append( "<mat-menu #menu=\"matMenu\" yPosition=\"below\"><ng-template matMenuContent=\"\"></ng-template></mat-menu>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置重叠
        /// </summary>
        [Fact]
        public void TestOverlap() {
            var attributes = new TagHelperAttributeList { { UiConst.Overlap, false } };
            var result = new String();
            result.Append( "<mat-menu #menu=\"matMenu\" [overlapTrigger]=\"false\"><ng-template matMenuContent=\"\"></ng-template></mat-menu>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}