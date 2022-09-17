using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.TreeViews;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.TreeViews {
    /// <summary>
    /// 树节点测试
    /// </summary>
    public class TreeNodeTagHelperTest {
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
        public TreeNodeTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TreeNodeTagHelper().ToWrapper();
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
            result.Append( "<nz-tree-node></nz-tree-node>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试树节点定义指令
        /// </summary>
        [Fact]
        public void TestTreeNodeDef() {
            _wrapper.SetContextAttribute( UiConst.TreeNodeDef, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node *nzTreeNodeDef=\"a\"></nz-tree-node>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试树节点内边距
        /// </summary>
        [Fact]
        public void TestTreeNodePadding() {
            _wrapper.SetContextAttribute( UiConst.TreeNodePadding, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node nzTreeNodePadding=\"\"></nz-tree-node>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试树节点内边距 - 值为false不添加nzTreeNodePadding
        /// </summary>
        [Fact]
        public void TestTreeNodePadding_False() {
            _wrapper.SetContextAttribute( UiConst.TreeNodePadding, false );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node></nz-tree-node>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试树节点缩进线
        /// </summary>
        [Fact]
        public void TestTreeNodeIndentLine() {
            _wrapper.SetContextAttribute( UiConst.TreeNodeIndentLine, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node nzTreeNodeIndentLine=\"\"></nz-tree-node>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试树节点缩进线 - 值为false不添加nzTreeNodeIndentLine
        /// </summary>
        [Fact]
        public void TestTreeNodeIndentLine_Flase() {
            _wrapper.SetContextAttribute( UiConst.TreeNodeIndentLine, false );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node></nz-tree-node>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node>a</nz-tree-node>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}