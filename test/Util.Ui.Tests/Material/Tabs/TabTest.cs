using System.IO;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Tabs;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Tabs {
    /// <summary>
    /// 选项卡测试
    /// </summary>
    public class TabTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 选项卡
        /// </summary>
        private readonly Tab _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TabTest( ITestOutputHelper output ) {
            _output = output;
            _component = new Tab( new StringWriter() );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( Tab component ) {
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
            result.Append( "<mat-tab><ng-template mat-tab-label=\"\"></ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( _component ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<mat-tab #a=\"\"><ng-template mat-tab-label=\"\"></ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( _component.Id( "a" ) ) );
        }

        /// <summary>
        /// 测试添加标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            var result = new String();
            result.Append( "<mat-tab><ng-template mat-tab-label=\"\">a</ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( _component.Label( "a" ) ) );
        }

        /// <summary>
        /// 测试Material图标
        /// </summary>
        [Fact]
        public void TestMaterialIcon() {
            var result = new String();
            result.Append( "<mat-tab><ng-template mat-tab-label=\"\"><mat-icon>add</mat-icon></ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( _component.Icon( MaterialIcon.Add ) ) );
        }

        /// <summary>
        /// 测试FontAwesome图标
        /// </summary>
        [Fact]
        public void TestFontAwesomeIcon() {
            var result = new String();
            result.Append( "<mat-tab><ng-template mat-tab-label=\"\"><i class=\"fa fa-bus\"></i></ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( _component.Icon( FontAwesomeIcon.Bus ) ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var result = new String();
            result.Append( "<mat-tab [disabled]=\"a\"><ng-template mat-tab-label=\"\"></ng-template></mat-tab>" );
            Assert.Equal( result.ToString(), GetResult( _component.Disable( "a" ) ) );
        }
    }
}