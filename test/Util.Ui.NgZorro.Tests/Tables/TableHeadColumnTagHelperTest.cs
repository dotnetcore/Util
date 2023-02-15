using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表头单元格测试
    /// </summary>
    public partial class TableHeadColumnTagHelperTest {
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
        public TableHeadColumnTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TableHeadColumnTagHelper().ToWrapper<Customer>();
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
            result.Append( "<th></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示复选框
        /// </summary>
        [Fact]
        public void TestShowCheckbox() {
            _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
            var result = new StringBuilder();
            result.Append( "<th [nzShowCheckbox]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示复选框
        /// </summary>
        [Fact]
        public void TestBindShowCheckbox() {
            _wrapper.SetContextAttribute( AngularConst.BindShowCheckbox, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzShowCheckbox]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用复选框
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<th [nzDisabled]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用复选框
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzDisabled]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复选框是否中间状态
        /// </summary>
        [Fact]
        public void TestIndeterminate() {
            _wrapper.SetContextAttribute( UiConst.Indeterminate, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzIndeterminate]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否选中复选框
        /// </summary>
        [Fact]
        public void TestChecked() {
            _wrapper.SetContextAttribute( UiConst.Checked, true );
            var result = new StringBuilder();
            result.Append( "<th [nzChecked]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否选中复选框
        /// </summary>
        [Fact]
        public void TestBindChecked() {
            _wrapper.SetContextAttribute( AngularConst.BindChecked, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzChecked]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否选中复选框
        /// </summary>
        [Fact]
        public void TestBindonChecked() {
            _wrapper.SetContextAttribute( AngularConst.BindonChecked, "a" );
            var result = new StringBuilder();
            result.Append( "<th [(nzChecked)]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否选中复选框
        /// </summary>
        [Fact]
        public void TestShowRowSelection() {
            _wrapper.SetContextAttribute( UiConst.ShowRowSelection, true );
            var result = new StringBuilder();
            result.Append( "<th [nzShowRowSelection]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否选中复选框
        /// </summary>
        [Fact]
        public void TestBindShowRowSelection() {
            _wrapper.SetContextAttribute( AngularConst.BindShowRowSelection, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzShowRowSelection]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉选择的内容
        /// </summary>
        [Fact]
        public void TestSelections() {
            _wrapper.SetContextAttribute( UiConst.Selections, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzSelections]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示排序
        /// </summary>
        [Fact]
        public void TestShowSort() {
            _wrapper.SetContextAttribute( UiConst.ShowSort, true );
            var result = new StringBuilder();
            result.Append( "<th [nzShowSort]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示排序
        /// </summary>
        [Fact]
        public void TestBindShowSort() {
            _wrapper.SetContextAttribute( AngularConst.BindShowSort, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzShowSort]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排序函数
        /// </summary>
        [Fact]
        public void TestSortFn() {
            _wrapper.SetContextAttribute( UiConst.SortFn, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzSortFn]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试支持的排序方式
        /// </summary>
        [Fact]
        public void TestSortDirections() {
            _wrapper.SetContextAttribute( UiConst.SortDirections, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzSortDirections]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排序方向
        /// </summary>
        [Fact]
        public void TestSortOrder() {
            _wrapper.SetContextAttribute( UiConst.SortOrder, "a" );
            var result = new StringBuilder();
            result.Append( "<th nzSortOrder=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排序方向
        /// </summary>
        [Fact]
        public void TestBindSortOrder() {
            _wrapper.SetContextAttribute( AngularConst.BindSortOrder, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzSortOrder]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排序方向
        /// </summary>
        [Fact]
        public void TestBindonSortOrder() {
            _wrapper.SetContextAttribute( AngularConst.BindonSortOrder, "a" );
            var result = new StringBuilder();
            result.Append( "<th [(nzSortOrder)]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示过滤
        /// </summary>
        [Fact]
        public void TestShowFilter() {
            _wrapper.SetContextAttribute( UiConst.ShowFilter, true );
            var result = new StringBuilder();
            result.Append( "<th [nzShowFilter]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示过滤
        /// </summary>
        [Fact]
        public void TestBindShowFilter() {
            _wrapper.SetContextAttribute( AngularConst.BindShowFilter, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzShowFilter]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试过滤函数
        /// </summary>
        [Fact]
        public void TestFilterFn() {
            _wrapper.SetContextAttribute( UiConst.FilterFn, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzFilterFn]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试过滤器
        /// </summary>
        [Fact]
        public void TestFilters() {
            _wrapper.SetContextAttribute( UiConst.Filters, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzFilters]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否多选过滤器
        /// </summary>
        [Fact]
        public void TestFilterMultiple() {
            _wrapper.SetContextAttribute( UiConst.FilterMultiple, true );
            var result = new StringBuilder();
            result.Append( "<th [nzFilterMultiple]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否多选过滤器
        /// </summary>
        [Fact]
        public void TestBindFilterMultiple() {
            _wrapper.SetContextAttribute( UiConst.FilterMultiple, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzFilterMultiple]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度 - 像素值
        /// </summary>
        [Fact]
        public void TestWidth_1() {
            _wrapper.SetContextAttribute( UiConst.Width,"1" );
            var result = new StringBuilder();
            result.Append( "<th nzWidth=\"1px\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度 - 百分比
        /// </summary>
        [Fact]
        public void TestWidth_2() {
            _wrapper.SetContextAttribute( UiConst.Width, "10%" );
            var result = new StringBuilder();
            result.Append( "<th nzWidth=\"10%\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestBindWidth() {
            _wrapper.SetContextAttribute( AngularConst.BindWidth, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzWidth]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试左侧距离
        /// </summary>
        [Fact]
        public void TestLeft() {
            _wrapper.SetContextAttribute( UiConst.Left, true );
            var result = new StringBuilder();
            result.Append( "<th [nzLeft]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试左侧距离
        /// </summary>
        [Fact]
        public void TestBindLeft() {
            _wrapper.SetContextAttribute( AngularConst.BindLeft, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzLeft]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右侧距离
        /// </summary>
        [Fact]
        public void TestRight() {
            _wrapper.SetContextAttribute( UiConst.Right, true );
            var result = new StringBuilder();
            result.Append( "<th [nzRight]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右侧距离
        /// </summary>
        [Fact]
        public void TestBindRight() {
            _wrapper.SetContextAttribute( AngularConst.BindRight, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzRight]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试对齐方式
        /// </summary>
        [Fact]
        public void TestAlign() {
            _wrapper.SetContextAttribute( UiConst.Align, TableHeadColumnAlign.Left );
            var result = new StringBuilder();
            result.Append( "<th nzAlign=\"left\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试对齐方式
        /// </summary>
        [Fact]
        public void TestBindAlign() {
            _wrapper.SetContextAttribute( AngularConst.BindAlign, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzAlign]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否折行显示
        /// </summary>
        [Fact]
        public void TestBreakWord() {
            _wrapper.SetContextAttribute( UiConst.BreakWord, true );
            var result = new StringBuilder();
            result.Append( "<th [nzBreakWord]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否折行显示
        /// </summary>
        [Fact]
        public void TestBindBreakWord() {
            _wrapper.SetContextAttribute( AngularConst.BindBreakWord, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzBreakWord]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动省略
        /// </summary>
        [Fact]
        public void TestEllipsis() {
            _wrapper.SetContextAttribute( UiConst.Ellipsis, true );
            var result = new StringBuilder();
            result.Append( "<th [nzEllipsis]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动省略
        /// </summary>
        [Fact]
        public void TestBindEllipsis() {
            _wrapper.SetContextAttribute( AngularConst.BindEllipsis, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzEllipsis]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列跨度
        /// </summary>
        [Fact]
        public void TestColspan() {
            _wrapper.SetContextAttribute( UiConst.Colspan, 1 );
            var result = new StringBuilder();
            result.Append( "<th colSpan=\"1\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列跨度
        /// </summary>
        [Fact]
        public void TestBindColspan() {
            _wrapper.SetContextAttribute( AngularConst.BindColspan, "a" );
            var result = new StringBuilder();
            result.Append( "<th [colSpan]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试行跨度
        /// </summary>
        [Fact]
        public void TestRowspan() {
            _wrapper.SetContextAttribute( UiConst.Rowspan, 1 );
            var result = new StringBuilder();
            result.Append( "<th rowSpan=\"1\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试行跨度
        /// </summary>
        [Fact]
        public void TestBindRowspan() {
            _wrapper.SetContextAttribute( AngularConst.BindRowspan, "a" );
            var result = new StringBuilder();
            result.Append( "<th [rowSpan]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列标识
        /// </summary>
        [Fact]
        public void TestColumnKey() {
            _wrapper.SetContextAttribute( UiConst.ColumnKey, "a" );
            var result = new StringBuilder();
            result.Append( "<th nzColumnKey=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列标识
        /// </summary>
        [Fact]
        public void TestBindColumnKey() {
            _wrapper.SetContextAttribute( AngularConst.BindColumnKey, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzColumnKey]=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<th>a</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复选框选中状态变化事件
        /// </summary>
        [Fact]
        public void TestOnCheckedChange() {
            _wrapper.SetContextAttribute( UiConst.OnCheckedChange, "a" );
            var result = new StringBuilder();
            result.Append( "<th (nzCheckedChange)=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排序方向变化事件
        /// </summary>
        [Fact]
        public void TestOnSortOrderChange() {
            _wrapper.SetContextAttribute( UiConst.OnSortOrderChange, "a" );
            var result = new StringBuilder();
            result.Append( "<th (nzSortOrderChange)=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试过滤条件变化事件
        /// </summary>
        [Fact]
        public void TestOnFilterChange() {
            _wrapper.SetContextAttribute( UiConst.OnFilterChange, "a" );
            var result = new StringBuilder();
            result.Append( "<th (nzFilterChange)=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}