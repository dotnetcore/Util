using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Grids {
    /// <summary>
    /// 栅格列测试 - Md中尺寸响应式栅格
    /// </summary>
    public partial class ColumnTagHelperTest {
        /// <summary>
        /// 测试中尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestMdSpan() {
            _wrapper.SetContextAttribute( UiConst.MdSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzMd]=\"{span:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试中尺寸栅格偏移量
        /// </summary>
        [Fact]
        public void TestMdOffset() {
            _wrapper.SetContextAttribute( UiConst.MdOffset, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzMd]=\"{offset:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试中尺寸栅格顺序
        /// </summary>
        [Fact]
        public void TestMdOrder() {
            _wrapper.SetContextAttribute( UiConst.MdOrder, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzMd]=\"{order:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试中尺寸栅格左移
        /// </summary>
        [Fact]
        public void TestMdPull() {
            _wrapper.SetContextAttribute( UiConst.MdPull, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzMd]=\"{pull:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试中尺寸栅格右移
        /// </summary>
        [Fact]
        public void TestMdPush() {
            _wrapper.SetContextAttribute( UiConst.MdPush, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzMd]=\"{push:1}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试中尺寸栅格
        /// </summary>
        [Fact]
        public void TestMd_1() {
            _wrapper.SetContextAttribute( UiConst.Md, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzMd]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置中尺寸栅格跨度和右移
        /// </summary>
        [Fact]
        public void TestMd_2() {
            _wrapper.SetContextAttribute( UiConst.MdSpan, 1 ).SetContextAttribute( UiConst.MdPush, 2 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzMd]=\"{span:1,push:2}\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置中尺寸栅格Md和MdSpan属性,Md生效
        /// </summary>
        [Fact]
        public void TestMd_3() {
            _wrapper.SetContextAttribute( UiConst.Md, "a" ).SetContextAttribute( UiConst.MdSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<div nz-col=\"\" [nzMd]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}