using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Grids;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Grids {
    /// <summary>
    /// 栅格列测试
    /// </summary>
    public partial class ColumnTagHelperTest {
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
        public ColumnTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ColumnTagHelper().ToWrapper();
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
            result.Append( "<div nz-col=\"\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试跨度
        /// </summary>
        [Fact]
        public void TestSpan() {
            _wrapper.SetContextAttribute( UiConst.Span, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" nzSpan=\"1\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试跨度
        /// </summary>
        [Fact]
        public void TestBindSpan() {
            _wrapper.SetContextAttribute( AngularConst.BindSpan, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzSpan]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试偏移量
        /// </summary>
        [Fact]
        public void TestOffset() {
            _wrapper.SetContextAttribute( UiConst.Offset, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" nzOffset=\"1\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试偏移量
        /// </summary>
        [Fact]
        public void TestBindOffset() {
            _wrapper.SetContextAttribute( AngularConst.BindOffset, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzOffset]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试左移
        /// </summary>
        [Fact]
        public void TestPull() {
            _wrapper.SetContextAttribute( UiConst.Pull, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" nzPull=\"1\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试左移
        /// </summary>
        [Fact]
        public void TestBindPull() {
            _wrapper.SetContextAttribute( AngularConst.BindPull, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzPull]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右移
        /// </summary>
        [Fact]
        public void TestPush() {
            _wrapper.SetContextAttribute( UiConst.Push, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" nzPush=\"1\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右移
        /// </summary>
        [Fact]
        public void TestBindPush() {
            _wrapper.SetContextAttribute( AngularConst.BindPush, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzPush]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试栅格顺序
        /// </summary>
        [Fact]
        public void TestOrder() {
            _wrapper.SetContextAttribute( UiConst.Order, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" nzOrder=\"1\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试栅格顺序
        /// </summary>
        [Fact]
        public void TestBindOrder() {
            _wrapper.SetContextAttribute( AngularConst.BindOrder, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzOrder]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试flex布局
        /// </summary>
        [Fact]
        public void TestFlex() {
            _wrapper.SetContextAttribute( UiConst.Flex, "1" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" nzFlex=\"1\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试flex布局
        /// </summary>
        [Fact]
        public void TestBindFlex() {
            _wrapper.SetContextAttribute( AngularConst.BindFlex, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzFlex]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}