using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Tables;
using Util.Ui.Zorro.Tables.Configs;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tables {
    /// <summary>
    /// 表格测试
    /// </summary>
    public class TableTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表格
        /// </summary>
        private readonly TableTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TableTagHelper();
            Id.SetId( "id" );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null,
            TagHelperContent content = null, IDictionary<object, object> items = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content, items );
        }

        /// <summary>
        /// 添加表格Html
        /// </summary>
        private void AppendTableHtml( String result ) {
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" " );
            result.Append( "[nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
            result.Append( "[nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
        }

        /// <summary>
        /// 添加表格BodyHtml
        /// </summary>
        private void AppendTableBodyHtml( String result ) {
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data;index as index\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "<ng-template #template_m_id=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( TableConfig.TotalTemplate );
            result.Append( "</ng-template>" );
            result.Append( "</nz-table-wrapper>" );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
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
            result.Append( "<nz-table-wrapper #a_wrapper=\"\">" );
            result.Append( "<nz-table #a=\"\" (nzPageIndexChange)=\"a_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"a_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"a_wrapper.queryParam.page\" [(nzPageSize)]=\"a_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"a_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"a_wrapper.loading\" [nzShowPagination]=\"a_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_a\" [nzTotal]=\"a_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of a.data;index as index\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "<ng-template #template_a=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( TableConfig.TotalTemplate );
            result.Append( "</ng-template>" );
            result.Append( "</nz-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试数据源
        /// </summary>
        [Fact]
        public void TestData() {
            var attributes = new TagHelperAttributeList { { UiConst.Data, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" [dataSource]=\"a\" [loading]=\"false\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试查询参数
        /// </summary>
        [Fact]
        public void TestQueryParam() {
            var attributes = new TagHelperAttributeList { { UiConst.QueryParam, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" [(queryParam)]=\"a\">" );
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
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" baseUrl=\"a\">" );
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
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" [baseUrl]=\"a\">" );
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
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" url=\"a\">" );
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
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" [url]=\"a\">" );
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
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" deleteUrl=\"a\">" );
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
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" [deleteUrl]=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试保存地址
        /// </summary>
        [Fact]
        public void TestSaveUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.SaveUrl, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" saveUrl=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试保存地址
        /// </summary>
        [Fact]
        public void TestBindSaveUrl() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindSaveUrl, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" [saveUrl]=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试滚动高度
        /// </summary>
        [Fact]
        public void TestScrollHeight() {
            var attributes = new TagHelperAttributeList { { UiConst.ScrollHeight, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" " );
            result.Append( "[nzLoading]=\"m_id_wrapper.loading\" [nzScroll]=\"{'y':'a'}\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
            result.Append( "[nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试滚动高度
        /// </summary>
        [Fact]
        public void TestScrollHeight_Number() {
            var attributes = new TagHelperAttributeList { { UiConst.ScrollHeight, "100" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" " );
            result.Append( "[nzLoading]=\"m_id_wrapper.loading\" [nzScroll]=\"{'y':'100px'}\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
            result.Append( "[nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试滚动宽度
        /// </summary>
        [Fact]
        public void TestScrollWidth() {
            var attributes = new TagHelperAttributeList { { UiConst.ScrollWidth, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" " );
            result.Append( "[nzLoading]=\"m_id_wrapper.loading\" [nzScroll]=\"{'x':'a'}\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
            result.Append( "[nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试滚动宽度
        /// </summary>
        [Fact]
        public void TestScrollWidth_Number() {
            var attributes = new TagHelperAttributeList { { UiConst.ScrollWidth, "100" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" " );
            result.Append( "[nzLoading]=\"m_id_wrapper.loading\" [nzScroll]=\"{'x':'100px'}\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
            result.Append( "[nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示边框
        /// </summary>
        [Fact]
        public void TestShowBorder() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowBorder, true } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "nzBordered=\"true\" [(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" " );
            result.Append( "[nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
            result.Append( "[nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示分页
        /// </summary>
        [Fact]
        public void TestShowPagination() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowPagination, true } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" [showPagination]=\"true\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试分页长度列表
        /// </summary>
        [Fact]
        public void TestPageSizeOptions() {
            var attributes = new TagHelperAttributeList { { UiConst.PageSizeOptions, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" [pageSizeOptions]=\"a\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" " );
            result.Append( "[nzPageSizeOptions]=\"m_id_wrapper.pageSizeOptions\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示跳转
        /// </summary>
        [Fact]
        public void TestShowJumper() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowJumper, false } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"false\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试表格尺寸
        /// </summary>
        [Fact]
        public void TestSize() {
            var attributes = new TagHelperAttributeList { { UiConst.Size, TableSize.Middle } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "nzSize=\"middle\" [(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试多选
        /// </summary>
        [Fact]
        public void TestMultiple() {
            var attributes = new TagHelperAttributeList { { UiConst.Multiple, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" [multiple]=\"a\">" );
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
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" [autoLoad]=\"false\">" );
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
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" sortKey=\"a\">" );
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
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"true\" " );
            result.Append( "[nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
            result.Append( "[nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
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
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" " );
            result.Append( "[nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"false\" " );
            result.Append( "[nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否显示分页总量 - 不显示
        /// </summary>
        [Fact]
        public void TestShowTotal_False() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowTotal, false } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data;index as index\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "</nz-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否显示分页总量 - 模板
        /// </summary>
        [Fact]
        public void TestShowTotal_Template() {
            var attributes = new TagHelperAttributeList { { UiConst.TotalTemplate, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data;index as index\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "<ng-template #template_m_id=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( "a" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试复选框选中的标识列表
        /// </summary>
        [Fact]
        public void TestCheckedKeys() {
            var attributes = new TagHelperAttributeList { { UiConst.CheckedKeys, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" [checkedKeys]=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试选中行背景色
        /// </summary>
        [Fact]
        public void TestSelectedRowBackgroundColor() {
            var attributes = new TagHelperAttributeList { { UiConst.SelectedRowBackgroundColor, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr (click)=\"m_id_wrapper.selectRowOnly(row)\" *ngFor=\"let row of m_id.data;index as index\" [style.background-color]=\"m_id_wrapper.isSelected(row)?a:''\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "<ng-template #template_m_id=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( TableConfig.TotalTemplate );
            result.Append( "</ng-template>" );
            result.Append( "</nz-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试编辑模式
        /// </summary>
        [Fact]
        public void TestEdit() {
            var shareConfig = new TableShareConfig( "m_id" ) { IsEdit = true };
            var items = new Dictionary<object, object> { { typeof( TableShareConfig ), shareConfig } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_edit=\"utilEditTable\" #m_id_wrapper=\"\" x-edit-table=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" " );
            result.Append( "[nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
            result.Append( "[nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr #m_id_row=\"utilEditRow\" (click)=\"m_id_edit.clickEdit(row.id)\" (dblclick)=\"m_id_edit.dblClickEdit(row.id)\" " );
            result.Append( "*ngFor=\"let row of m_id.data;index as index\" [x-edit-row]=\"row\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "<ng-template #template_m_id=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( TableConfig.TotalTemplate );
            result.Append( "</ng-template>" );
            result.Append( "</nz-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( items: items ) );
        }

        /// <summary>
        /// 测试编辑模式-双击启动编辑
        /// </summary>
        [Fact]
        public void TestEdit_DoubleClickStartEdit() {
            var attributes = new TagHelperAttributeList { { UiConst.DoubleClickStartEdit, false } };
            var shareConfig = new TableShareConfig( "m_id" ) { IsEdit = true };
            var items = new Dictionary<object, object> { { typeof( TableShareConfig ), shareConfig } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_edit=\"utilEditTable\" #m_id_wrapper=\"\" x-edit-table=\"\" [dblClickStartEdit]=\"false\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" " );
            result.Append( "[nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
            result.Append( "[nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr #m_id_row=\"utilEditRow\" (click)=\"m_id_edit.clickEdit(row.id)\" (dblclick)=\"m_id_edit.dblClickEdit(row.id)\" " );
            result.Append( "*ngFor=\"let row of m_id.data;index as index\" [x-edit-row]=\"row\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "<ng-template #template_m_id=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( TableConfig.TotalTemplate );
            result.Append( "</ng-template>" );
            result.Append( "</nz-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes,items: items ) );
        }

        /// <summary>
        /// 测试加载后事件
        /// </summary>
        [Fact]
        public void TestOnLoad() {
            var attributes = new TagHelperAttributeList { { UiConst.OnLoad, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\" (onLoad)=\"a\">" );
            AppendTableHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试分页大小变更事件
        /// </summary>
        [Fact]
        public void TestOnPageSizeChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnPageSizeChange, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
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
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"a\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            AppendTableBodyHtml( result );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击行事件
        /// </summary>
        [Fact]
        public void TestOnClickRow() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClickRow, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" [nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" [nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr (click)=\"a\" *ngFor=\"let row of m_id.data;index as index\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "<ng-template #template_m_id=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( TableConfig.TotalTemplate );
            result.Append( "</ng-template>" );
            result.Append( "</nz-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试编辑模式 - 单击行事件
        /// </summary>
        [Fact]
        public void TestEdit_OnClickRow() {
            var shareConfig = new TableShareConfig( "m_id" ) { IsEdit = true };
            var items = new Dictionary<object, object> { { typeof( TableShareConfig ), shareConfig } };
            var attributes = new TagHelperAttributeList { { UiConst.OnClickRow, "a" } };
            var result = new String();
            result.Append( "<nz-table-wrapper #m_id_edit=\"utilEditTable\" #m_id_wrapper=\"\" x-edit-table=\"\">" );
            result.Append( "<nz-table #m_id=\"\" (nzPageIndexChange)=\"m_id_wrapper.pageIndexChange($event)\" (nzPageSizeChange)=\"m_id_wrapper.pageSizeChange($event)\" " );
            result.Append( "[(nzPageIndex)]=\"m_id_wrapper.queryParam.page\" [(nzPageSize)]=\"m_id_wrapper.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"m_id_wrapper.dataSource\" [nzFrontPagination]=\"false\" " );
            result.Append( "[nzLoading]=\"m_id_wrapper.loading\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzShowQuickJumper]=\"true\" [nzShowSizeChanger]=\"true\" " );
            result.Append( "[nzShowTotal]=\"template_m_id\" [nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr #m_id_row=\"utilEditRow\" (click)=\"m_id_edit.clickEdit(row.id);a\" (dblclick)=\"m_id_edit.dblClickEdit(row.id)\" " );
            result.Append( "*ngFor=\"let row of m_id.data;index as index\" [x-edit-row]=\"row\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "<ng-template #template_m_id=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( TableConfig.TotalTemplate );
            result.Append( "</ng-template>" );
            result.Append( "</nz-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes, items: items ) );
        }
    }
}