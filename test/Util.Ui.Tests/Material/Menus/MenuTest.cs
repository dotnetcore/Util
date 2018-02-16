using System.IO;
using Util.Ui.Extensions;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Menus;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Menus {
    /// <summary>
    /// 菜单测试
    /// </summary>
    public class MenuTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 菜单
        /// </summary>
        private readonly Menu _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public MenuTest( ITestOutputHelper output ) {
            _output = output;
            _component = new Menu( new StringWriter() );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( Menu component ) {
            component.Begin();
            var result = component.ToString();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<mat-menu #menu=\"matMenu\"><ng-template matMenuContent=\"\"></ng-template></mat-menu>" );
            Assert.Equal( result.ToString(), GetResult( _component ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<mat-menu #a=\"matMenu\"><ng-template matMenuContent=\"\"></ng-template></mat-menu>" );
            Assert.Equal( result.ToString(), GetResult( _component.Id( "a" ) ) );
        }

        /// <summary>
        /// 测试X位置
        /// </summary>
        [Fact]
        public void TestPosition_X() {
            var result = new String();
            result.Append( "<mat-menu #menu=\"matMenu\" xPosition=\"after\"><ng-template matMenuContent=\"\"></ng-template></mat-menu>" );
            Assert.Equal( result.ToString(), GetResult( _component.Position(XPosition.Right) ) );
        }

        /// <summary>
        /// 测试Y位置
        /// </summary>
        [Fact]
        public void TestPosition_Y() {
            var result = new String();
            result.Append( "<mat-menu #menu=\"matMenu\" yPosition=\"below\"><ng-template matMenuContent=\"\"></ng-template></mat-menu>" );
            Assert.Equal( result.ToString(), GetResult( _component.Position( null,YPosition.Below ) ) );
        }

        /// <summary>
        /// 测试设置重叠
        /// </summary>
        [Fact]
        public void TestOverlap() {
            var result = new String();
            result.Append( "<mat-menu #menu=\"matMenu\" [overlapTrigger]=\"false\"><ng-template matMenuContent=\"\"></ng-template></mat-menu>" );
            Assert.Equal( result.ToString(), GetResult( _component.Overlap() ) );
        }
    }
}