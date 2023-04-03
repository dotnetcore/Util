using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格测试
    /// </summary>
    public partial class TableTagHelperTest {
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
        public TableTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TableTagHelper().ToWrapper();
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
            result.Append( "<nz-table></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标识
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table #a=\"\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数据
        /// </summary>
        [Fact]
        public void TestData() {
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzData]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否前端分页
        /// </summary>
        [Fact]
        public void TestFrontPagination() {
            _wrapper.SetContextAttribute( UiConst.FrontPagination, true );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzFrontPagination]=\"true\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否前端分页
        /// </summary>
        [Fact]
        public void TestBindFrontPagination() {
            _wrapper.SetContextAttribute( AngularConst.BindFrontPagination, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzFrontPagination]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数据总行数
        /// </summary>
        [Fact]
        public void TestTotal() {
            _wrapper.SetContextAttribute( UiConst.Total, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzTotal]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试当前页
        /// </summary>
        [Fact]
        public void TestPageIndex() {
            _wrapper.SetContextAttribute( UiConst.PageIndex, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-table nzPageIndex=\"1\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试当前页
        /// </summary>
        [Fact]
        public void TestBindPageIndex() {
            _wrapper.SetContextAttribute( AngularConst.BindPageIndex, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzPageIndex]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试当前页
        /// </summary>
        [Fact]
        public void TestBindonPageIndex() {
            _wrapper.SetContextAttribute( AngularConst.BindonPageIndex, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [(nzPageIndex)]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试每页显示行数
        /// </summary>
        [Fact]
        public void TestPageSize() {
            _wrapper.SetContextAttribute( UiConst.PageSize, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-table nzPageSize=\"1\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试每页显示行数
        /// </summary>
        [Fact]
        public void TestBindPageSize() {
            _wrapper.SetContextAttribute( AngularConst.BindPageSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzPageSize]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试每页显示行数
        /// </summary>
        [Fact]
        public void TestBindonPageSize() {
            _wrapper.SetContextAttribute( AngularConst.BindonPageSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [(nzPageSize)]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示分页
        /// </summary>
        [Fact]
        public void TestShowPagination() {
            _wrapper.SetContextAttribute( UiConst.ShowPagination, true );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzShowPagination]=\"true\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示分页
        /// </summary>
        [Fact]
        public void TestBindShowPagination() {
            _wrapper.SetContextAttribute( AngularConst.BindShowPagination, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzShowPagination]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试分页位置
        /// </summary>
        [Fact]
        public void TestPaginationPosition() {
            _wrapper.SetContextAttribute( UiConst.PaginationPosition, TablePaginationPosition.Bottom );
            var result = new StringBuilder();
            result.Append( "<nz-table nzPaginationPosition=\"bottom\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试分页位置
        /// </summary>
        [Fact]
        public void TestBindPaginationPosition() {
            _wrapper.SetContextAttribute( AngularConst.BindPaginationPosition, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzPaginationPosition]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试分页类型
        /// </summary>
        [Fact]
        public void TestPaginationType() {
            _wrapper.SetContextAttribute( UiConst.PaginationType, TablePaginationSize.Small );
            var result = new StringBuilder();
            result.Append( "<nz-table nzPaginationType=\"small\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试分页类型
        /// </summary>
        [Fact]
        public void TestBindPaginationType() {
            _wrapper.SetContextAttribute( AngularConst.BindPaginationType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzPaginationType]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示边框
        /// </summary>
        [Fact]
        public void TestBordered() {
            _wrapper.SetContextAttribute( UiConst.Bordered, true );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzBordered]=\"true\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示边框
        /// </summary>
        [Fact]
        public void TestBindBordered() {
            _wrapper.SetContextAttribute( AngularConst.BindBordered, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzBordered]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示外边框
        /// </summary>
        [Fact]
        public void TestOuterBordered() {
            _wrapper.SetContextAttribute( UiConst.OuterBordered, true );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzOuterBordered]=\"true\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示外边框
        /// </summary>
        [Fact]
        public void TestBindOuterBordered() {
            _wrapper.SetContextAttribute( AngularConst.BindOuterBordered, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzOuterBordered]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列宽度配置
        /// </summary>
        [Fact]
        public void TestWidthConfig() {
            _wrapper.SetContextAttribute( UiConst.WidthConfig, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzWidthConfig]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表格大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, TableSize.Small );
            var result = new StringBuilder();
            result.Append( "<nz-table nzSize=\"small\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表格大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzSize]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否加载状态
        /// </summary>
        [Fact]
        public void TestLoading() {
            _wrapper.SetContextAttribute( UiConst.Loading, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzLoading]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载指示符
        /// </summary>
        [Fact]
        public void TestLoadingIndicator() {
            _wrapper.SetContextAttribute( UiConst.LoadingIndicator, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzLoadingIndicator]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试延迟显示加载时间
        /// </summary>
        [Fact]
        public void TestLoadingDelay() {
            _wrapper.SetContextAttribute( UiConst.LoadingDelay, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-table nzLoadingDelay=\"1\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试延迟显示加载时间
        /// </summary>
        [Fact]
        public void TestBindLoadingDelay() {
            _wrapper.SetContextAttribute( AngularConst.BindLoadingDelay, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzLoadingDelay]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试滚动
        /// </summary>
        [Fact]
        public void TestScroll() {
            _wrapper.SetContextAttribute( UiConst.Scroll, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzScroll]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试滚动高度
        /// </summary>
        [Fact]
        public void TestScrollHeight() {
            _wrapper.SetContextAttribute( UiConst.ScrollHeight, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzScroll]=\"{'y':'a'}\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试滚动宽度
        /// </summary>
        [Fact]
        public void TestScrollWidth() {
            _wrapper.SetContextAttribute( UiConst.ScrollWidth, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzScroll]=\"{'x':'a'}\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table nzTitle=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzTitle]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试底部
        /// </summary>
        [Fact]
        public void TestFooter() {
            _wrapper.SetContextAttribute( UiConst.Footer, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table nzFooter=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试底部
        /// </summary>
        [Fact]
        public void TestBindFooter() {
            _wrapper.SetContextAttribute( AngularConst.BindFooter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzFooter]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试无数据显示内容
        /// </summary>
        [Fact]
        public void TestNoResult() {
            _wrapper.SetContextAttribute( UiConst.NoResult, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table nzNoResult=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试无数据显示内容
        /// </summary>
        [Fact]
        public void TestBindNoResult() {
            _wrapper.SetContextAttribute( AngularConst.BindNoResult, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzNoResult]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试每页行数选择列表
        /// </summary>
        [Fact]
        public void TestPageSizeOptions() {
            _wrapper.SetContextAttribute( UiConst.PageSizeOptions, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzPageSizeOptions]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示快速跳转
        /// </summary>
        [Fact]
        public void TestShowQuickJumper() {
            _wrapper.SetContextAttribute( UiConst.ShowQuickJumper, true );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzShowQuickJumper]=\"true\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示快速跳转
        /// </summary>
        [Fact]
        public void TestBindShowQuickJumper() {
            _wrapper.SetContextAttribute( AngularConst.BindShowQuickJumper, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzShowQuickJumper]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示改变分页大小按钮
        /// </summary>
        [Fact]
        public void TestShowSizeChanger() {
            _wrapper.SetContextAttribute( UiConst.ShowSizeChanger, true );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzShowSizeChanger]=\"true\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示改变分页大小按钮
        /// </summary>
        [Fact]
        public void TestBindShowSizeChanger() {
            _wrapper.SetContextAttribute( AngularConst.BindShowSizeChanger, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzShowSizeChanger]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示总行数和当前数据范围的模板
        /// </summary>
        [Fact]
        public void TestShowTotal() {
            _wrapper.SetContextAttribute( UiConst.ShowTotal, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzShowTotal]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义页码结构
        /// </summary>
        [Fact]
        public void TestItemRender() {
            _wrapper.SetContextAttribute( UiConst.ItemRender, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzItemRender]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试只有一页时是否隐藏分页器
        /// </summary>
        [Fact]
        public void TestHideOnSinglePage() {
            _wrapper.SetContextAttribute( UiConst.HideOnSinglePage, true );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzHideOnSinglePage]=\"true\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试只有一页时是否隐藏分页器
        /// </summary>
        [Fact]
        public void TestBindHideOnSinglePage() {
            _wrapper.SetContextAttribute( AngularConst.BindHideOnSinglePage, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzHideOnSinglePage]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示简单分页
        /// </summary>
        [Fact]
        public void TestSimple() {
            _wrapper.SetContextAttribute( UiConst.Simple, true );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzSimple]=\"true\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示简单分页
        /// </summary>
        [Fact]
        public void TestBindSimple() {
            _wrapper.SetContextAttribute( AngularConst.BindSimple, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzSimple]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示简单分页
        /// </summary>
        [Fact]
        public void TestTemplateMode() {
            _wrapper.SetContextAttribute( UiConst.TemplateMode, true );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzTemplateMode]=\"true\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示简单分页
        /// </summary>
        [Fact]
        public void TestBindTemplateMode() {
            _wrapper.SetContextAttribute( AngularConst.BindTemplateMode, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzTemplateMode]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动列高
        /// </summary>
        [Fact]
        public void TestVirtualItemSize() {
            _wrapper.SetContextAttribute( UiConst.VirtualItemSize, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-table nzVirtualItemSize=\"1\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动列高
        /// </summary>
        [Fact]
        public void TestBindVirtualItemSize() {
            _wrapper.SetContextAttribute( AngularConst.BindVirtualItemSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzVirtualItemSize]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动缓冲区最大高度
        /// </summary>
        [Fact]
        public void TestVirtualMaxBufferPx() {
            _wrapper.SetContextAttribute( UiConst.VirtualMaxBufferPx, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-table nzVirtualMaxBufferPx=\"1\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动缓冲区最大高度
        /// </summary>
        [Fact]
        public void TestBindVirtualMaxBufferPx() {
            _wrapper.SetContextAttribute( AngularConst.BindVirtualMaxBufferPx, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzVirtualMaxBufferPx]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动缓冲区最小高度
        /// </summary>
        [Fact]
        public void TestVirtualMinBufferPx() {
            _wrapper.SetContextAttribute( UiConst.VirtualMinBufferPx, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-table nzVirtualMinBufferPx=\"1\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动缓冲区最小高度
        /// </summary>
        [Fact]
        public void TestBindVirtualMinBufferPx() {
            _wrapper.SetContextAttribute( AngularConst.BindVirtualMinBufferPx, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzVirtualMinBufferPx]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动跟踪函数
        /// </summary>
        [Fact]
        public void TestVirtualForTrackBy() {
            _wrapper.SetContextAttribute( UiConst.VirtualForTrackBy, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzVirtualForTrackBy]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表格布局
        /// </summary>
        [Fact]
        public void TestLayout() {
            _wrapper.SetContextAttribute( UiConst.Layout, TableLayout.Fixed );
            var result = new StringBuilder();
            result.Append( "<nz-table nzTableLayout=\"fixed\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表格布局
        /// </summary>
        [Fact]
        public void TestBindLayout() {
            _wrapper.SetContextAttribute( AngularConst.BindLayout, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [nzTableLayout]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table>a</nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试页码变化事件
        /// </summary>
        [Fact]
        public void TestOnPageIndexChange() {
            _wrapper.SetContextAttribute( UiConst.OnPageIndexChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table (nzPageIndexChange)=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试每页行数变化事件
        /// </summary>
        [Fact]
        public void TestOnPageSizeChange() {
            _wrapper.SetContextAttribute( UiConst.OnPageSizeChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table (nzPageSizeChange)=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试当前页数据变化事件
        /// </summary>
        [Fact]
        public void TestOnCurrentPageDataChange() {
            _wrapper.SetContextAttribute( UiConst.OnCurrentPageDataChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table (nzCurrentPageDataChange)=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试查询参数变化事件
        /// </summary>
        [Fact]
        public void TestOnQueryParams() {
            _wrapper.SetContextAttribute( UiConst.OnQueryParams, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table (nzQueryParams)=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}