using System.IO;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Extensions;
using Util.Ui.Material.Commons.Configs;
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

        /// <summary>
        /// 测试设置固定高度
        /// </summary>
        [Fact]
        public void TestHeight() {
            var result = new String();
            result.Append( "<mat-tab-group style=\"height:200px\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( _component.Height(200) ) );
        }

        /// <summary>
        /// 测试设置动态高度
        /// </summary>
        [Fact]
        public void TestDynamicHeight() {
            var result = new String();
            result.Append( "<mat-tab-group dynamicHeight=\"\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( _component.DynamicHeight() ) );
        }

        /// <summary>
        /// 测试拉伸选项卡
        /// </summary>
        [Fact]
        public void TestStretch() {
            var result = new String();
            result.Append( "<mat-tab-group mat-stretch-tabs=\"\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( _component.Stretch() ) );
        }

        /// <summary>
        /// 测试选中索引
        /// </summary>
        [Fact]
        public void TestSelect() {
            var result = new String();
            result.Append( "<mat-tab-group [(selectedIndex)]=\"a\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( _component.Select( "a" ) ) );
        }

        /// <summary>
        /// 测试标题位置
        /// </summary>
        [Fact]
        public void TestHeaderPosition() {
            var result = new String();
            result.Append( "<mat-tab-group headerPosition=\"below\"></mat-tab-group>" );
            Assert.Equal( result.ToString(), GetResult( _component.HeaderPosition( YPosition.Below ) ) );
        }
    }
}