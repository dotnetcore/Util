using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Grids {
    /// <summary>
    /// 栅格列测试 - Xl超宽尺寸响应式栅格
    /// </summary>
    public partial class ColumnTagHelperTest {
        /// <summary>
        /// 测试超宽尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestXlSpan() {
            _wrapper.SetContextAttribute( UiConst.XlSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXl]=\"{span:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超宽尺寸栅格偏移量
        /// </summary>
        [Fact]
        public void TestXlOffset() {
            _wrapper.SetContextAttribute( UiConst.XlOffset, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXl]=\"{offset:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超宽尺寸栅格顺序
        /// </summary>
        [Fact]
        public void TestXlOrder() {
            _wrapper.SetContextAttribute( UiConst.XlOrder, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXl]=\"{order:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超宽尺寸栅格左移
        /// </summary>
        [Fact]
        public void TestXlPull() {
            _wrapper.SetContextAttribute( UiConst.XlPull, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXl]=\"{pull:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超宽尺寸栅格右移
        /// </summary>
        [Fact]
        public void TestXlPush() {
            _wrapper.SetContextAttribute( UiConst.XlPush, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXl]=\"{push:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超宽尺寸栅格
        /// </summary>
        [Fact]
        public void TestXl_1() {
            _wrapper.SetContextAttribute( UiConst.Xl, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXl]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置超宽尺寸栅格跨度和右移
        /// </summary>
        [Fact]
        public void TestXl_2() {
            _wrapper.SetContextAttribute( UiConst.XlSpan, 1 ).SetContextAttribute( UiConst.XlPush, 2 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXl]=\"{span:1,push:2}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置超宽尺寸栅格Xl和XlSpan属性,Xl生效
        /// </summary>
        [Fact]
        public void TestXl_3() {
            _wrapper.SetContextAttribute( UiConst.Xl, "a" ).SetContextAttribute( UiConst.XlSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzXl]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}