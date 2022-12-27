using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.TreeViews;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.TreeViews {
    /// <summary>
    /// 树节点切换测试
    /// </summary>
    public class TreeNodeToggleTagHelperTest {
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
        public TreeNodeToggleTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TreeNodeToggleTagHelper().ToWrapper();
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
            result.Append( "<nz-tree-node-toggle></nz-tree-node-toggle>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空操作切换
        /// </summary>
        [Fact]
        public void TestTreeNodeNoopToggle() {
            _wrapper.SetContextAttribute( UiConst.TreeNodeNoopToggle, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-toggle nzTreeNodeNoopToggle=\"\"></nz-tree-node-toggle>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空操作切换 - 值为false不添加nzTreeNodeNoopToggle
        /// </summary>
        [Fact]
        public void TestTreeNodeNoopToggle_False() {
            _wrapper.SetContextAttribute( UiConst.TreeNodeNoopToggle, false );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-toggle></nz-tree-node-toggle>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-toggle>a</nz-tree-node-toggle>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}