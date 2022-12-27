using System.Text;
using Util.Applications.Trees;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.TreeSelects {
    /// <summary>
    /// 树选择测试 - 指令扩展
    /// </summary>
    public partial class TreeSelectTagHelperTest {

        #region EnableExtend

        /// <summary>
        /// 测试启用扩展指令
        /// </summary>
        [Fact]
        public void TestEnableExtend_1() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select #x_id=\"xTreeExtend\" (nzExpandChange)=\"x_id.expandChange($event)\" x-tree-extend=\"\" " );
            result.Append( "[nzNodes]=\"x_id.dataSource\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试启用扩展指令 - 不启用
        /// </summary>
        [Fact]
        public void TestEnableExtend_2() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, false );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select>" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region AutoLoad

        /// <summary>
        /// 测试初始化时是否自动加载数据
        /// </summary>
        [Fact]
        public void TestAutoLoad() {
            _wrapper.SetContextAttribute( UiConst.AutoLoad, false );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [autoLoad]=\"false\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region QueryParam

        /// <summary>
        /// 测试查询参数
        /// </summary>
        [Fact]
        public void TestQueryParam() {
            _wrapper.SetContextAttribute( UiConst.QueryParam, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [(queryParam)]=\"a\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Sort

        /// <summary>
        /// 测试排序条件
        /// </summary>
        [Fact]
        public void TestSort() {
            _wrapper.SetContextAttribute( UiConst.Sort, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select order=\"a\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排序条件
        /// </summary>
        [Fact]
        public void TestBindSort() {
            _wrapper.SetContextAttribute( AngularConst.BindSort, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [order]=\"a\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Url

        /// <summary>
        /// 测试Api地址
        /// </summary>
        [Fact]
        public void TestUrl_1() {
            _wrapper.SetContextAttribute( UiConst.Url, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select #x_id=\"xTreeExtend\" (nzExpandChange)=\"x_id.expandChange($event)\" url=\"a\" x-tree-extend=\"\" " );
            result.Append( "[nzNodes]=\"x_id.dataSource\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Api地址 - 覆盖默认属性
        /// </summary>
        [Fact]
        public void TestUrl_2() {
            _wrapper.SetContextAttribute( UiConst.Url, "a" );
            _wrapper.SetContextAttribute( UiConst.Nodes, "b" );
            _wrapper.SetContextAttribute( UiConst.OnExpandChange, "c" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select #x_id=\"xTreeExtend\" (nzExpandChange)=\"c\" url=\"a\" x-tree-extend=\"\" " );
            result.Append( "[nzNodes]=\"b\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Api地址
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            _wrapper.SetContextAttribute( AngularConst.BindUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select #x_id=\"xTreeExtend\" (nzExpandChange)=\"x_id.expandChange($event)\" x-tree-extend=\"\" " );
            result.Append( "[nzNodes]=\"x_id.dataSource\" [url]=\"a\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region LoadUrl

        /// <summary>
        /// 测试加载地址
        /// </summary>
        [Fact]
        public void TestLoadUrl() {
            _wrapper.SetContextAttribute( UiConst.LoadUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select #x_id=\"xTreeExtend\" (nzExpandChange)=\"x_id.expandChange($event)\" loadUrl=\"a\" x-tree-extend=\"\" " );
            result.Append( "[nzNodes]=\"x_id.dataSource\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载地址
        /// </summary>
        [Fact]
        public void TestBindLoadUrl() {
            _wrapper.SetContextAttribute( AngularConst.BindLoadUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select #x_id=\"xTreeExtend\" (nzExpandChange)=\"x_id.expandChange($event)\" x-tree-extend=\"\" [loadUrl]=\"a\" " );
            result.Append( "[nzNodes]=\"x_id.dataSource\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region QueryUrl

        /// <summary>
        /// 测试查询地址
        /// </summary>
        [Fact]
        public void TestQueryUrl() {
            _wrapper.SetContextAttribute( UiConst.QueryUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select #x_id=\"xTreeExtend\" (nzExpandChange)=\"x_id.expandChange($event)\" queryUrl=\"a\" x-tree-extend=\"\" " );
            result.Append( "[nzNodes]=\"x_id.dataSource\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试查询地址
        /// </summary>
        [Fact]
        public void TestBindQueryUrl() {
            _wrapper.SetContextAttribute( AngularConst.BindQueryUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select #x_id=\"xTreeExtend\" (nzExpandChange)=\"x_id.expandChange($event)\" x-tree-extend=\"\" " );
            result.Append( "[nzNodes]=\"x_id.dataSource\" [queryUrl]=\"a\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region LoadChildrenUrl

        /// <summary>
        /// 测试加载下级节点地址
        /// </summary>
        [Fact]
        public void TestLoadChildrenUrl() {
            _wrapper.SetContextAttribute( UiConst.LoadChildrenUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select #x_id=\"xTreeExtend\" (nzExpandChange)=\"x_id.expandChange($event)\" loadChildrenUrl=\"a\" x-tree-extend=\"\" " );
            result.Append( "[nzNodes]=\"x_id.dataSource\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载下级节点地址
        /// </summary>
        [Fact]
        public void TestBindLoadChildrenUrl() {
            _wrapper.SetContextAttribute( AngularConst.BindLoadChildrenUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select #x_id=\"xTreeExtend\" (nzExpandChange)=\"x_id.expandChange($event)\" x-tree-extend=\"\" [loadChildrenUrl]=\"a\" " );
            result.Append( "[nzNodes]=\"x_id.dataSource\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region ExpandForRootAsync

        /// <summary>
        /// 测试根节点异步加载模式是否展开子节点
        /// </summary>
        [Fact]
        public void TestExpandForRootAsync() {
            _wrapper.SetContextAttribute( UiConst.ExpandForRootAsync, false );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [isExpandForRootAsync]=\"false\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region LoadMode

        /// <summary>
        /// 测试加载模式 - 同步
        /// </summary>
        [Fact]
        public void TestLoadMode_1() {
            _wrapper.SetContextAttribute( UiConst.LoadMode, LoadMode.Sync );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select loadMode=\"0\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载模式 - 异步
        /// </summary>
        [Fact]
        public void TestLoadMode_2() {
            _wrapper.SetContextAttribute( UiConst.LoadMode, LoadMode.Async );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select loadMode=\"1\" [nzAsyncData]=\"true\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载模式 - 根节点异步
        /// </summary>
        [Fact]
        public void TestLoadMode_3() {
            _wrapper.SetContextAttribute( UiConst.LoadMode, LoadMode.RootAsync );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select loadMode=\"2\" [nzAsyncData]=\"true\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region OnLoadChildrenBefore

        /// <summary>
        /// 测试子节点加载前事件
        /// </summary>
        [Fact]
        public void TestOnLoadChildrenBefore() {
            _wrapper.SetContextAttribute( UiConst.OnLoadChildrenBefore, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [onLoadChildrenBefore]=\"a\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region OnLoadChildren

        /// <summary>
        /// 测试子节点加载完成事件
        /// </summary>
        [Fact]
        public void TestOnLoadChildren() {
            _wrapper.SetContextAttribute( UiConst.OnLoadChildren, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select (onLoadChildren)=\"a\">" );
            result.Append( "</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region OnExpand

        /// <summary>
        /// 测试节点展开事件
        /// </summary>
        [Fact]
        public void TestOnExpand() {
            _wrapper.SetContextAttribute( UiConst.OnExpand, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select (onExpand)=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region OnCollapse

        /// <summary>
        /// 测试节点折叠事件
        /// </summary>
        [Fact]
        public void TestOnCollapse() {
            _wrapper.SetContextAttribute( UiConst.OnCollapse, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select (onCollapse)=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion
    }
}