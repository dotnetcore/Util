using System.Text;
using Util.Applications.Trees;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Components.TreeTables;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.TreeTables {
    /// <summary>
    /// 树形表格测试
    /// </summary>
    public class TreeTableTagHelperTest {

        #region 测试初始化

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
        public TreeTableTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TreeTableTagHelper().ToWrapper();
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
        /// 添加表格总行数模板标签
        /// </summary>
        /// <param name="result">结果</param>
        private void AppendTotalTemplate( StringBuilder result ) {
            result.Append( "<ng-template #total_id=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( "{{ 'util.tableTotalTemplate'|i18n:{start:range[0],end:range[1],total:total} }}" );
            result.Append( "</ng-template>" );
        }

        #endregion

        #region ExpandAll

        /// <summary>
        /// 测试展开
        /// </summary>
        [Fact]
        public void TestExpandAll() {
            _wrapper.SetContextAttribute( UiConst.ExpandAll, true );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table [isExpandAll]=\"true\">" );
            result.Append( "</nz-table>" );

            //验证
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

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table [isExpandForRootAsync]=\"false\">" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region LoadMode

        /// <summary>
        /// 测试加载模式
        /// </summary>
        [Fact]
        public void TestLoadMode() {
            _wrapper.SetContextAttribute( UiConst.LoadMode, LoadMode.RootAsync );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table loadMode=\"2\">" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载模式 - 同步加载时关闭分页
        /// </summary>
        [Fact]
        public void TestLoadMode_Sync() {
            _wrapper.SetContextAttribute( UiConst.LoadMode, LoadMode.Sync );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table loadMode=\"0\" [nzShowPagination]=\"false\">" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region CheckLeafOnly

        /// <summary>
        /// 测试只能选择叶节点
        /// </summary>
        [Fact]
        public void TestCheckLeafOnly() {
            _wrapper.SetContextAttribute( UiConst.CheckLeafOnly, "true" );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table [isCheckLeafOnly]=\"true\">" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region AutoCreate

        /// <summary>
        /// 测试自动创建嵌套结构 - 仅添加一个列,将自动创建其它嵌套结构
        /// </summary>
        [Fact]
        public void TestAutoCreate_1() {
            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
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
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建嵌套结构 - 设置完整结构,不生成
        /// </summary>
        [Fact]
        public void TestAutoCreate_2() {
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

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.AppendContent( "b" );
            row.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead [hidden]=\"true\">" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Url

        /// <summary>
        /// 测试Api地址 - 添加一个列,自动创建嵌套结构
        /// </summary>
        [Fact]
        public void TestUrl_1() {
            //设置url属性
            _wrapper.SetContextAttribute( UiConst.Url, "a" );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "url=\"a\" x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">b</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
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
        public void TestUrl_2() {
            //设置url属性
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
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "url=\"a\" x-tree-table-extend=\"\" " );
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
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region LoadUrl

        /// <summary>
        /// 测试加载地址
        /// </summary>
        [Fact]
        public void TestLoadUrl() {
            //设置LoadUrl属性
            _wrapper.SetContextAttribute( UiConst.LoadUrl, "a" );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "loadUrl=\"a\" x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">b</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载地址
        /// </summary>
        [Fact]
        public void TestBindLoadUrl() {
            //设置LoadUrl属性
            _wrapper.SetContextAttribute( AngularConst.BindLoadUrl, "a" );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [loadUrl]=\"a\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">b</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region QueryUrl

        /// <summary>
        /// 测试查询地址
        /// </summary>
        [Fact]
        public void TestQueryUrl() {
            //设置QueryUrl属性
            _wrapper.SetContextAttribute( UiConst.QueryUrl, "a" );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "queryUrl=\"a\" x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">b</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试查询地址
        /// </summary>
        [Fact]
        public void TestBindQueryUrl() {
            //设置QueryUrl属性
            _wrapper.SetContextAttribute( AngularConst.BindQueryUrl, "a" );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\" [queryUrl]=\"a\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">b</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region LoadChildrenUrl

        /// <summary>
        /// 测试加载子节点地址
        /// </summary>
        [Fact]
        public void TestLoadChildrenUrl() {
            //设置LoadChildrenUrl属性
            _wrapper.SetContextAttribute( UiConst.LoadChildrenUrl, "a" );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "loadChildrenUrl=\"a\" x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">b</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载子节点地址
        /// </summary>
        [Fact]
        public void TestBindLoadChildrenUrl() {
            //设置LoadChildrenUrl属性
            _wrapper.SetContextAttribute( AngularConst.BindLoadChildrenUrl, "a" );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [loadChildrenUrl]=\"a\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">b</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region ShowCheckbox

        /// <summary>
        /// 测试设置复选框 - 添加一个列
        /// </summary>
        [Fact]
        public void TestShowCheckbox_1() {
            _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>" );
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
            result.Append( "a" );
            result.Append( "</label>" );
            result.Append( "</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
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
            result.Append( "b" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置复选框 - 手工创建完整结构
        /// </summary>
        [Fact]
        public void TestShowCheckbox_2() {
            _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );

            //创建表头
            var head = new TableHeadTagHelper().ToWrapper();
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

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.AppendContent( "b" );
            row.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>" );
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
            result.Append( "a" );
            result.Append( "</label>" );
            result.Append( "</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
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
            result.Append( "b" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置复选框 - 添加2个列
        /// </summary>
        [Fact]
        public void TestShowCheckbox_3() {
            _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );

            //创建列1
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //创建列2
            var column2 = new TableColumnTagHelper().ToWrapper();
            column2.SetContextAttribute( UiConst.Title, "c" );
            column2.AppendContent( "d" );
            _wrapper.AppendContent( column2 );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>" );
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
            result.Append( "a" );
            result.Append( "</label>" );
            result.Append( "</th>" );
            result.Append( "<th>" );
            result.Append( "c" );
            result.Append( "</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
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
            result.Append( "b" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            result.Append( "<td>" );
            result.Append( "d" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置复选框 - 手工创建完整结构,添加2个列,设置仅选择叶节点属性,单元格内容不应受影响
        /// </summary>
        [Fact]
        public void TestShowCheckbox_4() {
            _wrapper.SetContextAttribute( UiConst.ShowCheckbox, true );
            _wrapper.SetContextAttribute( UiConst.CheckLeafOnly, true );

            //创建表头
            var head = new TableHeadTagHelper().ToWrapper();
            _wrapper.AppendContent( head );

            //创建表头行
            var headRow = new TableRowTagHelper().ToWrapper();
            head.AppendContent( headRow );

            //创建表头单元格1
            var th = new TableHeadColumnTagHelper().ToWrapper();
            th.AppendContent( "a" );
            headRow.AppendContent( th );

            //创建表头单元格2
            var th2 = new TableHeadColumnTagHelper().ToWrapper();
            th2.AppendContent( "a2" );
            headRow.AppendContent( th2 );

            //创建表格主体
            var body = new TableBodyTagHelper().ToWrapper();
            _wrapper.AppendContent( body );

            //创建表格主体行
            var row = new TableRowTagHelper().ToWrapper();
            body.AppendContent( row );

            //创建列1
            var column = new TableColumnTagHelper().ToWrapper();
            column.AppendContent( "b" );
            row.AppendContent( column );

            //创建列2
            var column2 = new TableColumnTagHelper().ToWrapper();
            column2.AppendContent( "b2" );
            row.AppendContent( column2 );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [isCheckLeafOnly]=\"true\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>" );
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
            result.Append( "a" );
            result.Append( "</label>" );
            result.Append( "</th>" );
            result.Append( "<th>" );
            result.Append( "a2" );
            result.Append( "</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
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
            result.Append( "b" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            result.Append( "<td>" );
            result.Append( "b2" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region ShowRadio

        /// <summary>
        /// 测试设置单选框 - 添加一个列
        /// </summary>
        [Fact]
        public void TestShowRadio_1() {
            _wrapper.SetContextAttribute( UiConst.ShowRadio, true );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">" );
            result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
            result.Append( "b" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置单选框 - 手工创建完整结构
        /// </summary>
        [Fact]
        public void TestShowRadio_2() {
            _wrapper.SetContextAttribute( UiConst.ShowRadio, true );

            //创建表头
            var head = new TableHeadTagHelper().ToWrapper();
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

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.AppendContent( "b" );
            row.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">" );
            result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
            result.Append( "b" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置单选框 - 添加2个列
        /// </summary>
        [Fact]
        public void TestShowRadio_3() {
            _wrapper.SetContextAttribute( UiConst.ShowRadio, true );

            //创建列1
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //创建列2
            var column2 = new TableColumnTagHelper().ToWrapper();
            column2.SetContextAttribute( UiConst.Title, "c" );
            column2.AppendContent( "d" );
            _wrapper.AppendContent( column2 );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "<th>c</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">" );
            result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
            result.Append( "b" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            result.Append( "<td>d</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置单选框 - 手工创建完整结构,添加2个列
        /// </summary>
        [Fact]
        public void TestShowRadio_4() {
            _wrapper.SetContextAttribute( UiConst.ShowRadio, true );

            //创建表头
            var head = new TableHeadTagHelper().ToWrapper();
            _wrapper.AppendContent( head );

            //创建表头行
            var headRow = new TableRowTagHelper().ToWrapper();
            head.AppendContent( headRow );

            //创建表头单元格1
            var th = new TableHeadColumnTagHelper().ToWrapper();
            th.AppendContent( "a" );
            headRow.AppendContent( th );

            //创建表头单元格2
            var th2 = new TableHeadColumnTagHelper().ToWrapper();
            th2.AppendContent( "a2" );
            headRow.AppendContent( th2 );

            //创建表格主体
            var body = new TableBodyTagHelper().ToWrapper();
            _wrapper.AppendContent( body );

            //创建表格主体行
            var row = new TableRowTagHelper().ToWrapper();
            body.AppendContent( row );

            //创建列1
            var column = new TableColumnTagHelper().ToWrapper();
            column.AppendContent( "b" );
            row.AppendContent( column );

            //创建列2
            var column2 = new TableColumnTagHelper().ToWrapper();
            column2.AppendContent( "b2" );
            row.AppendContent( column2 );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "<th>a2</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">" );
            result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
            result.Append( "b" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            result.Append( "<td>b2</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置单选框 - 仅允许选中叶节点
        /// </summary>
        [Fact]
        public void TestShowRadio_5() {
            _wrapper.SetContextAttribute( UiConst.ShowRadio, true );
            _wrapper.SetContextAttribute( UiConst.CheckLeafOnly, true );

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.Title, "a" );
            column.AppendContent( "b" );
            _wrapper.AppendContent( column );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #x_id=\"xTreeTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-tree-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" [isCheckLeafOnly]=\"true\" [nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<tr *ngIf=\"x_id.isShow(row)\">" );
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"x_id.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"x_id.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*x_id.config.table.indentUnitWidth\" " );
            result.Append( "[nzShowExpand]=\"!x_id.isLeaf(row)\"" );
            result.Append( ">" );
            result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" " );
            result.Append( "*ngIf=\"x_id.isShowRadio(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
            result.Append( "b" );
            result.Append( "</label>" );
            result.Append( "<ng-container *ngIf=\"!x_id.isShowRadio(row)\">" );
            result.Append( "b" );
            result.Append( "</ng-container>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
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
            result.Append( "<nz-table [onLoadChildrenBefore]=\"a\"></nz-table>" );
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
            result.Append( "<nz-table (onLoadChildren)=\"a\"></nz-table>" );
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
            result.Append( "<nz-table (onExpand)=\"a\"></nz-table>" );
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
            result.Append( "<nz-table (onCollapse)=\"a\"></nz-table>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion
    }
}