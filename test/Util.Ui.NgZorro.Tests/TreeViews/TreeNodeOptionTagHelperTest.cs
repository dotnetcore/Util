using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.TreeViews;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.TreeViews {
    /// <summary>
    /// 树节点可选项测试
    /// </summary>
    public class TreeNodeOptionTagHelperTest {
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
        public TreeNodeOptionTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TreeNodeOptionTagHelper().ToWrapper();
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
            result.Append( "<nz-tree-node-option></nz-tree-node-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否选中
        /// </summary>
        [Fact]
        public void TestSelected() {
            _wrapper.SetContextAttribute( UiConst.Selected, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-option [nzSelected]=\"true\"></nz-tree-node-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否选中
        /// </summary>
        [Fact]
        public void TestBindSelected() {
            _wrapper.SetContextAttribute( AngularConst.BindSelected, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-option [nzSelected]=\"a\"></nz-tree-node-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-option [nzDisabled]=\"true\"></nz-tree-node-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-option [nzDisabled]=\"a\"></nz-tree-node-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-option>a</nz-tree-node-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-option (nzClick)=\"a\"></nz-tree-node-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}