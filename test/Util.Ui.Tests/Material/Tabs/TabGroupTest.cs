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
    /// 选项卡组测试
    /// </summary>
    public class TabGroupTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 选项卡组
        /// </summary>
        private readonly TabGroup _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TabGroupTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TabGroup( new StringWriter() );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TabGroup component ) {
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
            result.Append( "<mat-tab-group></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( _component ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<mat-tab-group #a=\"\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( _component.Id( "a" ) ) );
        }

        /// <summary>
        /// 测试设置背景色
        /// </summary>
        [Fact]
        public void TestBackgroundColor() {
            var result = new String();
            result.Append( "<mat-tab-group backgroundColor=\"primary\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( _component.BackgroundColor( Color.Primary ) ) );
        }

        /// <summary>
        /// 测试设置主题色
        /// </summary>
        [Fact]
        public void TestColor() {
            var result = new String();
            result.Append( "<mat-tab-group color=\"primary\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( _component.Color( Color.Primary ) ) );
        }
    }
}