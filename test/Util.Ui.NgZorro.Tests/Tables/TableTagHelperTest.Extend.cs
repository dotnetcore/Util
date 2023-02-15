using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格测试 - 指令扩展
    /// </summary>
    public partial class TableTagHelperTest {
        /// <summary>
        /// 测试查询参数
        /// </summary>
        [Fact]
        public void TestQueryParam() {
            _wrapper.SetContextAttribute( UiConst.QueryParam, "b" );
            var result = new StringBuilder();
            result.Append( "<nz-table [(queryParam)]=\"b\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排序条件
        /// </summary>
        [Fact]
        public void TestSort() {
            _wrapper.SetContextAttribute( UiConst.Sort, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table order=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排序条件
        /// </summary>
        [Fact]
        public void TestBindSort() {
            _wrapper.SetContextAttribute( AngularConst.BindSort, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [order]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试复选框选中的标识列表
        /// </summary>
        [Fact]
        public void TestCheckedKeys() {
            _wrapper.SetContextAttribute( UiConst.CheckedKeys, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [checkedKeys]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Api地址
        /// </summary>
        [Fact]
        public void TestUrl_1() {
            _wrapper.SetContextAttribute( UiConst.Url, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "url=\"a\" x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );
            Assert.Equal( result.ToString(), GetResult() );
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

        /// <summary>
        /// 测试Api地址 - 添加一个列,自动创建嵌套结构
        /// </summary>
        [Fact]
        public void TestUrl_2() {
            //设置baseurl属性
            _wrapper.SetContextAttribute( UiConst.Url, "a" );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "url=\"a\" x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Api地址 - 自定义表格主体行的*ngFor 
        /// </summary>
        [Fact]
        public void TestUrl_3() {
            //设置baseurl属性
            _wrapper.SetContextAttribute( UiConst.Url, "a" );

            //创建表头
            var head = new TableHeadTagHelper().ToWrapper();
            head.SetContextAttribute( "hidden", "true" );
            _wrapper.AppendContent( head );

            //创建表头行
            var headRow = new TableRowTagHelper().ToWrapper();
            head.AppendContent( headRow );

            //创建表头单元格
            var th = new TableHeadColumnTagHelper().ToWrapper();
            th.AppendContent( "a" );
            headRow.AppendContent( th );

            //创建表格主体
            var body = new TableBodyTagHelper().ToWrapper();
            _wrapper.AppendContent( body );

            //创建表格主体行
            var row = new TableRowTagHelper().ToWrapper();
            body.AppendContent( row );
            row.SetContextAttribute( AngularConst.NgFor, "a" );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.AppendContent( "b" );
            row.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "url=\"a\" x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead [hidden]=\"true\">" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"a\">" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Api地址
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            _wrapper.SetContextAttribute( AngularConst.BindUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\" [url]=\"a\">" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试删除地址
        /// </summary>
        [Fact]
        public void TestDeleteUrl() {
            _wrapper.SetContextAttribute( UiConst.DeleteUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table deleteUrl=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试删除地址
        /// </summary>
        [Fact]
        public void TestBindDeleteUrl() {
            _wrapper.SetContextAttribute( AngularConst.BindDeleteUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table [deleteUrl]=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动加载
        /// </summary>
        [Fact]
        public void TestAutoLoad() {
            _wrapper.SetContextAttribute( UiConst.AutoLoad, false );
            var result = new StringBuilder();
            result.Append( "<nz-table [autoLoad]=\"false\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试启用扩展
        /// </summary>
        [Fact]
        public void TestEnableExtend() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试启用扩展 - 当启用扩展时,设置数据源会先输入到扩展指令再导出
        /// </summary>
        [Fact]
        public void TestEnableExtend_Data() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
            result.Append( "[dataSource]=\"a\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试启用扩展 - 覆盖是否显示改变分页大小按钮
        /// </summary>
        [Fact]
        public void TestEnableExtend_ShowSizeChanger() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            _wrapper.SetContextAttribute( UiConst.ShowSizeChanger, "false" );
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"false\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试启用扩展 - 覆盖是否显示分页快速跳转
        /// </summary>
        [Fact]
        public void TestEnableExtend_ShowQuickJumper() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            _wrapper.SetContextAttribute( UiConst.ShowQuickJumper, "false" );
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"false\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试启用扩展 - 覆盖总行数
        /// </summary>
        [Fact]
        public void TestEnableExtend_Total() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            _wrapper.SetContextAttribute( UiConst.Total, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"a\">" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数据加载完成事件
        /// </summary>
        [Fact]
        public void TestOnLoad() {
            _wrapper.SetContextAttribute( UiConst.OnLoad, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-table (onLoad)=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试行单击事件
        /// </summary>
        [Fact]
        public void TestOnClickRow() {
            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.SetContextAttribute( UiConst.OnClickRow, "c" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr (click)=\"c\">" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}