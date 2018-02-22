using System.IO;
using Util.Ui.Extensions;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Tabs;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Tabs {
    /// <summary>
    /// 导航选项卡测试
    /// </summary>
    public class TabNavigationTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 导航选项卡
        /// </summary>
        private readonly TabNavigation _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TabNavigationTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TabNavigation( new StringWriter() );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TabNavigation component ) {
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
            result.Append( "<nav mat-tab-nav-bar=\"\"></nav>" );
            Assert.Equal( result.ToString(), GetResult( _component ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<nav #a=\"\" mat-tab-nav-bar=\"\"></nav>" );
            Assert.Equal( result.ToString(), GetResult( _component.Id( "a" ) ) );
        }

        /// <summary>
        /// 测试设置背景色
        /// </summary>
        [Fact]
        public void TestBackgroundColor() {
            var result = new String();
            result.Append( "<nav backgroundColor=\"primary\" mat-tab-nav-bar=\"\"></nav>" );
            Assert.Equal( result.ToString(), GetResult( _component.BackgroundColor( Color.Primary ) ) );
        }

        /// <summary>
        /// 测试设置主题色
        /// </summary>
        [Fact]
        public void TestColor() {
            var result = new String();
            result.Append( "<nav color=\"primary\" mat-tab-nav-bar=\"\"></nav>" );
            Assert.Equal( result.ToString(), GetResult( _component.Color( Color.Primary ) ) );
        }
    }
}