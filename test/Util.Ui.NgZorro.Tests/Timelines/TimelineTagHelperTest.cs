using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Timelines;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Timelines {
    /// <summary>
    /// 时间轴测试
    /// </summary>
    public class TimelineTagHelperTest {
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
        public TimelineTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TimelineTagHelper().ToWrapper();
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
            result.Append( "<nz-timeline></nz-timeline>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试幽灵节点
        /// </summary>
        [Fact]
        public void TestPending() {
            _wrapper.SetContextAttribute( UiConst.Pending, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-timeline nzPending=\"a\"></nz-timeline>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试幽灵节点
        /// </summary>
        [Fact]
        public void TestBindPending() {
            _wrapper.SetContextAttribute( AngularConst.BindPending, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-timeline [nzPending]=\"a\"></nz-timeline>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试幽灵节点时间图点
        /// </summary>
        [Fact]
        public void TestPendingDot() {
            _wrapper.SetContextAttribute( UiConst.PendingDot, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-timeline nzPendingDot=\"a\"></nz-timeline>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试幽灵节点时间图点
        /// </summary>
        [Fact]
        public void TestBindPendingDot() {
            _wrapper.SetContextAttribute( AngularConst.BindPendingDot, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-timeline [nzPendingDot]=\"a\"></nz-timeline>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否倒序排列
        /// </summary>
        [Fact]
        public void TestReverse() {
            _wrapper.SetContextAttribute( UiConst.Reverse, true );
            var result = new StringBuilder();
            result.Append( "<nz-timeline [nzReverse]=\"true\"></nz-timeline>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否倒序排列
        /// </summary>
        [Fact]
        public void TestBindReverse() {
            _wrapper.SetContextAttribute( AngularConst.BindReverse, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-timeline [nzReverse]=\"a\"></nz-timeline>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模式
        /// </summary>
        [Fact]
        public void TestMode() {
            _wrapper.SetContextAttribute( UiConst.Mode, TimelineMode.Custom );
            var result = new StringBuilder();
            result.Append( "<nz-timeline nzMode=\"custom\"></nz-timeline>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模式
        /// </summary>
        [Fact]
        public void TestBindMode() {
            _wrapper.SetContextAttribute( AngularConst.BindMode, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-timeline [nzMode]=\"a\"></nz-timeline>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-timeline>a</nz-timeline>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}