using System.Text;
using Util.Helpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
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
            result.Append( NgZorroOptionsService.GetOptions().TableTotalTemplate );
            result.Append( "</ng-template>" );
        }

        #endregion

        #region Checkbox

        /// <summary>
        /// 测试设置复选框
        /// </summary>
        [Fact]
        public void TestCheckbox() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsShowCheckbox = true,IsTreeTable = true } );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"x_id.toggle(row)\" " );
            result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
            result.Append( "[nzShowCheckbox]=\"true\">" );
            result.Append( "</td>" );
            result.Append( "<td>{{row.a}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Radio

        /// <summary>
        /// 测试设置单选框
        /// </summary>
        [Fact]
        public void TestRadio_1() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsShowRadio = true } );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td>" );
            result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            result.Append( "<td>{{row.a}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置单选框 - 如果已设置复选框,则单选框不生效
        /// </summary>
        [Fact]
        public void TestRadio_2() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsShowCheckbox = true, IsShowRadio = true } );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"x_id.toggle(row)\" " );
            result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
            result.Append( "[nzShowCheckbox]=\"true\">" );
            result.Append( "</td>" );
            result.Append( "<td>{{row.a}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Bool

        /// <summary>
        /// 测试布尔类型列
        /// </summary>
        [Fact]
        public void TestType_Bool() {
            _wrapper.SetContextAttribute( UiConst.Type, TableColumnType.Bool );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td>{{row.a?'x_id.config.text.yes':'x_id.config.text.no'}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Width

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置标题,内容,宽度
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.SetContextAttribute( UiConst.Width, "100" );
            _wrapper.AppendContent( "b" );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th nzWidth=\"100px\">a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        #endregion
    }
}