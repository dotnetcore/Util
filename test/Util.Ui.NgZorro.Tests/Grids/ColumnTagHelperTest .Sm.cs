using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Grids {
    /// <summary>
    /// 栅格列测试 - Sm窄尺寸响应式栅格
    /// </summary>
    public partial class ColumnTagHelperTest {
        /// <summary>
        /// 测试窄尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestSmSpan() {
            _wrapper.SetContextAttribute( UiConst.SmSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzSm]=\"{span:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试窄尺寸栅格偏移量
        /// </summary>
        [Fact]
        public void TestSmOffset() {
            _wrapper.SetContextAttribute( UiConst.SmOffset, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzSm]=\"{offset:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试窄尺寸栅格顺序
        /// </summary>
        [Fact]
        public void TestSmOrder() {
            _wrapper.SetContextAttribute( UiConst.SmOrder, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzSm]=\"{order:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试窄尺寸栅格左移
        /// </summary>
        [Fact]
        public void TestSmPull() {
            _wrapper.SetContextAttribute( UiConst.SmPull, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzSm]=\"{pull:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试窄尺寸栅格右移
        /// </summary>
        [Fact]
        public void TestSmPush() {
            _wrapper.SetContextAttribute( UiConst.SmPush, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzSm]=\"{push:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试窄尺寸栅格
        /// </summary>
        [Fact]
        public void TestSm_1() {
            _wrapper.SetContextAttribute( UiConst.Sm, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzSm]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置窄尺寸栅格跨度和右移
        /// </summary>
        [Fact]
        public void TestSm_2() {
            _wrapper.SetContextAttribute( UiConst.SmSpan, 1 ).SetContextAttribute( UiConst.SmPush, 2 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzSm]=\"{span:1,push:2}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置窄尺寸栅格Sm和SmSpan属性,Sm生效
        /// </summary>
        [Fact]
        public void TestSm_3() {
            _wrapper.SetContextAttribute( UiConst.Sm, "a" ).SetContextAttribute( UiConst.SmSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzSm]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}