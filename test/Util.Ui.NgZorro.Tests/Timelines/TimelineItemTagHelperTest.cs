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
    /// 时间轴节点测试
    /// </summary>
    public class TimelineItemTagHelperTest {
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
        public TimelineItemTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TimelineItemTagHelper().ToWrapper();
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
            result.Append( "<nz-timeline-item></nz-timeline-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            _wrapper.SetContextAttribute( UiConst.Color, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-timeline-item nzColor=\"a\"></nz-timeline-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestBindColor() {
            _wrapper.SetContextAttribute( AngularConst.BindColor, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-timeline-item [nzColor]=\"a\"></nz-timeline-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义时间轴点
        /// </summary>
        [Fact]
        public void TestDot() {
            _wrapper.SetContextAttribute( UiConst.Dot, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-timeline-item [nzDot]=\"a\"></nz-timeline-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义节点位置
        /// </summary>
        [Fact]
        public void TestPosition() {
            _wrapper.SetContextAttribute( UiConst.Position, TimelineItemPosition.Left );
            var result = new StringBuilder();
            result.Append( "<nz-timeline-item nzPosition=\"left\"></nz-timeline-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义节点位置
        /// </summary>
        [Fact]
        public void TestBindPosition() {
            _wrapper.SetContextAttribute( AngularConst.BindPosition, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-timeline-item [nzPosition]=\"a\"></nz-timeline-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-timeline-item>a</nz-timeline-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}