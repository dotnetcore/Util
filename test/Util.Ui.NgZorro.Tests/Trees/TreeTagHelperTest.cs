using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Trees;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Trees {
    /// <summary>
    /// 树形控件测试
    /// </summary>
    public partial class TreeTagHelperTest {
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
        public TreeTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TreeTagHelper().ToWrapper();
            Id.SetId( "id" );
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
            result.Append( "<nz-tree></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数据
        /// </summary>
        [Fact]
        public void TestData() {
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzData]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否节点占一行
        /// </summary>
        [Fact]
        public void TestBlockNode() {
            _wrapper.SetContextAttribute( UiConst.BlockNode, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzBlockNode]=\"true\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否节点占一行
        /// </summary>
        [Fact]
        public void TestBindBlockNode() {
            _wrapper.SetContextAttribute( AngularConst.BindBlockNode, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzBlockNode]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试节点前是否显示复选框
        /// </summary>
        [Fact]
        public void TestCheckable() {
            _wrapper.SetContextAttribute( UiConst.Checkable, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzCheckable]=\"true\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试节点前是否显示复选框
        /// </summary>
        [Fact]
        public void TestBindCheckable() {
            _wrapper.SetContextAttribute( AngularConst.BindCheckable, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzCheckable]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试节点前是否显示展开图标
        /// </summary>
        [Fact]
        public void TestShowExpand() {
            _wrapper.SetContextAttribute( UiConst.ShowExpand, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzShowExpand]=\"true\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试节点前是否显示展开图标
        /// </summary>
        [Fact]
        public void TestBindShowExpand() {
            _wrapper.SetContextAttribute( AngularConst.BindShowExpand, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzShowExpand]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示连接线
        /// </summary>
        [Fact]
        public void TestShowLine() {
            _wrapper.SetContextAttribute( UiConst.ShowLine, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzShowLine]=\"true\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示连接线
        /// </summary>
        [Fact]
        public void TestBindShowLine() {
            _wrapper.SetContextAttribute( AngularConst.BindShowLine, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzShowLine]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义展开图标
        /// </summary>
        [Fact]
        public void TestExpandedIcon() {
            _wrapper.SetContextAttribute( UiConst.ExpandedIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzExpandedIcon]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示节点文本前图标
        /// </summary>
        [Fact]
        public void TestShowIcon() {
            _wrapper.SetContextAttribute( UiConst.ShowIcon, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzShowIcon]=\"true\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示节点文本前图标
        /// </summary>
        [Fact]
        public void TestBindShowIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindShowIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzShowIcon]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否异步加载
        /// </summary>
        [Fact]
        public void TestAsyncData() {
            _wrapper.SetContextAttribute( UiConst.AsyncData, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzAsyncData]=\"true\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否异步加载
        /// </summary>
        [Fact]
        public void TestBindAsyncData() {
            _wrapper.SetContextAttribute( AngularConst.BindAsyncData, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzAsyncData]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试节点是否可拖拽
        /// </summary>
        [Fact]
        public void TestDraggable() {
            _wrapper.SetContextAttribute( UiConst.Draggable, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzDraggable]=\"true\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试节点是否可拖拽
        /// </summary>
        [Fact]
        public void TestBindDraggable() {
            _wrapper.SetContextAttribute( AngularConst.BindDraggable, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzDraggable]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持点选多个节点
        /// </summary>
        [Fact]
        public void TestMultiple() {
            _wrapper.SetContextAttribute( UiConst.Multiple, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzMultiple]=\"true\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持点选多个节点
        /// </summary>
        [Fact]
        public void TestBindMultiple() {
            _wrapper.SetContextAttribute( AngularConst.BindMultiple, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzMultiple]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否隐藏未匹配节点
        /// </summary>
        [Fact]
        public void TestHideUnMatched() {
            _wrapper.SetContextAttribute( UiConst.HideUnmatched, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzHideUnMatched]=\"true\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否隐藏未匹配节点
        /// </summary>
        [Fact]
        public void TestBindHideUnMatched() {
            _wrapper.SetContextAttribute( AngularConst.BindHideUnmatched, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzHideUnMatched]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试严格勾选
        /// </summary>
        [Fact]
        public void TestCheckStrictly() {
            _wrapper.SetContextAttribute( UiConst.CheckStrictly, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzCheckStrictly]=\"true\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试严格勾选
        /// </summary>
        [Fact]
        public void TestBindCheckStrictly() {
            _wrapper.SetContextAttribute( AngularConst.BindCheckStrictly, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzCheckStrictly]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义模板
        /// </summary>
        [Fact]
        public void TestTreeTemplate() {
            _wrapper.SetContextAttribute( UiConst.TreeTemplate, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzTreeTemplate]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试默认展开所有节点
        /// </summary>
        [Fact]
        public void TestExpandAll() {
            _wrapper.SetContextAttribute( UiConst.ExpandAll, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzExpandAll]=\"true\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试默认展开所有节点
        /// </summary>
        [Fact]
        public void TestBindExpandAll() {
            _wrapper.SetContextAttribute( AngularConst.BindExpandAll, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzExpandAll]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展开节点的键集合
        /// </summary>
        [Fact]
        public void TestExpandedKeys() {
            _wrapper.SetContextAttribute( UiConst.ExpandedKeys, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzExpandedKeys]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试勾选节点复选框的键集合
        /// </summary>
        [Fact]
        public void TestCheckedKeys() {
            _wrapper.SetContextAttribute( UiConst.CheckedKeys, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzCheckedKeys]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中节点的键集合
        /// </summary>
        [Fact]
        public void TestSelectedKeys() {
            _wrapper.SetContextAttribute( UiConst.SelectedKeys, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzSelectedKeys]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试搜索值
        /// </summary>
        [Fact]
        public void TestSearchValue() {
            _wrapper.SetContextAttribute( UiConst.SearchValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree nzSearchValue=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试搜索值
        /// </summary>
        [Fact]
        public void TestBindSearchValue() {
            _wrapper.SetContextAttribute( AngularConst.BindSearchValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzSearchValue]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试搜索值
        /// </summary>
        [Fact]
        public void TestBindonSearchValue() {
            _wrapper.SetContextAttribute( AngularConst.BindonSearchValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [(nzSearchValue)]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义搜索方法
        /// </summary>
        [Fact]
        public void TestSearchFunc() {
            _wrapper.SetContextAttribute( UiConst.SearchFunc, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzSearchFunc]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试拖拽前函数
        /// </summary>
        [Fact]
        public void TestBeforeDrop() {
            _wrapper.SetContextAttribute( UiConst.BeforeDrop, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzBeforeDrop]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟高度
        /// </summary>
        [Fact]
        public void TestVirtualHeight() {
            _wrapper.SetContextAttribute( UiConst.VirtualHeight, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree nzVirtualHeight=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟高度
        /// </summary>
        [Fact]
        public void TestBindVirtualHeight() {
            _wrapper.SetContextAttribute( AngularConst.BindVirtualHeight, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzVirtualHeight]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动列高
        /// </summary>
        [Fact]
        public void TestVirtualItemSize() {
            _wrapper.SetContextAttribute( UiConst.VirtualItemSize, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-tree nzVirtualItemSize=\"1\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动列高
        /// </summary>
        [Fact]
        public void TestBindVirtualItemSize() {
            _wrapper.SetContextAttribute( AngularConst.BindVirtualItemSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzVirtualItemSize]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动缓冲区最大高度
        /// </summary>
        [Fact]
        public void TestVirtualMaxBufferPx() {
            _wrapper.SetContextAttribute( UiConst.VirtualMaxBufferPx, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-tree nzVirtualMaxBufferPx=\"1\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动缓冲区最大高度
        /// </summary>
        [Fact]
        public void TestBindVirtualMaxBufferPx() {
            _wrapper.SetContextAttribute( AngularConst.BindVirtualMaxBufferPx, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzVirtualMaxBufferPx]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动缓冲区最小高度
        /// </summary>
        [Fact]
        public void TestVirtualMinBufferPx() {
            _wrapper.SetContextAttribute( UiConst.VirtualMinBufferPx, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-tree nzVirtualMinBufferPx=\"1\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动缓冲区最小高度
        /// </summary>
        [Fact]
        public void TestBindVirtualMinBufferPx() {
            _wrapper.SetContextAttribute( AngularConst.BindVirtualMinBufferPx, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree [nzVirtualMinBufferPx]=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree>a</nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree (nzClick)=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试双击事件
        /// </summary>
        [Fact]
        public void TestOnDblClick() {
            _wrapper.SetContextAttribute( UiConst.OnDblClick, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree (nzDblClick)=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试上下文菜单事件
        /// </summary>
        [Fact]
        public void TestOnContextMenu() {
            _wrapper.SetContextAttribute( UiConst.OnContextmenu, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree (nzContextMenu)=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试树节点复选框选中状态变化事件
        /// </summary>
        [Fact]
        public void TestOnCheckBoxChange() {
            _wrapper.SetContextAttribute( UiConst.OnCheckBoxChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree (nzCheckBoxChange)=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展开收缩节点事件
        /// </summary>
        [Fact]
        public void TestOnExpandChange() {
            _wrapper.SetContextAttribute( UiConst.OnExpandChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree (nzExpandChange)=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试搜索值变化事件
        /// </summary>
        [Fact]
        public void TestOnSearchValueChange() {
            _wrapper.SetContextAttribute( UiConst.OnSearchValueChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree (nzSearchValueChange)=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试开始拖拽事件
        /// </summary>
        [Fact]
        public void TestOnDragStart() {
            _wrapper.SetContextAttribute( UiConst.OnDragStart, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree (nzOnDragStart)=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试dragenter事件
        /// </summary>
        [Fact]
        public void TestOnDragEnter() {
            _wrapper.SetContextAttribute( UiConst.OnDragEnter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree (nzOnDragEnter)=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试dragover事件
        /// </summary>
        [Fact]
        public void TestOnDragOver() {
            _wrapper.SetContextAttribute( UiConst.OnDragOver, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree (nzOnDragOver)=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试dragleave事件
        /// </summary>
        [Fact]
        public void TestOnDragLeave() {
            _wrapper.SetContextAttribute( UiConst.OnDragLeave, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree (nzOnDragLeave)=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试drop事件
        /// </summary>
        [Fact]
        public void TestOnDrop() {
            _wrapper.SetContextAttribute( UiConst.OnDrop, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree (nzOnDrop)=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试dragend事件
        /// </summary>
        [Fact]
        public void TestOnDragEnd() {
            _wrapper.SetContextAttribute( UiConst.OnDragEnd, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree (nzOnDragEnd)=\"a\"></nz-tree>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}