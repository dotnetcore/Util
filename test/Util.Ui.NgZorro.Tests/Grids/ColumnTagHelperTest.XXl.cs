using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Grids {
    /// <summary>
    /// 栅格列测试 - XXl极宽尺寸响应式栅格
    /// </summary>
    public partial class ColumnTagHelperTest {
        /// <summary>
        /// 测试极宽尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestXxlSpan() {
            _wrapper.SetContextAttribute( UiConst.XxlSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXXl]=\"{span:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试极宽尺寸栅格偏移量
        /// </summary>
        [Fact]
        public void TestXxlOffset() {
            _wrapper.SetContextAttribute( UiConst.XxlOffset, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXXl]=\"{offset:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试极宽尺寸栅格顺序
        /// </summary>
        [Fact]
        public void TestXxlOrder() {
            _wrapper.SetContextAttribute( UiConst.XxlOrder, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXXl]=\"{order:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试极宽尺寸栅格左移
        /// </summary>
        [Fact]
        public void TestXxlPull() {
            _wrapper.SetContextAttribute( UiConst.XxlPull, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXXl]=\"{pull:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试极宽尺寸栅格右移
        /// </summary>
        [Fact]
        public void TestXxlPush() {
            _wrapper.SetContextAttribute( UiConst.XxlPush, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXXl]=\"{push:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试极宽尺寸栅格
        /// </summary>
        [Fact]
        public void TestXxl_1() {
            _wrapper.SetContextAttribute( UiConst.Xxl, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXXl]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置极宽尺寸栅格跨度和右移
        /// </summary>
        [Fact]
        public void TestXxl_2() {
            _wrapper.SetContextAttribute( UiConst.XxlSpan, 1 ).SetContextAttribute( UiConst.XxlPush, 2 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXXl]=\"{span:1,push:2}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置极宽尺寸栅格Xxl和XxlSpan属性,Xxl生效
        /// </summary>
        [Fact]
        public void TestXxl_3() {
            _wrapper.SetContextAttribute( UiConst.Xxl, "a" ).SetContextAttribute( UiConst.XxlSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXXl]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}