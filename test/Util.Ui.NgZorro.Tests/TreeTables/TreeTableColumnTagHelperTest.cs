using System.Text;
using Util.Helpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.TreeTables {
    /// <summary>
    /// 树形表格单元格测试
    /// </summary>
    public class TreeTableColumnTagHelperTest {

        #region 测试初始化

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
        public TreeTableColumnTagHelperTest( ITestOutputHelper output ) {
            Id.SetId( "id" );
            _output = output;
            _wrapper = new TableColumnTagHelper().ToWrapper<Customer>();
        }

        #endregion

        #region 辅助操作

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 添加启用扩展的表格起始标签
        /// </summary>
        /// <param name="result">结果</param>
        private void AppendExtendTable( StringBuilder result ) {
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        }

        /// <summary>
        /// 添加表格总行数模板标签
        /// </summary>
        /// <param name="result">结果</param>
        private void AppendTotalTemplate( StringBuilder result ) {
            result.Append( "<ng-template #total_id=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( "{{ 'util.tableTotalTemplate'|i18n:{start:range[0],end:range[1],total:total} }}" );
            result.Append( "</ng-template>" );
        }

        #endregion

        #region Checkbox

        /// <summary>
        /// 测试设置复选框
        /// </summary>
        [Fact]
        public void TestCheckbox() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsEnableExtend = true,IsShowCheckbox = true,IsTreeTable = true } );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">" );
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"x_id.toggle(row)\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
            result.Append( "[nzIndeterminate]=\"x_id.isIndeterminate(row)\">" );
            result.Append( "{{row.a}}" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Radio

        /// <summary>
        /// 测试设置单选框
        /// </summary>
        [Fact]
        public void TestRadio_1() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsEnableExtend = true, IsShowRadio = true, IsTreeTable = true } );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">" );
            result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
            result.Append( "{{row.a}}" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置单选框 - 如果已设置复选框,则单选框不生效
        /// </summary>
        [Fact]
        public void TestRadio_2() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsEnableExtend = true, IsShowCheckbox = true, IsShowRadio = true, IsTreeTable = true } );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">" );
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"x_id.toggle(row)\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
            result.Append( "[nzIndeterminate]=\"x_id.isIndeterminate(row)\">" );
            result.Append( "{{row.a}}" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion
    }
}