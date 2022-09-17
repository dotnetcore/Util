using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.TreeViews;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.TreeViews {
    /// <summary>
    /// 树节点复选框测试
    /// </summary>
    public class TreeNodeCheckboxTagHelperTest {
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
        public TreeNodeCheckboxTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TreeNodeCheckboxTagHelper().ToWrapper();
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
            result.Append( "<nz-tree-node-checkbox></nz-tree-node-checkbox>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否勾选
        /// </summary>
        [Fact]
        public void TestChecked() {
            _wrapper.SetContextAttribute( UiConst.Checked, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-checkbox [nzChecked]=\"true\"></nz-tree-node-checkbox>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否勾选
        /// </summary>
        [Fact]
        public void TestBindChecked() {
            _wrapper.SetContextAttribute( AngularConst.BindChecked, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-checkbox [nzChecked]=\"a\"></nz-tree-node-checkbox>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否半选
        /// </summary>
        [Fact]
        public void TestIndeterminate() {
            _wrapper.SetContextAttribute( UiConst.Indeterminate, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-checkbox [nzIndeterminate]=\"a\"></nz-tree-node-checkbox>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-checkbox [nzDisabled]=\"true\"></nz-tree-node-checkbox>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-checkbox [nzDisabled]=\"a\"></nz-tree-node-checkbox>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-checkbox>a</nz-tree-node-checkbox>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-node-checkbox (nzClick)=\"a\"></nz-tree-node-checkbox>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}