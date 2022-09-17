using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Grids {
    /// <summary>
    /// 栅格列测试 - Lg宽尺寸响应式栅格
    /// </summary>
    public partial class ColumnTagHelperTest {
        /// <summary>
        /// 测试宽尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestLgSpan() {
            _wrapper.SetContextAttribute( UiConst.LgSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzLg]=\"{span:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽尺寸栅格偏移量
        /// </summary>
        [Fact]
        public void TestLgOffset() {
            _wrapper.SetContextAttribute( UiConst.LgOffset, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzLg]=\"{offset:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽尺寸栅格顺序
        /// </summary>
        [Fact]
        public void TestLgOrder() {
            _wrapper.SetContextAttribute( UiConst.LgOrder, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzLg]=\"{order:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽尺寸栅格左移
        /// </summary>
        [Fact]
        public void TestLgPull() {
            _wrapper.SetContextAttribute( UiConst.LgPull, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzLg]=\"{pull:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽尺寸栅格右移
        /// </summary>
        [Fact]
        public void TestLgPush() {
            _wrapper.SetContextAttribute( UiConst.LgPush, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzLg]=\"{push:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽尺寸栅格
        /// </summary>
        [Fact]
        public void TestLg_1() {
            _wrapper.SetContextAttribute( UiConst.Lg, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzLg]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置宽尺寸栅格跨度和右移
        /// </summary>
        [Fact]
        public void TestLg_2() {
            _wrapper.SetContextAttribute( UiConst.LgSpan, 1 ).SetContextAttribute( UiConst.LgPush, 2 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzLg]=\"{span:1,push:2}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置宽尺寸栅格Lg和LgSpan属性,Lg生效
        /// </summary>
        [Fact]
        public void TestLg_3() {
            _wrapper.SetContextAttribute( UiConst.Lg, "a" ).SetContextAttribute( UiConst.LgSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzLg]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}