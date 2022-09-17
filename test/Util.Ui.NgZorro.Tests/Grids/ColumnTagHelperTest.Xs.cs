using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Grids {
    /// <summary>
    /// 栅格列测试 - Xs超窄尺寸响应式栅格
    /// </summary>
    public partial class ColumnTagHelperTest {
        /// <summary>
        /// 测试超窄尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestXsSpan() {
            _wrapper.SetContextAttribute( UiConst.XsSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXs]=\"{span:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超窄尺寸栅格偏移量
        /// </summary>
        [Fact]
        public void TestXsOffset() {
            _wrapper.SetContextAttribute( UiConst.XsOffset, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXs]=\"{offset:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超窄尺寸栅格顺序
        /// </summary>
        [Fact]
        public void TestXsOrder() {
            _wrapper.SetContextAttribute( UiConst.XsOrder, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXs]=\"{order:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超窄尺寸栅格左移
        /// </summary>
        [Fact]
        public void TestXsPull() {
            _wrapper.SetContextAttribute( UiConst.XsPull, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXs]=\"{pull:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超窄尺寸栅格右移
        /// </summary>
        [Fact]
        public void TestXsPush() {
            _wrapper.SetContextAttribute( UiConst.XsPush, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXs]=\"{push:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超窄尺寸栅格
        /// </summary>
        [Fact]
        public void TestXs_1() {
            _wrapper.SetContextAttribute( UiConst.Xs, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXs]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置超窄尺寸栅格跨度和右移
        /// </summary>
        [Fact]
        public void TestXs_2() {
            _wrapper.SetContextAttribute( UiConst.XsSpan, 1 ).SetContextAttribute( UiConst.XsPush, 2 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXs]=\"{span:1,push:2}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置超窄尺寸栅格Xs和XsSpan属性,Xs生效
        /// </summary>
        [Fact]
        public void TestXs_3() {
            _wrapper.SetContextAttribute( UiConst.Xs, "a" ).SetContextAttribute( UiConst.XsSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXs]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}