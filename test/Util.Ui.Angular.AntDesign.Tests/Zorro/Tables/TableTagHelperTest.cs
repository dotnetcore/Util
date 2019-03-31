using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tables;
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
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();  
            result.Append( "<nz-table-wrapper #m_id_wrapper=\"\">" );
            result.Append( "<nz-table #m_id=\"\" [nzData]=\"m_id_wrapper.dataSource\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "</nz-table-wrapper>" );
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
            result.Append( "<nz-table #a=\"\" [nzData]=\"a_wrapper.dataSource\" [nzShowPagination]=\"a_wrapper.showPagination\" " );
            result.Append( "[nzTotal]=\"a_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of a.data\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "</nz-table-wrapper>" );
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
            result.Append( "<nz-table #m_id=\"\" [nzData]=\"m_id_wrapper.dataSource\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "</nz-table-wrapper>" );
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
            result.Append( "<nz-table #m_id=\"\" [nzData]=\"m_id_wrapper.dataSource\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "</nz-table-wrapper>" );
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
            result.Append( "<nz-table #m_id=\"\" [nzData]=\"m_id_wrapper.dataSource\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "</nz-table-wrapper>" );
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
            result.Append( "<nz-table #m_id=\"\" [nzData]=\"m_id_wrapper.dataSource\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "</nz-table-wrapper>" );
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
            result.Append( "<nz-table #m_id=\"\" [nzData]=\"m_id_wrapper.dataSource\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "</nz-table-wrapper>" );
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
            result.Append( "<nz-table #m_id=\"\" [nzData]=\"m_id_wrapper.dataSource\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "</nz-table-wrapper>" );
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
            result.Append( "<nz-table #m_id=\"\" [nzData]=\"m_id_wrapper.dataSource\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "</nz-table-wrapper>" );
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
            result.Append( "<nz-table #m_id=\"\" [nzData]=\"m_id_wrapper.dataSource\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "</nz-table-wrapper>" );
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
            result.Append( "<nz-table #m_id=\"\" [nzData]=\"m_id_wrapper.dataSource\" [nzShowPagination]=\"m_id_wrapper.showPagination\" " );
            result.Append( "[nzTotal]=\"m_id_wrapper.totalCount\">" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of m_id.data\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            result.Append( "</nz-table-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}