using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Badges;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Badges {
    /// <summary>
    /// 徽标测试
    /// </summary>
    public class BadgeTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public BadgeTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new BadgeTagHelper().ToWrapper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<nz-badge></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否独立使用
        /// </summary>
        [Fact]
        public void TestStandalone() {
            _wrapper.SetContextAttribute( UiConst.Standalone, true );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzStandalone]=\"true\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否独立使用
        /// </summary>
        [Fact]
        public void TestBindStandalone() {
            _wrapper.SetContextAttribute( AngularConst.BindStandalone, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzStandalone]=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            _wrapper.SetContextAttribute( UiConst.Color, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge nzColor=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestBindColor() {
            _wrapper.SetContextAttribute( AngularConst.BindColor, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzColor]=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示的数字
        /// </summary>
        [Fact]
        public void TestCount() {
            _wrapper.SetContextAttribute( UiConst.Count, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-badge nzCount=\"1\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示的数字
        /// </summary>
        [Fact]
        public void TestBindCount() {
            _wrapper.SetContextAttribute( AngularConst.BindCount, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzCount]=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否不显示数字,仅显示小红点
        /// </summary>
        [Fact]
        public void TestDot() {
            _wrapper.SetContextAttribute( UiConst.Dot, true );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzDot]=\"true\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否不显示数字,仅显示小红点
        /// </summary>
        [Fact]
        public void TestBindDot() {
            _wrapper.SetContextAttribute( AngularConst.BindDot, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzDot]=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示小红点
        /// </summary>
        [Fact]
        public void TestShowDot() {
            _wrapper.SetContextAttribute( UiConst.ShowDot, true );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzShowDot]=\"true\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示小红点
        /// </summary>
        [Fact]
        public void TestBindShowDot() {
            _wrapper.SetContextAttribute( AngularConst.BindShowDot, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzShowDot]=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试封顶数字
        /// </summary>
        [Fact]
        public void TestOverflowCount() {
            _wrapper.SetContextAttribute( UiConst.OverflowCount, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-badge nzOverflowCount=\"1\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试封顶数字
        /// </summary>
        [Fact]
        public void TestBindOverflowCount() {
            _wrapper.SetContextAttribute( AngularConst.BindOverflowCount, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzOverflowCount]=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示0值
        /// </summary>
        [Fact]
        public void TestShowZero() {
            _wrapper.SetContextAttribute( UiConst.ShowZero, true );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzShowZero]=\"true\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示0值
        /// </summary>
        [Fact]
        public void TestBindShowZero() {
            _wrapper.SetContextAttribute( AngularConst.BindShowZero, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzShowZero]=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态
        /// </summary>
        [Fact]
        public void TestStatus() {
            _wrapper.SetContextAttribute( UiConst.Status, BadgeStatus.Processing );
            var result = new StringBuilder();
            result.Append( "<nz-badge nzStatus=\"processing\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态
        /// </summary>
        [Fact]
        public void TestBindStatus() {
            _wrapper.SetContextAttribute( AngularConst.BindStatus, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzStatus]=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态点文本
        /// </summary>
        [Fact]
        public void TestText() {
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge nzText=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态点文本
        /// </summary>
        [Fact]
        public void TestBindText() {
            _wrapper.SetContextAttribute( AngularConst.BindText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzText]=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态点提示
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge nzTitle=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态点提示
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzTitle]=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态点位置偏移
        /// </summary>
        [Fact]
        public void TestOffset() {
            _wrapper.SetContextAttribute( UiConst.Offset, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge [nzOffset]=\"a\"></nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-badge>a</nz-badge>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}