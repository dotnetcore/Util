using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格行测试
    /// </summary>
    public class TableRowTagHelperTest {
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
        public TableRowTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TableRowTagHelper().ToWrapper();
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
            result.Append( "<tr></tr>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试当前列是否展开
        /// </summary>
        [Fact]
        public void TestExpand() {
            _wrapper.SetContextAttribute( UiConst.Expand, "a" );
            var result = new StringBuilder();
            result.Append( "<tr [nzExpand]=\"a\"></tr>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试行单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<tr (click)=\"a\"></tr>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<tr>a</tr>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}