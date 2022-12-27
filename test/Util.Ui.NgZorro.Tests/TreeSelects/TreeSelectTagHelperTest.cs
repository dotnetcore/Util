using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.TreeSelects;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.TreeSelects {
    /// <summary>
    /// 树选择测试
    /// </summary>
    public partial class TreeSelectTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper<Customer> _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TreeSelectTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TreeSelectTagHelper().ToWrapper<Customer>();
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
            result.Append( "<nz-tree-select></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select #a=\"\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [(ngModel)]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestAllowClear() {
            _wrapper.SetContextAttribute( UiConst.AllowClear, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzAllowClear]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestBindAllowClear() {
            _wrapper.SetContextAttribute( AngularConst.BindAllowClear, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzAllowClear]=\"Ab\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.Placeholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select nzPlaceHolder=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            _wrapper.SetContextAttribute( AngularConst.BindPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzPlaceHolder]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzDisabled]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzDisabled]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示图标
        /// </summary>
        [Fact]
        public void TestShowIcon() {
            _wrapper.SetContextAttribute( UiConst.ShowIcon, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzShowIcon]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示图标
        /// </summary>
        [Fact]
        public void TestBindShowIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindShowIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzShowIcon]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示搜索
        /// </summary>
        [Fact]
        public void TestShowSearch() {
            _wrapper.SetContextAttribute( UiConst.ShowSearch, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzShowSearch]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示搜索
        /// </summary>
        [Fact]
        public void TestBindShowSearch() {
            _wrapper.SetContextAttribute( AngularConst.BindShowSearch, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzShowSearch]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空列表默认内容
        /// </summary>
        [Fact]
        public void TestNotFoundContent() {
            _wrapper.SetContextAttribute( UiConst.NotFoundContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select nzNotFoundContent=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空列表默认内容
        /// </summary>
        [Fact]
        public void TestBindNotFoundContent() {
            _wrapper.SetContextAttribute( AngularConst.BindNotFoundContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzNotFoundContent]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单和选择器同宽
        /// </summary>
        [Fact]
        public void TestDropdownMatchSelectWidth() {
            _wrapper.SetContextAttribute( UiConst.DropdownMatchSelectWidth, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzDropdownMatchSelectWidth]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单和选择器同宽
        /// </summary>
        [Fact]
        public void TestBindDropdownMatchSelectWidth() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownMatchSelectWidth, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzDropdownMatchSelectWidth]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单样式
        /// </summary>
        [Fact]
        public void TestDropdownStyle() {
            _wrapper.SetContextAttribute( UiConst.DropdownStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzDropdownStyle]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单样式类名
        /// </summary>
        [Fact]
        public void TestDropdownClassName() {
            _wrapper.SetContextAttribute( UiConst.DropdownClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select nzDropdownClassName=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单样式类名
        /// </summary>
        [Fact]
        public void TestBindDropdownClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzDropdownClassName]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持多选
        /// </summary>
        [Fact]
        public void TestMultiple() {
            _wrapper.SetContextAttribute( UiConst.Multiple, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzMultiple]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持多选
        /// </summary>
        [Fact]
        public void TestBindMultiple() {
            _wrapper.SetContextAttribute( AngularConst.BindMultiple, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzMultiple]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试隐藏未匹配节点
        /// </summary>
        [Fact]
        public void TestHideUnmatched() {
            _wrapper.SetContextAttribute( UiConst.HideUnmatched, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzHideUnMatched]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试隐藏未匹配节点
        /// </summary>
        [Fact]
        public void TestBindHideUnmatched() {
            _wrapper.SetContextAttribute( AngularConst.BindHideUnmatched, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzHideUnMatched]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选择框大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, InputSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select nzSize=\"large\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选择框大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzSize]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试节点前是否添加复选框
        /// </summary>
        [Fact]
        public void TestCheckable() {
            _wrapper.SetContextAttribute( UiConst.Checkable, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzCheckable]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试节点前是否添加复选框
        /// </summary>
        [Fact]
        public void TestBindCheckable() {
            _wrapper.SetContextAttribute( AngularConst.BindCheckable, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzCheckable]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试严格勾选
        /// </summary>
        [Fact]
        public void TestCheckStrictly() {
            _wrapper.SetContextAttribute( UiConst.CheckStrictly, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzCheckStrictly]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试严格勾选
        /// </summary>
        [Fact]
        public void TestBindCheckStrictly() {
            _wrapper.SetContextAttribute( AngularConst.BindCheckStrictly, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzCheckStrictly]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示展开图标
        /// </summary>
        [Fact]
        public void TestShowExpand() {
            _wrapper.SetContextAttribute( UiConst.ShowExpand, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzShowExpand]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示展开图标
        /// </summary>
        [Fact]
        public void TestBindShowExpand() {
            _wrapper.SetContextAttribute( AngularConst.BindShowExpand, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzShowExpand]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示连接线
        /// </summary>
        [Fact]
        public void TestShowLine() {
            _wrapper.SetContextAttribute( UiConst.ShowLine, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzShowLine]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示连接线
        /// </summary>
        [Fact]
        public void TestBindShowLine() {
            _wrapper.SetContextAttribute( AngularConst.BindShowLine, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzShowLine]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否异步加载
        /// </summary>
        [Fact]
        public void TestAsyncData() {
            _wrapper.SetContextAttribute( UiConst.AsyncData, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzAsyncData]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否异步加载
        /// </summary>
        [Fact]
        public void TestBindAsyncData() {
            _wrapper.SetContextAttribute( AngularConst.BindAsyncData, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzAsyncData]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试节点数据
        /// </summary>
        [Fact]
        public void TestNodes() {
            _wrapper.SetContextAttribute( UiConst.Nodes, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzNodes]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试默认展开所有节点
        /// </summary>
        [Fact]
        public void TestDefaultExpandAll() {
            _wrapper.SetContextAttribute( UiConst.DefaultExpandAll, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzDefaultExpandAll]=\"true\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试默认展开所有节点
        /// </summary>
        [Fact]
        public void TestBindDefaultExpandAll() {
            _wrapper.SetContextAttribute( AngularConst.BindDefaultExpandAll, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzDefaultExpandAll]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试默认展开节点的键集合
        /// </summary>
        [Fact]
        public void TestExpandedKeys() {
            _wrapper.SetContextAttribute( UiConst.ExpandedKeys, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzExpandedKeys]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示函数
        /// </summary>
        [Fact]
        public void TestDisplayWith() {
            _wrapper.SetContextAttribute( UiConst.DisplayWith, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzDisplayWith]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大标签数量
        /// </summary>
        [Fact]
        public void TestMaxTagCount() {
            _wrapper.SetContextAttribute( UiConst.MaxTagCount, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select nzMaxTagCount=\"1\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大标签数量
        /// </summary>
        [Fact]
        public void TestBindMaxTagCount() {
            _wrapper.SetContextAttribute( AngularConst.BindMaxTagCount, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzMaxTagCount]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大标签占位符
        /// </summary>
        [Fact]
        public void TestMaxTagPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.MaxTagPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzMaxTagPlaceholder]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义模板
        /// </summary>
        [Fact]
        public void TestTreeTemplate() {
            _wrapper.SetContextAttribute( UiConst.TreeTemplate, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzTreeTemplate]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟高度
        /// </summary>
        [Fact]
        public void TestVirtualHeight() {
            _wrapper.SetContextAttribute( UiConst.VirtualHeight, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select nzVirtualHeight=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟高度
        /// </summary>
        [Fact]
        public void TestBindVirtualHeight() {
            _wrapper.SetContextAttribute( AngularConst.BindVirtualHeight, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzVirtualHeight]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动列高
        /// </summary>
        [Fact]
        public void TestVirtualItemSize() {
            _wrapper.SetContextAttribute( UiConst.VirtualItemSize, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select nzVirtualItemSize=\"1\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动列高
        /// </summary>
        [Fact]
        public void TestBindVirtualItemSize() {
            _wrapper.SetContextAttribute( AngularConst.BindVirtualItemSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzVirtualItemSize]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动缓冲区最大高度
        /// </summary>
        [Fact]
        public void TestVirtualMaxBufferPx() {
            _wrapper.SetContextAttribute( UiConst.VirtualMaxBufferPx, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select nzVirtualMaxBufferPx=\"1\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动缓冲区最大高度
        /// </summary>
        [Fact]
        public void TestBindVirtualMaxBufferPx() {
            _wrapper.SetContextAttribute( AngularConst.BindVirtualMaxBufferPx, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzVirtualMaxBufferPx]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动缓冲区最小高度
        /// </summary>
        [Fact]
        public void TestVirtualMinBufferPx() {
            _wrapper.SetContextAttribute( UiConst.VirtualMinBufferPx, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select nzVirtualMinBufferPx=\"1\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动缓冲区最小高度
        /// </summary>
        [Fact]
        public void TestBindVirtualMinBufferPx() {
            _wrapper.SetContextAttribute( AngularConst.BindVirtualMinBufferPx, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select [nzVirtualMinBufferPx]=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度 - 像素
        /// </summary>
        [Fact]
        public void TestWidth_1() {
            _wrapper.SetContextAttribute( UiConst.Width, "120" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select style=\"width:120px\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度 - 百分比
        /// </summary>
        [Fact]
        public void TestWidth_2() {
            _wrapper.SetContextAttribute( UiConst.Width, "100%" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select style=\"width:100%\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度 - 添加到已存在的style
        /// </summary>
        [Fact]
        public void TestWidth_3() {
            _wrapper.SetContextAttribute( UiConst.Style, "height:100px" );
            _wrapper.SetContextAttribute( UiConst.Width, "100%" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select style=\"height:100px;width:100%\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select>a</nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select (ngModelChange)=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展开收缩节点事件
        /// </summary>
        [Fact]
        public void TestOnOpenChange() {
            _wrapper.SetContextAttribute( UiConst.OnExpandChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select (nzExpandChange)=\"a\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<nz-tree-select *nzSpaceItem=\"\"></nz-tree-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}