using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.TreeViews;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.TreeViews {
    /// <summary>
    /// 树视图测试
    /// </summary>
    public class TreeViewTagHelperTest {
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
        public TreeViewTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TreeViewTagHelper().ToWrapper();
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
            result.Append( "<nz-tree-view></nz-tree-view>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试树控制器
        /// </summary>
        [Fact]
        public void TestTreeControl() {
            _wrapper.SetContextAttribute( UiConst.TreeControl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-view [nzTreeControl]=\"a\"></nz-tree-view>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数据源
        /// </summary>
        [Fact]
        public void TestDataSource() {
            _wrapper.SetContextAttribute( UiConst.Datasource, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-view [nzDataSource]=\"a\"></nz-tree-view>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否文件夹样式
        /// </summary>
        [Fact]
        public void TestDirectoryTree() {
            _wrapper.SetContextAttribute( UiConst.DirectoryTree, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-view [nzDirectoryTree]=\"true\"></nz-tree-view>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否文件夹样式
        /// </summary>
        [Fact]
        public void TestBindDirectoryTree() {
            _wrapper.SetContextAttribute( AngularConst.BindDirectoryTree, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-view [nzDirectoryTree]=\"a\"></nz-tree-view>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试节点是否占整行
        /// </summary>
        [Fact]
        public void TestBlockNode() {
            _wrapper.SetContextAttribute( UiConst.BlockNode, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-view [nzBlockNode]=\"true\"></nz-tree-view>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试节点是否占整行
        /// </summary>
        [Fact]
        public void TestBindBlockNode() {
            _wrapper.SetContextAttribute( AngularConst.BindBlockNode, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-view [nzBlockNode]=\"a\"></nz-tree-view>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-view>a</nz-tree-view>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}