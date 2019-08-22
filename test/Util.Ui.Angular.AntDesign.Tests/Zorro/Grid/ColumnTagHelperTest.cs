using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Grid;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Grid {
    /// <summary>
    /// 栅格列测试
    /// </summary>
    public class ColumnTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 栅格列
        /// </summary>
        private readonly ColumnTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ColumnTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new ColumnTagHelper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<div nz-col=\"\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<div #a=\"\" nz-col=\"\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试跨度
        /// </summary>
        [Fact]
        public void TestSpan() {
            var attributes = new TagHelperAttributeList { { UiConst.Span, 1 } };
            var result = new String();
            result.Append( "<div nz-col=\"\" [nzSpan]=\"1\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试偏移量
        /// </summary>
        [Fact]
        public void TestOffset() {
            var attributes = new TagHelperAttributeList { { UiConst.Offset, 1 } };
            var result = new String();
            result.Append( "<div nz-col=\"\" [nzOffset]=\"1\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试向左移动
        /// </summary>
        [Fact]
        public void TestPull() {
            var attributes = new TagHelperAttributeList { { UiConst.Pull, 1 } };
            var result = new String();
            result.Append( "<div nz-col=\"\" [nzPull]=\"1\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试向右移动
        /// </summary>
        [Fact]
        public void TestPush() {
            var attributes = new TagHelperAttributeList { { UiConst.Push, 1 } };
            var result = new String();
            result.Append( "<div nz-col=\"\" [nzPush]=\"1\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试栅格顺序
        /// </summary>
        [Fact]
        public void TestOrder() {
            var attributes = new TagHelperAttributeList { { UiConst.Order, 1 } };
            var result = new String();
            result.Append( "<div nz-col=\"\" [nzOrder]=\"1\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}