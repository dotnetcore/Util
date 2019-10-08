using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tables.Configs;
using Util.Ui.Zorro.TreeTables;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.TreeTables {
    /// <summary>
    /// 树形表格测试
    /// </summary>
    public class TreeTableTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 树形表格
        /// </summary>
        private readonly TreeTableTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TreeTableTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TreeTableTagHelper();
            Id.SetId( "id" );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content );
        }

        /// <summary>
        /// 添加表格Html
        /// </summary>
        private void AppendTableHtml( String result ) {
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
        }

        /// <summary>
        /// 添加表格BodyHtml
        /// </summary>
        private void AppendTableBodyHtml( String result ) {
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of m_id.data\">" );
            result.Append( "<tr *ngIf=\"m_id_wrapper.isShow(row)\">" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "<ng-template #template_m_id=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( TableConfig.TotalTemplate );
            result.Append( "</ng-template>" );
            result.Append( "</nz-tree-table-wrapper>" );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();  
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #a_wrapper=\"\">" );
            result.Append( "<nz-table #a=\"\" (nzPageIndexChange)=\"a_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"a_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"a_wrapper.queryParam.page\" [(nzPageSize)]=\"a_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"a_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"a_wrapper.loading\" [nzShowPagination]=\"a_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_a\" [nzTotal]=\"a_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<ng-container *ngFor=\"let row of a.data\">" );
            result.Append( "<tr *ngIf=\"a_wrapper.isShow(row)\">" );
            result.Append( "</tr>" );
            result.Append( "</ng-container>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "<ng-template #template_a=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( TableConfig.TotalTemplate );
            result.Append( "</ng-template>" );
            result.Append( "</nz-tree-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试查询参数
        /// </summary>
        [Fact]
        public void TestQueryParam() {
            var attributes = new TagHelperAttributeList { { UiConst.QueryParam, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" [(queryParam)]=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试基地址
        /// </summary>
        [Fact]
        public void TestBaseUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.BaseUrl, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" baseUrl=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试基地址
        /// </summary>
        [Fact]
        public void TestBindBaseUrl() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindBaseUrl, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" [baseUrl]=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试地址
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" url=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试地址
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindUrl, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" [url]=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试删除地址
        /// </summary>
        [Fact]
        public void TestDeleteUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.DeleteUrl, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" deleteUrl=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试删除地址
        /// </summary>
        [Fact]
        public void TestBindDeleteUrl() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindDeleteUrl, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" [deleteUrl]=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示边框
        /// </summary>
        [Fact]
        public void TestShowBorder() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowBorder, true } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "nzBordered=\"true\" [(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml(result);
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试全部展开
        /// </summary>
        [Fact]
        public void TestExpandAll() {
            var attributes = new TagHelperAttributeList { { UiConst.ExpandAll, false } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" [expandAll]=\"false\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示复选框
        /// </summary>
        [Fact]
        public void TestShowCheckbox() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowCheckbox, false } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" [showCheckbox]=\"false\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试多选
        /// </summary>
        [Fact]
        public void TestMultiple() {
            var attributes = new TagHelperAttributeList { { UiConst.Multiple, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" [multiple]=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试选择叶节点 
        /// </summary>
        [Fact]
        public void TestCheckLeafOnly() {
            var attributes = new TagHelperAttributeList { { UiConst.CheckLeafOnly, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" [checkLeafOnly]=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试自动加载
        /// </summary>
        [Fact]
        public void TestAutoLoad() {
            var attributes = new TagHelperAttributeList { { UiConst.AutoLoad, false } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" [autoLoad]=\"false\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试排序
        /// </summary>
        [Fact]
        public void TestSort() {
            var attributes = new TagHelperAttributeList { { UiConst.Sort, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" sortKey=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否前端分页
        /// </summary>
        [Fact]
        public void TestFrontPage() {
            var attributes = new TagHelperAttributeList { { UiConst.FrontPage, true } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"true\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否显示分页大小下拉列表
        /// </summary>
        [Fact]
        public void TestShowSizeChanger() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowSizeChanger, false } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"false\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试分页大小变更事件
        /// </summary>
        [Fact]
        public void TestOnPageSizeChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnPageSizeChange, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"a\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试页索引变更事件
        /// </summary>
        [Fact]
        public void TestOnPageIndexChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnPageIndexChange, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"a\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试展开事件
        /// </summary>
        [Fact]
        public void TestOnExpand() {
            var attributes = new TagHelperAttributeList { { UiConst.OnExpand, "a" } };
            var result = new String();
            result.Append( "<nz-tree-table-wrapper #m_id_wrapper=\"\" (onExpand)=\"a\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}